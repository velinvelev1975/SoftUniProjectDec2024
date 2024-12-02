namespace eMashineManager.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using static Common.EntityValidationConstants.Employee;


    public class ServiceRecordEmployeeConfiguration : IEntityTypeConfiguration<ServiceRecordEmployee>
    {
        public void Configure(EntityTypeBuilder<ServiceRecordEmployee> builder)
        {

            // Composite primary key
            builder.HasKey(sre => new { sre.ServiceRecordId, sre.EmployeeId });

            // Relationship between ServiceRecordEmployee and ServiceRecord
            builder.HasOne(sre => sre.ServiceRecord)
                .WithMany(sr => sr.ServiceRecordEmployees)  // ServiceRecord has many ServiceRecordEmployee
                .HasForeignKey(sre => sre.ServiceRecordId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete from ServiceRecord

            // Relationship between ServiceRecordEmployee and Employee
            builder.HasOne(sre => sre.Employee)
                .WithMany(e => e.ServiceRecordEmployees)  // Employee has many ServiceRecordEmployee
                .HasForeignKey(sre => sre.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete from Employee

            
        }
    }
}
