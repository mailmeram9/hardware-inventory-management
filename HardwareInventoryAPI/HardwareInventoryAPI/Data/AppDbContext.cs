using HardwareInventoryAPI.models;
using Microsoft.EntityFrameworkCore;

namespace HardwareInventoryAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Asset> Assets { get; set; }
    }
}