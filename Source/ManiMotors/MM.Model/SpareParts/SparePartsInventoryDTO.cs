using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model.SpareParts
{
    public class SparePartsInventoryDTO
    {
        public int SparePartsInventoryID { get; set; }
        public int SparePartsInfoID { get; set; }
        public string SparePartsModelName { get; set; }
        public string IdentificationNo { get; set; }
        public string OtherDescription { get; set; }
        public int SparePartsInventoryStatusID { get; set; }
        public string SparePartsInventoryStatusName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
