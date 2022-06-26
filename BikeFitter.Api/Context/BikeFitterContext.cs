using BikeFitter.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeFitter.Api.Context
{
    public class BikeFitterContext : DbContext
    {
        public BikeFitterContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Cassette> Cassettes { get; set; }
        public DbSet<Crankset> Cranksets { get; set; }
        public DbSet<Derailleur> Derailleurs { get; set; }
        public DbSet<Fork> Forks { get; set; }
        public DbSet<Brake> Brakes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Rim> Rims { get; set; }
        public DbSet<Shifter> Shifters { get; set; }
        public DbSet<Stem> Stems { get; set; }
        public DbSet<Tire> Tires { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bike>().ToTable("Bike");
            modelBuilder.Entity<Cassette>().ToTable("Cassette");
            modelBuilder.Entity<Crankset>().ToTable("Crankset");
            modelBuilder.Entity<Derailleur>().ToTable("Derailleur");
            modelBuilder.Entity<Fork>().ToTable("Fork");
            modelBuilder.Entity<Brake>().ToTable("Brake");
            modelBuilder.Entity<Manufacturer>().ToTable("Manufacturer");
            modelBuilder.Entity<Rim>().ToTable("Rim");
            modelBuilder.Entity<Shifter>().ToTable("Shifter");
            modelBuilder.Entity<Stem>().ToTable("Stem");
            modelBuilder.Entity<Tire>().ToTable("Tire");

        }
    }
}
