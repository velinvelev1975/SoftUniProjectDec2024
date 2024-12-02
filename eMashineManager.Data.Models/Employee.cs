namespace eMashineManager.Data.Models
{
    public class Employee : AuditableEntity
    {
        public Employee()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string EGN { get; set; } = null!;
        public DateTime DateOfBirth { get; set; } 
        public string IdCardNumber { get; set; } = null!;
        public DateTime CardReleaseDate { get; set; } 
        public DateTime CardExpireDate { get; set; }
        public string LicenceNumber { get; set; } = null!;
        public DateTime LicenceReleaseDate { get; set; }
        public DateTime LicenceExpireDate { get; set; }
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Position Position { get; set; } 
        public string Country { get; set; } = null!;
        public string  Region { get; set; } = null!;
        public string Municipality { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string TelephoneNumber { get; set; } = null!;
        public virtual ICollection<Waybill>? Waybills { get; set; } = new List<Waybill>();
        public virtual ICollection<Fuel>? Fuels { get; set; } = new List<Fuel>();
        public virtual ICollection<ServiceRecordEmployee>? ServiceRecordEmployees{ get; set; } = new List<ServiceRecordEmployee>();












    }
}
