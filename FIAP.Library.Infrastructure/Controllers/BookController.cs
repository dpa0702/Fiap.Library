using FIAP.Library.Infrastructure.Services.Interfaces;
using FIAP.Library.Domain.DTOs;
using FIAP.Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Library.Infrastructure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _BookService;

        public BookController(IBookService BookService)
        {
            _BookService = BookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct) => Ok(await _BookService.GetAll(ct));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            try
            {
                await _BookService.GetById(id, ct);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Book Book, CancellationToken ct)
        {
            try
            {
                await _BookService.Add(Book, ct);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> ChangeBookStatus(ChangeBookGenreDto dto, CancellationToken ct)
        {
            try
            {
                await _BookService.UpdateStatus(dto, ct);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
