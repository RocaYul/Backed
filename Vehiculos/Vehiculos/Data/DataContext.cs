using Microsoft.EntityFrameworkCore;
using Vehiculos.Data.Entities;

namespace Vehiculos.Data
{
    //Class where is create of connection with the DB
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<VehiculeType> VehiculeTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VehiculeType>().HasIndex(x => x.Description).IsUnique();
        }
    }
}
