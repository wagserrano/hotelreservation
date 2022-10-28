using Api.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class RoomOccupancy : BaseEntity
    {
        public int RoomId { get; set; }
        public DateTime DateBusy { get; set; }
        public int BookingId { get; set; }
    }
}
