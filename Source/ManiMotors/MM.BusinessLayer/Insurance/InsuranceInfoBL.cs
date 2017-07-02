using MM.DataLayer;
using MM.Model.Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.BusinessLayer.Insurance
{
    public class InsuranceInfoBL
    {
        public List<InsuranceInfoDTO> GetAllInsuranceInfo()
        {
            List<InsuranceInfoDTO> lst = new List<InsuranceInfoDTO>();
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    var entlist = entity.InsuranceInfoes.ToList();
                    foreach (var ent in entlist)
                    {
                        var dto = new InsuranceInfoDTO();
                        dto.InsuranceInfoID = ent.InsuranceInfoID;
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
