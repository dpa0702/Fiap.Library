using FIAP.Library.Domain.DTOs;
using FIAP.Library.Domain.Entities;
using FIAP.Library.Domain.Enums;
using FIAP.Library.Infrastructure.Repositories.Interfaces;
using FIAP.Library.Infrastructure.Services.Interfaces;

namespace FIAP.Library.Infrastructure.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _ReservationRepository;

        public ReservationService(IReservationRepository ReservationRepository)
        {
            _ReservationRepository = ReservationRepository;
        }

        public async Task<IList<Reservation>> GetAll(CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            return await _ReservationRepository.GetAll(ct);
        }

        public async Task<Reservation> GetById(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var Reservation = await _ReservationRepository.GetById(id, ct);

            return Reservation ?? throw new BadHttpRequestException("Reserva não encontrada");
        }

        public async Task Add(Reservation Reservation, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            await _ReservationRepository.Insert(Reservation, ct);
        }

        public async Task UpdateStatus(Reservation dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var Reservation = await GetById(dto.Id, ct);

            if (!Enum.IsDefined(typeof(EReservation), dto.status)) throw new BadHttpRequestException("Status Inválido");

            Reservation.status = dto.status;

            await _ReservationRepository.Update(Reservation, ct);
        }
    }
}
