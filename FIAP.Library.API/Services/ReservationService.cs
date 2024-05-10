using FIAP.Library.API.Services.Interfaces;
using FIAP.Library.Domain.DTOs;
using FIAP.Library.Domain.Entities;
using FIAP.Library.Domain.Enums;
using FIAP.Library.Domain.Helpers;
using MassTransit;
using System.Net;

namespace FIAP.Library.API.Services
{
    public class ReservationService : IReservationService
    {
        private static HttpClient _customerClient = HttpClientConfiguration.CustomerClient();
        private static HttpClient _bookClient = HttpClientConfiguration.BookClient();
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;

        public ReservationService(IBus bus, IConfiguration configuration)
        {
            _bus = bus;
            _configuration = configuration;
        }

        public async Task NewReservation(NewReservationDto dto)
        {
            try
            {
                
                HttpResponseMessage responseBook = await _bookClient.GetAsync($"/book/{dto.bookId}");
                responseBook.EnsureSuccessStatusCode();

                HttpResponseMessage responseCustomer = await _customerClient.GetAsync($"/customer/{dto.customerId}");
                responseCustomer.EnsureSuccessStatusCode();

                var reservation = new Reservation
                {
                    customerId = dto.customerId,
                    bookId = dto.bookId,
                    status = EReservation.Requested
                };

                var queueName = _configuration.GetSection("MassTransit")["NewReservationQueue"] ?? string.Empty;
                var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{queueName}"));

                await endpoint.Send(reservation);
                
            }
            catch (Exception ex)
            {
                throw new BadHttpRequestException("Livro ou Cliente não encontrado");

            }
        }
    }
}
