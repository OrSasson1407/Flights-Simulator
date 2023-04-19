﻿using System.ComponentModel.DataAnnotations;

namespace WebAirportServer.Models
{
    public class Logger
    {
        [Required]
        public int Id { get; set; }
        public virtual Leg? Leg { get; set; }
        public virtual Flight? Flight { get; set; }
        public DateTime? In { get; set; }
        public DateTime? Out { get; set; }
    }
}
