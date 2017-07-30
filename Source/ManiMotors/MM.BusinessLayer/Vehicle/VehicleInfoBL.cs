using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM.Model.Vehicle;
using MM.DataLayer;

namespace MM.BusinessLayer.Vehicle
{
    public class VehicleInfoBL
    {
        public List<VehicleTypeDTO> GetVehicleTypes()
        {
            List<VehicleTypeDTO> obj = new List<VehicleTypeDTO>();
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var lstVehicleType =  entities.VehicleTypes.ToList();
                    foreach(var vehicletype in lstVehicleType )
                    {
                        VehicleTypeDTO vehicletypedto = new VehicleTypeDTO();
                        vehicletypedto.VehicleTypeID = vehicletype.VehicleTypeID;
                        vehicletypedto.Description = vehicletype.Description;
                        obj.Add(vehicletypedto);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return obj;
        }


        public List<VehicleInfoDTO> GetAllVehicleInfo()
        {
            List<VehicleInfoDTO> obj = new List<VehicleInfoDTO>();
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var lstVehicleInfo = entities.VehicleInfoes.ToList();
                    foreach (var Info in lstVehicleInfo)
                    {
                        VehicleInfoDTO dto = new VehicleInfoDTO();
                        dto.VehicleInfoID = Info.VehicleInfoID;
                        dto.VehicleTypeID = Info.VehicleTypeID;
                        dto.ModelCode = Info.ModelCode;
                        dto.ModelName = Info.ModelName;
                        dto.ExShowRoomPrice = Info.ExShowRoomPrice;
                        dto.LT_RT_OtherExp = Info.LT_RT_OtherExp;
                        dto.InsurancePrice = Info.InsurancePrice;
                        dto.OnRoadPrice = Info.OnRoadPrice;
                        dto.MarginPrice = Info.MarginPrice;
                        dto.Margin50 = Info.C50PercentMargin;
                        dto.Margin70 = Info.C70PercentMargin;
                        dto.CreatedDate = Info.CreatedDate ?? DateTime.Now;
                        dto.CreatedBy = Info.Createdby ?? 0;
                        dto.ModifiedDate = Info.ModifiedDate ?? DateTime.Now;
                        dto.ModifiedBy = Info.Modifiedby ?? 0;
                        dto.WarrantyPrice = Info.WarrantyPrice ?? 0;
                        obj.Add(dto);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

        public VehicleInfoDTO GetVehicleInfo(int VehicleInfoID)
        {
            VehicleInfoDTO obj = new VehicleInfoDTO();
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var lstVehicleInfo = entities.VehicleInfoes.Where(x => x.VehicleInfoID == VehicleInfoID).FirstOrDefault();
                    obj.VehicleInfoID = lstVehicleInfo.VehicleInfoID;
                    obj.VehicleTypeID = lstVehicleInfo.VehicleTypeID;
                    obj.ModelCode = lstVehicleInfo.ModelCode;
                    obj.ModelName = lstVehicleInfo.ModelName;
                    obj.ExShowRoomPrice = lstVehicleInfo.ExShowRoomPrice;
                    obj.LT_RT_OtherExp = lstVehicleInfo.LT_RT_OtherExp;
                    obj.InsurancePrice = lstVehicleInfo.InsurancePrice;
                    obj.OnRoadPrice = lstVehicleInfo.OnRoadPrice;
                    obj.MarginPrice = lstVehicleInfo.MarginPrice;
                    obj.Margin50 = lstVehicleInfo.C50PercentMargin;
                    obj.Margin70 = lstVehicleInfo.C70PercentMargin;
                    obj.CreatedDate = lstVehicleInfo.CreatedDate ?? DateTime.Now;
                    obj.CreatedBy = lstVehicleInfo.Createdby ?? 0;
                    obj.ModifiedDate = lstVehicleInfo.ModifiedDate ?? DateTime.Now;
                    obj.ModifiedBy = lstVehicleInfo.Modifiedby ?? 0;
                    obj.WarrantyPrice = lstVehicleInfo.WarrantyPrice ?? 0; 
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

        public bool DeleteVehicleInfo(int VehicleInfoID)
        {
            var flag = false;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    entities.VehicleInfoes.Remove(entities.VehicleInfoes.FirstOrDefault(v => v.VehicleInfoID == VehicleInfoID));
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

        public bool SaveVehicleInfo(VehicleInfoDTO dto, string mode)
        {
            var flag = false;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    if (mode == "EDIT")
                    {
                        var info = entities.VehicleInfoes.FirstOrDefault(v => v.VehicleInfoID == dto.VehicleInfoID);
                        info.VehicleTypeID = dto.VehicleTypeID;
                        info.ModelCode = dto.ModelCode;
                        info.ModelName = dto.ModelName;
                        info.ExShowRoomPrice = dto.ExShowRoomPrice;
                        info.LT_RT_OtherExp = dto.LT_RT_OtherExp;
                        info.InsurancePrice = dto.InsurancePrice;
                        info.OnRoadPrice = dto.OnRoadPrice;
                        info.MarginPrice = dto.MarginPrice;
                        info.C50PercentMargin = dto.Margin50;
                        info.C70PercentMargin = dto.Margin70;
                        info.CreatedDate = dto.CreatedDate;
                        info.Createdby = dto.CreatedBy;
                        info.ModifiedDate = dto.ModifiedDate;
                        info.Modifiedby = dto.ModifiedBy;
                        info.WarrantyPrice = dto.WarrantyPrice;
                        entities.SaveChanges();
                        flag = true;
                    }
                    else
                    {
                        VehicleInfo info = new VehicleInfo();
                        info.VehicleTypeID = dto.VehicleTypeID;
                        info.ModelCode = dto.ModelCode;
                        info.ModelName = dto.ModelName;
                        info.ExShowRoomPrice = dto.ExShowRoomPrice;
                        info.LT_RT_OtherExp = dto.LT_RT_OtherExp;
                        info.InsurancePrice = dto.InsurancePrice;
                        info.OnRoadPrice = dto.OnRoadPrice;
                        info.MarginPrice = dto.MarginPrice;
                        info.C50PercentMargin = dto.Margin50;
                        info.C70PercentMargin = dto.Margin70;
                        info.CreatedDate = dto.CreatedDate;
                        info.Createdby = dto.CreatedBy;
                        info.ModifiedDate = dto.ModifiedDate;
                        info.Modifiedby = dto.ModifiedBy;
                        info.WarrantyPrice = dto.WarrantyPrice;
                        entities.VehicleInfoes.Add(info);
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

        public List<VehicleStatusDTO> GetVehicleSalesStatus(string mode)
        {
            List<VehicleStatusDTO> lst = new List<VehicleStatusDTO>();
            using (var entity = new ManiMotorsEntities1())
            {
                if (mode == "ALL")
                {
                    lst = (from v in entity.VehicleSalesStatus
                           select new VehicleStatusDTO
                           {
                               VehicleSalesStatusID = v.VehicleSalesStatusID,
                               Description = v.Description
                           }).ToList();
                }
                else
                {
                    lst = (from v in entity.VehicleSalesStatus
                           where v.Description == "Open" || v.Description == "Closed"
                           select new VehicleStatusDTO
                           {
                               VehicleSalesStatusID = v.VehicleSalesStatusID,
                               Description = v.Description
                           }).ToList();
                }
            }
            return lst;
        }
    }
}
