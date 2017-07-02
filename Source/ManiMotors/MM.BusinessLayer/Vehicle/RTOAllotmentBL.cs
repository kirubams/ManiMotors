using MM.DataLayer;
using MM.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.BusinessLayer.Vehicle
{
    public class RTOAllotmentBL
    {
        public int SaveRTOAllotment(RTOAllotmentDTO dto, string mode = "")
        {
            var rtoAllotmentId = 0;
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {

                    if (mode == "EDIT")
                    {
                        var obj = entity.VehicleBookingRTOAllotments.FirstOrDefault(vbfa => vbfa.VehicleBookingRTOAllotmentID == dto.VehicleBookingRTOAllotmentID);
                        obj.VehicleBookingID = dto.VehicleBookingId;
                        obj.RTOInfoID = dto.RTOInfoID;
                        obj.TempRegNo = dto.TempRegNo;
                        obj.RegNo = dto.RegNo;
                        obj.RegDate = dto.RegDate;
                        obj.Amount = dto.Amount;
                        obj.AgentName = dto.AgentName;
                        obj.RCBookNo = dto.RCBookNo;
                        obj.RCDeliveredDate = dto.RCDeliveredDate;
                        obj.Remark = dto.Remark;
                        obj.Createdby = dto.CreatedBy;
                        obj.CreatedDate = dto.CreatedDate;
                        obj.Modifiedby = dto.ModifiedBy;
                        obj.ModifiedDate = dto.ModifiedDate;
                        entity.SaveChanges();
                        rtoAllotmentId = obj.VehicleBookingRTOAllotmentID;
                    }
                    else
                    {
                        VehicleBookingRTOAllotment obj = new VehicleBookingRTOAllotment()
                        {
                            VehicleBookingID = dto.VehicleBookingId,
                            RTOInfoID = dto.RTOInfoID,
                            TempRegNo = dto.TempRegNo,
                            RegNo = dto.RegNo,
                            RegDate = dto.RegDate,
                            Amount = dto.Amount,
                            AgentName = dto.AgentName,
                            RCBookNo = dto.RCBookNo,
                            RCDeliveredDate = dto.RCDeliveredDate,
                            Remark = dto.Remark,
                            Createdby = dto.CreatedBy,
                            CreatedDate = dto.CreatedDate,
                            Modifiedby = dto.ModifiedBy,
                            ModifiedDate = dto.ModifiedDate
                        };
                        entity.VehicleBookingRTOAllotments.Add(obj);
                        entity.SaveChanges();
                        rtoAllotmentId = obj.VehicleBookingRTOAllotmentID;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rtoAllotmentId;
        }

        public RTOAllotmentDTO GetRTOAllotment(int rtoAllotmentId)
        {
            RTOAllotmentDTO dto = new RTOAllotmentDTO();
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    dto = (from vbfa in entity.VehicleBookingRTOAllotments
                           join fi in entity.RTOInfoes on vbfa.RTOInfoID equals fi.RTOInfoID
                           where vbfa.VehicleBookingRTOAllotmentID == rtoAllotmentId
                           select new RTOAllotmentDTO
                           {
                               VehicleBookingRTOAllotmentID = rtoAllotmentId,
                               VehicleBookingId = vbfa.VehicleBookingID,
                               RTOName = fi.Name,
                               RTOInfoID = vbfa.RTOInfoID,
                               TempRegNo = vbfa.TempRegNo,
                               RegNo = vbfa.RegNo,
                               RegDate = vbfa.RegDate,
                               Amount = vbfa.Amount,
                               AgentName = vbfa.AgentName,
                               RCBookNo = vbfa.RCBookNo,
                               RCDeliveredDate = vbfa.RCDeliveredDate,
                               Remark = vbfa.Remark,
                           }
                           ).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dto;

        }
    }
}
