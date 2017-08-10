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
                        ModifiedDate = lstInv.ModifiedDate
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
    }
}
