using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTOs
{
    public class HotelDTO
    {
        [Required(ErrorMessage = "The Name is required")]
        [StringLength(50, ErrorMessage = "The maxlenght is {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Fulladdress is required")]
        [StringLength(100, ErrorMessage = "The maxlenght is {1}")]
        public string Fulladdress { get; set; }

        //[Required(ErrorMessage = "The Rate per day is required")]
        //[Min(1, ErrorMessage = "The Rate per day minimun value is {1}")]
        //public decimal RatePerDay { get; set; }
    }
}
