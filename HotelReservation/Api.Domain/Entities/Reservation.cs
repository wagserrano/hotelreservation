using Api.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Reserved days are required")]
        //[StringLength(50, ErrorMessage = "The minimum day is {1}")]
        [Range(1, 3, ErrorMessage = "The minimum days is {1} and max is {2}")]
        public int ReservedDays { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
    }
}
