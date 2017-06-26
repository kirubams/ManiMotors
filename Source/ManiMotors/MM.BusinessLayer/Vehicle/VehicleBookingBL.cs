using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM.Model.Vehicle;
using MM.DataLayer;
using System.Transactions;
namespace MM.BusinessLayer.Vehicle
{
    public class VehicleBookingBL
    {
        public bool SaveVehicleBooking(VehicleBookingDTO dto)
        {
            var flag = false;
            try
            {
                //Populate VehicleBooking
                VehicleBooking ent = new VehicleBooking()
                {
                    VehicleEnquiryID = dto.VehicleEnquiryID,
                    CustomerID = dto.CustomerID,
                    CommittedDate = dto.CommittedDate,
                    ModelID = dto.ModelID,
                    Color1= dto.Color1,
                    Color2 =dto.Color2,
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

                using (var entities = new ManiMotorsEntities1())
                {
                    using (var scope = new TransactionScope())
                    {
                        try
                        {
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
                            scope.Complete();
                        }
                        catch(Exception ex)
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
    }
}
