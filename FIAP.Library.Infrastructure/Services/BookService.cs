using FIAP.Library.Infrastructure.Repositories;
using FIAP.Library.Infrastructure.Repositories.Interfaces;
using FIAP.Library.Infrastructure.Services.Interfaces;
using FIAP.Library.Core.DTOs;
using FIAP.Library.Core.Entities;
using FIAP.Library.Core.Enums;

namespace FIAP.Library.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _BookRepository;

        public BookService(IBookRepository BookRepository)
        {
            _BookRepository = BookRepository;
        }

        public async Task<IList<Book>> GetAll(CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            return await _BookRepository.GetAll(ct);
        }

        public async Task<Book> GetById(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var Book = await _BookRepository.GetById(id, ct);

            return Book ?? throw new BadHttpRequestException("Livro não encontrado");
        }

        public async Task Add(Book Book, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            await _BookRepository.Insert(Book, ct);
        }

        public async Task UpdateStatus(ChangeBookGenreDto dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var Book = await GetById(dto.BookId, ct);

            if (!Enum.IsDefined(typeof(ERentalStatus), dto.genre)) throw new BadHttpRequestException("Genero Inválido");

            Book.genre = dto.genre;

            await _BookRepository.Update(Book, ct);
        }
    }
}
