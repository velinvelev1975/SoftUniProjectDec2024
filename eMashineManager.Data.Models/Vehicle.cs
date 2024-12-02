using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMashineManager.Data.Models
{
    public class Vehicle : AuditableEntity
    {
        public Guid Id { get; set; }
        public string RegistrationNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public VehicleType Type { get; set; } // Enum: Truck, Car, Machine, etc.
        public string? Company { get; set; } // Optional: Associated company
        public virtual ICollection<Waybill> Waybills { get; set; } = new List<Waybill>();
        public virtual ICollection<Fuel> FuelEntries { get; set; } = new List<Fuel>();
        public virtual ICollection<Tire> Tires { get; set; } = new List<Tire>();
        public virtual ICollection<SparePart> SpareParts { get; set; } = new List<SparePart>();
        public virtual ICollection<Insurance> Insurances { get; set; } = new List<Insurance>();
        public virtual ICollection<Tax> Taxes { get; set; } = new List<Tax>();
        public virtual ICollection<ServiceRecord> ServiceRecords { get; set; } = new List<ServiceRecord>();
        public virtual ICollection<OtherCost> OtherCosts { get; set; } = new List<OtherCost>();

    }
}
