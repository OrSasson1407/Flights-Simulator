using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAirportServer.Models;

namespace ConsoleSim.Models
{
    public class LegDto
    {
        public int Number { get; set; }
        public int WaitTime { get; set; }
        public virtual FlightDto? Flight { get; set; }
        public int? FlightId { get; set; }
        public LegNumber? CurrentLeg { get; set; }
        public LegNumber? NextLegs { get; set; }
        public bool IsChangeStatus { get; set; }
    }
}
