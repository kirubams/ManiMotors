using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model.Admin
{

    public class InvoiceMarginGridDTO
    {
        public int VehicleBookingId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerID { get; set; }
        public string CustomerMobileNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string ModelName { get; set; }
        public string EngineNo { get; set; }
        public string ChasisNo { get; set; }
        public int ShowRoomPrice { get; set; }
        public int OnRoadPrice { get; set; }
        public int? IAMarginwithDTSDeduction { get; set; }
        public int? FinanceMargin { get; set; }
        public int? FinanceMarginManualAmount { get; set; }
        public int? ExtraFittingsTotalActualAmount { get; set; }
        public int? ExtraFittingsTotalMarginAmount { get; set; }
        public int? ExtraFittingsManualMarginAmount { get; set; }
        public int? WarrantyMarginwithDTSDeduction { get; set; }
        public int? WarrantyMarginManualAmount { get; set; }
        public int? DiscountGiven { get; set; }
        public int? IA70PercentMargin { get; set; }
        public int? IA40PercentMargin { get; set; }
        public int? IA100PercentMargin { get; set; }
        public int? IAMarginManualAmount { get; set; }
        public bool? IAMarginReceivedByCash { get; set; }
        public bool? IAMarginReceived { get; set; }
        public string IAMarginByChequeorNEFTNo { get; set; }
        public DateTime? IAMarginReceivedDate { get; set; }
        public string IARemarks { get; set; }
        public string FinanceBy { get; set; }
        public int? FinanceAmount { get; set; }
        public DateTime? FinanceMarginReceivedDate { get; set; }
        public bool? FinanceMarginReceived { get; set; }
        public string FinanceRemarks { get; set; }
        public bool? FinanceMarginReceivedByCash { get; set; }
        public string FinanceMarginByChequeorNEFTNo { get; set; }
        public DateTime? ExtraFittingsReceivedDate { get; set; }
        public bool? ExtraFittingsReceived { get; set; }
        public bool? ExtraFittingsReceivedByCash { get; set; }
        public string ExtraFittingsMarginByChequeorNEFTNo { get; set; }
        public string ExtraFittingsRemarks { get; set; }
        public int? WarrantyPrice { get; set; }
        public int? WarrantyMarginPrice { get; set; }
        public bool WarrantyMarginReceivedByCash { get; set; }
        public string WarrantyMarginByChequeorNEFTNo { get; set; }
        public DateTime? WarrantyMarginReceivedDate { get; set; }
        public string WarrantyMarginRemarks { get; set; }
        public bool? WarrantyMarginReceived { get; set; }
        public string DiscountRemarks { get; set; }
        public DateTime? ManiMotorsInvoiceDate { get; set; }
        public DateTime? IAInvoiceDate { get; set; }

    }
}
