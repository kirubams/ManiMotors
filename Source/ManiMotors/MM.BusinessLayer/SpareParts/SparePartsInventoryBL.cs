using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM.Model.SpareParts;
using MM.DataLayer;
namespace MM.BusinessLayer.SpareParts
{
    public class SparePartsInventoryBL
    {
        public List<SparePartsInventoryDTO> GetAllSparePartsInventory()
        {
            List<SparePartsInventoryDTO> lst = new List<SparePartsInventoryDTO>();
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    lst = (from invlist in entities.SparePartsInventories
                           join invstatus in entities.SparePartsInventoryStatus
                           on invlist.SparePartsInventoryID equals invstatus.SparePartsInventoryID
                           join vehinfo in entities.SparePartsInfoes
                           on invlist.SparePartsInfoID equals vehinfo.SparePartsInfoID
                           join vehStatus in entities.SparePartsInventoryStatus
                           on invlist.SparePartsInventoryID equals vehStatus.SparePartsInventoryID
                           join vehStatusTypes in entities.SparePartsInventoryStatusTypes
                           on vehStatus.SparePartsInventoryStatusTypeID equals vehStatusTypes.SparePartsInventoryStatusTypeID
                           select new SparePartsInventoryDTO
                           {
                               SparePartsModelName = vehinfo.ModelName,
                               SparePartsInventoryID = invlist.SparePartsInventoryID,
                               SparePartsInfoID = invlist.SparePartsInfoID,
                               IdentificationNo = invlist.IdentificationNo,
                               OtherDescription = invlist.OtherDescription,
                               SparePartsInventoryStatusTypeID = vehStatus.SparePartsInventoryStatusTypeID,
                               SparePartsInventoryStatusName = vehStatusTypes.Description,
                               Is50PerMarginPrice = invlist.Is50PercentMarginPrice ?? false,
                               Is70PerMarginPrice = invlist.Is70PercentMarginPrice ?? false,
                               IsMarginPrice = invlist.IsMarginPrice ?? false
                           }).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst;
        }

        public List<SparePartsInventoryStatusTypeDTO> GetInventoryStatusType()
        {
            List<SparePartsInventoryStatusTypeDTO> lst = new List<SparePartsInventoryStatusTypeDTO>();
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    foreach (var obj in entities.SparePartsInventoryStatusTypes)
                    {
                        SparePartsInventoryStatusTypeDTO o = new SparePartsInventoryStatusTypeDTO();
                        o.Description = obj.Description;
                        o.SparePartsInventoryStatusTypeID = obj.SparePartsInventoryStatusTypeID;
                        lst.Add(o);
                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst;
        }

        public bool DeleteSparePartsInventory(int SparePartsInventoryID)
        {
            var flag = false;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    entities.SparePartsInventoryStatus.Remove(entities.SparePartsInventoryStatus.FirstOrDefault(v => v.SparePartsInventoryID == SparePartsInventoryID));
                    entities.SparePartsInventories.Remove(entities.SparePartsInventories.FirstOrDefault(v => v.SparePartsInventoryID == SparePartsInventoryID));
                    entities.SaveChanges();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flag;
        }

        public bool SaveInventorySpareParts(SparePartsInventoryDTO dto, string mode)
        {
            var flag = false;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    if (mode == "EDIT")
                    {
                        var info = entities.SparePartsInventories.FirstOrDefault(v => v.SparePartsInventoryID == dto.SparePartsInventoryID);
                        info.SparePartsInfoID = dto.SparePartsInfoID;
                        info.IdentificationNo = dto.IdentificationNo;
                        info.OtherDescription = dto.OtherDescription;
                        info.CreatedDate = dto.CreatedDate;
                        info.Createdby = dto.CreatedBy;
                        info.ModifiedDate = dto.ModifiedDate;
                        info.Modifiedby = dto.ModifiedBy;
                        info.IsMarginPrice = dto.IsMarginPrice;
                        info.Is50PercentMarginPrice = dto.Is50PerMarginPrice;
                        info.Is70PercentMarginPrice = dto.Is70PerMarginPrice;
                        entities.SaveChanges();
                        flag = true;
                    }
                    else
                    {
                        SparePartsInventory info = new SparePartsInventory()
                        {
                            SparePartsInfoID = dto.SparePartsInfoID,
                            IdentificationNo = dto.IdentificationNo,
                            OtherDescription = dto.OtherDescription,
                            CreatedDate = dto.CreatedDate,
                            Createdby = dto.CreatedBy,
                            ModifiedDate = dto.ModifiedDate,
                            Modifiedby = dto.ModifiedBy,
                            IsMarginPrice = dto.IsMarginPrice,
                            Is50PercentMarginPrice = dto.Is50PerMarginPrice,
                            Is70PercentMarginPrice = dto.Is70PerMarginPrice
                        };
                        entities.SparePartsInventories.Add(info);
                        entities.SaveChanges();
                        SparePartsInventoryStatu obj = new SparePartsInventoryStatu();
                        obj.SparePartsInventoryID = info.SparePartsInventoryID;
                        obj.SparePartsInventoryStatusTypeID = 1;//InStock Status
                        entities.SparePartsInventoryStatus.Add(obj);
                        entities.SaveChanges();
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flag;
        }
    }
}
