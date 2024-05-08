using FIAP.Library.Core.Entities;

namespace FIAP.Library.Infrastructure.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IList<Customer>> GetAll(CancellationToken ct);
        Task<Customer> GetById(int id, CancellationToken ct);
        Task Add(Customer customer, CancellationToken ct);
    }
}
