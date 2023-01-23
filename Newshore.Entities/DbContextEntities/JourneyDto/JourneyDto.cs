namespace Newshore.Entities.DbContextEntities.JourneyDto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using FlightDto;
    public class JourneyDto
    {
        [Key]
        public int IdJourney { get; set; }
        public string? Flights { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public double? Price { get; set; }

    }
}
