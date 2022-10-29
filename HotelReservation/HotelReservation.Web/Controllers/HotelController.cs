using Api.Domain.Entities;
using Api.Services.Interfaces;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Web.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    //[Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class HotelController : Controller
    {
        private IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        //[HttpPost]
        //[ProducesResponseType((200), Type = typeof(Hotel))]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(401)]
        //public IActionResult Post([FromBody] Hotel hotel)
        //{
        //    if (hotel == null) return BadRequest();
        //    return Ok(_hotelService.Create(hotel));
        //}

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(Hotel))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            var hotel = _hotelService.FindById(id);
            if (hotel == null) return NotFound();
            return Ok(hotel);
        }

        [HttpGet("checkdatesbusy")]
        [ProducesResponseType((200), Type = typeof(Hotel))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetAll()
        {
            var hotel = _hotelService.FindAll();
            if (hotel == null) return NotFound();
            return Ok(hotel);
        }

        //[HttpPut]
        //[ProducesResponseType((200), Type = typeof(Hotel))]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(401)]
        //public IActionResult Put([FromBody] Hotel hotel)
        //{
        //    if (hotel == null) return BadRequest();
        //    return Ok(_hotelService.Update(hotel));
        //}

    }
}
