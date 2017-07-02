using MM.DataLayer;
using MM.Model.RTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.BusinessLayer.RTO
{
    public class RTOInfoBL
    {
        public List<RTOInfoDTO> GetAllRTOInfo()
        {
            List<RTOInfoDTO> lst = new List<RTOInfoDTO>();
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    var entlist = entity.RTOInfoes.ToList();
                    foreach (var ent in entlist)
                    {
                        var dto = new RTOInfoDTO();
                        dto.RTOInfoID = ent.RTOInfoID;
                        dto.Name = ent.Name;
                        dto.Address1 = ent.Address1;
                        dto.Address2 = ent.Address2;
                        dto.ContactNo = ent.ContactNo;
                        lst.Add(dto);
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst; ;
        }
    }
}
