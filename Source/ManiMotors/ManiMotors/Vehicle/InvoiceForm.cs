using MM.BusinessLayer.Admin;
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
                var warrantymargin = ConfigurationManager.AppSettings["WarrantyMargin"].ToString();
                invMargin.Text = vInvDTO.MarginPrice.ToString();
                lblWarrantyMargin.Text = warrantymargin;
                totalDebitVal.Text = (vInvDTO.OnRoadPrice + vInvDTO.WarrantyPrice).ToString();
            }

            //SparePartsInventory
            if(invDTO.lstSparePartsInventory.Count > 0)
            {
                int i = 1;
                foreach(var spInventory in invDTO.lstSparePartsInventory)
                {
                    if(i==1)
                    {
                        lblFitting1.Visible = true;
                        lblFitting1Value.Visible = true;
                        lblFitting1.Text = spInventory.SparePartsModelName.ToUpper();
                        lblFitting1Value.Text = spInventory.ShowRoomPrice.ToString();
                        fMargin1.Visible = true;
                        fMargin1.Text = spInventory.MarginPrice.ToString();
                        var totalPrice = Convert.ToInt32(totalDebitVal.Text);
                        totalDebitVal.Text = (totalPrice + spInventory.ShowRoomPrice).ToString();
                    }
                    else if(i==2)
                    {
                        lblFitting2.Visible = true;
                        lblFitting2Val.Visible = true;
                        lblFitting2.Text = spInventory.SparePartsModelName.ToUpper();
                        lblFitting2Val.Text = spInventory.ShowRoomPrice.ToString();
                        fMargin2.Text = spInventory.MarginPrice.ToString();
                        var totalPrice = Convert.ToInt32(totalDebitVal.Text);
                        totalDebitVal.Text = (totalPrice + spInventory.ShowRoomPrice).ToString();
                        fMargin2.Visible = true;
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
                    }

                    i++;
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
                }

                if(txtDiscount.Text != "")
                {
                    var totalcreditPrice = Convert.ToInt32(totalCreditVal.Text);
                    var discountAmt = Convert.ToInt32(txtDiscount.Text);
                    totalCreditVal.Text = (totalcreditPrice + discountAmt).ToString();
                }
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            var totalcreditPrice = Convert.ToInt32(totalCreditVal.Text);
            if (txtDiscount.Text != "")
            {
                var discountAmt = Convert.ToInt32(txtDiscount.Text);
                int prevDisAmount = 0;
                if (lblPrevDis.Text != "")
                {
                    prevDisAmount = Convert.ToInt32(lblPrevDis.Text);
                }
                totalCreditVal.Text = ((totalcreditPrice + discountAmt) - prevDisAmount).ToString();
                lblPrevDis.Text = txtDiscount.Text;
            }
        }
    }
}
