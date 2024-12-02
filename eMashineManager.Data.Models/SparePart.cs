using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMashineManager.Data.Models
{
    public class SparePart : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; } // FK to Vehicle
        public virtual Vehicle Vehicle { get; set; } = null!;
        public decimal Milage { get; set; }
        public Guid? ServiceRecordId { get; set; } // FK to Maintenance (optional)
        public virtual ServiceRecord ServiceRecord { get; set; } = null!;
        public string PartName { get; set; } = null!;
        public string? PartNumber { get; set; } 
        public string Supplier { get; set; } = null!;
        public decimal Cost { get; set; } 
        public decimal Quantity { get; set; } 
        public DateTime DateAdded { get; set; }
        public string? Note { get; set; }
    }
}
