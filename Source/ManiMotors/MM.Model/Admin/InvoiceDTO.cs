using MM.Model.Customer;
using MM.Model.SpareParts;
using MM.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model.Admin
{
    public class InvoiceDTO
    {
        public int VehicleBookingID { get; set; }
        public VehicleBookingDTO VclBooking { get; set; }
        public CustomerDTO Customer { get; set; }
        public VehicleInventoryDTO VehicleInventory { get; set; }
        public FinanceAllotmentDTO FinanceAllotment { get; set; }
        public List<SparePartsInventoryDTO> lstSparePartsInventory { get; set; }
        public int DiscountValue { get; set; }
        public string DiscountRemarks { get; set; }
    }
}
