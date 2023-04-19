using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
    public class FlightDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Code { get; set; }
        public bool IsDeparture { get; set; }
    }
}
