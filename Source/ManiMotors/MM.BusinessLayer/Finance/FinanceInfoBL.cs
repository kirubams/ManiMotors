using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM.Model.Finance;
using MM.DataLayer;

namespace MM.BusinessLayer.Finance
{
    public class FinanceInfoBL
    {
        public List<FinanceInfoDTO> GetAllFinanceInfo()
        {
            List<FinanceInfoDTO> lst = new List<FinanceInfoDTO>();
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    var entlist = entity.FinanceInfoes.ToList();
                    foreach(var ent in entlist)
                    {
                        var dto = new FinanceInfoDTO();
                        dto.FinanceInfoID = ent.FinanceInfoID;
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
