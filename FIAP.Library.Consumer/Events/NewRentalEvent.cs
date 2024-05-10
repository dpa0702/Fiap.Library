using FIAP.Library.Domain.Entities;
using FIAP.Library.Domain.Helpers;
using MassTransit;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace FIAP.Library.Consumer.Events
{
    public class NewRentalEvent : IConsumer<Reservation>
    {
        private static HttpClient _rentalClient = HttpClientConfiguration.RentalClient();

        public Task Consume(ConsumeContext<Reservation> context)
        {
            Console.WriteLine($"Nova locação do cliente {context.Message.customerId} para o livro {context.Message.bookId}.");

            RentBook rentBook = new()
            {
                bookId = context.Message.bookId,
                customerId = context.Message.customerId,
                datePossibleLocation = DateTime.Now,
                status = Domain.Enums.ERentalStatus.Borrowed
            };

            var jsonContent = JsonConvert.SerializeObject(rentBook);
            var body = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            body.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _rentalClient.PostAsync("/rentbook", body);

            return Task.CompletedTask;
        }
    }
}
