using Microsoft.EntityFrameworkCore;

namespace demoApi.Models
{
    public class LocationContext : DbContext
    {
        public LocationContext(DbContextOptions<LocationContext> options)
            : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
    }
}