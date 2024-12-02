using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMashineManager.Data.Models
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
