using FIAP.Library.Domain.Entities;
using FIAP.Library.Domain.Repository.Interfaces;

namespace FIAP.Library.Infrastructure.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetByNamePhone(Customer customer, CancellationToken ct);
    }
}
