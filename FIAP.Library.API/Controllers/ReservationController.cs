using FIAP.Library.API.Services.Interfaces;
using FIAP.Library.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Library.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> NewReservation([FromBody] NewReservationDto dto)
        {
            try
            {
                await _reservationService.NewReservation(dto);

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}