using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace WebAirportServer.Models
{
    public class Leg
    {
        [Required]
        public int Id { get; set; }
        public int Number { get; set; }
        public int WaitTime { get; set; }

        [ForeignKey("FlightId")]
        public virtual Flight? Flight { get; set; }
        public int? FlightId { get; set; }
        public LegNumber? CurrentLeg { get; set; }
        public LegNumber? NextLegs { get; set; }
        public bool IsChangeStatus { get; set; }
    }
}
