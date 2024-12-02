
namespace eMashineManager.Data.Configuration
{
    
        using Microsoft.EntityFrameworkCore;
        using Microsoft.EntityFrameworkCore.Metadata.Builders;
        using eMashineManager.Common;
        using eMashineManager.Data.Models;
        using static Common.EntityValidationConstants.Fuel;
        using static Common.EntityValidationConstants.SeedConstants;

    public class FuelConfiguration : IEntityTypeConfiguration<Fuel>
    {
        public void Configure(EntityTypeBuilder<Fuel> builder)
        {
            // Primary Key
            builder.HasKey(f => f.Id);

            // Properties
            builder.Property(f => f.Supplier)
                .IsRequired()
                .HasMaxLength(SupplierMaxLength);

            builder.Property(f => f.InvoiceNumber)
                .IsRequired()
                .HasMaxLength(InvoiceNumberMaxLength);

            builder.Property(f => f.Date)
                .IsRequired();

            builder.Property(f => f.Quantity)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // Precision for Quantity

            builder.Property(f => f.Cost)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // Precision for Cost

            builder.Property(f => f.Odometer)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(f => f.StartingFuel)
                .HasColumnType("decimal(18,2)"); // Optional

            builder.Property(f => f.IsFullTank)
                .IsRequired();

            builder.Property(f => f.Location)
                .HasMaxLength(LocationMaxLength);

            // Relationships
            builder.HasOne(f => f.Vehicle)
                .WithMany(v => v.FuelEntries)
                .HasForeignKey(f => f.VehicleId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade on Vehicle deletion

            builder.HasOne(f => f.Employee)
                .WithMany(e => e.Fuels)
                .HasForeignKey(f => f.EmlpoyeeId)
                .OnDelete(DeleteBehavior.Restrict); // Optional tracking of driver
            builder.HasData(SeedFuels());
        }
        private List<Fuel> SeedFuels()
        {
            List<Fuel> fuels = new List<Fuel>()
            {
                new Fuel
                {
                    Id = Guid.NewGuid(),
                    Supplier = "Shell",
                    FuelType = FuelType.Diesel,
                    InvoiceNumber = "INV-001",
                    VehicleId = Vehicle1Id,
                    Date = DateTime.UtcNow.AddDays(-10),
                    Quantity = 50.5m,
                    Cost = 200.75m,
                    Odometer = 10500.25m,
                    StartingFuel = 10m,
                    IsFullTank = true,
                    Location = "New York",
                    EmlpoyeeId = Employee1Id,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                },
                new Fuel
                {
                    Id = Guid.NewGuid(),
                    Supplier = "BP",
                    FuelType = FuelType.Gasoline,
                    InvoiceNumber = "INV-002",
                    VehicleId = Vehicle2Id,
                    Date = DateTime.UtcNow.AddDays(-8),
                    Quantity = 45m,
                    Cost = 180m,
                    Odometer = 11025.75m,
                    StartingFuel = 5m,
                    IsFullTank = false,
                    Location = "Los Angeles",
                    EmlpoyeeId = Employee2Id,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                }

            };
            return fuels;
        }

    }
    


}
