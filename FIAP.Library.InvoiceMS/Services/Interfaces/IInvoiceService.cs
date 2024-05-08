using FIAP.Library.Core.DTOs;
using FIAP.Library.Core.Entities;

namespace FIAP.Library.InvoiceMS.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<IList<Invoice>> GetAll(CancellationToken ct);
        Task<Invoice> GetById(int id, CancellationToken ct);
        Task Add(Invoice invoice, CancellationToken ct);
        Task UpdateStatus(ChangeInvoiceStatusDto dto, CancellationToken ct);
    }
}
