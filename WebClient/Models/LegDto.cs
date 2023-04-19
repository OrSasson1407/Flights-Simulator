using System.ComponentModel.DataAnnotations;
using WebAirportServer.Models;

namespace WebClient.Models
{
    public class LegDto
    {
        [Required]
        public int Id { get; set; }
        public int Number { get; set; }
        public int WaitTime { get; set; }
        public virtual FlightDto? Flight { get; set; }
        public int? FlightId { get; set; }
        public LegNumber? CurrentLeg { get; set; }
        public LegNumber? NextLegs { get; set; }
        public bool IsChangeStatus { get; set; }
    }
}
