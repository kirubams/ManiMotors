using MessageBoxExample;
using MM.BusinessLayer.Admin;
using MM.Model.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManiMotors.Vehicle
{
    public partial class InvoiceMarginfrm : Form
    {
        int _vehicleBookingId;
        public InvoiceMarginfrm(int vehicleBookingId)
        {
            InitializeComponent();
            _vehicleBookingId = vehicleBookingId;
        }

        private void InvoiceMarginfrm_Load(object sender, EventArgs e)
        {
            LoadDefaultvalues();
        }

        private void LoadDefaultvalues()
        {
            int TotalMarginAmount = 0;
            int TMA_CASH = 0;
            int TMA_CASH_Received = 0;
            int TMA_BANK = 0;
            int TMA_BANK_Received = 0;
            InvoiceBL bl = new InvoiceBL();
            var _dto = bl.GetInvoiceMarginDTO(_vehicleBookingId);
            lblCustomerName.Text = _dto.CustomerName;
            lblVehicleName.Text = _dto.ModelName;
            lblChasisNo.Text = _dto.ChasisNo;
            lblEngineNo.Text = _dto.EngineNo;
            if (_dto.ManiMotorsInvoiceDate != null)
            {
                dtMMInvoiceDt.Text = _dto.ManiMotorsInvoiceDate.ToString();
            }

            if(_dto.IAInvoiceDate != null)
            {
                dtIAInvoiceDt.Text = _dto.IAInvoiceDate.ToString();
                chkIAInvoice.Checked = true;
                dtIAInvoiceDt.Enabled = true;
            }

            //Display Vehicle Margin
            lblVehicleMarginAmt.Visible = true;
            lblVehicleTotalamt.Visible = true;
            txtVehicleManualAmt.Visible = true;
            chkvehcleAR.Visible = true;
            dtVehicle.Visible = true;
            chkVehicleCash.Visible = true;
            txtVehicleCheqNo.Visible = true;
            txtVehicleRemarks.Visible = true;
            lblVehicleTDS.Visible = true;
            
            if(_dto.IA100PercentMargin != null && _dto.IA100PercentMargin != 0)
            {
                lblVehicleMarginAmt.Text = _dto.IA100PercentMargin.ToString();
            }
            else if(_dto.IA70PercentMargin != null && _dto.IA70PercentMargin != 0)
            {
                lblVehicleMarginAmt.Text = _dto.IA70PercentMargin.ToString();
            }
            else if(_dto.IA40PercentMargin != null && _dto.IA40PercentMargin != 0)
            {
                lblVehicleMarginAmt.Text = _dto.IA40PercentMargin.ToString();
            }
            if (_dto.IAMarginwithDTSDeduction != null)
            {
                lblVehicleTDS.Text = _dto.IAMarginwithDTSDeduction.ToString();
            }
            if (_dto.ShowRoomPrice != null)
            {
                lblVehicleTotalamt.Text = _dto.ShowRoomPrice.ToString();
            }
            if (_dto.IAMarginManualAmount != null)
            {
                txtVehicleManualAmt.Text = _dto.IAMarginManualAmount.ToString();
            }
            if(_dto.IAMarginReceived ?? false)
            {
                chkVehicleCash.Enabled = true;
                txtVehicleCheqNo.Enabled = true;
                chkvehcleAR.Enabled = true;
                chkvehcleAR.Checked = true;
            }

            if(_dto.IAMarginReceivedDate != null)
            {
                dtVehicle.Text = _dto.IAMarginReceivedDate.ToString();
            }

            if(_dto.IAMarginReceivedByCash ?? false)
            {
                chkVehicleCash.Checked = true;
                if (_dto.IAMarginReceived ?? false)
                {
                    TMA_CASH = TMA_CASH + +(txtVehicleManualAmt.Text == "0" || txtVehicleManualAmt.Text == "" ? Convert.ToInt32(lblVehicleTDS.Text) : Convert.ToInt32(txtVehicleManualAmt.Text));
                }
            }
            else
            {
                if (_dto.IAMarginReceived ?? false)
                {
                    TMA_BANK = TMA_BANK + +(txtVehicleManualAmt.Text == "0" || txtVehicleManualAmt.Text == "" ? Convert.ToInt32(lblVehicleTDS.Text) : Convert.ToInt32(txtVehicleManualAmt.Text));
                }
            }
            if (_dto.IAMarginByChequeorNEFTNo != null)
            {
                txtVehicleCheqNo.Text = _dto.IAMarginByChequeorNEFTNo.ToString();
            }
            txtVehicleRemarks.Text = _dto.IARemarks;
            TotalMarginAmount = TotalMarginAmount + (txtVehicleManualAmt.Text == "0" || txtVehicleManualAmt.Text == "" ? Convert.ToInt32(lblVehicleTDS.Text) : Convert.ToInt32(txtVehicleManualAmt.Text));
            //End Vehicle Margin

            //Display Warranty Margin
            lblWarrantyMarginAmt.Visible = true;
            lblWarrantyTotAmt.Visible = true;
            txtWarrantyManAmt.Visible = true;
            chkWarrantyAR.Visible = true;
            dtWarranty.Visible = true;
            chkWarrantyCash.Visible = true;
            txtWarrantyNo.Visible = true;
            txtWarrantyRemarks.Visible = true;
            lblWarrantyTDS.Visible = true;
           if(_dto.WarrantyMarginPrice != null && _dto.WarrantyMarginPrice != 0)
            {
                lblWarrantyMarginAmt.Text = _dto.WarrantyMarginPrice.ToString();
            }
            if (_dto.WarrantyMarginwithDTSDeduction != null)
            {
                lblWarrantyTDS.Text = _dto.WarrantyMarginwithDTSDeduction.ToString();
            }
            if (_dto.WarrantyPrice != null)
            {
                lblWarrantyTotAmt.Text = _dto.WarrantyPrice.ToString();
            }
            if (_dto.WarrantyMarginManualAmount != null)
            {
                txtWarrantyManAmt.Text = _dto.WarrantyMarginManualAmount.ToString();
            }
            if (_dto.WarrantyMarginReceived ?? false)
            {
                chkWarrantyAR.Enabled = true;
                chkWarrantyAR.Checked = true;
                chkWarrantyCash.Enabled = true;
                txtWarrantyNo.Enabled = true;
            }

            if (_dto.WarrantyMarginReceivedDate != null)
            {
                dtWarranty.Text = _dto.WarrantyMarginReceivedDate.ToString();
            }

            if (_dto.WarrantyMarginReceivedByCash)
            {
                if (_dto.WarrantyMarginReceived ?? false)
                {
                    TMA_CASH = TMA_CASH + (txtWarrantyManAmt.Text == "0" || txtWarrantyManAmt.Text == "" ? Convert.ToInt32(lblWarrantyTDS.Text) : Convert.ToInt32(txtWarrantyManAmt.Text));
                }
            }
            else
            {
                if (_dto.WarrantyMarginReceived ?? false)
                {
                    TMA_BANK = TMA_BANK + (txtWarrantyManAmt.Text == "0" || txtWarrantyManAmt.Text == "" ? Convert.ToInt32(lblWarrantyTDS.Text) : Convert.ToInt32(txtWarrantyManAmt.Text));
                }
            }
            if (_dto.WarrantyMarginByChequeorNEFTNo != null)
            {
                txtWarrantyNo.Text = _dto.WarrantyMarginByChequeorNEFTNo.ToString();
            }
            txtWarrantyRemarks.Text = _dto.WarrantyMarginRemarks;
            TotalMarginAmount = TotalMarginAmount + (txtWarrantyManAmt.Text == "0" || txtWarrantyManAmt.Text == "" ? Convert.ToInt32(lblWarrantyTDS.Text) : Convert.ToInt32(txtWarrantyManAmt.Text));
            //End Warranty Margin

            //Display ExtraFitting Margin
            int totalEFAmount = 0;
            int totalEFMarginAmount = 0;
            if (_dto.ExtraFittingsTotalMarginAmount > 0 && _dto.ExtraFittingsTotalActualAmount > 0)
            {
                lblEFMarginAmt.Visible = true;
                lblEFTotAmt.Visible = true;
                txtEFManAmt.Visible = true;
                chkEFAR.Visible = true;
                dtEF.Visible = true;
                chkEFCash.Visible = true;
                txtEFCheqNo.Visible = true;
                txtEFRemarks.Visible = true;
                if (_dto.ExtraFittingsTotalMarginAmount != null)
                {
                    lblEFMarginAmt.Text = _dto.ExtraFittingsTotalMarginAmount.ToString();
                }
                if (_dto.ExtraFittingsTotalActualAmount != null)
                {
                    lblEFTotAmt.Text = _dto.ExtraFittingsTotalActualAmount.ToString();
                }
                if (_dto.ExtraFittingsManualMarginAmount != null)
                {
                    txtEFManAmt.Text = _dto.ExtraFittingsManualMarginAmount.ToString();
                }

                if (_dto.ExtraFittingsReceived ?? false)
                {
                    chkEFAR.Enabled = true;
                    chkEFAR.Checked = true;
                    chkEFCash.Enabled = true;
                    txtEFCheqNo.Enabled = true;
                }

                if (_dto.ExtraFittingsReceivedDate != null)
                {
                    dtEF.Text = _dto.ExtraFittingsReceivedDate.ToString();
                }

                if (_dto.ExtraFittingsReceivedByCash ?? false)
                {
                    chkEFCash.Checked = true;
                    if (_dto.ExtraFittingsReceived ?? false)
                    {
                        TMA_CASH = TMA_CASH + (txtEFManAmt.Text == "0" || txtEFManAmt.Text == "" ? Convert.ToInt32(lblEFMarginAmt.Text) : Convert.ToInt32(txtEFManAmt.Text));
                    }
                }
                else
                {
                    if (_dto.ExtraFittingsReceived ?? false)
                    {
                        TMA_BANK = TMA_BANK + (txtEFManAmt.Text == "0" || txtEFManAmt.Text == "" ? Convert.ToInt32(lblEFMarginAmt.Text) : Convert.ToInt32(txtEFManAmt.Text));
                    }
                }
                if (_dto.ExtraFittingsMarginByChequeorNEFTNo != null)
                {
                    txtEFCheqNo.Text = _dto.ExtraFittingsMarginByChequeorNEFTNo.ToString();
                }
                txtEFRemarks.Text = _dto.ExtraFittingsRemarks;
                TotalMarginAmount = TotalMarginAmount + (txtEFManAmt.Text == "0" || txtEFManAmt.Text == "" ? Convert.ToInt32(lblEFMarginAmt.Text) : Convert.ToInt32(txtEFManAmt.Text));
                totalEFAmount = Convert.ToInt32(lblEFTotAmt.Text);
                totalEFMarginAmount = (txtEFManAmt.Text == "0" || txtEFManAmt.Text == "" ? Convert.ToInt32(lblEFMarginAmt.Text) : Convert.ToInt32(txtEFManAmt.Text));
            }

            //Display Finance Amount
            
            if(_dto.FinanceAmount > 0 && _dto.FinanceMargin > 0)
            {
                lblFinMarginAmt.Visible = true;
                lblFinTA.Visible = true;
                txtFinManAmt.Visible = true;
                chkFinAR.Visible = true;
                dtFinance.Visible = true;
                chkFinCash.Visible = true;
                txtFinCheqNo.Visible = true;
                txtFinRemarks.Visible = true;

                if (_dto.FinanceMargin != null)
                {
                    lblFinMarginAmt.Text = _dto.FinanceMargin.ToString();
                }
                if (_dto.FinanceAmount != null)
                {
                    lblFinTA.Text = _dto.FinanceAmount.ToString();
                }
                if (_dto.FinanceMarginManualAmount != null)
                {
                    txtFinManAmt.Text = _dto.FinanceMarginManualAmount.ToString();
                }

                if (_dto.FinanceMarginReceived ?? false)
                {
                    chkFinAR.Enabled = true;
                    chkFinAR.Checked = true;
                    chkFinCash.Enabled = true;
                    txtFinCheqNo.Enabled = true;
                }

                if (_dto.FinanceMarginReceivedDate != null)
                {
                    dtFinance.Text = _dto.FinanceMarginReceivedDate.ToString();
                }

                if (_dto.FinanceMarginReceivedByCash ?? false)
                {
                    chkFinCash.Checked = true;
                    if (_dto.FinanceMarginReceived ?? false)
                    {
                        TMA_CASH = TMA_CASH + (txtFinManAmt.Text == "0" || txtFinManAmt.Text == "" ? Convert.ToInt32(lblFinMarginAmt.Text) : Convert.ToInt32(txtFinManAmt.Text));
                    }
                }
                else
                {
                    if (_dto.FinanceMarginReceived ?? false)
                    {
                        TMA_BANK = TMA_BANK + (txtFinManAmt.Text == "0" || txtFinManAmt.Text == "" ? Convert.ToInt32(lblFinMarginAmt.Text) : Convert.ToInt32(txtFinManAmt.Text));
                    }
                }
                if (_dto.FinanceMarginByChequeorNEFTNo != null)
                {
                    txtFinCheqNo.Text = _dto.FinanceMarginByChequeorNEFTNo.ToString();
                }
                txtFinRemarks.Text = _dto.FinanceRemarks;
                TotalMarginAmount = TotalMarginAmount + (txtFinManAmt.Text == "0" || txtFinManAmt.Text == "" ? Convert.ToInt32(lblFinMarginAmt.Text) : Convert.ToInt32(txtFinManAmt.Text));
                
            }
            int netprofit = TotalMarginAmount;
            //Display Discount Amount
            int discount = 0;
            if (_dto.DiscountGiven != null && _dto.DiscountGiven != 0)
            {
                lblDisMaringAmt.Visible = true;
                txtDiscountRemarks.Visible = true;
                lblDisMaringAmt.Text = _dto.DiscountGiven.ToString();
                txtDiscountRemarks.Text = _dto.DiscountRemarks;
                netprofit = (TotalMarginAmount + _dto.DiscountGiven ?? 0);
                TMA_CASH = TMA_CASH + _dto.DiscountGiven?? 0;
                discount = _dto.DiscountGiven ?? 0;
            }
            lblTotalMarginAmt.Text = TotalMarginAmount.ToString();
            lblMarginByCash.Text = TMA_CASH.ToString();
            lblMarginByBank.Text = TMA_BANK.ToString();
            lblMarginpending.Text = (TotalMarginAmount - (TMA_CASH + TMA_BANK) + discount).ToString();
            lblNetProfit.Text = netprofit.ToString();
            lblTotalAmt.Text = (netprofit + totalEFAmount - totalEFMarginAmount).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<InvoiceMarginDTO> lst = new List<InvoiceMarginDTO>();
            //Update Invoice Margin
            if (lblVehicleMarginAmt.Visible)
            {
                if ((txtVehicleManualAmt.Text != "0" && txtVehicleManualAmt.Text != "") && txtVehicleRemarks.Text == "")
                {
                    MyMessageBox.ShowBox("Vehicle Remarks cannot be empty for Manual Amount");
                    return;
                }

                if(chkvehcleAR.Checked  && (!chkVehicleCash.Checked && txtVehicleCheqNo.Text == ""))
                {
                    MyMessageBox.ShowBox("Amount Received should be either Cash or Tran No");
                    return;
                }
                InvoiceMarginDTO IAMargin = new InvoiceMarginDTO();
                IAMargin.VehicleBookingID = _vehicleBookingId;
                IAMargin.MarginTypeID = 1;
                if (txtVehicleManualAmt.Text != "0" && txtVehicleManualAmt.Text != "")
                {
                    IAMargin.ManualAmount = Convert.ToInt32(txtVehicleManualAmt.Text);
                }
                IAMargin.IsReceived = chkvehcleAR.Checked;
                if (chkvehcleAR.Checked)
                {
                    IAMargin.ReceivedDate = Convert.ToDateTime(dtVehicle.Text);
                    IAMargin.IsCash = chkVehicleCash.Checked;
                    IAMargin.ChequeBankTranNo = txtVehicleCheqNo.Text;
                }
                IAMargin.Remarks = txtVehicleRemarks.Text;
                if(chkIAInvoice.Checked)
                {
                    IAMargin.IAInvoiceDate = Convert.ToDateTime(dtIAInvoiceDt.Text);
                }
                lst.Add(IAMargin);
            }

            //Update Warranty Margin
            if (lblWarrantyMarginAmt.Visible)
            {

                if ((txtWarrantyManAmt.Text != "0" && txtWarrantyManAmt.Text != "") && txtWarrantyRemarks.Text == "")
                {
                    MyMessageBox.ShowBox("Warranty Remarks cannot be empty for Manual Amount");
                    return;
                }

                if (chkWarrantyAR.Checked && (!chkWarrantyCash.Checked && txtWarrantyNo.Text == ""))
                {
                    MyMessageBox.ShowBox("Amount Received should be either Cash or Tran No");
                    return;
                }
                InvoiceMarginDTO warrMargin = new InvoiceMarginDTO();
                warrMargin.VehicleBookingID = _vehicleBookingId;
                warrMargin.MarginTypeID = 3;
                if (txtWarrantyManAmt.Text != "0" && txtWarrantyManAmt.Text != "")
                {
                    warrMargin.ManualAmount = Convert.ToInt32(txtWarrantyManAmt.Text);
                }
                warrMargin.IsReceived = chkWarrantyAR.Checked;
                if (chkWarrantyAR.Checked)
                {
                    warrMargin.ReceivedDate = Convert.ToDateTime(dtWarranty.Text);
                    warrMargin.IsCash = chkWarrantyCash.Checked;
                    warrMargin.ChequeBankTranNo = txtWarrantyNo.Text;
                }
                warrMargin.Remarks = txtWarrantyRemarks.Text;
                if (chkIAInvoice.Checked)
                {
                    warrMargin.IAInvoiceDate = Convert.ToDateTime(dtIAInvoiceDt.Text);
                }
                lst.Add(warrMargin);
            }

            //Update EF Margin
            if (lblEFMarginAmt.Visible)
            {

                if ((txtEFManAmt.Text != "0" && txtEFManAmt.Text != "") && txtEFRemarks.Text == "")
                {
                    MyMessageBox.ShowBox("Extra Fitting Remarks cannot be empty for Manual Amount");
                    return;
                }

                if (chkEFAR.Checked && (!chkEFCash.Checked && txtEFCheqNo.Text == ""))
                {
                    MyMessageBox.ShowBox("Amount Received should be either Cash or Tran No");
                    return;
                }
                InvoiceMarginDTO efMargin = new InvoiceMarginDTO();
                efMargin.VehicleBookingID = _vehicleBookingId;
                efMargin.MarginTypeID = 4;
                if (txtEFManAmt.Text != "0" && txtEFManAmt.Text != "")
                {
                    efMargin.ManualAmount = Convert.ToInt32(txtEFManAmt.Text);
                }
                efMargin.IsReceived = chkEFAR.Checked;
                if (chkEFAR.Checked)
                {
                    efMargin.ReceivedDate = Convert.ToDateTime(dtEF.Text);
                    efMargin.IsCash = chkEFCash.Checked;
                    efMargin.ChequeBankTranNo = txtEFCheqNo.Text;
                }
                efMargin.Remarks = txtEFRemarks.Text;
                if (chkIAInvoice.Checked)
                {
                    efMargin.IAInvoiceDate = Convert.ToDateTime(dtIAInvoiceDt.Text);
                }
                lst.Add(efMargin);
            }

            //Update Finance Margin
            if (lblFinMarginAmt.Visible)
            {

                if ((txtFinManAmt.Text != "0" && txtFinManAmt.Text != "") && txtFinRemarks.Text == "")
                {
                    MyMessageBox.ShowBox("Finance Remarks cannot be empty for Manual Amount");
                    return;
                }

                if (chkFinAR.Checked && (!chkFinCash.Checked && txtFinCheqNo.Text == ""))
                {
                    MyMessageBox.ShowBox("Amount Received should be either Cash or Tran No");
                    return;
                }
                InvoiceMarginDTO finMargin = new InvoiceMarginDTO();
                finMargin.VehicleBookingID = _vehicleBookingId;
                finMargin.MarginTypeID = 2;
                if (txtFinManAmt.Text != "0" && txtFinManAmt.Text != "")
                {
                    finMargin.ManualAmount = Convert.ToInt32(txtFinManAmt.Text);
                }
                finMargin.IsReceived = chkFinAR.Checked;
                if (chkFinAR.Checked)
                {
                    finMargin.ReceivedDate = Convert.ToDateTime(dtFinance.Text);
                    finMargin.IsCash = chkFinCash.Checked;
                    finMargin.ChequeBankTranNo = txtFinCheqNo.Text;
                }
                finMargin.Remarks = txtFinRemarks.Text;
                if (chkIAInvoice.Checked)
                {
                    finMargin.IAInvoiceDate = Convert.ToDateTime(dtIAInvoiceDt.Text);
                }
                lst.Add(finMargin);
            }

            //Update Discount Margin
            if (lblDisMaringAmt.Visible)
            {
                InvoiceMarginDTO disMargin = new InvoiceMarginDTO();
                disMargin.VehicleBookingID = _vehicleBookingId;
                disMargin.MarginTypeID = 5;
                disMargin.Remarks = txtDiscountRemarks.Text;
                if (chkIAInvoice.Checked)
                {
                    disMargin.IAInvoiceDate = Convert.ToDateTime(dtIAInvoiceDt.Text);
                }
                lst.Add(disMargin);
            }

            InvoiceBL bl = new InvoiceBL();
            var flag = bl.UpdateInvoiceMargin(lst);
            if(flag)
            {
                MyMessageBox.ShowBox("Invoice Margin Updated");
            }
            else
            {
                MyMessageBox.ShowBox("Invoice Margin Failed");
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkIAInvoice_CheckedChanged(object sender, EventArgs e)
        {
            if(chkIAInvoice.Checked)
            {
                dtIAInvoiceDt.Enabled = true;

            }
            else
            {
                dtIAInvoiceDt.Enabled = false;
            }
        }

        private void chkvehcleAR_CheckedChanged(object sender, EventArgs e)
        {
            if(chkvehcleAR.Checked)
            {
                dtVehicle.Enabled = true;
                chkVehicleCash.Enabled = true;
                txtVehicleCheqNo.Enabled = true;
            }
            else
            {
                dtVehicle.Enabled = false;
                chkVehicleCash.Enabled = false;
                txtVehicleCheqNo.Enabled = false;
                chkVehicleCash.Checked = false;
                txtVehicleCheqNo.Text = "";
            }
        }

        private void chkWarrantyAR_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWarrantyAR.Checked)
            {
                dtWarranty.Enabled = true;
                chkWarrantyCash.Enabled = true;
                txtWarrantyNo.Enabled = true;
            }
            else
            {
                dtWarranty.Enabled = false;
                chkWarrantyCash.Enabled = false;
                txtWarrantyNo.Enabled = false;
                chkWarrantyCash.Checked = false;
                txtWarrantyNo.Text = "";
            }
        }

        private void chkEFAR_CheckedChanged(object sender, EventArgs e)
        {

            if (chkEFAR.Checked)
            {
                dtEF.Enabled = true;
                chkEFCash.Enabled = true;
                txtEFCheqNo.Enabled = true;
            }
            else
            {
                dtEF.Enabled = false;
                chkEFCash.Enabled = false;
                txtEFCheqNo.Enabled = false;
                chkEFCash.Checked = false;
                txtEFCheqNo.Text = "";
            }
        }

        private void chkFinAR_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFinAR.Checked)
            {
                dtFinance.Enabled = true;
                chkFinCash.Enabled = true;
                txtFinCheqNo.Enabled = true;
            }
            else
            {
                dtFinance.Enabled = false;
                chkFinCash.Enabled = false;
                txtFinCheqNo.Enabled = false;
                chkFinCash.Checked = false;
                txtFinCheqNo.Text = "";
            }
        }
    }
}
