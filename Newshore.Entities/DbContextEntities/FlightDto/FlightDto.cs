namespace Newshore.Entities.DbContextEntities.FlightDto
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using TransportDto;
    public class FlightDto
    {
        [Key]
        public int IdFlight { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public double? Price { get; set; }

        [ForeignKey("Transport")]
        public int IdTransport { get; set; }
        public string? Transport { get; set; }
    }
}
