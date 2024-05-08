using FIAP.Library.Domain.Entities;
using FIAP.Library.InvoiceMS.Data;
using FIAP.Library.InvoiceMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Library.InvoiceMS.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public readonly InvoiceMSContext _context;

        public InvoiceRepository(InvoiceMSContext context)
        {
            _context = context;
        }

        public async Task<IList<Invoice>> GetAll(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            return await _context.Invoices.ToListAsync(ct);
        }

        public async Task<Invoice> GetById(int id, CancellationToken ct)
        {
           ct.ThrowIfCancellationRequested();

            return await _context.Invoices.FirstOrDefaultAsync(invoice => invoice.Id == id, ct);
        }

        public async Task Insert(Invoice entity, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            _context.Invoices.Add(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task Update(Invoice entity, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            _context.Invoices.Update(entity);
            await _context.SaveChangesAsync(ct);
        }
    }
}
