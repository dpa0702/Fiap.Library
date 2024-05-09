using FIAP.Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Library.Infrastructure.Data
{
    public class MSContext : DbContext
    {
        public MSContext(DbContextOptions<MSContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } = default!;

        public DbSet<Customer> Customers { get; set; } = default!;

        public DbSet<Reservation> Reservations { get; set; } = default!;

        public DbSet<RentBook> RentBooks { get; set; } = default!;
    }
}
