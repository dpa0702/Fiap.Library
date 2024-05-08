using FIAP.Library.Core.Entities;
using FIAP.Library.Core.Repository.Interfaces;

namespace FIAP.Library.Infrastructure.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetByNamePhone(Customer customer, CancellationToken ct);
    }
}
