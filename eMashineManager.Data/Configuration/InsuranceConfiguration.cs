namespace eMashineManager.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using static Common.EntityValidationConstants.Insurance;
    using static Common.EntityValidationConstants.SeedConstants;

    public class InsuranceConfiguration : IEntityTypeConfiguration<Insurance>
    {
        public void Configure(EntityTypeBuilder<Insurance> builder)
        {
            // Primary Key Configuration
            builder.HasKey(i => i.Id);

            // Property Configurations with Constants for Validation
            builder.Property(i => i.Type)
                .IsRequired()  // Insurance type is required
                .HasMaxLength(TypeMaxLength);

            builder.Property(i => i.Provider)
                .IsRequired()  // Provider is required
                .HasMaxLength(ProviderMaxLength);

            builder.Property(i => i.PolicyNumber)
                .IsRequired()  // Policy number is required
                .HasMaxLength(PolicyNumberMaxLength);

            builder.Property(i => i.StartDate)
                .IsRequired();  // Start date is required

            builder.Property(i => i.EndDate)
                .IsRequired();  // End date is required

            builder.Property(i => i.Premium)
                .HasColumnType("decimal(18,2)")  
                .IsRequired();  // Premium is required

            // Relationships
            builder.HasOne(i => i.Vehicle)
                .WithMany(v => v.Insurances)  
                .HasForeignKey(i => i.VehicleId)  
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete on Vehicle deletion
            builder.HasData(SeedInsurances());

        }
        private List<Insurance> SeedInsurances()
        {
            List<Insurance> seedInsurances = new List<Insurance>()
            {
                new Insurance
                {
                    Id = Guid.NewGuid(),
                    Type = "Third Party",
                    VehicleId = Vehicle1Id,
                    StartDate = DateTime.UtcNow.AddMonths(-12),
                    EndDate = DateTime.UtcNow.AddMonths(12),
                    Provider = "Allianz",
                    Premium = 1200.50m,
                    PolicyNumber = "POL-123456",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                },
                new Insurance
                {
                    Id = Guid.NewGuid(),
                    Type = "Comprehensive",
                    VehicleId = Vehicle2Id,
                    StartDate = DateTime.UtcNow.AddMonths(-6),
                    EndDate = DateTime.UtcNow.AddMonths(6),
                    Provider = "State Farm",
                    Premium = 1500.75m,
                    PolicyNumber = "POL-654321",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                }

            };
            return seedInsurances;
        }
    }
}
