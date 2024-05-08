using FIAP.Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Library.InvoiceMS.Data
{
    public class InvoiceMSContext : DbContext
    {
        public InvoiceMSContext(DbContextOptions<InvoiceMSContext> options) : base(options) { }

        public DbSet<Invoice> Invoices { get; set; } = default!;
    }
}
