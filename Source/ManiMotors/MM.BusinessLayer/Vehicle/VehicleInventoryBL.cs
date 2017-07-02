using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM.Model.Vehicle;
using MM.DataLayer;
namespace MM.BusinessLayer.Vehicle
{
    public class VehicleInventoryBL
    {
        public List<VehicleInventoryDTO> GetAllVehicleInventory()
        {
            List<VehicleInventoryDTO> lst = new List<VehicleInventoryDTO>();
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    lst = (from invlist in entities.VehicleInventories
                           join invstatus in entities.VehicleInventoryStatus
                           on invlist.VehicleInventoryID equals invstatus.VehicleInventoryID
                           join vehinfo in entities.VehicleInfoes
                           on invlist.VehicleInfoID equals vehinfo.VehicleInfoID
                           join vehStatus in entities.VehicleInventoryStatus
                           on invlist.VehicleInventoryID equals vehStatus.VehicleInventoryID
                           join vehStatusTypes in entities.VehicleInventoryStatusTypes
                           on vehStatus.VehicleInventoryStatusTypeID equals vehStatusTypes.VehicleInventoryStatusTypeID
                           select new VehicleInventoryDTO
                           {
                               VehicleInventoryID = invlist.VehicleInventoryID,
                               VehicleInfoID = invlist.VehicleInfoID,
                               VehicleModelName = vehinfo.ModelName,
                               ChasisNo = invlist.ChasisNo,
                               EngineNo = invlist.EngineNo,
                               Color = invlist.Color,
                               MfgDate = invlist.ManfgDate ?? DateTime.Now,
                               ServiceBookNo = invlist.ServiceBookNo,
                               KeyNo = invlist.KeyNo,
                               BatteryMake = invlist.BatteryMake,
                               BatteryNo = invlist.BatteryNo,
                               VehicleInventoryStatusTypeID = vehStatusTypes.VehicleInventoryStatusTypeID,
                               VehicleInventoryStatusName = vehStatusTypes.Description,
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

        public List<VehicleInventoryStatusTypeDTO> GetInventoryStatusType()
        {
            List<VehicleInventoryStatusTypeDTO> lst = new List<VehicleInventoryStatusTypeDTO>();
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    foreach( var obj in entities.VehicleInventoryStatusTypes)
                    {
                        VehicleInventoryStatusTypeDTO o = new VehicleInventoryStatusTypeDTO();
                        o.Description = obj.Description;
                        o.VehicleInventoryStatusTypeID = obj.VehicleInventoryStatusTypeID;
                        lst.Add(o);
                    }
                        
                    
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return lst;
        }

        public bool DeleteVehicleInventory(int vehicleInventoryID)
        {
            var flag = false;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    entities.VehicleInventoryStatus.Remove(entities.VehicleInventoryStatus.FirstOrDefault(v => v.VehicleInventoryID == vehicleInventoryID));
                    entities.VehicleInventories.Remove(entities.VehicleInventories.FirstOrDefault(v => v.VehicleInventoryID == vehicleInventoryID));
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

        public bool SaveInventoryVehicle(VehicleInventoryDTO dto, string mode)
        {
            var flag = false;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    if (mode == "EDIT")
                    {
                        var info = entities.VehicleInventories.FirstOrDefault(v => v.VehicleInventoryID == dto.VehicleInventoryID);
                        info.VehicleInfoID = dto.VehicleInfoID;
                        info.ChasisNo = dto.ChasisNo;
                        info.EngineNo = dto.EngineNo;
                        info.Color = dto.Color;
                        info.ManfgDate = dto.MfgDate;
                        info.ServiceBookNo = dto.ServiceBookNo;
                        info.KeyNo = dto.KeyNo;
                        info.BatteryMake = dto.BatteryMake;
                        info.BatteryNo = dto.BatteryNo;
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
                        VehicleInventory info = new VehicleInventory()
                        {
                            VehicleInfoID = dto.VehicleInfoID,
                            ChasisNo = dto.ChasisNo,
                            EngineNo = dto.EngineNo,
                            Color = dto.Color,
                            ManfgDate = dto.MfgDate,
                            ServiceBookNo = dto.ServiceBookNo,
                            KeyNo = dto.KeyNo,
                            BatteryNo = dto.BatteryNo,
                            BatteryMake = dto.BatteryMake,
                            CreatedDate = dto.CreatedDate,
                            Createdby = dto.CreatedBy,
                            ModifiedDate = dto.ModifiedDate,
                            Modifiedby = dto.ModifiedBy,
                            IsMarginPrice = dto.IsMarginPrice,
                            Is50PercentMarginPrice = dto.Is50PerMarginPrice,
                            Is70PercentMarginPrice = dto.Is70PerMarginPrice
                    };
                        entities.VehicleInventories.Add(info);
                        entities.SaveChanges();
                        VehicleInventoryStatu obj = new VehicleInventoryStatu();
                        obj.VehicleInventoryID = info.VehicleInventoryID;
                        obj.VehicleInventoryStatusTypeID = 1;//InStock Status
                        entities.VehicleInventoryStatus.Add(obj);
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

