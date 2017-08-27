using MessageBoxExample;
using MM.BusinessLayer.Admin;
using MM.Model.Admin;
using MM.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManiMotors.Vehicle
{
    public partial class InvoiceForm : Form
    {
        private int _vehicleBookingId;
        private List<InvoiceMarginDTO> lst = new List<InvoiceMarginDTO>();
        private int _invoiceId;
        public InvoiceForm(int VehicleBookingId)
        {
            InitializeComponent();
            _vehicleBookingId = VehicleBookingId;
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
        }

        private void LoadDefaultValues()
        {
            InvoiceBL iBL = new InvoiceBL();
            _invoiceId = iBL.NextInvoiceID();
            var invDTO = iBL.GetInvoiceDetails(_vehicleBookingId);
            //Customer
            if (invDTO.Customer != null)
            {
                lblCustomerName.Text = invDTO.Customer.Name;
            }
            //VehicleInventory
            if(invDTO.VehicleInventory != null)
            {
                var vInvDTO = invDTO.VehicleInventory;
                lblEngineNo.Text = vInvDTO.EngineNo;
                lblChasisNo.Text = vInvDTO.ChasisNo;
                lblVehicleName.Text = vInvDTO.VehicleModelName;
                lblEXshowroomprice.Text = vInvDTO.ExShowRoomPrice.ToString();
                lblLTRT.Text = vInvDTO.LT_RT_OtherExp.ToString();
                lblInsurance.Text = vInvDTO.InsurancePrice.ToString();
                lblTotalOnRoadPrice.Text = vInvDTO.OnRoadPrice.ToString();
                lblWarranty.Text = vInvDTO.WarrantyPrice.ToString();
                var warrantymargin555 = ConfigurationManager.AppSettings["WarrantyMargin555"].ToString();
                var warrantymargin777 = ConfigurationManager.AppSettings["WarrantyMargin777"].ToString();
                invMargin.Text = vInvDTO.MarginPrice.ToString();
                //Add IA Margin
                var IAMgnDTO = new InvoiceMarginDTO()
                {
                    InvoiceID = _invoiceId,
                    InvoiceType = "SALES",
                    VehicleBookingID = _vehicleBookingId,
                    MarginTypeID = 1,//For IA Margin
                    MarginID = vInvDTO.VehicleInventoryID,
                    ManualAmount = 0,
                    MarginAmount = vInvDTO.MarginPrice,
                    ActualAmount = vInvDTO.ExShowRoomPrice,
                    IsReceived = false,
                    ReceivedDate = null,
                    IsCash = false,
                    ChequeBankTranNo = "",
                    Remarks = "",
                    CreatedDate = DateTime.Now,
                    CreatedBy = GlobalSetup.Userid,
                    ModifiedBy = null,
                    ModifiedDate = null
                    , InvoiceDate = Convert.ToDateTime(dtInvoice.Text)
                };
                lst.Add(IAMgnDTO);

                if (vInvDTO.WarrantyPrice == 555)
                {
                    lblWarrantyMargin.Text = warrantymargin555;
                    int m555 = Convert.ToInt32(warrantymargin555);
                    //Add Warranty Margin
                    var marginW555 = new InvoiceMarginDTO()
                    {
                        InvoiceID = _invoiceId,
                        InvoiceType = "SALES",
                        VehicleBookingID = _vehicleBookingId,
                        MarginTypeID = 3,//For warranty
                        MarginID = vInvDTO.VehicleInventoryID,
                        ManualAmount = 0,
                        MarginAmount = m555,
                        ActualAmount = vInvDTO.WarrantyPrice,
                        IsReceived = false,
                        ReceivedDate = null,
                        IsCash = false,
                        ChequeBankTranNo = "",
                        Remarks = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = GlobalSetup.Userid,
                        ModifiedBy = null,
                        ModifiedDate = null
                        ,
                        InvoiceDate = Convert.ToDateTime(dtInvoice.Text)
                    };
                    lst.Add(marginW555);
                }
                else if(vInvDTO.WarrantyPrice == 777)
                {
                    lblWarrantyMargin.Text = warrantymargin777;
                    int m777 = Convert.ToInt32(warrantymargin777);
                    //Add Warranty Margin
                    var marginW555 = new InvoiceMarginDTO()
                    {
                        InvoiceID = _invoiceId,
                        InvoiceType = "SALES",
                        VehicleBookingID = _vehicleBookingId,
                        MarginID = vInvDTO.VehicleInventoryID,
                        MarginTypeID = 3,//For warranty
                        ManualAmount = 0,
                        MarginAmount = m777,
                        ActualAmount = vInvDTO.WarrantyPrice,
                        IsReceived = false,
                        ReceivedDate = null,
                        IsCash = false,
                        ChequeBankTranNo = "",
                        Remarks = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = GlobalSetup.Userid,
                        ModifiedBy = null,
                        ModifiedDate = null,
                        InvoiceDate = Convert.ToDateTime(dtInvoice.Text)
                    };
                    lst.Add(marginW555);
                }
                else
                {
                    lblWarrantyMargin.Text = "0";
                }
                
                totalDebitVal.Text = (vInvDTO.OnRoadPrice).ToString();
            }

            //SparePartsInventory
            if (invDTO.lstSparePartsInventory != null && invDTO.lstSparePartsInventory.Count > 0)
            {
                int i = 1;
                foreach (var spInventory in invDTO.lstSparePartsInventory)
                {
                    if (i == 1)
                    {
                        lblFitting1.Visible = true;
                        lblFitting1Value.Visible = true;
                        lblFitting1.Text = spInventory.SparePartsModelName.ToUpper();
                        lblFitting1Value.Text = spInventory.ShowRoomPrice.ToString();
                        fMargin1.Visible = true;
                        fMargin1.Text = spInventory.MarginPrice.ToString();
                        var totalPrice = Convert.ToInt32(totalDebitVal.Text);
                        totalDebitVal.Text = (totalPrice + spInventory.ShowRoomPrice).ToString();

                        //Add SP Margin
                        var sp = new InvoiceMarginDTO()
                        {
                            InvoiceID = _invoiceId,
                            InvoiceType = "SALES",
                            VehicleBookingID = _vehicleBookingId,
                            MarginTypeID = 4,//For Extra Fitting
                            ManualAmount = 0,
                            MarginID = spInventory.SparePartsInventoryID,
                            MarginAmount = spInventory.MarginPrice,
                            ActualAmount = spInventory.ShowRoomPrice,
                            IsReceived = false,
                            ReceivedDate = null,
                            IsCash = false,
                            ChequeBankTranNo = "",
                            Remarks = "",
                            CreatedDate = DateTime.Now,
                            CreatedBy = GlobalSetup.Userid,
                            ModifiedBy = null,
                            ModifiedDate = null,
                            InvoiceDate = Convert.ToDateTime(dtInvoice.Text)
                        };
                        lst.Add(sp);

                    }
                    else if (i == 2)
                    {
                        lblFitting2.Visible = true;
                        lblFitting2Val.Visible = true;
                        lblFitting2.Text = spInventory.SparePartsModelName.ToUpper();
                        lblFitting2Val.Text = spInventory.ShowRoomPrice.ToString();
                        fMargin2.Text = spInventory.MarginPrice.ToString();
                        var totalPrice = Convert.ToInt32(totalDebitVal.Text);
                        totalDebitVal.Text = (totalPrice + spInventory.ShowRoomPrice).ToString();
                        fMargin2.Visible = true;

                        //Add SP Margin
                        var sp = new InvoiceMarginDTO()
                        {
                            InvoiceID = _invoiceId,
                            InvoiceType = "SALES",
                            VehicleBookingID = _vehicleBookingId,
                            MarginTypeID = 4,//For Extra Fitting
                            ManualAmount = 0,
                            MarginID = spInventory.SparePartsInventoryID,
                            MarginAmount = spInventory.MarginPrice,
                            ActualAmount = spInventory.ShowRoomPrice,
                            IsReceived = false,
                            ReceivedDate = null,
                            IsCash = false,
                            ChequeBankTranNo = "",
                            Remarks = "",
                            CreatedDate = DateTime.Now,
                            CreatedBy = GlobalSetup.Userid,
                            ModifiedBy = null,
                            ModifiedDate = null,
                            InvoiceDate = Convert.ToDateTime(dtInvoice.Text)
                        };
                        lst.Add(sp);
                    }
                    else if (i == 3)
                    {
                        lblFitting3.Visible = true;
                        lblFitting3Val.Visible = true;
                        lblFitting3.Text = spInventory.SparePartsModelName.ToUpper();
                        lblFitting3Val.Text = spInventory.ShowRoomPrice.ToString();
                        fMargin3.Text = spInventory.MarginPrice.ToString();
                        var totalPrice = Convert.ToInt32(totalDebitVal.Text);
                        totalDebitVal.Text = (totalPrice + spInventory.ShowRoomPrice).ToString();
                        fMargin3.Visible = true;

                        //Add SP Margin
                        var sp = new InvoiceMarginDTO()
                        {
                            InvoiceID = _invoiceId,
                            InvoiceType = "SALES",
                            VehicleBookingID = _vehicleBookingId,
                            MarginTypeID = 4,//For Extra Fitting
                            ManualAmount = 0,
                            MarginID = spInventory.SparePartsInventoryID,
                            MarginAmount = spInventory.MarginPrice,
                            ActualAmount = spInventory.ShowRoomPrice,
                            IsReceived = false,
                            ReceivedDate = null,
                            IsCash = false,
                            ChequeBankTranNo = "",
                            Remarks = "",
                            CreatedDate = DateTime.Now,
                            CreatedBy = GlobalSetup.Userid,
                            ModifiedBy = null,
                            ModifiedDate = null,
                            InvoiceDate = Convert.ToDateTime(dtInvoice.Text)
                        };
                        lst.Add(sp);
                    }
                    else if (i == 4)
                    {
                        lblFitting4.Visible = true;
                        lblFitting4Val.Visible = true;
                        lblFitting4.Text = spInventory.SparePartsModelName.ToUpper();
                        lblFitting4Val.Text = spInventory.ShowRoomPrice.ToString();
                        fMargin4.Text = spInventory.MarginPrice.ToString();
                        var totalPrice = Convert.ToInt32(totalDebitVal.Text);
                        totalDebitVal.Text = (totalPrice + spInventory.ShowRoomPrice).ToString();
                        fMargin4.Visible = true;

                        //Add SP Margin
                        var sp = new InvoiceMarginDTO()
                        {
                            InvoiceID = _invoiceId,
                            InvoiceType = "SALES",
                            VehicleBookingID = _vehicleBookingId,
                            MarginTypeID = 4,//For Extra Fitting
                            ManualAmount = 0,
                            MarginID = spInventory.SparePartsInventoryID,
                            MarginAmount = spInventory.MarginPrice,
                            ActualAmount = spInventory.ShowRoomPrice,
                            IsReceived = false,
                            ReceivedDate = null,
                            IsCash = false,
                            ChequeBankTranNo = "",
                            Remarks = "",
                            CreatedDate = DateTime.Now,
                            CreatedBy = GlobalSetup.Userid,
                            ModifiedBy = null,
                            ModifiedDate = null,
                            InvoiceDate = Convert.ToDateTime(dtInvoice.Text)
                        };
                        lst.Add(sp);
                    }
                    else if (i == 5)
                    {
                        lblFitting5.Visible = true;
                        lblFitting5Val.Visible = true;
                        lblFitting5.Text = spInventory.SparePartsModelName.ToUpper();
                        lblFitting5Val.Text = spInventory.ShowRoomPrice.ToString();
                        fMargin5.Text = spInventory.MarginPrice.ToString();
                        var totalPrice = Convert.ToInt32(totalDebitVal.Text);
                        totalDebitVal.Text = (totalPrice + spInventory.ShowRoomPrice).ToString();
                        fMargin5.Visible = true;

                        //Add SP Margin
                        var sp = new InvoiceMarginDTO()
                        {
                            InvoiceID = _invoiceId,
                            InvoiceType = "SALES",
                            VehicleBookingID = _vehicleBookingId,
                            MarginTypeID = 4,//For Extra Fitting
                            ManualAmount = 0,
                            MarginID = spInventory.SparePartsInventoryID,
                            MarginAmount = spInventory.MarginPrice,
                            ActualAmount = spInventory.ShowRoomPrice,
                            IsReceived = false,
                            ReceivedDate = null,
                            IsCash = false,
                            ChequeBankTranNo = "",
                            Remarks = "",
                            CreatedDate = DateTime.Now,
                            CreatedBy = GlobalSetup.Userid,
                            ModifiedBy = null,
                            ModifiedDate = null,
                            InvoiceDate = Convert.ToDateTime(dtInvoice.Text)
                        };
                        lst.Add(sp);
                    }
                    else if (i == 6)
                    {
                        lblFitting6.Visible = true;
                        lblFitting6Val.Visible = true;
                        lblFitting6.Text = spInventory.SparePartsModelName.ToUpper();
                        lblFitting6Val.Text = spInventory.ShowRoomPrice.ToString();
                        fMargin6.Text = spInventory.MarginPrice.ToString();
                        var totalPrice = Convert.ToInt32(totalDebitVal.Text);
                        totalDebitVal.Text = (totalPrice + spInventory.ShowRoomPrice).ToString();
                        fMargin6.Visible = true;

                        //Add SP Margin
                        var sp = new InvoiceMarginDTO()
                        {
                            InvoiceID = _invoiceId,
                            InvoiceType = "SALES",
                            VehicleBookingID = _vehicleBookingId,
                            MarginTypeID = 4,//For Extra Fitting
                            ManualAmount = 0,
                            MarginID = spInventory.SparePartsInventoryID,
                            MarginAmount = spInventory.MarginPrice,
                            ActualAmount = spInventory.ShowRoomPrice,
                            IsReceived = false,
                            ReceivedDate = null,
                            IsCash = false,
                            ChequeBankTranNo = "",
                            Remarks = "",
                            CreatedDate = DateTime.Now,
                            CreatedBy = GlobalSetup.Userid,
                            ModifiedBy = null,
                            ModifiedDate = null,
                            InvoiceDate = Convert.ToDateTime(dtInvoice.Text)
                        };
                        lst.Add(sp);
                    }
                    else if (i == 7)
                    {
                        lblFitting7.Visible = true;
                        lblFitting7Val.Visible = true;
                        lblFitting7.Text = spInventory.SparePartsModelName.ToUpper();
                        lblFitting7Val.Text = spInventory.ShowRoomPrice.ToString();
                        fMargin7.Text = spInventory.MarginPrice.ToString();
                        var totalPrice = Convert.ToInt32(totalDebitVal.Text);
                        totalDebitVal.Text = (totalPrice + spInventory.ShowRoomPrice).ToString();
                        fMargin7.Visible = true;

                        //Add SP Margin
                        var sp = new InvoiceMarginDTO()
                        {
                            InvoiceID = _invoiceId,
                            InvoiceType = "SALES",
                            VehicleBookingID = _vehicleBookingId,
                            MarginTypeID = 4,//For Extra Fitting
                            ManualAmount = 0,
                            MarginID = spInventory.SparePartsInventoryID,
                            MarginAmount = spInventory.MarginPrice,
                            ActualAmount = spInventory.ShowRoomPrice,
                            IsReceived = false,
                            ReceivedDate = null,
                            IsCash = false,
                            ChequeBankTranNo = "",
                            Remarks = "",
                            CreatedDate = DateTime.Now,
                            CreatedBy = GlobalSetup.Userid,
                            ModifiedBy = null,
                            ModifiedDate = null,
                            InvoiceDate = Convert.ToDateTime(dtInvoice.Text)
                        };
                        lst.Add(sp);
                    }
                    else if (i == 8)
                    {
                        lblFitting8.Visible = true;
                        lblFitting8Val.Visible = true;
                        lblFitting8.Text = spInventory.SparePartsModelName.ToUpper();
                        lblFitting8Val.Text = spInventory.ShowRoomPrice.ToString();
                        fMargin8.Text = spInventory.MarginPrice.ToString();
                        var totalPrice = Convert.ToInt32(totalDebitVal.Text);
                        totalDebitVal.Text = (totalPrice + spInventory.ShowRoomPrice).ToString();
                        fMargin8.Visible = true;

                        //Add SP Margin
                        var sp = new InvoiceMarginDTO()
                        {
                            InvoiceID = _invoiceId,
                            InvoiceType = "SALES",
                            VehicleBookingID = _vehicleBookingId,
                            MarginTypeID = 4,//For Extra Fitting
                            ManualAmount = 0,
                            MarginID = spInventory.SparePartsInventoryID,
                            MarginAmount = spInventory.MarginPrice,
                            ActualAmount = spInventory.ShowRoomPrice,
                            IsReceived = false,
                            ReceivedDate = null,
                            IsCash = false,
                            ChequeBankTranNo = "",
                            Remarks = "",
                            CreatedDate = DateTime.Now,
                            CreatedBy = GlobalSetup.Userid,
                            ModifiedBy = null,
                            ModifiedDate = null,
                            InvoiceDate = Convert.ToDateTime(dtInvoice.Text)
                        };
                        lst.Add(sp);
                    }
                    else if (i == 9)
                    {
                        lblFitting9.Visible = true;
                        lblFitting9Val.Visible = true;
                        lblFitting9.Text = spInventory.SparePartsModelName.ToUpper();
                        lblFitting9Val.Text = spInventory.ShowRoomPrice.ToString();
                        fMargin9.Text = spInventory.MarginPrice.ToString();
                        var totalPrice = Convert.ToInt32(totalDebitVal.Text);
                        totalDebitVal.Text = (totalPrice + spInventory.ShowRoomPrice).ToString();
                        fMargin9.Visible = true;
                        //Add SP Margin
                        var sp = new InvoiceMarginDTO()
                        {
                            InvoiceID = _invoiceId,
                            InvoiceType = "SALES",
                            VehicleBookingID = _vehicleBookingId,
                            MarginTypeID = 4,//For Extra Fitting
                            ManualAmount = 0,
                            MarginID = spInventory.SparePartsInventoryID,
                            MarginAmount = spInventory.MarginPrice,
                            ActualAmount = spInventory.ShowRoomPrice,
                            IsReceived = false,
                            ReceivedDate = null,
                            IsCash = false,
                            ChequeBankTranNo = "",
                            Remarks = "",
                            CreatedDate = DateTime.Now,
                            CreatedBy = GlobalSetup.Userid,
                            ModifiedBy = null,
                            ModifiedDate = null,
                            InvoiceDate = Convert.ToDateTime(dtInvoice.Text)
                        };
                        lst.Add(sp);

                    }
                    else if (i == 10)
                    {
                        lblFitting10.Visible = true;
                        lblFitting10Val.Visible = true;
                        lblFitting10.Text = spInventory.SparePartsModelName.ToUpper();
                        lblFitting10Val.Text = spInventory.ShowRoomPrice.ToString();
                        fMargin10.Text = spInventory.MarginPrice.ToString();
                        var totalPrice = Convert.ToInt32(totalDebitVal.Text);
                        totalDebitVal.Text = (totalPrice + spInventory.ShowRoomPrice).ToString();
                        fMargin10.Visible = true;

                        //Add SP Margin
                        var sp = new InvoiceMarginDTO()
                        {
                            InvoiceID = _invoiceId,
                            InvoiceType = "SALES",
                            VehicleBookingID = _vehicleBookingId,
                            MarginTypeID = 4,//For Extra Fitting
                            ManualAmount = 0,
                            MarginID = spInventory.SparePartsInventoryID,
                            MarginAmount = spInventory.MarginPrice,
                            ActualAmount = spInventory.ShowRoomPrice,
                            IsReceived = false,
                            ReceivedDate = null,
                            IsCash = false,
                            ChequeBankTranNo = "",
                            Remarks = "",
                            CreatedDate = DateTime.Now,
                            CreatedBy = GlobalSetup.Userid,
                            ModifiedBy = null,
                            ModifiedDate = null,
                            InvoiceDate = Convert.ToDateTime(dtInvoice.Text)
                        };
                        lst.Add(sp);
                    }

                    i++;
                }
            }
                //Customer Credit
                if(invDTO.VclBooking != null)
                {
                    var vBk = invDTO.VclBooking;
                    lblAdvanceCash.Text = vBk.AdvanceAmount.ToString();
                    lblFinance.Text = "Finance By -- " + vBk.FinancierName;
                    totalCreditVal.Text = vBk.AdvanceAmount.ToString();
                }

                //Finance Allotment
                if(invDTO.FinanceAllotment != null)
                {
                    var fAlt = invDTO.FinanceAllotment;
                    lblFinanceVal.Text = fAlt.FinanceAmount.ToString();
                    var totalcreditPrice = Convert.ToInt32(totalCreditVal.Text);
                    totalCreditVal.Text = (totalcreditPrice + fAlt.FinanceAmount).ToString();
                    if (invDTO.VclBooking.FinanceDealer)
                    {
                        txtFinanceMargin.Visible = true;
                        //Add Finance margin
                        var sp = new InvoiceMarginDTO()
                        {
                            InvoiceID = _invoiceId,
                            InvoiceType = "SALES",
                            VehicleBookingID = _vehicleBookingId,
                            MarginTypeID = 2,//For Finance Margin
                            ManualAmount = 0,
                            MarginID = invDTO.VclBooking.FinancierInfoId ?? 0,
                            MarginAmount = 0,  //Margin Amount wil be updated
                            ActualAmount = invDTO.FinanceAllotment.FinanceAmount ?? 0,
                            IsReceived = false,
                            ReceivedDate = null,
                            IsCash = false,
                            ChequeBankTranNo = "",
                            Remarks = "",
                            CreatedDate = DateTime.Now,
                            CreatedBy = GlobalSetup.Userid,
                            ModifiedBy = null,
                            ModifiedDate = null,
                            InvoiceDate = Convert.ToDateTime(dtInvoice.Text)
                        };
                        lst.Add(sp);
                    }

                }

                if(txtDiscount.Text != "")
                {
                    var totalcreditPrice = Convert.ToInt32(totalCreditVal.Text);
                    var discountAmt = Convert.ToInt32(txtDiscount.Text);
                    totalCreditVal.Text = (totalcreditPrice + discountAmt).ToString();

                }
            //}
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            var totalcreditPrice = Convert.ToInt32(totalCreditVal.Text);
            if (txtDiscount.Text != "")
            {
                var discountAmt = Convert.ToInt32(txtDiscount.Text);
                int prevDisAmount = 0;
                if (lblPrevDis.Text != "" && lblPrevDis.Text != "lblPrevDis")
                {
                    prevDisAmount = Convert.ToInt32(lblPrevDis.Text);
                }
                totalCreditVal.Text = ((totalcreditPrice + discountAmt) - prevDisAmount).ToString();
                lblPrevDis.Text = txtDiscount.Text;
            }
        }

        private void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            string result = MyMessageBoxYesorNo.ShowBox("Please verify the margin price for Vehicle, Extra Fittings and Customer Credit???");
            if(result == "1")
            {
                if(invMargin.Text == "0" || invMargin.Text == "")
                {
                    MyMessageBox.ShowBox("Invoice Margin Cannot be Empty!!!");
                    return;
                }
                if(lblWarrantyMargin.Text == "0" || lblWarrantyMargin.Text == "")
                {
                    MyMessageBox.ShowBox("Warranty Margin Price Cannot be Empty!!!");
                    return;
                }

                if((fMargin1.Visible && (fMargin1.Text == "0" || fMargin1.Text == "")) ||
                    (fMargin2.Visible && (fMargin2.Text == "0" || fMargin2.Text == "")) ||
                    (fMargin3.Visible && (fMargin3.Text == "0" || fMargin3.Text == "")) ||
                    (fMargin4.Visible && (fMargin4.Text == "0" || fMargin4.Text == ""))  ||
                    (fMargin5.Visible && (fMargin5.Text == "0" || fMargin5.Text == ""))  ||
                    (fMargin6.Visible && (fMargin6.Text == "0" || fMargin6.Text == ""))  ||
                    (fMargin7.Visible && (fMargin7.Text == "0" || fMargin7.Text == ""))  ||
                    (fMargin8.Visible && (fMargin8.Text == "0" || fMargin8.Text == "")) ||
                    (fMargin9.Visible && (fMargin9.Text == "0" || fMargin9.Text == ""))  ||
                    (fMargin10.Visible && (fMargin10.Text == "0" || fMargin10.Text == "")))
                {
                    MyMessageBox.ShowBox("Extra Fitting Margin Price Cannot be Empty!!!");
                    return;
                }

                if(txtDiscount.Text != "" && txtRemarks.Text == "")
                {
                    MyMessageBox.ShowBox("Discount Remarks Cannot be Empty for Discount Offer!!!");
                    return;
                }


                if (txtDiscount.Text != "")
                {
                    var discountAmt = Convert.ToInt32(txtDiscount.Text);
                    //Add Discount margin
                    var sp = new InvoiceMarginDTO()
                    {
                        InvoiceID = _invoiceId,
                        InvoiceType = "SALES",
                        VehicleBookingID = _vehicleBookingId,
                        MarginTypeID = 5,//For Discount Margin
                        ManualAmount = 0,
                        MarginID = _vehicleBookingId,
                        MarginAmount = -discountAmt,
                        ActualAmount = 0,
                        IsReceived = false,
                        ReceivedDate = null,
                        IsCash = false,
                        ChequeBankTranNo = "",
                        Remarks = txtRemarks.Text,
                        CreatedDate = DateTime.Now,
                        CreatedBy = GlobalSetup.Userid,
                        ModifiedBy = null,
                        ModifiedDate = null,
                        InvoiceDate = Convert.ToDateTime(dtInvoice.Text)
                    };
                    lst.Add(sp);
                }

                if(txtFinanceMargin.Text != "")
                {
                    var finmarginType = lst.Where(x => x.MarginTypeID == 2).FirstOrDefault();
                    finmarginType.MarginAmount = Convert.ToInt32(txtFinanceMargin.Text);
                }

                string result1 = MyMessageBoxYesorNo.ShowBox("Previously Generated Invoice will be Deleted???");
                if (result1 == "1")
                {
                    InvoiceBL bl = new InvoiceBL();
                    var flag = bl.SaveInvoiceMargin(lst, _vehicleBookingId);

                    if (flag)
                    {
                        MyMessageBox.ShowBox("Invoice Margin Created !!!");
                    }
                    else
                    {
                        MyMessageBox.ShowBox("Invoice Margin failed to create !!!");
                    }
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFinanceMargin_TextChanged(object sender, EventArgs e)
        {
            var totaldebitPrice = Convert.ToInt32(totalDebitVal.Text);
            if (txtFinanceMargin.Text != "")
            {
                var financeMarginAmt = Convert.ToInt32(txtFinanceMargin.Text);
                int prevfinAmount = 0;
                if (lblPrevFin.Text != "" && lblPrevFin.Text != "lblPrevFin")
                {
                    prevfinAmount = Convert.ToInt32(lblPrevFin.Text);
                }
                totalDebitVal.Text = ((totaldebitPrice + financeMarginAmt) - prevfinAmount).ToString();
                lblPrevFin.Text = txtFinanceMargin.Text;
            }
        }
    }
}
