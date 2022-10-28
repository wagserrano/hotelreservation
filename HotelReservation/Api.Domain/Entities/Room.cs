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
    [Table("rooms")]
    public class Room : BaseEntity
    {
        public string Name { get; set; }
        public int HotelId { get; set; }
        public virtual ICollection<RoomOccupancy> RoomOccupancies { get; set; }

    }
}
