using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMashineManager.Common
{
    public class EntityValidationConstants
    {
        public static class Employee
        {
            public const int EGNMaxLength = 10;
            public const int IdCardNumberMaxLength = 20;
            public const int LicenceNumberMaxLength = 20;
            public const int NameMaxLength = 50;
            public const int CountryMaxLength = 50;
            public const int RegionMaxLength = 50;
            public const int MunicipalityMaxLength = 50;
            public const int CityMaxLength = 50;
            public const int AddressMaxLength = 100;
            public const int EmailMaxLength = 100;
            public const int TelephoneMaxLength = 15;

        }
        public static class Fuel
        {
            public const int SupplierMaxLength = 100;
            public const int InvoiceNumberMaxLength = 50;
            public const int LocationMaxLength = 100;
        }
        public static class Insurance
        {
            public const int TypeMaxLength = 50;
            public const int ProviderMaxLength = 100;
            public const int PolicyNumberMaxLength = 100;
        }
        public static class OtherCost
        {
            public const int DescriptionMaxLength = 200;
        }
        public static class ServiceRecord
        {
            public const int SupplierMaxLength = 100;
            public const int DescriptionMaxLength = 500;
            public const int InvoiceNumberMaxLength = 50;
            public const int MaintenanceTypeMaxLength = 50;
        }
        public static class SparePart
        {
            public const int PartNameMaxLength = 100;
            public const int PartNumberMaxLength = 50;
            public const int SupplierMaxLength = 100;
            public const int NoteMaxLength = 500;
        }
        public static class Tax
        {
            public const int DescriptionMaxLength = 500;
        }
        public static class Tire
        {
            public const int TireSizeMaxLength = 50;
            public const int TireBrandMaxLength = 50;
            public const int TireModelMaxLength = 50;
            public const int TireTypeMaxLength = 30;
            public const int PositionMaxLength = 50;
            public const int SupplierMaxLength = 100;
            public const int InvoiceNumberMaxLength = 50;
            public const int ActionMaxLength = 50;
            public const int NotesMaxLength = 500;
        }
        public static class Vehicle
        {
            public const int RegistrationNumberMaxLength = 20;
            public const int NameMaxLength = 100;
            public const int CompanyMaxLength = 100;
        }
        public static class Waybill
        {
            public const int WaybillNumberMaxLength = 50;
            public const int StartLocationMaxLength = 100;
            public const int EndLocationMaxLength = 100;
            public const int NotesMaxLength = 500;
        }
        public static class SeedConstants
        {
            public static readonly Guid Vehicle1Id = Guid.NewGuid();
            public static readonly Guid Vehicle2Id = Guid.NewGuid();
            public static readonly Guid Employee1Id = Guid.NewGuid();
            public static readonly Guid Employee2Id = Guid.NewGuid();
            public static readonly Guid ServiceRecord1Id = Guid.NewGuid();
            public static readonly Guid ServiceRecord2Id = Guid.NewGuid();
        }




    }
}
