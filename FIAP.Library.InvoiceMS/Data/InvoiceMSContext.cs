using FIAP.Library.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Library.InvoiceMS.Data
{
    public class InvoiceMSContext : DbContext
    {
        public InvoiceMSContext(DbContextOptions<InvoiceMSContext> options) : base(options) { }

        public DbSet<Invoice> Invoices { get; set; } = default!;
    }
}
