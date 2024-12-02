namespace eMashineManager.Data.Configuration
{
    using eMashineManager.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using static Common.EntityValidationConstants.OtherCost;
    using static Common.EntityValidationConstants.SeedConstants;

    public class OtherCostConfiguration : IEntityTypeConfiguration<OtherCost>
    {
        public void Configure(EntityTypeBuilder<OtherCost> builder)
        {
            // Primary Key Configuration
            builder.HasKey(o => o.Id);

            // Property Configurations
            builder.Property(o => o.Date)
                .IsRequired();  // Date is required

            builder.Property(o => o.Cost)
                .HasColumnType("decimal(18,2)")  // Ensure correct decimal precision
                .IsRequired();  // Cost is required

            builder.Property(o => o.Description)
                .HasMaxLength(DescriptionMaxLength);  // Max length for Description

            // Relationships
            builder.HasOne(o => o.Vehicle)
                .WithMany(v => v.OtherCosts)  // A Vehicle can have multiple OtherCosts
                .HasForeignKey(o => o.VehicleId)  // Foreign Key is VehicleId
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete on Vehicle deletion
            builder.HasData(SeedOtherCost());

        }

        private List<OtherCost> SeedOtherCost()
        {
            List<OtherCost> seedOtherCost= new List<OtherCost>()
            {
                new OtherCost
                {
                    Id = Guid.NewGuid(),
                    VehicleId = Vehicle1Id,
                    Date = DateTime.UtcNow.AddMonths(-3),
                    Description = "Parking fees",
                    Cost = 25.00m,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                },
                new OtherCost
                {
                    Id = Guid.NewGuid(),
                    VehicleId = Vehicle2Id,
                    Date = DateTime.UtcNow.AddMonths(-1),
                    Description = "Highway tolls",
                    Cost = 45.75m,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                },

            };
            return seedOtherCost;
        }
    }
}
