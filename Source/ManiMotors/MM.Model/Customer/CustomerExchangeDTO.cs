using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model.Customer
{
    public class CustomerExchangeDTO
    {
        public int CustomerExchangeID { get; set; }
        public int? CustomerEnquiryID { get; set; }
        public int CustomerId { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public DateTime? MfgDate { get; set; }
        public string EngineCondition { get; set; }
        public string OutlookCondition { get; set; }
        public int CustomerRate { get; set; }
        public string BrokerName1 { get; set; }
        public string MobileNo1 { get; set; }
        public int? Rate1 { get; set; }
        public int? DifferenceAmount1 { get; set; }
        public string BrokerName2 { get; set; }
        public string MobileNo2 { get; set; }
        public int? Rate2 { get; set; }
        public int? DifferenceAmount2 { get; set; }
        public string ExchangeRemark { get; set; }
        public int? FinalAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
