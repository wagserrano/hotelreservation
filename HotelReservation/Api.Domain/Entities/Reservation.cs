using Api.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        [DefaultValue(1)]
        [Range(1, int.MaxValue, ErrorMessage = "The minimum Id is {1} and the max is {2}")]
        public int HotelId { get; set; }

        [DefaultValue(1)]
        [Range(1, int.MaxValue, ErrorMessage = "The minimum Id is {1} and the max is {2}")]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Reserved days are required")]
        //[StringLength(50, ErrorMessage = "The minimum day is {1}")]
        [Range(1, 3, ErrorMessage = "The minimum days is {1} and max is {2}")]
        public int ReservedDays { get; set; }

        [Required(ErrorMessage = "Begin Date is required")]
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
}
