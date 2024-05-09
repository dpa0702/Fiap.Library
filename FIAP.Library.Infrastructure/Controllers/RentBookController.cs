using FIAP.Library.Domain.Entities;
using FIAP.Library.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Library.Infrastructure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentBookController : ControllerBase
    {
        private readonly IRentBookService _rentBookService;

        public RentBookController(IRentBookService RentBookService)
        {
            _rentBookService = RentBookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct) => Ok(await _rentBookService.GetAll(ct));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            try
            {
                await _rentBookService.GetById(id, ct);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(RentBook rentBook, CancellationToken ct)
        {
            try
            {
                await _rentBookService.Add(rentBook, ct);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> ChangeRentBookStatus(RentBook dto, CancellationToken ct)
        {
            try
            {
                await _rentBookService.UpdateStatus(dto, ct);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
