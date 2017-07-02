using MM.DataLayer;
using MM.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.BusinessLayer.Vehicle
{
    public class InsuranceAllotmentBL
    {
        public int SaveInsuranceAllotment(InsuranceAllotmentDTO dto, string mode = "")
        {
            var insuranceAllotmentId = 0;
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {

                    if (mode == "EDIT")
                    {
                        var obj = entity.VehicleBookingInsuranceAllotments.FirstOrDefault(vbfa => vbfa.VehicleBookingInsuranceAllotmentID == dto.VehicleBookingInsuranceAllotmentID);
                        obj.VehicleBookingID = dto.VehicleBookingId;
                        obj.InsuranceByDealer = dto.InsuranceByDealer;
                        obj.InsuranceInfoID = dto.InsuranceInfoID;
                        obj.CoverNoteNo = dto.CoverNoteNo;
                        obj.PolicyNo = dto.PolicyNumber;
                        obj.PolicyAmount = dto.PolicyAmount;
                        obj.FromDate = dto.FromDate;
                        obj.ToDate = dto.ToDate;
                        obj.PolicyDeliveredDate = dto.PolicyDeliveredDate;
                        obj.ContactNo = dto.ContactNo;
                        obj.Createdby = dto.CreatedBy;
                        obj.CreatedDate = dto.CreatedDate;
                        obj.Modifiedby = dto.ModifiedBy;
                        obj.ModifiedDate = dto.ModifiedDate;
                        entity.SaveChanges();
                        insuranceAllotmentId = obj.VehicleBookingInsuranceAllotmentID;
                    }
                    else
                    {
                        VehicleBookingInsuranceAllotment obj = new VehicleBookingInsuranceAllotment()
                        {
                            VehicleBookingID = dto.VehicleBookingId,
                            InsuranceByDealer = dto.InsuranceByDealer,
                            InsuranceInfoID = dto.InsuranceInfoID,
                            CoverNoteNo = dto.CoverNoteNo,
                            PolicyNo = dto.PolicyNumber,
                            PolicyAmount = dto.PolicyAmount,
                            FromDate = dto.FromDate,
                            ToDate = dto.ToDate,
                            PolicyDeliveredDate = dto.PolicyDeliveredDate,
                            Createdby = dto.CreatedBy,
                            CreatedDate = dto.CreatedDate,
                            Modifiedby = dto.ModifiedBy,
                            ModifiedDate = dto.ModifiedDate
                        };
                        entity.VehicleBookingInsuranceAllotments.Add(obj);
                        entity.SaveChanges();
                        insuranceAllotmentId = obj.VehicleBookingInsuranceAllotmentID;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return insuranceAllotmentId;
        }

        public InsuranceAllotmentDTO GetInsuranceAllotment(int insuranceAllotmentId)
        {
            InsuranceAllotmentDTO dto = new InsuranceAllotmentDTO();
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    dto = (from vbfa in entity.VehicleBookingInsuranceAllotments
                           join fi in entity.InsuranceInfoes on vbfa.InsuranceInfoID equals fi.InsuranceInfoID
                           where vbfa.VehicleBookingInsuranceAllotmentID == insuranceAllotmentId
                           select new InsuranceAllotmentDTO
                           {
                               VehicleBookingInsuranceAllotmentID = insuranceAllotmentId,
                               VehicleBookingId = vbfa.VehicleBookingID,
                               InsuranceByDealer = vbfa.InsuranceByDealer,
                               InsuranceInfoID = vbfa.InsuranceInfoID,
                               InsuranceName = fi.Name,
                               CoverNoteNo = vbfa.CoverNoteNo,
                               PolicyNumber = vbfa.PolicyNo,
                               PolicyAmount = vbfa.PolicyAmount,
                               FromDate = vbfa.FromDate,
                               ToDate = vbfa.ToDate,
                               PolicyDeliveredDate = vbfa.PolicyDeliveredDate,
                               ContactNo = vbfa.ContactNo,
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
