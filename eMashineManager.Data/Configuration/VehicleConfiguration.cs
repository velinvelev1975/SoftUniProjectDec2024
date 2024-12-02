namespace eMashineManager.Data.Configuration
{
    using eMashineManager.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using static Common.EntityValidationConstants.Vehicle;
    using static Common.EntityValidationConstants.SeedConstants;

    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            // Primary Key
            builder.HasKey(v => v.Id);

            // Properties
            builder.Property(v => v.RegistrationNumber)
                .IsRequired()
                .HasMaxLength(RegistrationNumberMaxLength);

            builder.Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder.Property(v => v.Company)
                .HasMaxLength(CompanyMaxLength);

            builder.Property(v => v.Type)
                .IsRequired(); // Enum field - ensure it's required

            // Relationships
            builder.HasMany(v => v.Waybills)
                .WithOne(w => w.Vehicle)
                .HasForeignKey(w => w.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(v => v.FuelEntries)
                .WithOne(f => f.Vehicle)
                .HasForeignKey(f => f.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(v => v.Tires)
                .WithOne(t => t.Vehicle)
                .HasForeignKey(t => t.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(v => v.SpareParts)
                .WithOne(sp => sp.Vehicle)
                .HasForeignKey(sp => sp.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(v => v.Insurances)
                .WithOne(i => i.Vehicle)
                .HasForeignKey(i => i.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(v => v.Taxes)
                .WithOne(t => t.Vehicle)
                .HasForeignKey(t => t.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(v => v.ServiceRecords)
                .WithOne(sr => sr.Vehicle)
                .HasForeignKey(sr => sr.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(v => v.OtherCosts)
                .WithOne(oc => oc.Vehicle)
                .HasForeignKey(oc => oc.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            // AuditableEntity properties
            builder.Property(v => v.CreatedOn).IsRequired();
            builder.Property(v => v.CreatedBy).IsRequired().HasMaxLength(256);
            builder.HasData(SeedVehicles());
        }
        private List<Vehicle> SeedVehicles()
        {
            List<Vehicle> seedVehicles = new List<Vehicle>()
            {
                new Vehicle
                {
                    Id = Vehicle1Id,
                    RegistrationNumber = "ABC1234",
                    Name = "Truck 1",
                    Type = VehicleType.Truck,
                    Company = "ABC Logistics",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                },
                new Vehicle
                {
                    Id = Vehicle2Id,
                    RegistrationNumber = "DEF5678",
                    Name = "Van 2",
                    Type = VehicleType.Van,
                    Company = "XYZ Logistics",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                }

            };
            return seedVehicles;
        }

    }
}
