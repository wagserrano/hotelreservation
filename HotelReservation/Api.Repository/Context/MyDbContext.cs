using Api.Domain.Entities;
using Api.Repository.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Proxies;

namespace Api.Repository.Context
{
    public class MyDbContext : DbContext
    {
        private IConfiguration config;
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms{ get; set; }
        public DbSet<RoomOccupancy> RoomOccupancy { get; set; }
        public DbSet<Reservation> Reservation { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            //await mydb.Database.EnsureCreatedAsync();
        }

        //public MyDbContext()
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite(config["ConnectionStrings:SqLite"],
            //    sqliteOptionsAction: op =>
            //    {
            //        op.MigrationsAssembly(
            //            Assembly.GetExecutingAssembly().FullName);
            //    });
            //base.OnConfiguring(optionsBuilder);
            //var myConnStr = config["ConnectionStrings:SqlLocalDb"];
            //optionsBuilder.UseSqlServer(myConnStr);
            optionsBuilder.UseLazyLoadingProxies();
            //base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Hotel entity configuration and initial population
            modelBuilder.Entity<Hotel>().ToTable("hotel"); //.HasMany(h => h.Rooms);
            //modelBuilder.Entity<Hotel>().HasMany(c => c.Rooms).WithRequired(a => a.RoomValuable).HasForeignKey(a => a.RoomId);
            // modelBuilder.Entity<Hotel>().ToTable("hotel").HasMany(h => h.Rooms).WithOne(r => r.Hotel);
            modelBuilder.Entity<Hotel>().HasKey(p => p.Id);
            //modelBuilder.Entity<Hotel>().Property(p => p.ID).UseIdentityColumn();
            modelBuilder.Entity<Hotel>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Hotel>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Hotel>().Property(p => p.Fulladdress).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Hotel>().HasData(new Hotel { Id = 1, Name="Cancun Plaza", Fulladdress="77 Queen street" });

            // Room entity configuration and initial population
            //modelBuilder.Entity<Room>().ToTable("room").HasOne(r => r.Hotel).WithMany(h => h.Rooms);
            modelBuilder.Entity<Room>().ToTable("room");
            modelBuilder.Entity<Room>().HasKey(p => p.Id);
            modelBuilder.Entity<Room>().Property(p => p.Id).UseIdentityColumn();
            modelBuilder.Entity<Room>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Room>().HasData(new Room { Id = 1, Name = "Spring Flower", HotelId = 1 });

            // Room Occupancy entity configuration and initial population
            modelBuilder.Entity<RoomOccupancy>().ToTable("roomoccupancy");
            modelBuilder.Entity<RoomOccupancy>().HasKey(p => p.Id);
            modelBuilder.Entity<RoomOccupancy>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<RoomOccupancy>().HasData(new RoomOccupancy { Id = 1, RoomId = 1, BookingId=1, DateBusy = DateTime.Now.AddDays(-7)});

            // Rerservation entity configuration and initial population
            modelBuilder.Entity<Reservation>().ToTable("reservation");
            modelBuilder.Entity<Reservation>().HasKey(p => p.Id);
            modelBuilder.Entity<Reservation>().Property(p => p.Id).ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
