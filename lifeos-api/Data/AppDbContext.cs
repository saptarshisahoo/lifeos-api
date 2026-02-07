using Microsoft.EntityFrameworkCore;
using lifeos_api.Models;

namespace lifeos_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Goal> Goals { get; set; } = null!;
    }
}