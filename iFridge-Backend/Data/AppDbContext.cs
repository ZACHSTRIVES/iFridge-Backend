using iFridge_Backend.Models;

using Microsoft.EntityFrameworkCore;

namespace iFridge_Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<Food> Foods { get; set; }
     
        public DbSet<UserFridge> UserFridges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFridge>()
                .HasKey(uf => new { uf.UserId, uf.FridgeId });

            modelBuilder.Entity<UserFridge>()
                .HasOne(uf => uf.User)
                .WithMany(uf => uf.UserFridges)
                .HasForeignKey(uf => uf.UserId);

            modelBuilder.Entity<UserFridge>()
                .HasOne(uf => uf.Fridge)
                .WithMany(uf => uf.UserFridges)
                .HasForeignKey(uf => uf.FridgeId);

            modelBuilder.Entity<Food>()
                .HasOne(b => b.Fridge)
                .WithMany(f => f.Foods)
                .HasForeignKey(b => b.FridgeID);

           
        }

    }
}
