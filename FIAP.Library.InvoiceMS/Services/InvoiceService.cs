using FIAP.Library.Core.DTOs;
using FIAP.Library.Core.Entities;
using FIAP.Library.Core.Enums;
using FIAP.Library.InvoiceMS.Repositories.Interfaces;
using FIAP.Library.InvoiceMS.Services.Interfaces;

namespace FIAP.Library.InvoiceMS.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<IList<Invoice>> GetAll(CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            return await _invoiceRepository.GetAll(ct);
        }

        public async Task<Invoice> GetById(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var invoice = await _invoiceRepository.GetById(id, ct);

            return invoice ?? throw new BadHttpRequestException("Pedido não encontrado");
        }

        public async Task Add(Invoice invoice, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            await _invoiceRepository.Insert(invoice, ct);
        }

        public async Task UpdateStatus(ChangeInvoiceStatusDto dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var invoice = await GetById(dto.InvoiceId, ct);

            if (!Enum.IsDefined(typeof(EInvoiceStatus), dto.Status)) throw new BadHttpRequestException("Status Inválido");

            invoice.Status = dto.Status;

            await _invoiceRepository.Update(invoice, ct);
        }
    }
}
