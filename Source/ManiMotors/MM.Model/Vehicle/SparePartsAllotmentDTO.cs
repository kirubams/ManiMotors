using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model.Vehicle
{
    public class SparePartsAllotmentDTO
    {
        public int SparePartsBookingAllotmentID { get; set; }
        public int VehicleBookingID { get; set; }
        public int SparePartsInventoryID { get; set; }
    }
}
