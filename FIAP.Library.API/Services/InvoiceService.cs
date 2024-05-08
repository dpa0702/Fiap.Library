using FIAP.Library.API.Services.Interfaces;
using FIAP.Library.Domain.DTOs;
using FIAP.Library.Domain.Entities;
using FIAP.Library.Domain.Enums;
using FIAP.Library.Domain.Helpers;
using MassTransit;

namespace FIAP.Library.API.Services
{
    public class InvoiceService : IInvoiceService
    {
        private static HttpClient _customerClient = HttpClientConfiguration.CustomerClient();
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;

        public InvoiceService(IBus bus, IConfiguration configuration)
        {
            _bus = bus;
            _configuration = configuration;
        }

        public async Task NewInvoice(NewInvoiceDto dto)
        {
            try
            {
                HttpResponseMessage response = await _customerClient.GetAsync($"/customer/{dto.IdCliente}");
                response.EnsureSuccessStatusCode();

                var invoice = new Invoice
                {
                    CustomerId = dto.IdCliente,
                    Description = dto.Descricao,
                    Quantity = dto.Quantidade,
                    Total = dto.Valor,
                    Status = (int)EInvoiceStatus.Recebido
                };

                var queueName = _configuration.GetSection("MassTransit")["NewInvoiceQueue"] ?? string.Empty;
                var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{queueName}"));

                await endpoint.Send(invoice);
            }
            catch (Exception)
            {
                throw new BadHttpRequestException("Cliente não encontrado");
            }
        }
    }
}
