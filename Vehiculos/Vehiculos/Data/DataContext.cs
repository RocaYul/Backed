using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vehiculos.Data.Entities;

namespace Vehiculos.Data
{
    //Class where is create of connection with the DB
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<VehiculeType> VehiculeTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<TypeDocument> TypeDocuments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Procedure>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<VehiculeType>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Brand>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<TypeDocument>().HasIndex(x => x.Description).IsUnique();
        }
    }
}
