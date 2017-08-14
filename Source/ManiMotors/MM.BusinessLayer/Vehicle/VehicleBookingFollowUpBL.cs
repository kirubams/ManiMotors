using MM.DataLayer;
using MM.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.BusinessLayer.Vehicle
{
    public class VehicleBookingFollowUpBL
    {
        public List<VehicleBookingFollowupDTO> GetVehicleBookingFollowUp(DateTime startDate, DateTime endDate, int statusId,string mode ="")
        {
            List<VehicleBookingFollowupDTO> lst = new List<VehicleBookingFollowupDTO>();
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    if (mode == "")
                    {
                        lst = (from vb in entity.VehicleBookings
                               join vbf in entity.VehicleBookingFollowUps on vb.VehicleBookingID equals vbf.VehicleBookingID
                               join vs in entity.VehicleSalesStatus on vb.StatusID equals vs.VehicleSalesStatusID
                               join vi in entity.VehicleInfoes on vb.ModelID equals vi.VehicleInfoID
                               join c in entity.Customers on vb.CustomerID equals c.CustomerID
                               join e in entity.Employees on vb.SalesExecutiveID equals e.EmployeeID
                               join f in entity.FinanceInfoes on vb.FinancierID equals f.FinanceInfoID into fi
                               from fiInfo1 in fi.DefaultIfEmpty()
                               where vbf.FollowupDate >= startDate && vbf.FollowupDate <= endDate && vs.VehicleSalesStatusID == statusId
                               && vbf.isActive == true
                               select new VehicleBookingFollowupDTO
                               {
                                   CustomerName = c.Name,
                                   CustomerId = c.CustomerID,
                                   ModelName = vi.ModelName,
                                   VehicleColor = vb.Color1,
                                   SalesExecutive = e.FirstName + " " + e.LastName,
                                   AdvanceAmount = vb.AdvanceAmount ?? 0,
                                   IsCashAdvance = vb.AdvanceAmountModeBit,
                                   IsCashPayment = vb.isCash,
                                   FinancierName = fiInfo1.Name,
                                   VehicleBookingID = vb.VehicleBookingID,
                                   FollowUpDate = vbf.FollowupDate,
                                   IsActive = vbf.isActive,
                                   StatusDescription = vs.Description,
                                   StatusId = vs.VehicleSalesStatusID,
                                   CustomerMobileNo = c.ContactNo,
                                   Description = vbf.Description,
                                   CreatedDate = vb.CreatedDate,
                                   ModifiedDate = vb.ModifiedDate,
                               }).ToList();
                        
                    }
                    else if(mode == "MARGIN")
                    {
                        lst = (from vb in entity.VehicleBookings
                        join vbf in entity.VehicleBookingFollowUps on vb.VehicleBookingID equals vbf.VehicleBookingID
                        join im in entity.InvoiceMargins on vb.VehicleBookingID equals im.VehicleBookingID
                        join vs in entity.VehicleSalesStatus on vb.StatusID equals vs.VehicleSalesStatusID
                        join vi in entity.VehicleInfoes on vb.ModelID equals vi.VehicleInfoID
                        join c in entity.Customers on vb.CustomerID equals c.CustomerID
                        join e in entity.Employees on vb.SalesExecutiveID equals e.EmployeeID
                        join f in entity.FinanceInfoes on vb.FinancierID equals f.FinanceInfoID into fi
                        from fiInfo1 in fi.DefaultIfEmpty()
                        where vbf.FollowupDate >= startDate && vbf.FollowupDate <= endDate && vs.VehicleSalesStatusID == statusId
                        && vbf.isActive == true
                        select new VehicleBookingFollowupDTO
                        {
                            CustomerName = c.Name,
                            CustomerId = c.CustomerID,
                            ModelName = vi.ModelName,
                            VehicleColor = vb.Color1,
                            SalesExecutive = e.FirstName + " " + e.LastName,
                            AdvanceAmount = vb.AdvanceAmount ?? 0,
                            IsCashAdvance = vb.AdvanceAmountModeBit,
                            IsCashPayment = vb.isCash,
                            FinancierName = fiInfo1.Name,
                            VehicleBookingID = vb.VehicleBookingID,
                            FollowUpDate = vbf.FollowupDate,
                            IsActive = vbf.isActive,
                            StatusDescription = vs.Description,
                            StatusId = vs.VehicleSalesStatusID,
                            CustomerMobileNo = c.ContactNo,
                            Description = vbf.Description,
                            CreatedDate = vb.CreatedDate,
                            ModifiedDate = vb.ModifiedDate,
                        }).ToList();
                        lst = lst.GroupBy(x => x.VehicleBookingID).Select(y => y.First()).ToList();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst;
        }


        public VehicleBookingFollowupDTO GetVehicleBookingFollowupbyId(int vehicleBookingId)
        {
            VehicleBookingFollowupDTO lst = new VehicleBookingFollowupDTO();
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    lst = (from vb in entity.VehicleBookings
                           join vbf in entity.VehicleBookingFollowUps on vb.VehicleBookingID equals vbf.VehicleBookingID
                           join vs in entity.VehicleSalesStatus on vb.StatusID equals vs.VehicleSalesStatusID
                           join vi in entity.VehicleInfoes on vb.ModelID equals vi.VehicleInfoID
                           join c in entity.Customers on vb.CustomerID equals c.CustomerID
                           where vbf.VehicleBookingID == vehicleBookingId
                           && vbf.isActive == true
                           select new VehicleBookingFollowupDTO
                           {
                               CustomerName = c.Name,
                               CustomerId = c.CustomerID,
                               ModelName = vi.ModelName,
                               VehicleBookingID = vb.VehicleBookingID,
                               FollowUpDate = vbf.FollowupDate,
                               StatusDescription = vs.Description,
                               StatusId = vs.VehicleSalesStatusID,
                               CustomerMobileNo = c.ContactNo,
                               Description = vbf.Description
                           }).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst;
        }
    }
}
