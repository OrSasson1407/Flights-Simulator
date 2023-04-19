using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAirportServer.Dal;
using WebAirportServer.Models;
using WebAirportServer.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAirportServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FLightController : ControllerBase
    {
        private readonly DataContext _data;
        private IFlightRepo _flightRepo;
        private readonly ILogger<Flight> _logger;

        public FLightController(DataContext data, IFlightRepo flightRepo, ILogger<Flight> logger)
        {
            this._data = data;
            this._flightRepo = flightRepo;
            this._logger = logger;
            //AddTerminalsToDb();//do it once at the first time
        }
        [HttpPost("Add")]
        public async Task<int> AddFlight(Flight flight)
        {
            _logger.LogInformation($"Flight number {flight.Code} is created");
            await _flightRepo.AddFlight(flight);
            return 0;
        }
        [HttpGet("GetFlights")]
        public async Task<IEnumerable<Flight>> GetFlights() => await _data.Flights.ToListAsync();

        [HttpGet("GetLegs")]
        public async Task<IEnumerable<Leg>> GetLegs() => await  _data.Legs.ToListAsync();

        //private void AddTerminalsToDb()
        //{
        //    var l1 = new Leg { Number = 1, WaitTime = 3, IsChangeStatus = false, CurrentLeg = LegNumber.One, NextLegs = LegNumber.Two };
        //    var l2 = new Leg { Number = 2, WaitTime = 5, IsChangeStatus = false, CurrentLeg = LegNumber.Two, NextLegs = LegNumber.Thr };
        //    var l3 = new Leg { Number = 3, WaitTime = 6, IsChangeStatus = false, CurrentLeg = LegNumber.Thr, NextLegs = LegNumber.Fou };
        //    var l4 = new Leg { Number = 4, WaitTime = 8, IsChangeStatus = false, CurrentLeg = LegNumber.Fou, NextLegs = LegNumber.Fiv | LegNumber.Dep };
        //    var l5 = new Leg { Number = 5, WaitTime = 4, IsChangeStatus = false, CurrentLeg = LegNumber.Fiv, NextLegs = LegNumber.Six | LegNumber.Sev };
        //    var l6 = new Leg { Number = 6, WaitTime = 7, IsChangeStatus = true, CurrentLeg = LegNumber.Six, NextLegs = LegNumber.Eig };
        //    var l7 = new Leg { Number = 7, WaitTime = 8, IsChangeStatus = true, CurrentLeg = LegNumber.Sev, NextLegs = LegNumber.Eig };
        //    var l8 = new Leg { Number = 8, WaitTime = 2, IsChangeStatus = true, CurrentLeg = LegNumber.Eig, NextLegs = LegNumber.Fou };
        //    _data.Legs.AddRange(new List<Leg> { l1, l2, l3, l4, l5, l6, l7, l8 });
        //    _data.SaveChanges();
        //}
    }
}

