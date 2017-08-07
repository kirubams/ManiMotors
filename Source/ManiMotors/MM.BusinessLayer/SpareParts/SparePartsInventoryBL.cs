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
                               MarginPrice = invlist.MarginPrice ?? 0,
                               ShowRoomPrice = invlist.ShowroomPrice?? 0
                           }).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst;
        }

        public SparePartsInventoryDTO GetSparePartsInventory(int inventoryId)
        {
            SparePartsInventoryDTO dto = new SparePartsInventoryDTO();
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    dto = (from invlist in entities.SparePartsInventories
                           join invstatus in entities.SparePartsInventoryStatus
                           on invlist.SparePartsInventoryID equals invstatus.SparePartsInventoryID
                           join vehinfo in entities.SparePartsInfoes
                           on invlist.SparePartsInfoID equals vehinfo.SparePartsInfoID
                           join vehStatus in entities.SparePartsInventoryStatus
                           on invlist.SparePartsInventoryID equals vehStatus.SparePartsInventoryID
                           join vehStatusTypes in entities.SparePartsInventoryStatusTypes
                           on vehStatus.SparePartsInventoryStatusTypeID equals vehStatusTypes.SparePartsInventoryStatusTypeID
                           where invlist.SparePartsInventoryID == inventoryId
                           select new SparePartsInventoryDTO
                           {
                               SparePartsModelName = vehinfo.ModelName,
                               SparePartsInventoryID = invlist.SparePartsInventoryID,
                               SparePartsInfoID = invlist.SparePartsInfoID,
                               IdentificationNo = invlist.IdentificationNo,
                               OtherDescription = invlist.OtherDescription,
                               SparePartsInventoryStatusTypeID = vehStatus.SparePartsInventoryStatusTypeID,
                               SparePartsInventoryStatusName = vehStatusTypes.Description,
                               MarginPrice = invlist.MarginPrice ?? 0,
                               ShowRoomPrice = invlist.ShowroomPrice ?? 0
                           }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dto;
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
                        info.MarginPrice = dto.MarginPrice;
                        info.ShowroomPrice = dto.ShowRoomPrice;
                        entities.SaveChanges();
                        var spInfo = entities.SparePartsInventoryStatus.FirstOrDefault(vi => vi.SparePartsInventoryID == dto.SparePartsInventoryID);
                        if (spInfo != null)
                        {
                            spInfo.SparePartsInventoryStatusTypeID = dto.SparePartsInventoryStatusTypeID;
                            spInfo.Remarks = dto.OtherDescription;
                            spInfo.Modifiedby = dto.ModifiedBy;
                            spInfo.ModifiedDate = dto.ModifiedDate;
                            entities.SaveChanges();
                        }
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
                            MarginPrice = dto.MarginPrice,
                            ShowroomPrice = dto.ShowRoomPrice,
                        };
                        entities.SparePartsInventories.Add(info);
                        entities.SaveChanges();
                        SparePartsInventoryStatu obj = new SparePartsInventoryStatu();
                        obj.SparePartsInventoryID = info.SparePartsInventoryID;
                        obj.SparePartsInventoryStatusTypeID = dto.SparePartsInventoryStatusTypeID;
                        obj.Remarks = dto.OtherDescription;
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
