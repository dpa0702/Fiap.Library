using FIAP.Library.Domain.Entities;
using FIAP.Library.Infrastructure.Data;
using FIAP.Library.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Library.Infrastructure.Repositories
{
    public class RentBookRepository : IRentBookRepository
    {
        public readonly MSContext _context;

        public RentBookRepository(MSContext context)
        {
            _context = context;
        }
        public async Task<IList<RentBook>> GetAll(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            return await _context.RentBooks.ToListAsync(ct);
        }

        public async Task<RentBook> GetById(int id, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            return await _context.RentBooks.FirstOrDefaultAsync(Reservation => Reservation.Id == id, ct);
        }

        public async Task Insert(RentBook entity, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            _context.RentBooks.Add(entity);
            await _context.SaveChangesAsync(ct);
        }

        public Task Update(RentBook entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
