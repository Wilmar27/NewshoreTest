namespace Newshore.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Newshore.Entities.DbContextEntities.FlightDto;
    using Newshore.Entities.DbContextEntities.JourneyDto;
    using Newshore.Entities.DbContextEntities.JourneyFlight;
    using Newshore.Entities.DbContextEntities.TransportDto;

    public class AplicationDbContext: DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-1ONFS98\\SQLEXPRESS;Database=Newshore;Trusted_Connection=True;Encrypt=False");
        }
        public DbSet<FlightDto> Flights { get; set; }
        public DbSet<JourneyDto> Journey { get; set; }
        public DbSet<JourneyFlight> JourneyFlight { get; set; }
        public DbSet<TransportDto> Transport { get; set; }

    }
}