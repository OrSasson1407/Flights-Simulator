using Microsoft.Identity.Client;
using WebAirportServer.Models;

namespace WebAirportServer.Repositories
{
    public interface IFlightRepo
    {
        Task AddFlight(Flight flight);
        public void NextTerminal(Flight flight, Leg leg);

    }
}
