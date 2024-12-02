namespace eMashineManager.Data.Configuration
{
    using eMashineManager.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using static Common.EntityValidationConstants.ServiceRecord;
    using static Common.EntityValidationConstants.SeedConstants;

    public class ServiceRecordConfiguration : IEntityTypeConfiguration<ServiceRecord>
    {
        public void Configure(EntityTypeBuilder<ServiceRecord> builder)
        {
            // Primary Key
            builder.HasKey(sr => sr.Id);

            // Property Configurations
            builder.Property(sr => sr.Date)
                .IsRequired(); // Date is mandatory

            builder.Property(sr => sr.Type)
                .HasConversion<string>()
                .IsRequired(); // Enum (WorkType) is required

            builder.Property(sr => sr.Supplier)
                .HasMaxLength(SupplierMaxLength)
                .IsRequired(); // Supplier is mandatory with max length

            builder.Property(sr => sr.Description)
                .HasMaxLength(DescriptionMaxLength); // Optional with max length

            builder.Property(sr => sr.InvoiceNumber)
                .HasMaxLength(InvoiceNumberMaxLength); // Optional with max length

            builder.Property(sr => sr.MaintenanceType)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(sr => sr.ManHour)
                .HasColumnType("decimal(18,2)"); // Precision for optional ManHour

            builder.Property(sr => sr.Cost)
                .HasColumnType("decimal(18,2)")
                .IsRequired(); // Precision for Cost (mandatory)

            builder.Property(sr => sr.Mileage)
                .HasColumnType("decimal(18,2)")
                .IsRequired(); // Mileage is mandatory

            builder.Property(sr => sr.NextMaintenanceMileage)
                .HasColumnType("decimal(18,2)")
                .IsRequired(); // Next maintenance mileage is mandatory

            builder.Property(sr => sr.IsOutsourced)
                .IsRequired(); // IsOutsourced is required (boolean)

            // Relationships

            // Many-to-One: Vehicle
            builder.HasOne(sr => sr.Vehicle)
                .WithMany(v => v.ServiceRecords)
                .HasForeignKey(sr => sr.VehicleId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if Vehicle is removed

            // One-to-Many: SpareParts
            builder.HasMany(sr => sr.SpareParts)
                .WithOne(sp => sp.ServiceRecord)
                .HasForeignKey(sp => sp.ServiceRecordId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if ServiceRecord is removed

            // Many-to-Many: Employees (via ServiceRecordEmployee)
            builder.HasMany(sr => sr.ServiceRecordEmployees)
                .WithOne(sre => sre.ServiceRecord)
                .HasForeignKey(sre => sre.ServiceRecordId)
                .OnDelete(DeleteBehavior.Restrict); // No cascade delete for employees
            builder.HasData(SeedServiceRecords());
        }
        private List<ServiceRecord> SeedServiceRecords()
        {
            List<ServiceRecord> seedServiceRecord = new List<ServiceRecord>()
            {
               new ServiceRecord
               {

                    Id = Guid.NewGuid(),
                    VehicleId = Vehicle1Id,
                    Date = DateTime.UtcNow.AddMonths(-6),
                    Type = WorkType.Repair,
                    Supplier = "QuickFix Auto",
                    Description = "Oil change and filter replacement",
                    InvoiceNumber = "INV12345",
                    ManHour = 2.5m,
                    Cost = 150.00m,
                    Mileage = 12000m,
                    NextMaintenanceMileage = 18000m,
                    MaintenanceType = MaintenanceType.Scheduled,
                    IsOutsourced = true,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                },
                new ServiceRecord
                {
                    Id = Guid.NewGuid(),
                    VehicleId = Vehicle2Id,
                    Date = DateTime.UtcNow.AddMonths(-3),
                    Type = WorkType.Repair,
                    Supplier = "FixIt Garage",
                    Description = "Brake pads replacement",
                    InvoiceNumber = "INV67890",
                    ManHour = 3.0m,
                    Cost = 200.00m,
                    Mileage = 15000m,
                    NextMaintenanceMileage = 20000m,
                   MaintenanceType = MaintenanceType.Unscheduled,
                    IsOutsourced = false,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                }

            };
            return seedServiceRecord;
        }





    }

}
