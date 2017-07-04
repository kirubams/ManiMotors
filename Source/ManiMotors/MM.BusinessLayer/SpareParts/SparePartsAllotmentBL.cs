using MM.DataLayer;
using MM.Model.Vehicle;
using MM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MM.BusinessLayer.SpareParts
{
    public class SparePartsAllotmentBL
    {
        public int GetSPInventoryId(int spAllotmentId)
        {
            var spInventoryId = 0;
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    var vbaent = entity.SparePartsBookingAllotments.FirstOrDefault(vba => vba.SparePartsBookingAllotmentID == spAllotmentId);
                    if (vbaent != null)
                    {
                        spInventoryId = vbaent.SparePartsInventoryID;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return spInventoryId;
        }

        public List<SparePartsAllotmentDTO> GetSparePartsAllotmentbyBookingId(int _bookingId)
        {
            List<SparePartsAllotmentDTO> lst = new List<SparePartsAllotmentDTO>();
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                     lst = entities.SparePartsBookingAllotments.Where(sp => sp.VehicleBookingID == _bookingId).
                        Select(x => new SparePartsAllotmentDTO
                        {
                            SparePartsBookingAllotmentID = x.SparePartsBookingAllotmentID,
                            VehicleBookingID = x.VehicleBookingID,
                            SparePartsInventoryID = x.SparePartsInventoryID,
                        }).ToList();
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return lst;
        }

        public List<int> SaveSparePartsAllotment(List<SparePartsAllotmentDTO> lstSPAlt, string mode, List<int> vehicleBookingAllotmentId = null)
        {
            List<int> lstSPAllotment = new List<int>();
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
                                bool flag = true;
                                foreach (var spalt in lstSPAlt)
                                {
                                    if (flag)
                                    {
                                        foreach (var invId in entity.SparePartsBookingAllotments.Where(sp => sp.VehicleBookingID == spalt.VehicleBookingID))
                                        {
                                            var invstatus = entity.SparePartsInventoryStatus.FirstOrDefault(spi => spi.SparePartsInventoryID == invId.SparePartsInventoryID);
                                            invstatus.SparePartsInventoryStatusTypeID = 1;
                                            invstatus.Modifiedby = GlobalSetup.Userid;
                                            invstatus.ModifiedDate = DateTime.Now;
                                            entity.SaveChanges();
                                        }
                                        //Delete existing spare parts allotment
                                        entity.SparePartsBookingAllotments.RemoveRange(entity.SparePartsBookingAllotments.Where(x => x.VehicleBookingID == spalt.VehicleBookingID));
                                        entity.SaveChanges();
                                         flag = false;
                                    }

                                    SparePartsBookingAllotment vbaent = new SparePartsBookingAllotment();
                                    vbaent.VehicleBookingID = spalt.VehicleBookingID;
                                    vbaent.SparePartsInventoryID = spalt.SparePartsInventoryID;
                                    vbaent.Createdby = GlobalSetup.Userid;
                                    vbaent.CreatedDate = DateTime.Now;
                                    entity.SparePartsBookingAllotments.Add(vbaent);
                                    entity.SaveChanges();
                                    lstSPAllotment.Add(vbaent.SparePartsBookingAllotmentID);

                                    //Update new inventory id back to Alloted
                                    var invnewStatus = entity.SparePartsInventoryStatus.FirstOrDefault(vis => vis.SparePartsInventoryID == spalt.SparePartsInventoryID);
                                    invnewStatus.SparePartsInventoryStatusTypeID = 2; //Alloted
                                    invnewStatus.Modifiedby = GlobalSetup.Userid;
                                    invnewStatus.ModifiedDate = DateTime.Now;
                                    entity.SaveChanges();
                                }

                            }
                            else
                            {
                                foreach (var spalt in lstSPAlt)
                                {
                                    SparePartsBookingAllotment vbaent = new SparePartsBookingAllotment();
                                    vbaent.VehicleBookingID = spalt.VehicleBookingID;
                                    vbaent.SparePartsInventoryID = spalt.SparePartsInventoryID;
                                    vbaent.Createdby = GlobalSetup.Userid;
                                    vbaent.CreatedDate = DateTime.Now;
                                    entity.SparePartsBookingAllotments.Add(vbaent);
                                    entity.SaveChanges();
                                    lstSPAllotment.Add(vbaent.SparePartsBookingAllotmentID);

                                    //Update new inventory id back to Alloted
                                    var invnewStatus = entity.SparePartsInventoryStatus.FirstOrDefault(vis => vis.SparePartsInventoryID == spalt.SparePartsInventoryID);
                                    invnewStatus.SparePartsInventoryStatusTypeID = 2; //Alloted
                                    invnewStatus.Modifiedby = GlobalSetup.Userid;
                                    invnewStatus.ModifiedDate = DateTime.Now;
                                    entity.SaveChanges();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstSPAllotment;
        }
    }
}
