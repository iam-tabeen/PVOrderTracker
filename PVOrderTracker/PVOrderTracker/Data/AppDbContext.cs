using Microsoft.EntityFrameworkCore;
using PVOrderTracker.Models; // <-- Make sure this matches your Models namespace

namespace OrderTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
    }
}
