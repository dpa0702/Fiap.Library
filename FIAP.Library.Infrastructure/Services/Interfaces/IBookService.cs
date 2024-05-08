using FIAP.Library.Core.DTOs;
using FIAP.Library.Core.Entities;

namespace FIAP.Library.Infrastructure.Services.Interfaces
{
    public interface IBookService
    {
        Task<IList<Book>> GetAll(CancellationToken ct);
        Task<Book> GetById(int id, CancellationToken ct);
        Task Add(Book Book, CancellationToken ct);
        Task UpdateStatus(ChangeBookGenreDto dto, CancellationToken ct);
    }
}
