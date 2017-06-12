using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model.SpareParts
{
    public class SparePartsInfoDTO
    {
        public int SparePartsInfoID { get; set; }
        public int SparePartsTypeID { get; set; }
        public string ModelCode { get; set; }
        public string ModelName { get; set; }
        public int ShowRoomPrice { get; set; }
        public int MarginPrice { get; set; }
        public int Margin50 { get; set; }
        public int Margin70 { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
