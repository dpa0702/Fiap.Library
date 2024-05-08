using FIAP.Library.API.Services.Interfaces;
using FIAP.Library.Core.DTOs;
using FIAP.Library.Core.Entities;
using MassTransit;

namespace FIAP.Library.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;

        public CustomerService(IBus bus, IConfiguration configuration)
        {
            _bus = bus;
            _configuration = configuration;
        }

        public async Task NewCustomer(NewCustomerDto dto)
        {
            var queueName = _configuration.GetSection("MassTransit")["NewCustomerQueue"] ?? string.Empty;
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{queueName}"));

            Customer customer = new()
            {
                Name = dto.Nome,
                Phone = dto.Telefone,
                Active = true
            };

            await endpoint.Send(customer);
        }
    }
}
