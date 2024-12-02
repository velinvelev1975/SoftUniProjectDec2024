using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMashineManager.Data.Models
{
    public class Fuel : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Supplier { get; set; } = null!;

        public FuelType FuelType { get; set; } // e.g., Diesel, Gasoline

        public string InvoiceNumber { get; set; } = null!;

        public Guid VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; } = null!;

        public DateTime Date { get; set; }

        public decimal Quantity { get; set; }

        public decimal Cost { get; set; }

        public decimal Odometer { get; set; }

        public decimal? StartingFuel { get; set; }
        public bool IsFullTank { get; set; }

        public string? Location { get; set; }

        public Guid EmlpoyeeId { get; set; } // Nullable if not tracked.
        public virtual Employee? Employee { get; set; }
    }
}

