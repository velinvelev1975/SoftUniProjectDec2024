using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMashineManager.Data.Models
{
    public class ServiceRecord : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; } = null!;
        public DateTime Date { get; set; }
        public WorkType Type { get; set; } // Enum to distinguish
        public string Supplier { get; set; } = null!;
        public string? Description { get; set; }
        public string? InvoiceNumber { get; set; }
        public decimal? ManHour { get; set; }
        public decimal Cost { get; set; }
        public decimal Mileage { get; set; }
        public decimal NextMaintenanceMileage { get; set; }
        public MaintenanceType MaintenanceType { get; set; }  // e.g., Scheduled, Unscheduled
        public bool IsOutsourced { get; set; }
        public virtual ICollection<SparePart>? SpareParts { get; set; } = new List<SparePart>();
        public virtual ICollection<ServiceRecordEmployee>? ServiceRecordEmployees { get; set; } = new List<ServiceRecordEmployee>();  
    }
}
