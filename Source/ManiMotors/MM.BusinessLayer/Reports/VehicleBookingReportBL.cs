using MM.DataLayer;
using MM.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.BusinessLayer.Reports
{
    public class VehicleBookingReportBL
    {

        public List<VehicleBookingDTO> GetAllVehicleBooking()
        {
            List<VehicleBookingDTO> dto = new List<VehicleBookingDTO>();
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    dto = (from vb in entity.VehicleBookings
                           join c in entity.Customers on vb.CustomerID equals c.CustomerID
                           join emp in entity.Employees on vb.SalesExecutiveID equals emp.EmployeeID
                           join vs in entity.VehicleSalesStatus on vb.StatusID equals vs.VehicleSalesStatusID
                           join ce in entity.CustomerEnquiries on vb.VehicleEnquiryID equals ce.CustomerEnquiryID into ce1
                           from ceinfo1 in ce1.DefaultIfEmpty()
                           join vi1 in entity.VehicleInfoes on vb.ModelID equals vi1.VehicleInfoID into viI1
                           from viInfo1 in viI1.DefaultIfEmpty()
                           join fi in entity.FinanceInfoes on vb.FinancierID equals fi.FinanceInfoID into fiI1
                           from fiInfo1 in fiI1.DefaultIfEmpty()
                           join vba in entity.VehicleBookingAllotments on vb.VehicleBookingID equals vba.VehicleBookingID into vba1
                           from vba1Info1 in vba1.DefaultIfEmpty()
                           join vfa in entity.VehicleBookingFinanceAllotments on vb.VehicleBookingID equals vfa.VehicleBookingID into vfa1
                           from vfa1Info1 in vfa1.DefaultIfEmpty()
                           join vfia in entity.VehicleBookingInsuranceAllotments on vb.VehicleBookingID equals vfia.VehicleBookingID into vfia1
                           from vfia1Info1 in vfia1.DefaultIfEmpty()
                           join vfra in entity.VehicleBookingRTOAllotments on vb.VehicleBookingID equals vfra.VehicleBookingID into vfra1
                           from vfra1Info1 in vfra1.DefaultIfEmpty()
                           select new VehicleBookingDTO
                           {
                               VehicleBookingID = vb.VehicleBookingID,
                               VehicleEnquiryID = ceinfo1.CustomerEnquiryID,
                               CustomerID = vb.CustomerID,
                               CustomerName = c.Name,
                               CommittedDate = vb.CommittedDate,
                               ReferenceBy = vb.Referenceby,
                               SalesExecutiveName = emp.FirstName,
                               SalesExecutiveId = vb.SalesExecutiveID,
                               ModelID = vb.ModelID,
                               ModelName = viInfo1.ModelName,
                               Color1 = vb.Color1,
                               Color2 = vb.Color2,
                               Color3 = vb.Color3,
                               CustomerRemark = vb.CustomerRemark,
                               IsCash = vb.isCash,
                               AdvanceAmount = vb.AdvanceAmount,
                               AdvanceMode = vb.AdvanceAmountModeBit ?? false,
                               AdvanceChequeNo = vb.AdvanceChequeno,
                               FinancierInfoId = fiInfo1.FinanceInfoID,
                               FinancierName = fiInfo1.Name ?? "",
                               FinancierRemark = vb.FinancierRemark,
                               ReadyToDeliver = vb.ReadytoDelivery,
                               StatusId = vb.StatusID,
                               StatusDescription = vs.Description,
                               ClosingRemark = vb.ClosingRemark,
                               VehicleBookingAllotmentId = vba1Info1.VehicleBookingAllotmentID,
                               FinanceAllotmentId = vfa1Info1.VehicleBookingFinanceAllotmentID,
                               InsuranceAllotmentId = vfia1Info1.VehicleBookingInsuranceAllotmentID,
                               RTOAllotmentId = vfra1Info1.VehicleBookingRTOAllotmentID,
                               CreatedDate = vb.CreatedDate,
                               CreatedBy = vb.Createdby,
                               ModifiedDate = vb.ModifiedDate,
                               ModifiedBy = vb.Modifiedby
                           }).ToList();
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
