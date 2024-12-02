namespace eMashineManager.Data.Configuration
{
    using eMashineManager.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using static Common.EntityValidationConstants.Tire;
    using static Common.EntityValidationConstants.SeedConstants;

    public class TireConfiguration : IEntityTypeConfiguration<Tire>
    {
        public void Configure(EntityTypeBuilder<Tire> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            // Relationships
            builder.HasOne(t => t.Vehicle)
                .WithMany(v => v.Tires)
                .HasForeignKey(t => t.VehicleId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete when Vehicle is removed

            // Properties
            builder.Property(t => t.Date)
                .IsRequired();

            builder.Property(t => t.TireSize)
                .IsRequired()
                .HasMaxLength(TireSizeMaxLength);

            builder.Property(t => t.TireBrand)
                .IsRequired()
                .HasMaxLength(TireBrandMaxLength);

            builder.Property(t => t.TireModel)
                .IsRequired()
                .HasMaxLength(TireModelMaxLength);

            builder.Property(t => t.TireType)
                .HasMaxLength(TireTypeMaxLength);

            builder.Property(t => t.Position)
                .HasMaxLength(PositionMaxLength);

            builder.Property(t => t.Cost)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(t => t.Mileage)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(t => t.Supplier)
                .IsRequired()
                .HasMaxLength(SupplierMaxLength);

            builder.Property(t => t.InvoiceNumber)
                .IsRequired()
                .HasMaxLength(InvoiceNumberMaxLength);

            builder.Property(t => t.Action)
                .HasMaxLength(ActionMaxLength);

            builder.Property(t => t.Notes)
                .HasMaxLength(NotesMaxLength);

            // AuditableEntity Properties
            builder.Property(t => t.CreatedOn).IsRequired();
            builder.Property(t => t.CreatedBy).IsRequired().HasMaxLength(256);
            builder.HasData(SeedTire());
        }
        private List<Tire> SeedTire()
        {
            List<Tire> seedTire = new List<Tire>()
            {
                new Tire
                {
                    Id = Guid.NewGuid(),
                    VehicleId = Vehicle1Id,
                    Date = DateTime.UtcNow.AddMonths(-6),
                    TireSize = "265/70R17",
                    TireBrand = "Michelin",
                    TireModel = "LTX M/S",
                    TireType = "All-Season", // Optional: Summer, Winter, All-Season, etc.
                    Position = "Front Left",
                    Cost = 150.00m,
                    Mileage = 20000,
                    Supplier = "Michelin Tires Inc.",
                    InvoiceNumber = "INV12345",
                    Action = "Replaced",
                    Notes = "Replaced after wear",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                },
                new Tire
                {
                    Id = Guid.NewGuid(),
                    VehicleId = Vehicle2Id,
                    Date = DateTime.UtcNow.AddMonths(-12),
                    TireSize = "225/60R16",
                    TireBrand = "Bridgestone",
                    TireModel = "Turanza T005",
                    TireType = "Summer",
                    Position = "Rear Right",
                    Cost = 120.00m,
                    Mileage = 25000,
                    Supplier = "Bridgestone Tires Ltd.",
                    InvoiceNumber = "INV67890",
                    Action = "Rotated",
                    Notes = "Rotated as part of regular maintenance",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                },

            };
            return seedTire;
        }


    }
}
