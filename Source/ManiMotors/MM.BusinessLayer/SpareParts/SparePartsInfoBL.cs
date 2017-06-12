using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM.Model.SpareParts;
using MM.DataLayer;

namespace MM.BusinessLayer.SpareParts
{
    public class SparePartsInfoBL
    {
        public List<SparePartsTypeDTO> GetSparePartsTypes()
        {
            List<SparePartsTypeDTO> obj = new List<SparePartsTypeDTO>();
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var lstSparePartsType = entities.SparePartsTypes.ToList();
                    foreach (var SparePartstype in lstSparePartsType)
                    {
                        SparePartsTypeDTO SparePartstypedto = new SparePartsTypeDTO();
                        SparePartstypedto.SparePartsTypeID = SparePartstype.SparePartsTypeID;
                        SparePartstypedto.Description = SparePartstype.Description;
                        obj.Add(SparePartstypedto);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }


        public List<SparePartsInfoDTO> GetAllSparePartsInfo()
        {
            List<SparePartsInfoDTO> obj = new List<SparePartsInfoDTO>();
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var lstSparePartsInfo = entities.SparePartsInfoes.ToList();
                    foreach (var Info in lstSparePartsInfo)
                    {
                        SparePartsInfoDTO dto = new SparePartsInfoDTO();
                        dto.SparePartsInfoID = Info.SparePartsInfoID;
                        dto.SparePartsTypeID = Info.SparePartsTypeID;
                        dto.ModelCode = Info.ModelCode;
                        dto.ModelName = Info.ModelName;
                        dto.ShowRoomPrice = Info.ShowRoomPrice;
                        dto.MarginPrice = Info.MarginPrice;
                        dto.Margin50 = Info.C50PercentMargin;
                        dto.Margin70 = Info.C70PercentMargin;
                        dto.CreatedDate = Info.CreatedDate ?? DateTime.Now;
                        dto.CreatedBy = Info.Createdby ?? 0;
                        dto.ModifiedDate = Info.ModifiedDate ?? DateTime.Now;
                        dto.ModifiedBy = Info.Modifiedby ?? 0;
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

        public SparePartsInfoDTO GetSparePartsInfo(int SparePartsInfoID)
        {
            SparePartsInfoDTO obj = new SparePartsInfoDTO();
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var lstSparePartsInfo = entities.SparePartsInfoes.Where(x => x.SparePartsInfoID == SparePartsInfoID).FirstOrDefault();
                    obj.SparePartsInfoID = lstSparePartsInfo.SparePartsInfoID;
                    obj.SparePartsTypeID = lstSparePartsInfo.SparePartsTypeID;
                    obj.ModelCode = lstSparePartsInfo.ModelCode;
                    obj.ModelName = lstSparePartsInfo.ModelName;
                    obj.ShowRoomPrice = lstSparePartsInfo.ShowRoomPrice;
                    obj.MarginPrice = lstSparePartsInfo.MarginPrice;
                    obj.Margin50 = lstSparePartsInfo.C50PercentMargin;
                    obj.Margin70 = lstSparePartsInfo.C70PercentMargin;
                    obj.CreatedDate = lstSparePartsInfo.CreatedDate ?? DateTime.Now;
                    obj.CreatedBy = lstSparePartsInfo.Createdby ?? 0;
                    obj.ModifiedDate = lstSparePartsInfo.ModifiedDate ?? DateTime.Now;
                    obj.ModifiedBy = lstSparePartsInfo.Modifiedby ?? 0;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

        public bool DeleteSparePartsInfo(int SparePartsInfoID)
        {
            var flag = false;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    entities.SparePartsInfoes.Remove(entities.SparePartsInfoes.FirstOrDefault(v => v.SparePartsInfoID == SparePartsInfoID));
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

        public bool SaveSparePartsInfo(SparePartsInfoDTO dto, string mode)
        {
            var flag = false;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    if (mode == "EDIT")
                    {
                        var info = entities.SparePartsInfoes.FirstOrDefault(v => v.SparePartsInfoID == dto.SparePartsInfoID);
                        info.SparePartsTypeID = dto.SparePartsTypeID;
                        info.ModelCode = dto.ModelCode;
                        info.ModelName = dto.ModelName;
                        info.ShowRoomPrice = dto.ShowRoomPrice;
                        info.MarginPrice = dto.MarginPrice;
                        info.C50PercentMargin = dto.Margin50;
                        info.C70PercentMargin = dto.Margin70;
                        info.CreatedDate = dto.CreatedDate;
                        info.Createdby = dto.CreatedBy;
                        info.ModifiedDate = dto.ModifiedDate;
                        info.Modifiedby = dto.ModifiedBy;
                        entities.SaveChanges();
                        flag = true;
                    }
                    else
                    {
                        SparePartsInfo info = new SparePartsInfo();
                        info.SparePartsTypeID = dto.SparePartsTypeID;
                        info.ModelCode = dto.ModelCode;
                        info.ModelName = dto.ModelName;
                        info.ShowRoomPrice = dto.ShowRoomPrice;
                        info.MarginPrice = dto.MarginPrice;
                        info.C50PercentMargin = dto.Margin50;
                        info.C70PercentMargin = dto.Margin70;
                        info.CreatedDate = dto.CreatedDate;
                        info.Createdby = dto.CreatedBy;
                        info.ModifiedDate = dto.ModifiedDate;
                        info.Modifiedby = dto.ModifiedBy;
                        entities.SparePartsInfoes.Add(info);
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
