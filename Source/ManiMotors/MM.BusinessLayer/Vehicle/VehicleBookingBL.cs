using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM.Model.Vehicle;
using MM.DataLayer;
using System.Transactions;
using MM.Utilities;
namespace MM.BusinessLayer.Vehicle
{
    public class VehicleBookingBL
    {
        public bool SaveVehicleBooking(VehicleBookingDTO dto, string mode ="")
        {
            var flag = false;
            try
            {
                

                using (var entities = new ManiMotorsEntities1())
                {
                    using (var scope = new TransactionScope())
                    {
                        try
                        {
                            if (mode != "EDIT" && mode != "DELIVERY")
                            {
                                //Populate VehicleBooking
                                VehicleBooking ent = new VehicleBooking()
                                {
                                    VehicleEnquiryID = dto.VehicleEnquiryID,
                                    CustomerID = dto.CustomerID,
                                    CommittedDate = dto.CommittedDate,
                                    ModelID = dto.ModelID,
                                    Color1 = dto.Color1,
                                    Color2 = dto.Color2,
                                    Color3 = dto.Color3,
                                    CustomerRemark = dto.CustomerRemark,
                                    Referenceby = dto.ReferenceBy,
                                    SalesExecutiveID = dto.SalesExecutiveId,
                                    isCash = dto.IsCash,
                                    AdvanceAmount = dto.AdvanceAmount,
                                    AdvanceAmountModeBit = dto.AdvanceMode,
                                    AdvanceChequeno = dto.AdvanceChequeNo,
                                    FinancierID = dto.FinancierInfoId,
                                    FinancierRemark = dto.FinancierRemark,
                                    ReadytoDelivery = dto.ReadyToDeliver,
                                    StatusID = dto.StatusId,
                                    ClosingRemark = dto.ClosingRemark,
                                    CreatedDate = dto.CreatedDate,
                                    Createdby = dto.CreatedBy,
                                    Modifiedby = dto.ModifiedBy,
                                    ModifiedDate = dto.ModifiedDate

                                };

                                //Populate VehicleBookingFollowup
                                VehicleBookingFollowUp entF = new VehicleBookingFollowUp()
                                {
                                    VehicleBookingID = dto.VehicleBookingID,
                                    CustomerID = dto.CustomerID,
                                    Description = dto.FollowupDescription,
                                    FollowupDate = dto.FollowupDate,
                                    isActive = dto.FollowupIsActive,
                                    CreatedDate = dto.CreatedDate,
                                    Createdby = dto.CreatedBy,
                                    Modifiedby = dto.ModifiedBy,
                                    ModifiedDate = dto.ModifiedDate
                                };
                                entities.VehicleBookings.Add(ent);
                                entities.SaveChanges();
                                int vehicleBookingId = ent.VehicleBookingID;

                                //Invalid previous booking followup for the same booking id

                                foreach (var bf in entities.VehicleBookingFollowUps.Where(vf => vf.VehicleBookingID == vehicleBookingId))
                                {
                                    bf.isActive = false;
                                    entities.SaveChanges();
                                }
                                entF.VehicleBookingID = vehicleBookingId;
                                entities.VehicleBookingFollowUps.Add(entF);
                                entities.SaveChanges();
                                //Update Customer enquiry status to booked 
                                var enquiry = entities.CustomerEnquiries.FirstOrDefault(c => c.CustomerEnquiryID == dto.VehicleEnquiryID);
                                if (enquiry != null)
                                {
                                    enquiry.VehicleStatusID = 4; //update to booked
                                    enquiry.Modifiedby = GlobalSetup.Userid;
                                    enquiry.ModifiedDate = DateTime.Now;
                                    entities.SaveChanges();
                                }
                            }
                            else
                            {
                                var entVehicleBooking = entities.VehicleBookings.FirstOrDefault(vb => vb.VehicleBookingID == dto.VehicleBookingID);

                                //Populate VehicleBooking
                                entVehicleBooking.VehicleEnquiryID = dto.VehicleEnquiryID;
                                entVehicleBooking.CustomerID = dto.CustomerID;
                                entVehicleBooking.CommittedDate = dto.CommittedDate;
                                entVehicleBooking.ModelID = dto.ModelID;
                                entVehicleBooking.Color1 = dto.Color1;
                                entVehicleBooking.Color2 = dto.Color2;
                                entVehicleBooking.Color3 = dto.Color3;
                                entVehicleBooking.CustomerRemark = dto.CustomerRemark;
                                entVehicleBooking.Referenceby = dto.ReferenceBy;
                                entVehicleBooking.SalesExecutiveID = dto.SalesExecutiveId;
                                entVehicleBooking.isCash = dto.IsCash;
                                entVehicleBooking.AdvanceAmount = dto.AdvanceAmount;
                                entVehicleBooking.AdvanceAmountModeBit = dto.AdvanceMode;
                                entVehicleBooking.AdvanceChequeno = dto.AdvanceChequeNo;
                                entVehicleBooking.FinancierID = dto.FinancierInfoId;
                                entVehicleBooking.FinancierRemark = dto.FinancierRemark;
                                entVehicleBooking.ReadytoDelivery = dto.ReadyToDeliver;
                                entVehicleBooking.StatusID = dto.StatusId;
                                entVehicleBooking.ClosingRemark = dto.ClosingRemark;
                                entVehicleBooking.CreatedDate = dto.CreatedDate;
                                entVehicleBooking.Createdby = dto.CreatedBy;
                                entVehicleBooking.Modifiedby = dto.ModifiedBy;
                                entVehicleBooking.ModifiedDate = dto.ModifiedDate;
                                entities.SaveChanges();

                                //Populate VehicleBookingFollowup
                                VehicleBookingFollowUp entF = new VehicleBookingFollowUp()
                                {
                                    VehicleBookingID = dto.VehicleBookingID,
                                    CustomerID = dto.CustomerID,
                                    Description = dto.FollowupDescription,
                                    FollowupDate = dto.FollowupDate,
                                    isActive = dto.FollowupIsActive,
                                    CreatedDate = dto.CreatedDate,
                                    Createdby = dto.CreatedBy,
                                    Modifiedby = dto.ModifiedBy,
                                    ModifiedDate = dto.ModifiedDate
                                };
                               
                                //Invalid previous booking followup for the same booking id

                                foreach (var bf in entities.VehicleBookingFollowUps.Where(vf => vf.VehicleBookingID == dto.VehicleBookingID))
                                {
                                    bf.isActive = false;
                                    entities.SaveChanges();
                                }
                                entF.VehicleBookingID = dto.VehicleBookingID;
                                entities.VehicleBookingFollowUps.Add(entF);
                                entities.SaveChanges();

                                if(mode == "DELIVERY")
                                {
                                    // Mark all inventories to Delivered

                                    var vehicleBookingAlt = entities.VehicleBookingAllotments.FirstOrDefault(vba => vba.VehicleBookingID == dto.VehicleBookingID);
                                    if(vehicleBookingAlt != null)
                                    {
                                        var vehInv = entities.VehicleInventoryStatus.FirstOrDefault(vis => vis.VehicleInventoryID == vehicleBookingAlt.VehicleInventoryID);
                                        vehInv.VehicleInventoryStatusTypeID = 3;// Delivered
                                        vehInv.Modifiedby = GlobalSetup.Userid;
                                        vehInv.ModifiedDate = DateTime.Now;
                                        entities.SaveChanges();
                                    }

                                    var sparePartsBookingAlt = entities.SparePartsBookingAllotments.Where(spba => spba.VehicleBookingID == dto.VehicleBookingID);
                                    foreach( var spaltid in sparePartsBookingAlt)
                                    {
                                        var spInv = entities.SparePartsInventoryStatus.FirstOrDefault(spi => spi.SparePartsInventoryID == spaltid.SparePartsInventoryID);
                                        spInv.SparePartsInventoryStatusTypeID = 3; //Delivered
                                        spInv.Modifiedby = GlobalSetup.Userid;
                                        spInv.ModifiedDate = DateTime.Now;
                                        entities.SaveChanges();
                                    }

                                    var custEnquiry = entities.CustomerEnquiries.FirstOrDefault(ce => ce.CustomerEnquiryID == dto.VehicleEnquiryID); 
                                    if(custEnquiry != null)
                                    {
                                        custEnquiry.VehicleStatusID = 5; //Delivered -- Table VehicleSalesStatus
                                        custEnquiry.Modifiedby = GlobalSetup.Userid;
                                        custEnquiry.ModifiedDate = DateTime.Now;
                                        entities.SaveChanges();
                                    }
                                }

                            }
                            scope.Complete();
                        }
                        catch (Exception ex)
                        {
                            scope.Dispose();
                            throw ex;
                        }
                    }

                }
                    flag = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return flag;
        }


        public List<VehicleBookingDTO> GetVehicleBookingforCustomerId(int CustomerId)
        {
            List<VehicleBookingDTO> lst = new List<VehicleBookingDTO>();
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    var bookinglist = entity.VehicleBookings.Where(c => c.StatusID == 1 && c.CustomerID == CustomerId);
                    foreach (var booking in bookinglist)
                    {
                        lst.Add(GetVehicleBooking(booking.VehicleBookingID));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst;
        }


        public VehicleBookingDTO GetVehicleBooking(int bookingId)
        {
            VehicleBookingDTO dto = new VehicleBookingDTO();
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
                           where vb.VehicleBookingID == bookingId
                           select new VehicleBookingDTO
                           {
                               VehicleBookingID = bookingId,
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
                           }).FirstOrDefault();
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
