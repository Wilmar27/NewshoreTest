namespace Newshore.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Newshore.Entities.Entities.Flight;
    using Newshore.Entities.Entities.Journey;
    using Newshore.Entities.Entities.Transport;

    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Journey> Journey { get; set; }
        public DbSet<Transport > Transport { get; set; }

    }
}