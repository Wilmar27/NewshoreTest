namespace Newshore.Entities.DbContextEntities.TransportDto
{
    using System.ComponentModel.DataAnnotations;

    public class TransportDto
    {
        [Key]
        public int IdTransport { get; set; }
        public string? FlightCarrier { get; set; }
        public string? FlightNumber { get; set; }
    }
}
