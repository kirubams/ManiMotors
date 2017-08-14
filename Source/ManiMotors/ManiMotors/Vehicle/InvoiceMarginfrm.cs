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
            lblVehicleTDS.Text = _dto.IAMarginwithDTSDeduction.ToString();
            lblVehicleTotalamt.Text = _dto.ShowRoomPrice.ToString();
            txtVehicleManualAmt.Text = _dto.IAMarginManualAmount.ToString();
            if(_dto.IAMarginReceived ?? false)
            {
                chkvehcleAR.Checked = true;
            }

            if(_dto.IAMarginReceivedDate != null)
            {
                dtVehicle.Text = _dto.IAMarginReceivedDate.ToString();
            }

            if(_dto.IAMarginReceivedByCash ?? false)
            {
                chkVehicleCash.Checked = true;
            }

            txtVehicleCheqNo.Text = _dto.IAMarginByChequeorNEFTNo.ToString();
            txtVehicleRemarks.Text = _dto.IARemarks;
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
            lblWarrantyTDS.Text = _dto.WarrantyMarginwithDTSDeduction.ToString();
            lblWarrantyTotAmt.Text = _dto.WarrantyPrice.ToString();
            txtWarrantyManAmt.Text = _dto.WarrantyMarginManualAmount.ToString();
            if (_dto.WarrantyMarginReceived ?? false)
            {
                chkWarrantyAR.Checked = true;
            }

            if (_dto.WarrantyMarginReceivedDate != null)
            {
                dtWarranty.Text = _dto.WarrantyMarginReceivedDate.ToString();
            }

            if (_dto.WarrantyMarginReceivedByCash)
            {
                chkWarrantyCash.Checked = true;
            }

            txtWarrantyNo.Text = _dto.WarrantyMarginByChequeorNEFTNo.ToString();
            txtWarrantyRemarks.Text = _dto.WarrantyMarginRemarks;
            //End Warranty Margin

            //Display ExtraFitting Margin
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

                lblEFMarginAmt.Text = _dto.ExtraFittingsTotalMarginAmount.ToString();
                lblEFTotAmt.Text = _dto.ExtraFittingsTotalActualAmount.ToString();
                txtEFManAmt.Text = _dto.ExtraFittingsManualMarginAmount.ToString();

                if (_dto.ExtraFittingsReceived ?? false)
                {
                    chkEFAR.Checked = true;
                }

                if (_dto.ExtraFittingsReceivedDate != null)
                {
                    dtEF.Text = _dto.ExtraFittingsReceivedDate.ToString();
                }

                if (_dto.ExtraFittingsReceivedByCash ?? false)
                {
                    chkEFCash.Checked = true;
                }

                txtEFCheqNo.Text = _dto.ExtraFittingsMarginByChequeorNEFTNo.ToString();
                txtEFRemarks.Text = _dto.ExtraFittingsRemarks;
            }

            //Display Finance Amount
            if(_dto.FinanceAmount > 0 && _dto.FinanceMargin > 0)
            {

            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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
    }
}
