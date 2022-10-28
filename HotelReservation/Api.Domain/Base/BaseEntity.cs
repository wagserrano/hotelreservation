using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Base
{
    public class BaseEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        //[Column("id")]
        public int Id { get; set; }

        //[Column("name")]
        //public string Name { get; set; }
        //public int Active { get; set; }
    }
}
