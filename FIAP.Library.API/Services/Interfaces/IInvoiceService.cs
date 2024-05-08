using FIAP.Library.Core.DTOs;

namespace FIAP.Library.API.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task NewInvoice(NewInvoiceDto dto);
    }
}
