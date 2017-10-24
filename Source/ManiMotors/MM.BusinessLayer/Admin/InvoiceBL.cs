using MM.BusinessLayer.Customer;
using MM.BusinessLayer.SpareParts;
using MM.BusinessLayer.Vehicle;
using MM.DataLayer;
using MM.Model.Admin;
using MM.Model.Customer;
using MM.Model.SpareParts;
using MM.Model.Vehicle;
using MM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MM.BusinessLayer.Admin
{
    public class InvoiceBL
    {
        public InvoiceDTO GetInvoiceDetails(int VehicleBookingId)
        {
            var Invoicedto = new InvoiceDTO();
            var vBL = new VehicleBookingBL();
            var viBL = new VehicleInventoryBL();
            var vABL = new VehicleAllotmentBL();
            var spABL = new SparePartsAllotmentBL();
            var spInventory = new SparePartsInventoryBL();
            var fABL = new FinanceAllotmentBL();
            var vehicleBooking =  vBL.GetVehicleBooking(VehicleBookingId);
            //Customer Information
            var ctmrDTO = new CustomerDTO();
            //VehicleInventory
            var vIDTO = new VehicleInventoryDTO();
            //VehicleBooking
            var vBDTO = new VehicleBookingDTO();
            //SpareParts Inventory
            var spInvDTOlist = new List<SparePartsInventoryDTO>();
            //Finance Allotment
            var fDTO = new FinanceAllotmentDTO();
            if(vehicleBooking != null)
            {
                vBDTO = vehicleBooking;
                Invoicedto.VclBooking = vBDTO;
                ctmrDTO.CustomerID = vehicleBooking.CustomerID;
                ctmrDTO.Name = vehicleBooking.CustomerName;
                Invoicedto.Customer = ctmrDTO;
                //Get Vehicle Inventory ID from VehicleAllotment Id
                int vInventoryId = vABL.GeInventoryId(vehicleBooking.VehicleBookingAllotmentId ?? 0);

                if(vInventoryId != 0)
                {
                    var invDTO = viBL.GetVehicleInventory(vInventoryId);
                    vIDTO.EngineNo = invDTO.EngineNo;
                    vIDTO.ChasisNo = invDTO.ChasisNo;
                    vIDTO.VehicleModelName = invDTO.VehicleModelName;
                    vIDTO.ExShowRoomPrice = invDTO.ExShowRoomPrice;
                    vIDTO.LT_RT_OtherExp = invDTO.LT_RT_OtherExp;
                    vIDTO.InsurancePrice = invDTO.InsurancePrice;
                    vIDTO.OnRoadPrice = invDTO.OnRoadPrice;
                    vIDTO.WarrantyPrice = invDTO.WarrantyPrice;
                    vIDTO.VehicleInventoryID = vInventoryId;
                    if(invDTO.Is70PerMarginPrice)
                    {
                        vIDTO.MarginPrice = invDTO.Margin70;
                    }
                    if(invDTO.Is50PerMarginPrice)
                    {
                        vIDTO.MarginPrice = invDTO.Margin50;
                    }
                    Invoicedto.VehicleInventory = vIDTO;
                }

                //Get SpareParts Allotment Details
                var sPAltList = spABL.GetSparePartsAllotmentbyBookingId(VehicleBookingId);
                if(sPAltList.Count > 0)
                {
                    foreach (var sp in sPAltList)
                    {
                        var spIDTO = new SparePartsInventoryDTO();
                        if (sp.SparePartsInventoryID != 0)
                        {
                            var spI = spInventory.GetSparePartsInventory(sp.SparePartsInventoryID);
                            //SpareParts Inventory
                            SparePartsInventoryDTO spidto = new SparePartsInventoryDTO();
                            spidto.SparePartsInventoryID = sp.SparePartsInventoryID;
                            spidto.ShowRoomPrice = spI.ShowRoomPrice;
                            spidto.MarginPrice = spI.MarginPrice;
                            spidto.SparePartsModelName = spI.SparePartsModelName;
                            spidto.SparePartsInfoID = spI.SparePartsInfoID;
                            spInvDTOlist.Add(spidto);
                        }
                    }
                    Invoicedto.lstSparePartsInventory = spInvDTOlist;
                }

                //Finance Allotment

                if (vehicleBooking.FinanceAllotmentId != null && vehicleBooking.FinanceAllotmentId != 0)
                {
                    fDTO = fABL.GetFinanceAllotment(vehicleBooking.FinanceAllotmentId ?? 0);
                    Invoicedto.FinanceAllotment = fDTO;
                }

              

            }
            

            return Invoicedto;
        }

        public bool  SaveInvoiceMargin(List<InvoiceMarginDTO> lstInvMargin, int vehicleBookingId)
        {
            var flag = false;
            using (var entities = new ManiMotorsEntities1())
            {
                try
                {
                    //Delete and Add Again
                    entities.InvoiceMargins.RemoveRange(entities.InvoiceMargins.Where(x => x.VehicleBookingID == vehicleBookingId));
                    entities.SaveChanges();
                    foreach (var lstInv in lstInvMargin)
                    {
                        InvoiceMargin mg = new InvoiceMargin()
                        {
                            InvoiceID = lstInv.InvoiceID,
                            InvoiceType = lstInv.InvoiceType,
                            VehicleBookingID = vehicleBookingId,
                            MarginTypeID = lstInv.MarginTypeID,
                            MarginID = lstInv.MarginID,
                            MarginAmount = lstInv.MarginAmount,
                            ActualAmount = lstInv.ActualAmount,
                            ManualAmount = lstInv.ManualAmount,
                            Remarks = lstInv.Remarks,
                            IsReceived = lstInv.IsReceived,
                            ReceivedDate = lstInv.ReceivedDate,
                            IsCash = lstInv.IsCash,
                            ChequeOrBankTranNo = lstInv.ChequeBankTranNo,
                            Createdby = lstInv.CreatedBy,
                            CreatedDate = lstInv.CreatedDate,
                            Modifiedby = lstInv.ModifiedBy,
                            ModifiedDate = lstInv.ModifiedDate,
                            InvoiceDate = lstInv.InvoiceDate
                        };
                        entities.InvoiceMargins.Add(mg);
                    }
                    entities.SaveChanges();
                    flag = true;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
               
            }
            return flag;
        }

        public bool UpdateInvoiceMargin(List<InvoiceMarginDTO> lstInvMargin)
        {
            var flag = false;
            using (var entities = new ManiMotorsEntities1())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        foreach (var lstInv in lstInvMargin)
                        {
                            var margins = entities.InvoiceMargins.Where(x => x.VehicleBookingID == lstInv.VehicleBookingID && x.MarginTypeID == lstInv.MarginTypeID);
                            foreach (var margin in margins)
                            {
                                margin.ManualAmount = lstInv.ManualAmount;
                                margin.IsReceived = lstInv.IsReceived;
                                margin.ReceivedDate = lstInv.ReceivedDate;
                                margin.IsCash = lstInv.IsCash;
                                margin.ChequeOrBankTranNo = lstInv.ChequeBankTranNo;
                                margin.Remarks = lstInv.Remarks;
                                margin.InvoiceDate = lstInv.InvoiceDate;
                                margin.IAInvoiceDate = lstInv.IAInvoiceDate;
                                margin.Modifiedby = GlobalSetup.Userid;
                                margin.ModifiedDate = DateTime.Now;
                                entities.SaveChanges();
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
                flag = true;
            }
            return flag;
        }

        public int NextInvoiceID()
        {
            int marginid = 0;
            using (var entities = new ManiMotorsEntities1())
            {
                if (entities.InvoiceMargins.Any())
                {
                    var invm = entities.InvoiceMargins.OrderByDescending(x => x.InvoiceMarginID).FirstOrDefault();
                    marginid = invm.InvoiceID + 1;
                }
                else
                {
                    marginid = 1;
                }
            }
            return marginid;
        }

        public List<InvoiceMarginGridDTO> GetInvoiceMarginDTOList(DateTime startDate, DateTime endDate, string invoiceType)
        {
            List<InvoiceMarginGridDTO> lst = new List<InvoiceMarginGridDTO>();
            using (var entities = new ManiMotorsEntities1())
            {
                List<InvoiceMargin> marginList = new List<InvoiceMargin>();
                if(invoiceType.ToUpper() == "IA")
                {
                    marginList = entities.InvoiceMargins.Where(x => x.IAInvoiceDate >= startDate && x.IAInvoiceDate <= endDate).ToList().OrderBy(x => x.VehicleBookingID).ToList();
                }
                else if(invoiceType.ToUpper() == "MANIMOTORS")
                {
                    marginList = entities.InvoiceMargins.Where(x => x.InvoiceDate >= startDate && x.InvoiceDate <= endDate).ToList().OrderBy(x => x.VehicleBookingID).ToList();
                }
                 
                if (marginList != null && marginList.Count > 0)
                {
                    //lst.GroupBy(x => x.VehicleBookingID).Select(y => y.First()).ToList();
                    var distintmarginLst = marginList.GroupBy(x => x.VehicleBookingID).Select(y => y.First()).ToList();

                    foreach (var marginlist in distintmarginLst)
                    {
                        var bookingId = marginlist.VehicleBookingID;
                        //Invoice Margin Grid DTO for each booking
                        InvoiceMarginGridDTO gDTO = new InvoiceMarginGridDTO();

                        //Get VehicleDetails
                        var IAMargin = marginList.Where(x => x.MarginTypeID == 1 && x.VehicleBookingID == bookingId).FirstOrDefault();
                        if (IAMargin != null)
                        {
                            var vehicleInventoryId = IAMargin.MarginID;
                            VehicleInventoryBL vBL = new VehicleInventoryBL();
                            //Get Inventory Details
                            var vDTO = vBL.GetVehicleInventory(vehicleInventoryId ?? 0);
                            gDTO.VehicleBookingId = bookingId;
                            gDTO.InvoiceDate = IAMargin.InvoiceDate;
                            gDTO.ModelName = vDTO.VehicleModelName;
                            gDTO.EngineNo = vDTO.EngineNo;
                            gDTO.ChasisNo = vDTO.ChasisNo;
                            gDTO.ShowRoomPrice = vDTO.ExShowRoomPrice;
                            gDTO.OnRoadPrice = vDTO.OnRoadPrice;
                            gDTO.ManiMotorsInvoiceDate = IAMargin.InvoiceDate;
                            gDTO.IAInvoiceDate = IAMargin.IAInvoiceDate;
                            if (vDTO.Is50PerMarginPrice)
                            {
                                gDTO.IA40PercentMargin = vDTO.Margin50;
                                gDTO.IAMarginwithDTSDeduction = Convert.ToInt32(gDTO.IA40PercentMargin * .90);
                            }
                            else if (vDTO.Is70PerMarginPrice)
                            {
                                gDTO.IA70PercentMargin = vDTO.Margin70;
                                gDTO.IAMarginwithDTSDeduction = Convert.ToInt32(gDTO.IA70PercentMargin * .90);
                            }
                            else if (vDTO.IsMarginPrice)
                            {
                                gDTO.IA100PercentMargin = vDTO.MarginPrice;
                                gDTO.IAMarginwithDTSDeduction = Convert.ToInt32(gDTO.IA100PercentMargin * .90);
                            }
                            gDTO.IAMarginManualAmount = IAMargin.ManualAmount;
                            if (gDTO.IAMarginManualAmount != 0 && gDTO.IAMarginManualAmount != null)
                            {
                                gDTO.IAMarginwithDTSDeduction = Convert.ToInt32(gDTO.IAMarginManualAmount * .90);
                            }

                            gDTO.IAMarginReceivedByCash = IAMargin.IsCash;
                            gDTO.IAMarginByChequeorNEFTNo = IAMargin.ChequeOrBankTranNo;
                            gDTO.IAMarginReceivedDate = IAMargin.ReceivedDate;
                            gDTO.IAMarginReceived = IAMargin.IsReceived;
                            gDTO.IARemarks = IAMargin.Remarks;
                            //Get Customer Details
                            var vb = entities.VehicleBookings.FirstOrDefault(x => x.VehicleBookingID == bookingId);
                            if (vb != null)
                            {
                                CustomerBL cBL = new CustomerBL();
                                var cust = cBL.GetCustomer(vb.CustomerID);
                                if (cust != null)
                                {
                                    gDTO.CustomerName = cust.Name;
                                    gDTO.CustomerID = cust.CustomerID;
                                    gDTO.CustomerMobileNo = cust.ContactNo;
                                }
                            }

                            //Margin Calculation
                            if (gDTO.IAMarginReceivedByCash ?? false)
                            {
                                if (gDTO.IAMarginReceived ?? false)
                                {
                                    gDTO.TotalMarginReceived_Cash = gDTO.TotalMarginReceived_Cash  +(gDTO.IAMarginManualAmount == 0 || gDTO.IAMarginManualAmount == null ? gDTO.IAMarginwithDTSDeduction?? 0 : gDTO.IAMarginManualAmount ?? 0);
                                }
                            }
                            else
                            {
                                if (gDTO.IAMarginReceived ?? false)
                                {
                                    gDTO.TotalMarginReceived_ChequeorBank = gDTO.TotalMarginReceived_ChequeorBank  +(gDTO.IAMarginManualAmount == 0 || gDTO.IAMarginManualAmount == null ?  gDTO.IAMarginwithDTSDeduction ?? 0 : gDTO.IAMarginManualAmount ?? 0);
                                }
                            }

                            gDTO.TotalMarginAmount = gDTO.TotalMarginAmount + (gDTO.IAMarginManualAmount == 0 || gDTO.IAMarginManualAmount == null ? gDTO.IAMarginwithDTSDeduction ?? 0 : gDTO.IAMarginManualAmount ?? 0);
                        }
                        //Vehicle and IA Margin Complete

                        //- Get Finance Margin
                        var FAMargin = marginList.Where(x => x.MarginTypeID == 2 && x.VehicleBookingID == bookingId).FirstOrDefault();
                        if (FAMargin != null)
                        {
                            var fInfo = entities.FinanceInfoes.FirstOrDefault(x => x.FinanceInfoID == FAMargin.MarginID);
                            if (fInfo != null)
                            {
                                gDTO.FinanceBy = fInfo.Name;
                            }
                            gDTO.FinanceAmount = FAMargin.ActualAmount;
                            gDTO.FinanceMargin = FAMargin.MarginAmount;
                            gDTO.FinanceMarginManualAmount = FAMargin.ManualAmount;
                            gDTO.FinanceMarginReceivedDate = FAMargin.ReceivedDate;
                            gDTO.FinanceMarginReceived = FAMargin.IsReceived;
                            gDTO.FinanceRemarks = FAMargin.Remarks;
                            gDTO.FinanceMarginReceivedByCash = FAMargin.IsCash;
                            gDTO.FinanceMarginByChequeorNEFTNo = FAMargin.ChequeOrBankTranNo;

                            //Margin Calculation
                            if (gDTO.FinanceMarginReceivedByCash ?? false)
                            {
                                if (gDTO.FinanceMarginReceived ?? false)
                                {
                                    gDTO.TotalMarginReceived_Cash = gDTO.TotalMarginReceived_Cash + (gDTO.FinanceMarginManualAmount == 0 || gDTO.FinanceMarginManualAmount == null ? gDTO.FinanceMargin ?? 0 : gDTO.FinanceMarginManualAmount ?? 0);
                                }
                            }
                            else
                            {
                                if (gDTO.FinanceMarginReceived ?? false)
                                {
                                    gDTO.TotalMarginReceived_ChequeorBank = gDTO.TotalMarginReceived_ChequeorBank + (gDTO.FinanceMarginManualAmount == 0 || gDTO.FinanceMarginManualAmount == null ? gDTO.FinanceMargin ?? 0 : gDTO.FinanceMarginManualAmount ?? 0);
                                }
                            }

                            gDTO.TotalMarginAmount = gDTO.TotalMarginAmount + (gDTO.FinanceMarginManualAmount == 0 || gDTO.FinanceMarginManualAmount == null ? gDTO.FinanceMargin ?? 0 : gDTO.FinanceMarginManualAmount ?? 0);

                        }

                        //Get Extra Fittings Margin
                        var EFMargin = marginList.Where(x => x.MarginTypeID == 4 && x.VehicleBookingID == bookingId).ToList();
                        if (EFMargin != null && EFMargin.Count > 0)
                        {
                            int totalActualAmount = EFMargin.Sum(x => x.ActualAmount) ?? 0;
                            int totalMarginAmount = EFMargin.Sum(x => x.MarginAmount) ?? 0;
                            int totalManualAmount = EFMargin.FirstOrDefault().ManualAmount ?? 0;
                            gDTO.ExtraFittingsTotalActualAmount = totalActualAmount;
                            gDTO.ExtraFittingsTotalMarginAmount = totalMarginAmount;
                            gDTO.ExtraFittingsManualMarginAmount = totalManualAmount;
                            gDTO.ExtraFittingsRemarks = EFMargin.FirstOrDefault().Remarks;
                            gDTO.ExtraFittingsReceivedDate = EFMargin.FirstOrDefault().ReceivedDate;
                            gDTO.ExtraFittingsReceived = EFMargin.FirstOrDefault().IsReceived;
                            gDTO.ExtraFittingsReceivedByCash = EFMargin.FirstOrDefault().IsCash;
                            gDTO.ExtraFittingsMarginByChequeorNEFTNo = EFMargin.FirstOrDefault().ChequeOrBankTranNo;

                            //Margin Calculation
                            if (gDTO.ExtraFittingsReceivedByCash ?? false)
                            {
                                if (gDTO.ExtraFittingsReceived ?? false)
                                {
                                    gDTO.TotalMarginReceived_Cash = gDTO.TotalMarginReceived_Cash + (gDTO.ExtraFittingsManualMarginAmount == 0 || gDTO.ExtraFittingsManualMarginAmount == null ? gDTO.ExtraFittingsTotalActualAmount ?? 0 : gDTO.ExtraFittingsManualMarginAmount ?? 0);
                                }
                            }
                            else
                            {
                                if (gDTO.ExtraFittingsReceived ?? false)
                                {
                                    gDTO.TotalMarginReceived_ChequeorBank = gDTO.TotalMarginReceived_ChequeorBank + (gDTO.ExtraFittingsManualMarginAmount == 0 || gDTO.ExtraFittingsManualMarginAmount == null ? gDTO.ExtraFittingsTotalActualAmount ?? 0 : gDTO.ExtraFittingsManualMarginAmount ?? 0);
                                }
                            }

                            gDTO.TotalMarginAmount = gDTO.TotalMarginAmount + (gDTO.ExtraFittingsManualMarginAmount == 0 || gDTO.ExtraFittingsManualMarginAmount == null ? gDTO.ExtraFittingsTotalMarginAmount ?? 0 : gDTO.ExtraFittingsManualMarginAmount ?? 0);
                            gDTO.ExtraFittingsActualMarginAmount = (gDTO.ExtraFittingsManualMarginAmount == 0 || gDTO.ExtraFittingsManualMarginAmount == null ? gDTO.ExtraFittingsTotalMarginAmount ?? 0 : gDTO.ExtraFittingsManualMarginAmount ?? 0);
                        }

                        //Get Warranty Margin

                        var wMargin = marginList.Where(x => x.MarginTypeID == 3 && x.VehicleBookingID == bookingId).FirstOrDefault();
                        if (wMargin != null)
                        {
                            gDTO.WarrantyPrice = wMargin.ActualAmount;
                            gDTO.WarrantyMarginPrice = wMargin.MarginAmount;
                            gDTO.WarrantyMarginReceivedByCash = wMargin.IsCash;
                            gDTO.WarrantyMarginByChequeorNEFTNo = wMargin.ChequeOrBankTranNo;
                            gDTO.WarrantyMarginReceivedDate = wMargin.ReceivedDate;
                            gDTO.WarrantyMarginManualAmount = wMargin.ManualAmount;
                            if (wMargin.ManualAmount != null && wMargin.ManualAmount != 0)
                            {
                                gDTO.WarrantyMarginwithDTSDeduction = Convert.ToInt32(wMargin.ManualAmount * 0.9);
                            }
                            else
                            {
                                gDTO.WarrantyMarginwithDTSDeduction = Convert.ToInt32(wMargin.MarginAmount * 0.9);
                            }
                            gDTO.WarrantyMarginRemarks = wMargin.Remarks;
                            gDTO.WarrantyMarginReceived = wMargin.IsReceived;

                            //Margin Calculation
                            if (gDTO.WarrantyMarginReceivedByCash)
                            {
                                if (gDTO.WarrantyMarginReceived ?? false)
                                {
                                    gDTO.TotalMarginReceived_Cash = gDTO.TotalMarginReceived_Cash + (gDTO.WarrantyMarginManualAmount == 0 || gDTO.WarrantyMarginManualAmount == null ? gDTO.WarrantyMarginwithDTSDeduction ?? 0 : gDTO.WarrantyMarginManualAmount ?? 0);
                                }
                            }
                            else
                            {
                                if (gDTO.WarrantyMarginReceived ?? false)
                                {
                                    gDTO.TotalMarginReceived_ChequeorBank = gDTO.TotalMarginReceived_ChequeorBank + (gDTO.WarrantyMarginManualAmount == 0 || gDTO.WarrantyMarginManualAmount == null ? gDTO.WarrantyMarginwithDTSDeduction ?? 0 : gDTO.WarrantyMarginManualAmount ?? 0);
                                }
                            }

                            gDTO.TotalMarginAmount = gDTO.TotalMarginAmount+ (gDTO.WarrantyMarginManualAmount == 0 || gDTO.WarrantyMarginManualAmount == null ? gDTO.WarrantyMarginwithDTSDeduction ?? 0 : gDTO.WarrantyMarginManualAmount ?? 0);
                        }
                        //Get Discount Margin
                        var dMargin = marginList.Where(x => x.MarginTypeID == 5 && x.VehicleBookingID == bookingId).FirstOrDefault();
                        if (dMargin != null)
                        {
                            gDTO.DiscountGiven = dMargin.MarginAmount;
                            gDTO.DiscountRemarks = dMargin.Remarks;
                            
                        }
                        gDTO.NetProfit = (gDTO.TotalMarginAmount + Convert.ToInt32(gDTO.DiscountGiven ?? 0));
                        gDTO.TotalMarginReceived_Cash = gDTO.TotalMarginReceived_Cash  +Convert.ToInt32(gDTO.DiscountGiven ?? 0);
                        gDTO.TotalMarginPending = Convert.ToInt32((gDTO.TotalMarginAmount - (gDTO.TotalMarginReceived_Cash + gDTO.TotalMarginReceived_ChequeorBank))) + Convert.ToInt32(gDTO.DiscountGiven ?? 0);
                        gDTO.TotalAmountWithExtraFittings = Convert.ToInt32((gDTO.NetProfit - gDTO.ExtraFittingsActualMarginAmount)) + Convert.ToInt32(gDTO.ExtraFittingsTotalActualAmount ?? 0);
                        lst.Add(gDTO);
                    }
                }
            }
            return lst;
        }

        public InvoiceMarginGridDTO GetInvoiceMarginDTO(int vehicleBookingId)
        {
            InvoiceMarginGridDTO dto = new InvoiceMarginGridDTO();
            using (var entities = new ManiMotorsEntities1())
            {
                var marginList = entities.InvoiceMargins.Where(x => x.VehicleBookingID == vehicleBookingId).ToList();
                if (marginList != null && marginList.Count > 0)
                {
                    var distintmarginLst = marginList.GroupBy(x => x.VehicleBookingID).Select(y => y.First()).FirstOrDefault();

                    //foreach (var marginlist in distintmarginLst)
                    {
                        var bookingId = distintmarginLst.VehicleBookingID;
                        //Invoice Margin Grid DTO for each booking
                        InvoiceMarginGridDTO gDTO = new InvoiceMarginGridDTO();

                        //Get VehicleDetails
                        var IAMargin = marginList.Where(x => x.MarginTypeID == 1 && x.VehicleBookingID == bookingId).FirstOrDefault();
                        if (IAMargin != null)
                        {
                            var vehicleInventoryId = IAMargin.MarginID;
                            VehicleInventoryBL vBL = new VehicleInventoryBL();
                            //Get Inventory Details
                            var vDTO = vBL.GetVehicleInventory(vehicleInventoryId ?? 0);
                            gDTO.VehicleBookingId = bookingId;
                            gDTO.InvoiceDate = IAMargin.InvoiceDate;
                            gDTO.ModelName = vDTO.VehicleModelName;
                            gDTO.EngineNo = vDTO.EngineNo;
                            gDTO.ChasisNo = vDTO.ChasisNo;
                            gDTO.ShowRoomPrice = vDTO.ExShowRoomPrice;
                            gDTO.OnRoadPrice = vDTO.OnRoadPrice;
                            gDTO.ManiMotorsInvoiceDate = IAMargin.InvoiceDate;
                            gDTO.IAInvoiceDate = IAMargin.IAInvoiceDate;
                            if (vDTO.Is50PerMarginPrice)
                            {
                                gDTO.IA40PercentMargin = vDTO.Margin50;
                                gDTO.IAMarginwithDTSDeduction = Convert.ToInt32(gDTO.IA40PercentMargin * .90);
                            }
                            else if (vDTO.Is70PerMarginPrice)
                            {
                                gDTO.IA70PercentMargin = vDTO.Margin70;
                                gDTO.IAMarginwithDTSDeduction = Convert.ToInt32(gDTO.IA70PercentMargin * .90);
                            }
                            else if (vDTO.IsMarginPrice)
                            {
                                gDTO.IA100PercentMargin = vDTO.MarginPrice;
                                gDTO.IAMarginwithDTSDeduction = Convert.ToInt32(gDTO.IA100PercentMargin * .90);
                            }
                            gDTO.IAMarginManualAmount = IAMargin.ManualAmount;
                            if (gDTO.IAMarginManualAmount != 0 && gDTO.IAMarginManualAmount != null)
                            {
                                gDTO.IAMarginwithDTSDeduction = Convert.ToInt32(gDTO.IAMarginManualAmount * .90);
                            }

                            gDTO.IAMarginReceivedByCash = IAMargin.IsCash;
                            gDTO.IAMarginByChequeorNEFTNo = IAMargin.ChequeOrBankTranNo;
                            gDTO.IAMarginReceivedDate = IAMargin.ReceivedDate;
                            gDTO.IAMarginReceived = IAMargin.IsReceived;
                            gDTO.IARemarks = IAMargin.Remarks;
                            //Get Customer Details
                            var vb = entities.VehicleBookings.FirstOrDefault(x => x.VehicleBookingID == bookingId);
                            if (vb != null)
                            {
                                CustomerBL cBL = new CustomerBL();
                                var cust = cBL.GetCustomer(vb.CustomerID);
                                if (cust != null)
                                {
                                    gDTO.CustomerName = cust.Name;
                                    gDTO.CustomerID = cust.CustomerID;
                                    gDTO.CustomerMobileNo = cust.ContactNo;
                                }
                            }
                        }
                        //Vehicle and IA Margin Complete

                        //- Get Finance Margin
                        var FAMargin = marginList.Where(x => x.MarginTypeID == 2 && x.VehicleBookingID == bookingId).FirstOrDefault();
                        if (FAMargin != null)
                        {
                            var fInfo = entities.FinanceInfoes.FirstOrDefault(x => x.FinanceInfoID == FAMargin.MarginID);
                            if (fInfo != null)
                            {
                                gDTO.FinanceBy = fInfo.Name;
                            }
                            gDTO.FinanceAmount = FAMargin.ActualAmount;
                            gDTO.FinanceMargin = FAMargin.MarginAmount;
                            gDTO.FinanceMarginManualAmount = FAMargin.ManualAmount;
                            gDTO.FinanceMarginReceivedDate = FAMargin.ReceivedDate;
                            gDTO.FinanceMarginReceived = FAMargin.IsReceived;
                            gDTO.FinanceRemarks = FAMargin.Remarks;
                            gDTO.FinanceMarginReceivedByCash = FAMargin.IsCash;
                            gDTO.FinanceMarginByChequeorNEFTNo = FAMargin.ChequeOrBankTranNo;
                        }

                        //Get Extra Fittings Margin
                        var EFMargin = marginList.Where(x => x.MarginTypeID == 4 && x.VehicleBookingID == bookingId).ToList();
                        if (EFMargin != null && EFMargin.Count > 0)
                        {
                            int totalActualAmount = EFMargin.Sum(x => x.ActualAmount) ?? 0;
                            int totalMarginAmount = EFMargin.Sum(x => x.MarginAmount) ?? 0;
                            int totalManualAmount = EFMargin.FirstOrDefault().ManualAmount ?? 0;
                            gDTO.ExtraFittingsTotalActualAmount = totalActualAmount;
                            gDTO.ExtraFittingsTotalMarginAmount = totalMarginAmount;
                            gDTO.ExtraFittingsManualMarginAmount = totalManualAmount;
                            gDTO.ExtraFittingsRemarks = EFMargin.FirstOrDefault().Remarks;
                            gDTO.ExtraFittingsReceivedDate = EFMargin.FirstOrDefault().ReceivedDate;
                            gDTO.ExtraFittingsReceived = EFMargin.FirstOrDefault().IsReceived;
                            gDTO.ExtraFittingsReceivedByCash = EFMargin.FirstOrDefault().IsCash;
                            gDTO.ExtraFittingsMarginByChequeorNEFTNo = EFMargin.FirstOrDefault().ChequeOrBankTranNo;
                        }

                        //Get Warranty Margin

                        var wMargin = marginList.Where(x => x.MarginTypeID == 3 && x.VehicleBookingID == bookingId).FirstOrDefault();
                        if (wMargin != null)
                        {
                            gDTO.WarrantyPrice = wMargin.ActualAmount;
                            gDTO.WarrantyMarginPrice = wMargin.MarginAmount;
                            gDTO.WarrantyMarginReceivedByCash = wMargin.IsCash;
                            gDTO.WarrantyMarginByChequeorNEFTNo = wMargin.ChequeOrBankTranNo;
                            gDTO.WarrantyMarginReceivedDate = wMargin.ReceivedDate;
                            gDTO.WarrantyMarginManualAmount = wMargin.ManualAmount;
                            if (wMargin.ManualAmount != null && wMargin.ManualAmount != 0)
                            {
                                gDTO.WarrantyMarginwithDTSDeduction = Convert.ToInt32(wMargin.ManualAmount * 0.9);
                            }
                            else
                            {
                                gDTO.WarrantyMarginwithDTSDeduction = Convert.ToInt32(wMargin.MarginAmount * 0.9);
                            }
                            gDTO.WarrantyMarginRemarks = wMargin.Remarks;
                            gDTO.WarrantyMarginReceived = wMargin.IsReceived;
                        }
                        //Get Discount Margin
                        var dMargin = marginList.Where(x => x.MarginTypeID == 5 && x.VehicleBookingID == bookingId).FirstOrDefault();
                        if (dMargin != null)
                        {
                            gDTO.DiscountGiven = dMargin.MarginAmount;
                            gDTO.DiscountRemarks = dMargin.Remarks;
                        }
                        dto = gDTO;
                    }
                }
            }
            return dto;
        }

        public int InvoiceMarginGenerated()
        {
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            int InvoiceMarginGeneated = 0;
            using (var entities = new ManiMotorsEntities1())
            {
                InvoiceMarginGeneated = (from im in entities.InvoiceMargins
                                         join vb in entities.VehicleBookings on im.VehicleBookingID equals vb.VehicleBookingID
                                         where vb.CommittedDate >= startDate && vb.StatusID == 5 && im.MarginTypeID == 1
                                         select new { }
                                         ).Count();
            }
            return InvoiceMarginGeneated;
        }

        public int InvoiceMarginPending()
        {
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            int InvoiceMarginGeneated = 0;
            using (var entities = new ManiMotorsEntities1())
            {
                var InvoiceMarginGeneatedt = (from
                                         vb in entities.VehicleBookings                                       
                                         join im in entities.InvoiceMargins on vb.VehicleBookingID equals im.VehicleBookingID into im1
                                         from im1Info in im1.DefaultIfEmpty()
                                         where vb.CommittedDate >= startDate && vb.StatusID == 5 && im1Info.VehicleBookingID.Equals(null)
                                         select new { }
                                         );
                InvoiceMarginGeneated = InvoiceMarginGeneatedt.Count();
            }
            return InvoiceMarginGeneated;
        }

    }
}
