using ConsoleSim.Models;
using RandomFriendlyNameGenerator;
using System.Net.Http.Json;
using WebAirportServer.Models;

HttpClient client = new HttpClient { BaseAddress = new Uri("https://localhost:7254") };
System.Timers.Timer timer = new System.Timers.Timer(12000);
timer.Elapsed += async (s, e) => await CreateStam();
timer.Start();

Console.ReadLine();

async Task CreateStam()
{
        var flight = new FlightDto { Code = Guid.NewGuid().ToString(), IsDeparture = false };
        var response = await client.PostAsJsonAsync("api/flight/add", flight);
        if (response.IsSuccessStatusCode)
            await Console.Out.WriteLineAsync($"{flight.Code}");
}




