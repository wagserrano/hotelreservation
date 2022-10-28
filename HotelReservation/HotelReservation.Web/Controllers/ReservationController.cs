using Api.Domain.Entities;
using Api.Services.Interfaces;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Web.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ReservationController : Controller
    {
        private IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(Reservation))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            var reservation = _reservationService.FindById(id);
            if (reservation == null) return NotFound();
            return Ok(reservation);
        }
        [HttpGet("allreservations")]
        [ProducesResponseType((200), Type = typeof(Reservation))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetAll()
        {
            var hotel = _reservationService.FindAll();
            if (hotel == null) return NotFound();
            return Ok(hotel);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(Reservation))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] Reservation reservation)
        {
            if (reservation == null) return BadRequest();
            if (reservation.BeginDate < DateTime.Now.AddDays(1)) return BadRequest("Invalid begin date");
            return Ok(_reservationService.Create(reservation));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(Reservation))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] Reservation reservation)
        {
            if (reservation == null) return BadRequest();
            if (reservation.BeginDate < DateTime.Now.AddDays(1)) return BadRequest("Invalid begin date");
            return Ok(_reservationService.Update(reservation));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _reservationService.Delete(id);
            return NoContent();
        }
    }
}
