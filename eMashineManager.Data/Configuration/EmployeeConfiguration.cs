namespace eMashineManager.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using static Common.EntityValidationConstants.Employee;
    using static Common.EntityValidationConstants.SeedConstants;

    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .ValueGeneratedOnAdd(); // GUID auto-generation

            // Properties
            builder.Property(e => e.EGN)
                .IsRequired()
                .HasMaxLength(EGNMaxLength);

            builder.Property(e => e.IdCardNumber)
                .IsRequired()
                .HasMaxLength(IdCardNumberMaxLength);

            builder.Property(e => e.LicenceNumber)
                .IsRequired()
                .HasMaxLength(LicenceNumberMaxLength);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder.Property(e => e.MiddleName)
                .HasMaxLength(NameMaxLength)
                .IsRequired();

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(CountryMaxLength);

            builder.Property(e => e.Region)
                .IsRequired()
                .HasMaxLength(RegionMaxLength);

            builder.Property(e => e.Municipality)
                .IsRequired()
                .HasMaxLength(MunicipalityMaxLength);

            builder.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(CityMaxLength);

            builder.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(AddressMaxLength);

            builder.Property(e => e.Email)
                .HasMaxLength(EmailMaxLength)
                .IsRequired();

            builder.Property(e => e.TelephoneNumber)
                .HasMaxLength(TelephoneMaxLength)
                .IsRequired();

            // Enums
            builder.Property(e => e.Position)
                .HasConversion<string>() // Stores enum as string
                .IsRequired();

            // Relationships

            // Employee and Waybills (One-to-Many)
            builder.HasMany(e => e.Waybills)
                .WithOne(w => w.Employee)
                .HasForeignKey(w => w.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee and Waybills(One-to - Many)
            builder.HasMany(e => e.Fuels)
                .WithOne(w => w.Employee)
                .HasForeignKey(w => w.EmlpoyeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee and ServiceRecord (Many-to-Many via ServiceRecordEmployee)
            builder.HasMany(e => e.ServiceRecordEmployees)
                .WithOne(se => se.Employee)
                .HasForeignKey(se => se.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(SeedEmployees());
        }
        private List<Employee> SeedEmployees()
        {
            List<Employee> seedEmployees = new List<Employee>()
            {
                new Employee
                {
                Id = Employee1Id,
                EGN = "1234567890",
                DateOfBirth = new DateTime(1985, 5, 10),
                IdCardNumber = "ID123456",
                CardReleaseDate = DateTime.UtcNow.AddYears(-5),
                CardExpireDate = DateTime.UtcNow.AddYears(5),
                LicenceNumber = "LIC12345",
                LicenceReleaseDate = DateTime.UtcNow.AddYears(-10),
                LicenceExpireDate = DateTime.UtcNow.AddYears(10),
                FirstName = "John",
                MiddleName = "M.",
                LastName = "Doe",
                Position = Position.Driver,
                Country = "USA",
                Region = "California",
                Municipality = "Los Angeles",
                City = "Los Angeles",
                Address = "123 Elm St",
                Email = "john.doe@example.com",
                TelephoneNumber = "+123456789",
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "Admin",  // Set the user who created the entry
                ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                },
                new Employee
                {
                    Id = Employee2Id,
                    EGN = "9876543210",
                    DateOfBirth = new DateTime(1990, 7, 15),
                    IdCardNumber = "ID789456",
                    CardReleaseDate = DateTime.UtcNow.AddYears(-7),
                    CardExpireDate = DateTime.UtcNow.AddYears(3),
                    LicenceNumber = "LIC98765",
                    LicenceReleaseDate = DateTime.UtcNow.AddYears(-12),
                    LicenceExpireDate = DateTime.UtcNow.AddYears(8),
                    FirstName = "Jane",
                    MiddleName = "D.",
                    LastName = "Smith",
                    Position = Position.Manager,
                    Country = "UK",
                    Region = "London",
                    Municipality = "Westminster",
                    City = "London",
                    Address = "45 High St",
                    Email = "jane.smith@example.com",
                    TelephoneNumber = "+447700900123",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",  // Set the user who created the entry
                    ModifiedOn = DateTime.UtcNow,  // Optional: Set modified date if applicable
                    ModifiedBy = "Admin"  // Optional: Set modified by user if applicable
                }


            };
            return seedEmployees;
        }
            
    }
}
