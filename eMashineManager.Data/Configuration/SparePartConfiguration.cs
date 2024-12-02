namespace eMashineManager.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using static Common.EntityValidationConstants.SparePart;
    using static Common.EntityValidationConstants.SeedConstants;

    public class SparePartConfiguration : IEntityTypeConfiguration<SparePart>
    {
        public void Configure(EntityTypeBuilder<SparePart> builder)
        {
            // Primary Key
            builder.HasKey(sp => sp.Id);

            // Relationships
            builder.HasOne(sp => sp.Vehicle)
                .WithMany(v => v.SpareParts)
                .HasForeignKey(sp => sp.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sp => sp.ServiceRecord)
                .WithMany(sr => sr.SpareParts)
                .HasForeignKey(sp => sp.ServiceRecordId)
                .OnDelete(DeleteBehavior.Restrict); // Optional association

            // Properties
            builder.Property(sp => sp.PartName)
                .IsRequired()
                .HasMaxLength(PartNameMaxLength);

            builder.Property(sp => sp.PartNumber)
                .HasMaxLength(PartNumberMaxLength);

            builder.Property(sp => sp.Supplier)
                .IsRequired()
                .HasMaxLength(SupplierMaxLength);

            builder.Property(sp => sp.Cost)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(sp => sp.Quantity)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(sp => sp.Note)
                .HasMaxLength(NoteMaxLength);

            builder.Property(sp => sp.Milage)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(sp => sp.DateAdded)
                .IsRequired();

            // AuditableEntity Configuration (if any additional specifics are needed)
            builder.Property(sp => sp.CreatedOn).IsRequired();
            builder.Property(sp => sp.CreatedBy).IsRequired().HasMaxLength(256); // Example
            builder.HasData(SeedSparePart());
        }
        private List<SparePart> SeedSparePart()
        {
            List<SparePart> seedSparePart = new List<SparePart>()
            {
                new SparePart
                {
                    Id = Guid.NewGuid(),
                    VehicleId = Vehicle1Id,
                    Milage = 15000m,
                    ServiceRecordId = ServiceRecord1Id,
                    PartName = "Brake Pad",
                    PartNumber = "BP12345",
                    Supplier = "AutoParts Warehouse",
                    Cost = 75.00m,
                    Quantity = 4,
                    DateAdded = DateTime.UtcNow.AddMonths(-3),
                    Note = "Replaced all brake pads.",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                },
                new SparePart
                {
                    Id = Guid.NewGuid(),
                    VehicleId = Vehicle2Id,
                    Milage = 22000m,
                    ServiceRecordId = ServiceRecord2Id,
                    PartName = "Air Filter",
                    PartNumber = "AF67890",
                    Supplier = "QuickFix Auto",
                    Cost = 20.00m,
                    Quantity = 1,
                    DateAdded = DateTime.UtcNow.AddMonths(-2),
                    Note = "Replaced air filter during routine maintenance.",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                }

            };
            return seedSparePart;
        }





    }
}
