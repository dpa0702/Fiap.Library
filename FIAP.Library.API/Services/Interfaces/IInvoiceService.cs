using FIAP.Library.Domain.DTOs;

namespace FIAP.Library.API.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task NewInvoice(NewInvoiceDto dto);
    }
}
