namespace eMashineManager.Data.Configuration
{
    using eMashineManager.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using static Common.EntityValidationConstants.Waybill;
    using static Common.EntityValidationConstants.SeedConstants;


    public class WaybillConfiguration : IEntityTypeConfiguration<Waybill>
    {
        public void Configure(EntityTypeBuilder<Waybill> builder)
        {
            // Primary Key
            builder.HasKey(w => w.Id);

            // Properties
            builder.Property(w => w.WaybillNumber)
                .IsRequired()
                .HasMaxLength(WaybillNumberMaxLength);

            builder.Property(w => w.StartLocation)
                .IsRequired()
                .HasMaxLength(StartLocationMaxLength);

            builder.Property(w => w.EndLocation)
                .IsRequired()
                .HasMaxLength(EndLocationMaxLength);

            builder.Property(w => w.Notes)
                .HasMaxLength(NotesMaxLength);

            builder.Property(w => w.StartDate)
                .IsRequired();

            builder.Property(w => w.EndDate)
                .IsRequired();

            builder.Property(w => w.StartOdometer)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(w => w.EndOdometer)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(w => w.DrivenDistanceWithTrailer)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(w => w.TransportedGoodsInTons)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(w => w.LoadedFuel)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(w => w.WorkingHours)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(w => w.OvertimeHours)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(w => w.BusinessTripExpenses)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(w => w.AccommodationExpenses)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(w => w.OtherExpenses)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(w => w.DriverBonus)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            // Relationships
            builder.HasOne(w => w.Vehicle)
                .WithMany(v => v.Waybills)
                .HasForeignKey(w => w.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(w => w.Employee)
                .WithMany(e => e.Waybills)
                .HasForeignKey(w => w.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // AuditableEntity properties
            builder.Property(w => w.CreatedOn).IsRequired();
            builder.Property(w => w.CreatedBy).IsRequired().HasMaxLength(256);
            builder.HasData(SeedWayBills());
        }
        private List<Waybill> SeedWayBills()
        {
            List<Waybill> seedWayBills = new List<Waybill>()
            {
                new Waybill
                {
                    Id = Guid.NewGuid(),
                    WaybillNumber = "WB123",
                    StartLocation = "New York",
                    EndLocation = "Chicago",
                    VehicleId = Vehicle1Id,
                    EmployeeId = Employee1Id,
                    StartDate = DateTime.UtcNow.AddDays(-3),
                    EndDate = DateTime.UtcNow.AddDays(-2),
                    StartOdometer = 1000,
                    EndOdometer = 1500,
                    DrivenDistanceWithTrailer = 200,
                    TransportedGoodsInTons = 5,
                    LoadedFuel = 100,
                    WorkingHours = 8,
                    OvertimeHours = 2,
                    BusinessTripExpenses = 150,
                    AccommodationExpenses = 50,
                    OtherExpenses = 30,
                    DriverBonus = 100,
                    Notes = "Smooth trip",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                },
                new Waybill
                {
                    Id = Guid.NewGuid(),
                    WaybillNumber = "WB124",
                    StartLocation = "San Francisco",
                    EndLocation = "Seattle",
                    VehicleId = Vehicle2Id,
                    EmployeeId = Employee2Id,
                    StartDate = DateTime.UtcNow.AddDays(-5),
                    EndDate = DateTime.UtcNow.AddDays(-4),
                    StartOdometer = 2000,
                    EndOdometer = 2500,
                    DrivenDistanceWithTrailer = 300,
                    TransportedGoodsInTons = 8,
                    LoadedFuel = 120,
                    WorkingHours = 10,
                    OvertimeHours = 1,
                    BusinessTripExpenses = 200,
                    AccommodationExpenses = 70,
                    OtherExpenses = 40,
                    DriverBonus = 150,
                    Notes = "Tough road",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                }

            };
            return seedWayBills;
        }
    }
}
