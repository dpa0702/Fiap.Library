using FIAP.Library.Infrastructure.Data;
using FIAP.Library.Infrastructure.Repositories.Interfaces;
using FIAP.Library.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Library.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        public readonly MSContext _context;

        public BookRepository(MSContext context)
        {
            _context = context;
        }

        public async Task<IList<Book>> GetAll(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            return await _context.Books.ToListAsync(ct);
        }

        public async Task<Book> GetById(int id, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            return await _context.Books.FirstOrDefaultAsync(Book => Book.Id == id, ct);
        }

        public async Task Insert(Book entity, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            _context.Books.Add(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task Update(Book entity, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            _context.Books.Update(entity);
            await _context.SaveChangesAsync(ct);
        }
    }
}
