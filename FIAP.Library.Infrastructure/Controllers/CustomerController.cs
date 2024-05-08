using FIAP.Library.Infrastructure.Services.Interfaces;
using FIAP.Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Library.Infrastructure.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct) => Ok(await _customerService.GetAll(ct));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            try
            {
                await _customerService.GetById(id, ct);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Customer customer, CancellationToken ct)
        {
            try
            {
                await _customerService.Add(customer, ct);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
