using FIAP.Library.API.Services.Interfaces;
using FIAP.Library.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Library.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> NewCustomer([FromBody] NewCustomerDto dto)
        {
            try
            {
                await _customerService.NewCustomer(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
