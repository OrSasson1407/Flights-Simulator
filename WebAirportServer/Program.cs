using Microsoft.EntityFrameworkCore;
using NLog.Web;
using WebAirportServer.Dal;
using WebAirportServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("my")));
builder.Services.AddLogging();
builder.Logging.ClearProviders();
builder.Host.UseNLog();
builder.Services.AddScoped<IFlightRepo, FlightRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
