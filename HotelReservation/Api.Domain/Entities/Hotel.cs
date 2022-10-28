using Api.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities
{
    [Table("hotels")]
    public class Hotel : BaseEntity
    {
        public string Name { get; set; }

        //[Column("fulladdress")]
        public string Fulladdress { get; set; }

        //[Column("rooms")]
        public virtual ICollection<Room> Rooms { get; set; }

    }
}
