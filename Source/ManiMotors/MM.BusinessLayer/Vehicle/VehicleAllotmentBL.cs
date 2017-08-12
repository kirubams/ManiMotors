using MM.DataLayer;
using MM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MM.BusinessLayer.Vehicle
{
    public class VehicleAllotmentBL
    {
        public int  GeInventoryId(int vehicleAllotmentId)
        {
            var vehicleInventoryId = 0;
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    var vbaent = entity.VehicleBookingAllotments.FirstOrDefault(vba => vba.VehicleBookingAllotmentID == vehicleAllotmentId);
                    if (vbaent != null)
                    {
                        vehicleInventoryId = vbaent.VehicleInventoryID;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vehicleInventoryId;
        }

        public int GetAllotmentId(int inventoryId)
        {
            var allotmentId = 0;
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    var vbaent = entity.VehicleBookingAllotments.FirstOrDefault(vba => vba.VehicleInventoryID == inventoryId);
                    if (vbaent != null)
                    {
                        allotmentId = vbaent.VehicleBookingAllotmentID;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return allotmentId;
        }

        public int SaveVehicleAllotment(int vehicleInventoryId, int vehicleBookingId, string mode, int vehicleBookingAllotmentId = 0)
        {
            var VehicleBookingAllotmentId = 0;
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        try
                        {
                            if (mode == "EDIT")
                            {
                                var vbaent = entity.VehicleBookingAllotments.FirstOrDefault(vba => vba.VehicleBookingAllotmentID == vehicleBookingAllotmentId);
                                //update inventory status to back to Instock
                                var invStatus = entity.VehicleInventoryStatus.FirstOrDefault(vis => vis.VehicleInventoryID == vbaent.VehicleInventoryID);
                                invStatus.VehicleInventoryStatusTypeID = 1; //InStock
                                invStatus.Modifiedby = GlobalSetup.Userid;
                                invStatus.ModifiedDate = DateTime.Now;
                                entity.SaveChanges();
                                //Update booking allotment 
                                vbaent.VehicleBookingID = vehicleBookingId;
                                vbaent.VehicleInventoryID = vehicleInventoryId;
                                vbaent.Modifiedby = GlobalSetup.Userid;
                                vbaent.ModifiedDate = DateTime.Now;
                                entity.SaveChanges();
                                VehicleBookingAllotmentId = vehicleBookingAllotmentId;

                                //Update new inventory id back to Alloted
                                var invnewStatus = entity.VehicleInventoryStatus.FirstOrDefault(vis => vis.VehicleInventoryID == vehicleInventoryId);
                                invnewStatus.VehicleInventoryStatusTypeID = 2; //Alloted
                                invnewStatus.Modifiedby = GlobalSetup.Userid;
                                invnewStatus.ModifiedDate = DateTime.Now;
                                entity.SaveChanges();

                            }
                            else
                            {
                                VehicleBookingAllotment vbaent = new VehicleBookingAllotment();
                                vbaent.VehicleBookingID = vehicleBookingId;
                                vbaent.VehicleInventoryID = vehicleInventoryId;
                                vbaent.Createdby = GlobalSetup.Userid;
                                vbaent.CreatedDate = DateTime.Now;
                                entity.VehicleBookingAllotments.Add(vbaent);
                                entity.SaveChanges();
                                VehicleBookingAllotmentId = vbaent.VehicleBookingAllotmentID;

                                //Update new inventory id back to Alloted
                                var invnewStatus = entity.VehicleInventoryStatus.FirstOrDefault(vis => vis.VehicleInventoryID == vehicleInventoryId);
                                invnewStatus.VehicleInventoryStatusTypeID = 2; //Alloted
                                invnewStatus.Modifiedby = GlobalSetup.Userid;
                                invnewStatus.ModifiedDate = DateTime.Now;
                                entity.SaveChanges();
                            }
                            scope.Complete();
                        }
                        catch(Exception ex)
                        {
                            scope.Dispose();
                            throw ex;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return VehicleBookingAllotmentId;
        }
    }
}
