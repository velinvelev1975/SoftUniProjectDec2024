using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMashineManager.Data.Models
{
    public class Tax : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; } = null!;
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = null!;
    }
}
