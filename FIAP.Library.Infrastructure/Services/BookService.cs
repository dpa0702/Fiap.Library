using FIAP.Library.Infrastructure.Repositories;
using FIAP.Library.Infrastructure.Repositories.Interfaces;
using FIAP.Library.Infrastructure.Services.Interfaces;
using FIAP.Library.Domain.DTOs;
using FIAP.Library.Domain.Entities;
using FIAP.Library.Domain.Enums;

namespace FIAP.Library.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository BookRepository)
        {
            _bookRepository = BookRepository;
        }

        public async Task<IList<Book>> GetAll(CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            return await _bookRepository.GetAll(ct);
        }

        public async Task<Book> GetById(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var Book = await _bookRepository.GetById(id, ct);

            return Book ?? throw new BadHttpRequestException("Livro não encontrado");
        }

        public async Task Add(Book Book, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            await _bookRepository.Insert(Book, ct);
        }

        public async Task UpdateStatus(ChangeBookGenreDto dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var Book = await GetById(dto.BookId, ct);

            if (!Enum.IsDefined(typeof(ERentalStatus), dto.genre)) throw new BadHttpRequestException("Genero Inválido");

            Book.genre = dto.genre;

            await _bookRepository.Update(Book, ct);
        }
    }
}
