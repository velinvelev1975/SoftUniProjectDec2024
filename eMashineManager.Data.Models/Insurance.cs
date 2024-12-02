using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMashineManager.Data.Models
{
    public class Insurance : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!; //  to do Insurance type: Third party, Comprehensive, etc.
        public Guid VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Provider { get; set; } = null!;
        public decimal Premium { get; set; } 
        public string PolicyNumber { get; set; } = null!;
    }
}
