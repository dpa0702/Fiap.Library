using FIAP.Library.Domain.DTOs;
using FIAP.Library.Domain.Entities;

namespace FIAP.Library.Infrastructure.Services.Interfaces
{
    public interface IReservationService
    {
        Task<IList<Reservation>> GetAll(CancellationToken ct);
        Task<Reservation> GetById(int id, CancellationToken ct);
        Task Add(Reservation reservation, CancellationToken ct);
        Task UpdateStatus(Reservation dto, CancellationToken ct);
    }
}
