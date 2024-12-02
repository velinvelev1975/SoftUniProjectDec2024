using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMashineManager.Data.Models
{
    public class Waybill : AuditableEntity
    {
        public Guid Id { get; set; }
        public string WaybillNumber { get; set; } = null!;
        public string StartLocation { get; set; } = null!;
        public string EndLocation { get; set; } = null!;
        public Guid VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; } = null!;
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal StartOdometer { get; set; }
        public decimal EndOdometer { get; set; }
        public decimal TotalWorked => EndOdometer - StartOdometer;
        public decimal DrivenDistanceWithTrailer { get; set; }
        public decimal TransportedGoodsInTons { get; set; }
        public decimal LoadedFuel { get; set; }
        public decimal WorkingHours { get; set; }
        public decimal OvertimeHours { get; set; }
        public decimal BusinessTripExpenses { get; set; }
        public decimal AccommodationExpenses { get; set; }
        public decimal OtherExpenses { get; set; }
        public decimal DriverBonus { get; set; }
        public string? Notes { get; set; }



    }
}
