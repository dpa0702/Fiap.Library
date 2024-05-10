using FIAP.Library.Domain.DTOs;

namespace FIAP.Library.API.Services.Interfaces
{
    public interface IReservationService
    {
        Task NewReservation(NewReservationDto dto);
    }
}
