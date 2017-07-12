using MM.DataLayer;
using MM.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.BusinessLayer.Admin
{
    public class SparePartsTypeBL
    {
        public List<SparePartsTypeDTO> GetSparePartsTypes()
        {
            var lstSparePartsTypes = new List<SparePartsTypeDTO>();
            using (var entities = new ManiMotorsEntities1())
            {
                foreach (var ent in entities.SparePartsTypes)
                {
                    var sparePartsDTO = new SparePartsTypeDTO();
                    sparePartsDTO.SparePartsTypeID = ent.SparePartsTypeID;
                    sparePartsDTO.Description = ent.Description;
                    lstSparePartsTypes.Add(sparePartsDTO);
                }
            }

            return lstSparePartsTypes;
        }

        public bool AddSpareParts(SparePartsTypeDTO sparePartsDTO)
        {
            var flag = true;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var sp = new SparePartsType()
                    {
                        Description = sparePartsDTO.Description,
                        CreatedDate = sparePartsDTO.CreatedDate,
                        Createdby = sparePartsDTO.CreatedBy,
                        Modifiedby = sparePartsDTO.ModifiedBy,
                        ModifiedDate = sparePartsDTO.ModifiedDate
                    };
                    entities.SparePartsTypes.Add(sp);
                    entities.SaveChanges();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                throw ex;
            }

            return flag;

        }

        public bool DeleteSpareParts(int sparePartsID)
        {
            var flag = true;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    entities.SparePartsTypes.Remove(entities.SparePartsTypes.Where(g => g.SparePartsTypeID == sparePartsID).FirstOrDefault());
                    entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                flag = false;
                throw ex;
            }

            return flag;

        }

        public bool UpdateSpareParts(SparePartsTypeDTO sparePartsDTO)
        {
            var flag = true;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var Gamesys = entities.SparePartsTypes.Where(g => g.SparePartsTypeID == sparePartsDTO.SparePartsTypeID).FirstOrDefault();
                    Gamesys.Description = sparePartsDTO.Description;
                    //Gamesys.CreatedDate = expensesDTO.CreatedDate;
                    //Gamesys.Createdby = expensesDTO.CreatedBy;
                    Gamesys.Modifiedby = sparePartsDTO.ModifiedBy;
                    Gamesys.ModifiedDate = sparePartsDTO.ModifiedDate;
                    entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                flag = false;
                throw ex;
            }

            return flag;

        }
    }
}
