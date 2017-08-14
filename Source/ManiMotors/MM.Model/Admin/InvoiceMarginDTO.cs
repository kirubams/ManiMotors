using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model.Admin
{
    public class InvoiceMarginDTO
    {
        public int InvoiceMarginID { get; set; }
        public int InvoiceID { get; set; }
        public string InvoiceType { get; set; }
        public int VehicleBookingID { get; set; }
        public int MarginTypeID { get; set; }
        public int MarginID { get; set; }
        public int ManualAmount { get; set; }
        public int MarginAmount { get; set; }
        public int ActualAmount { get; set; }
        public bool IsReceived { get; set; }
        public string Remarks { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public bool IsCash { get; set; }
        public string ChequeBankTranNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
