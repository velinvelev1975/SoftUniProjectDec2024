using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMashineManager.Data.Models
{
    public class ServiceRecordEmployee
    {
        public Guid ServiceRecordId { get; set; }
        public virtual ServiceRecord? ServiceRecord { get; set; }

        public Guid EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
