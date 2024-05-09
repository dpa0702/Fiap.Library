using FIAP.Library.Domain.Entities;
using FIAP.Library.Infrastructure.Data;
using FIAP.Library.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Library.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public readonly MSContext _context;

        public ReservationRepository(MSContext context)
        {
            _context = context;
        }
        public async Task<IList<Reservation>> GetAll(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            return await _context.Reservations.ToListAsync(ct);
        }

        public async Task<Reservation> GetById(int id, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            return await _context.Reservations.FirstOrDefaultAsync(Reservation => Reservation.Id == id, ct);
        }

        public async Task Insert(Reservation entity, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            _context.Reservations.Add(entity);
            await _context.SaveChangesAsync(ct);
        }

        public Task Update(Reservation entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
