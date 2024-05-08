using FIAP.Library.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Library.Infrastructure.Data
{
    public class MSContext : DbContext
    {
        public MSContext(DbContextOptions<MSContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } = default!;

        public DbSet<Customer> Customers { get; set; } = default!;
    }
}
