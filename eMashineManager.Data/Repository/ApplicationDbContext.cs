
namespace eMashineManager.Data.Repository
{
    using Microsoft.EntityFrameworkCore;
    using eMashineManager.Data.Configuration;
    using eMashineManager.Data.Models;
    using System.Reflection;

    public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext() 
            { 

            }
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
            { 

            }

            // DbSet properties for all entities
            public virtual DbSet<Employee> Employees { get; set; } = null!;
            public virtual DbSet<Waybill> Waybills { get; set; } = null!;
            public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;
            public virtual DbSet<Fuel> Fuels { get; set; } = null!;
            public virtual DbSet<Insurance> Insurances { get; set; } = null!;
            public virtual DbSet<Tax> Taxes { get; set; } = null!;
            public virtual DbSet<Tire> Tires { get; set; } = null!;
            public virtual DbSet<OtherCost> OtherCosts { get; set; } = null!;
            public virtual DbSet<ServiceRecord> ServiceRecords { get; set; } = null!;
            public virtual DbSet<ServiceRecordEmployee> ServiceRecordEmployees { get; set; } = null!;
            public virtual DbSet<SparePart> SpareParts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           

        }
    }
    
    
    
}
