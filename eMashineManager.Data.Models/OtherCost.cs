using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMashineManager.Data.Models
{
    public class OtherCost : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
    }
}
