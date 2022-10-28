using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Repository.Config
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Fulladdress).IsRequired().HasMaxLength(100);
            //builder.Property(o => o.RatePerDay).HasColumnType("decimal(18,4)");
            builder.HasData(
                new Hotel { 
                    Id = 1,
                    Name = "Cancun Plaza", 
                    Fulladdress = "77 King street",
                    //Rooms = new List<Room>() {
                    //    new Room() {
                    //        Id =1, Name="Spring Marvel Room", GuestsNumber=4, RatePerDay=91.5M
                    //    }
                    //}
                }
            );
        }
    }
}
