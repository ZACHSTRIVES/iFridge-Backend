using iFridge_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace iFridge_Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
