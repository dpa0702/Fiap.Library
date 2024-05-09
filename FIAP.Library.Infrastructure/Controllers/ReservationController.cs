using FIAP.Library.Domain.DTOs;
using FIAP.Library.Domain.Entities;
using FIAP.Library.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Library.Infrastructure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService ReservationService)
        {
            _reservationService = ReservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct) => Ok(await _reservationService.GetAll(ct));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            try
            {
                await _reservationService.GetById(id, ct);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(NewReservationDto newReservationDto, CancellationToken ct)
        {
            try
            {
                Reservation reservation = new Reservation();
                reservation.customerId = newReservationDto.customerId;
                reservation.bookId = newReservationDto.bookId;
                reservation.status = Domain.Enums.EReservation.Reserved;
                await _reservationService.Add(reservation, ct);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> ChangeReservationStatus(Reservation dto, CancellationToken ct)
        {
            try
            {
                await _reservationService.UpdateStatus(dto, ct);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
