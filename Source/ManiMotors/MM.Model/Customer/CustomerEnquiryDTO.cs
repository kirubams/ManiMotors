using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model.Customer
{
    public class CustomerEnquiryDTO
    {
        public int CustomerEnquiryID { get; set; }
        public int CustomerID { get; set; }
        public string ReferenceBy { get; set; }
        public string CashorFinance { get; set; }
        public int SalesExecutiveId { get; set; }
        public int Model1 { get; set; }
        public int? Model2 { get; set; }
        public int? Model3 { get; set; }
        public string Color { get; set; }
        public bool TestDrive { get; set; }
        public bool IsExchangeVehicle { get; set; }
        public string CompetitiveModel { get; set; }
        public int VehicleStatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
