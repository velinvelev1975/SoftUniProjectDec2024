namespace eMashineManager.Data.Configuration
{
    using eMashineManager.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using static Common.EntityValidationConstants.Tax;
    using static Common.EntityValidationConstants.SeedConstants;


    public class TaxConfiguration : IEntityTypeConfiguration<Tax>
    {
        public void Configure(EntityTypeBuilder<Tax> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            // Relationships
            builder.HasOne(t => t.Vehicle)
                .WithMany(v => v.Taxes)
                .HasForeignKey(t => t.VehicleId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete when Vehicle is removed

            // Properties
            builder.Property(t => t.PaymentDate)
                .IsRequired();

            builder.Property(t => t.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            // AuditableEntity Configuration (if specific configuration is needed)
            builder.Property(t => t.CreatedOn).IsRequired();
            builder.Property(t => t.CreatedBy).IsRequired().HasMaxLength(256); // Example
            builder.HasData(SeedTax());
        }
        private List<Tax> SeedTax()
        {
            List<Tax> seedTax = new List<Tax>()
            {
                new Tax
                {
                    Id = Guid.NewGuid(),
                    VehicleId = Vehicle1Id,
                    PaymentDate = DateTime.UtcNow.AddMonths(-6),
                    Amount = 500.00m,
                    Description = "Annual vehicle tax payment for 2024.",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                },
                new Tax
                {
                    Id = Guid.NewGuid(),
                    VehicleId = Vehicle2Id,
                    PaymentDate = DateTime.UtcNow.AddMonths(-9),
                    Amount = 300.00m,
                    Description = "Quarterly vehicle tax payment for Q3 2024.",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                },

            };
            return seedTax;
        }




    }
}
