using FIAP.Library.Core.DTOs;

namespace FIAP.Library.API.Services.Interfaces
{
    public interface ICustomerService
    {
        Task NewCustomer(NewCustomerDto dto);
    }
}
