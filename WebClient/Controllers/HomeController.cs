using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAirportServer.Dal;
using WebAirportServer.Models;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClient client = new HttpClient { BaseAddress = new Uri("https://localhost:7254") };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var legs = await client.GetFromJsonAsync<IEnumerable<LegDto>>("api/flight/getlegs");
            ViewBag.Flights= await client.GetFromJsonAsync<IEnumerable<FlightDto>>("api/flight/getflights");
            return View(legs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}