using iFridge_Backend.Models;
using iFridge_Backend.Models.Foods;
using Microsoft.EntityFrameworkCore;

namespace iFridge_Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<Bread> Breads { get; set; }
        public DbSet<Fruit> Fruit { get; set; }
        public DbSet<Milk> Milks { get; set; }
        public DbSet<Other> Others { get; set; }
        public DbSet<Seafood> Seafood { get; set; }
        public DbSet<Spices> Spicess { get; set; }
        public DbSet<Vegetable> Vegetables { get; set; }
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

            modelBuilder.Entity<Bread>()
                .HasOne(b => b.Fridge)
                .WithMany(f => f.Breads)
                .HasForeignKey(b => b.FridgeID);

            modelBuilder.Entity<Fruit>()
                .HasOne(b => b.Fridge)
                .WithMany(f => f.Fruits)
                .HasForeignKey(b => b.FridgeID);

            modelBuilder.Entity<Milk>()
                .HasOne(b => b.Fridge)
                .WithMany(f => f.Milks)
                .HasForeignKey(b => b.FridgeID);

            modelBuilder.Entity<Other>()
                .HasOne(b => b.Fridge)
                .WithMany(f => f.Others)
                .HasForeignKey(b => b.FridgeID);

            modelBuilder.Entity<Seafood>()
                .HasOne(b => b.Fridge)
                .WithMany(f => f.Seafoods)
                .HasForeignKey(b => b.FridgeID);

            modelBuilder.Entity<Spices>()
                .HasOne(b => b.Fridge)
                .WithMany(f => f.Spicess)
                .HasForeignKey(b => b.FridgeID);

            modelBuilder.Entity<Vegetable>()
               .HasOne(b => b.Fridge)
               .WithMany(f => f.Vegetables)
               .HasForeignKey(b => b.FridgeID);





        }

    }
}
