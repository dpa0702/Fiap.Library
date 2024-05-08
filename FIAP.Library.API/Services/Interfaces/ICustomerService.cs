using FIAP.Library.Domain.DTOs;

namespace FIAP.Library.API.Services.Interfaces
{
    public interface ICustomerService
    {
        Task NewCustomer(NewCustomerDto dto);
    }
}
