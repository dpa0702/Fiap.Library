using FIAP.Library.Infrastructure.Repositories.Interfaces;
using FIAP.Library.Infrastructure.Services.Interfaces;
using FIAP.Library.Core.Entities;

namespace FIAP.Library.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IList<Customer>> GetAll(CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            return await _customerRepository.GetAll(ct);
        }

        public async Task<Customer> GetById(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var customer = await _customerRepository.GetById(id, ct);

            return customer ?? throw new BadHttpRequestException("Cliente não encontrado");
        }

        public async Task Add(Customer customer, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var existingCustomer = await _customerRepository.GetById(customer.Id, ct);

            if (existingCustomer != null) throw new BadHttpRequestException("O cliente já possui cadastro");

            await _customerRepository.Insert(customer, ct);
        }
    }
}
