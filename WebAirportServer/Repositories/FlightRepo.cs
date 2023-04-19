using WebAirportServer.Dal;
using WebAirportServer.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAirportServer.Repositories
{
    public class FlightRepo : IFlightRepo
    {
        private DataContext _data;
        private readonly ILogger<FlightRepo> _logger;
        public FlightRepo(DataContext dataContext, ILogger<FlightRepo> logger)
        {
            _data = dataContext;
            _logger = logger;
        }
        public async Task AddFlight(Flight flight)
        {
            await _data.Flights.AddAsync(flight);
            await _data.SaveChangesAsync();
            var startLeg = _data.Legs.First(l => l.Number == 1);
            startLeg.Flight = flight;
            NextTerminal(flight, startLeg);
        }
        public void NextTerminal(Flight flight,Leg leg)
        {
            var log = new Logger { Flight = flight, Leg = leg, In = DateTime.Now };
            _data.Loggers.Add(log);
            Console.WriteLine($"{flight.Code}: {leg.Number} ({DateTime.Now})");
            _logger.LogInformation($"{flight.Code}: {leg.Number} ({DateTime.Now})");
            Thread.Sleep(leg.WaitTime * 1000);
            var nextLeg = _data.Legs.FirstOrDefault(l => (leg.NextLegs & l.CurrentLeg) == l.CurrentLeg);
            if (leg.CurrentLeg == LegNumber.Fou && flight.IsDeparture)
            {
                log.Out = DateTime.Now;
                leg.Flight = null;
                Console.WriteLine($"{flight.Code}: Departure from {leg.Number}");
                _logger.LogInformation($"{flight.Code}: Departure from {leg.Number}");
                _data.SaveChanges();
                return;
            }
            else if (nextLeg?.Flight == null)
            {
                nextLeg.Flight = flight;
                nextLeg.FlightId= flight.Id;
                leg.Flight = null;
                log.Out = DateTime.Now;
                flight.IsDeparture = leg.IsChangeStatus;
                _data.SaveChanges();
            }
            _data.SaveChanges();
            NextTerminal(flight, nextLeg);
        }

    }
}
