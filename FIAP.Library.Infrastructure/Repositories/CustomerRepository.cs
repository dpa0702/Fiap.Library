using FIAP.Library.Infrastructure.Data;
using FIAP.Library.Infrastructure.Repositories.Interfaces;
using FIAP.Library.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Library.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MSContext _context;

        public CustomerRepository(MSContext context)
        {
            _context = context;
        }

        public async Task<IList<Customer>> GetAll(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            return await _context.Customers.ToListAsync(ct);
        }

        public async Task<Customer> GetByNamePhone(Customer customer, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            return await _context.Customers.FirstOrDefaultAsync(c => c.Name == customer.Name && c.Phone == customer.Phone, ct);
        }

        public async Task<Customer> GetById(int id, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            return await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == id, ct);
        }

        public async Task Insert(Customer entity, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            _context.Customers.Add(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task Update(Customer entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
