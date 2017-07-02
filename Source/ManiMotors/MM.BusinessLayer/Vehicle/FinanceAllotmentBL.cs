using MM.DataLayer;
using MM.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.BusinessLayer.Vehicle
{
    public class FinanceAllotmentBL
    {
        public int SaveFinanceAllotment(FinanceAllotmentDTO dto, string mode = "")
        {
            var financeAllotmentId = 0;
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                   
                    if (mode == "EDIT")
                    {
                        var obj = entity.VehicleBookingFinanceAllotments.FirstOrDefault(vbfa => vbfa.VehicleBookingFinanceAllotmentID == dto.VehicleBookingFinanceAllotmentID);
                        obj.VehicleBookingID = dto.VehicleBookingId;
                        obj.FinancierID = dto.FinancierID;
                        obj.LoanNo = dto.LoanNumber;
                        obj.FinanceDate = dto.FinanceDate;
                        obj.FinanceAmount = dto.FinanceAmount;
                        obj.OtherChargesDesc = dto.OtherChargesDescription;
                        obj.OtherAmount = dto.OtherAmount;
                        obj.Createdby = dto.CreatedBy;
                        obj.CreatedDate = dto.CreatedDate;
                        obj.Modifiedby = dto.ModifiedBy;
                        obj.ModifiedDate = dto.ModifiedDate;
                        entity.SaveChanges();
                        financeAllotmentId = obj.VehicleBookingFinanceAllotmentID;
                    }
                    else
                    {
                        VehicleBookingFinanceAllotment obj = new VehicleBookingFinanceAllotment()
                        {
                            VehicleBookingID = dto.VehicleBookingId,
                            FinancierID = dto.FinancierID,
                            LoanNo = dto.LoanNumber,
                            FinanceDate = dto.FinanceDate,
                            FinanceAmount = dto.FinanceAmount,
                            OtherChargesDesc = dto.OtherChargesDescription,
                            OtherAmount = dto.OtherAmount,
                            Createdby = dto.CreatedBy,
                            CreatedDate = dto.CreatedDate,
                            Modifiedby = dto.ModifiedBy,
                            ModifiedDate = dto.ModifiedDate
                        };
                        entity.VehicleBookingFinanceAllotments.Add(obj);
                        entity.SaveChanges();
                        financeAllotmentId = obj.VehicleBookingFinanceAllotmentID;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return financeAllotmentId;
        }

        public FinanceAllotmentDTO GetFinanceAllotment(int financeAllotmentId)
        {
            FinanceAllotmentDTO dto = new FinanceAllotmentDTO();
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    dto = (from vbfa in entity.VehicleBookingFinanceAllotments
                           join fi in entity.FinanceInfoes on vbfa.FinancierID equals fi.FinanceInfoID
                           where vbfa.VehicleBookingFinanceAllotmentID == financeAllotmentId
                           select new FinanceAllotmentDTO
                           {
                               VehicleBookingFinanceAllotmentID = financeAllotmentId,
                               VehicleBookingId = vbfa.VehicleBookingID,
                               FinancierName = fi.Name,
                               FinancierID = vbfa.FinancierID,
                               LoanNumber = vbfa.LoanNo,
                               FinanceDate = vbfa.FinanceDate,
                               FinanceAmount = vbfa.FinanceAmount,
                               OtherAmount = vbfa.OtherAmount,
                               OtherChargesDescription = vbfa.OtherChargesDesc
                           }
                           ).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return dto;

        }
    }
}
