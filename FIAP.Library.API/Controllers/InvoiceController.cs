using FIAP.Library.API.Services.Interfaces;
using FIAP.Library.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Library.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost]
        public async Task<IActionResult> NewInvoice([FromBody] NewInvoiceDto dto)
        {
            try
            {
                await _invoiceService.NewInvoice(dto);

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}