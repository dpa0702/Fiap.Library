using FIAP.Library.Domain.Entities;

namespace FIAP.Library.Infrastructure.Services.Interfaces
{
    public interface IRentBookService
    {
        Task<IList<RentBook>> GetAll(CancellationToken ct);
        Task<RentBook> GetById(int id, CancellationToken ct);
        Task Add(RentBook reservation, CancellationToken ct);
        Task UpdateStatus(RentBook dto, CancellationToken ct);
    }
}
