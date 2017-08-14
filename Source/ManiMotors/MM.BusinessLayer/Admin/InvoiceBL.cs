using MM.BusinessLayer.Customer;
using MM.BusinessLayer.SpareParts;
using MM.BusinessLayer.Vehicle;
using MM.DataLayer;
using MM.Model.Admin;
using MM.Model.Customer;
using MM.Model.SpareParts;
using MM.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<InvoiceMargin> lst = new List<InvoiceMargin>();
            var flag = false;
            

            using (var entities = new ManiMotorsEntities1())
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

        public List<InvoiceMarginGridDTO> GetInvoiceMarginDTOList(DateTime startDate, DateTime endDate)
        {
            List<InvoiceMarginGridDTO> lst = new List<InvoiceMarginGridDTO>();
            using (var entities = new ManiMotorsEntities1())
            {
                var marginList = entities.InvoiceMargins.Where(x => x.InvoiceDate >= startDate && x.InvoiceDate <= endDate).ToList().OrderBy(x => x.VehicleBookingID).ToList();
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
                        if (EFMargin != null)
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
                        if (EFMargin != null)
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


    }
}
