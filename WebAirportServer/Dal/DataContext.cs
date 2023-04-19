using Microsoft.EntityFrameworkCore;
using WebAirportServer.Models;

namespace WebAirportServer.Dal
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Leg> Legs { get; set; }
        public virtual DbSet<Logger> Loggers { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}