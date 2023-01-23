namespace Newshore.Entities.DbContextEntities.JourneyFlight
{
    using Newshore.Entities.DbContextEntities.FlightDto;
    using Newshore.Entities.DbContextEntities.JourneyDto;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class JourneyFlight
    {
        [Key]
        public int IdJourneyFlight { get; set; }

        [ForeignKey("Journey")]
        public int IdJourney { get; set; }
        public string? JourneyDto { get; set; }

        [ForeignKey("Flight")]
        public int IdFlight { get; set; }
        public string? FlightDto { get; set; }
    }
}
