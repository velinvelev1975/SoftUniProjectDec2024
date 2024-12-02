using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMashineManager.Data.Models
{
    public class Tire : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; } = null!;
        public DateTime Date { get; set; }
        public string TireSize { get; set; } = null!;
        public string TireBrand { get; set; } = null!;
        public string TireModel { get; set; } = null!;
        public string? TireType { get; set; } // e.g., Winter, Summer, All-Season
        public string? Position { get; set; } // e.g., Front Left, Rear Right
        public decimal Cost { get; set; }
        public decimal Mileage { get; set; }
        public string Supplier { get; set; } = null!;
        public string InvoiceNumber { get; set; } = null!;
        public string? Action { get; set; } // e.g., "Replaced", "Rotated"
        public string? Notes { get; set; }
    }
}
