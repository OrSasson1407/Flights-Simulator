using System.ComponentModel.DataAnnotations;

namespace WebAirportServer.Models
{
    public class Flight
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Code { get; set; }
        public bool IsDeparture { get; set; }
    }
}
