using MM.BusinessLayer.Finance;
using MM.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MM.BusinessLayer.Vehicle;
using MM.Model.Vehicle;

namespace ManiMotors.Vehicle
{
    public partial class AddFinanceAllotmentfrm : Form
    {
        private int _vehicleBookingId;
        private string _mode = "";
        private int _financeAllotmentId;
        public AddFinanceAllotmentfrm(string mode, int vehicleBookingId, int financeAllotmentId = 0)
        {
            InitializeComponent();
            _vehicleBookingId = vehicleBookingId;
            _financeAllotmentId = financeAllotmentId;
            lblVehicleBookingId.Text = vehicleBookingId.ToString();
            _mode = mode;
        }

        private void AddFinanceAllotmentfrm_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
            if(_mode == "EDIT")
            {
                PopulateFinance();
            }
        }

        private void PopulateFinance()
        {
            FinanceAllotmentBL bl = new FinanceAllotmentBL();
            var fAllot = bl.GetFinanceAllotment(_financeAllotmentId);

            //Financier
            if (fAllot.FinancierID != 0)
            {
                ComboboxItem financeItem = new ComboboxItem();
                financeItem.Text = fAllot.FinancierName;
                financeItem.Value = fAllot.FinancierID;
                ddlFinance.Text = financeItem.Text;
            }
            lblVehicleBookingId.Text = _vehicleBookingId.ToString();
            txtLoanNo.Text = (fAllot.LoanNumber ?? 0).ToString();
            dtFinanceDate.Text = fAllot.FinanceDate.ToString();
            txtFinanceamt.Text = (fAllot.FinanceAmount ?? 0).ToString();
            txtOtherChargesDesc.Text = fAllot.OtherChargesDescription;
            txtOtherChargesAmt.Text = (fAllot.OtherAmount ?? 0).ToString();

        }

        private void LoadDefaultValues()
        {
            //Load finance
            FinanceInfoBL fBL = new FinanceInfoBL();
            foreach (var vl in fBL.GetAllFinanceInfo())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = vl.Name;
                item.Value = vl.FinanceInfoID;
                ddlFinance.Items.Add(item);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FinanceAllotmentBL obj = new FinanceAllotmentBL();
            //FinancierId

            int financierId = 0;
            if (ddlFinance.SelectedIndex != -1)
            {
                var financeItem = (ComboboxItem)ddlFinance.SelectedItem;
                financierId = Convert.ToInt32(financeItem.Value);

            }

            int _loanNo = 0;
            if (txtLoanNo.Text != "")
            {
                _loanNo = Convert.ToInt32(txtLoanNo.Text);
            }

            int _financeAmt = 0;
            if (txtFinanceamt.Text != "")
            {
                _financeAmt = Convert.ToInt32(txtFinanceamt.Text);
            }

            int _otherAmt = 0;
            if (txtOtherChargesAmt.Text != "")
            {
                _otherAmt = Convert.ToInt32(txtOtherChargesAmt.Text);
            }
            
            //Populate dto
            FinanceAllotmentDTO dto = new FinanceAllotmentDTO()
            {
                VehicleBookingId = Convert.ToInt32(lblVehicleBookingId.Text),
                FinancierID = financierId,
                LoanNumber = _loanNo,
                FinanceDate = Convert.ToDateTime(dtFinanceDate.Text),
                FinanceAmount = _financeAmt,
                OtherChargesDescription = txtOtherChargesDesc.Text,
                OtherAmount = _otherAmt,
                CreatedBy = GlobalSetup.Userid,
                CreatedDate = DateTime.Now,
                ModifiedBy = GlobalSetup.Userid,
                ModifiedDate = DateTime.Now
            };

            if(_mode == "EDIT")
            {
                dto.VehicleBookingFinanceAllotmentID = _financeAllotmentId;
            }

            int financeAllotmentId = obj.SaveFinanceAllotment(dto,_mode);
            lblFinanceAllotmentId.Text = financeAllotmentId.ToString();
            this.Close();
        }
    }
}
