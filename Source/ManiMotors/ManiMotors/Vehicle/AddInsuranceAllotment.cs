using MM.BusinessLayer.Insurance;
using MM.BusinessLayer.Vehicle;
using MM.Model.Vehicle;
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

namespace ManiMotors.Vehicle
{
    public partial class AddInsuranceAllotment : Form
    {
        private int _vehicleBookingId;
        private string _mode = "";
        private int _insuranceAllotmentId;

        public AddInsuranceAllotment(string mode, int vehicleBookingId, int insuranceAllotmentId = 0)
        {
            InitializeComponent();
            _vehicleBookingId = vehicleBookingId;
            _insuranceAllotmentId = insuranceAllotmentId;
            lblVehicleBookingId.Text = vehicleBookingId.ToString();
            _mode = mode;
        }

        private void AddInsuranceAllotment_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
            if (_mode == "EDIT")
            {
                PopulateInsurance();
            }
        }

        private void PopulateInsurance()
        {
            InsuranceAllotmentBL bl = new InsuranceAllotmentBL();
            var iAllot = bl.GetInsuranceAllotment(_insuranceAllotmentId);

            //Insurance
            if (iAllot.InsuranceInfoID != 0)
            {
                ComboboxItem insuranceItem = new ComboboxItem();
                insuranceItem.Text = iAllot.InsuranceName;
                insuranceItem.Value = iAllot.InsuranceInfoID;
                ddlInsurance.Text = insuranceItem.Text;
            }
            lblVehicleBookingId.Text = _vehicleBookingId.ToString();
            if(iAllot.InsuranceByDealer)
            {
                rdnYesbyDealer.Checked = true;
                rdnNobyDealer.Checked = false;
            }
            txtCoverNote.Text = (iAllot.CoverNoteNo ?? 0).ToString();
            txtPolicyAmount.Text = (iAllot.PolicyAmount ?? 0).ToString();
            txtPolicyNo.Text = (iAllot.PolicyNumber).ToString();
            dtPolicyFromDate.Text = (iAllot.FromDate).ToString();
            dtPolicyToDate.Text = (iAllot.ToDate).ToString();
            dtPolicyDeliveredDate.Text = (iAllot.PolicyDeliveredDate).ToString();
            txtContactNo.Text = (iAllot.ContactNo);
        }

        private void LoadDefaultValues()
        {
            //Load finance
            InsuranceInfoBL fBL = new InsuranceInfoBL();
            foreach (var vl in fBL.GetAllInsuranceInfo())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = vl.Name;
                item.Value = vl.InsuranceInfoID;
                ddlInsurance.Items.Add(item);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InsuranceAllotmentBL obj = new InsuranceAllotmentBL();
            //InsuranceId

            int insuranceId = 0;
            if (ddlInsurance.SelectedIndex != -1)
            {
                var insuranceItem = (ComboboxItem)ddlInsurance.SelectedItem;
                insuranceId = Convert.ToInt32(insuranceItem.Value);

            }

            bool isInsByDealer = false;
            if(rdnYesbyDealer.Checked)
            {
                isInsByDealer = true;
            }

            int _coverNoteNo = 0;
            if (txtCoverNote.Text != "")
            {
                _coverNoteNo = Convert.ToInt32(txtCoverNote.Text);
            }

            int _policyAmount = 0;
            if (txtPolicyAmount.Text != "")
            {
                _policyAmount = Convert.ToInt32(txtPolicyAmount.Text);
            }

           
            //Populate dto
            InsuranceAllotmentDTO dto = new InsuranceAllotmentDTO()
            {
                VehicleBookingId = Convert.ToInt32(lblVehicleBookingId.Text),
                InsuranceInfoID = insuranceId,
                InsuranceByDealer = isInsByDealer,
                CoverNoteNo = _coverNoteNo,
                PolicyAmount = _policyAmount,
                PolicyNumber = txtPolicyNo.Text,
                FromDate = Convert.ToDateTime(dtPolicyFromDate.Text),
                ToDate = Convert.ToDateTime(dtPolicyToDate.Text),
                PolicyDeliveredDate = Convert.ToDateTime(dtPolicyDeliveredDate.Text),
                ContactNo = txtContactNo.Text,
                CreatedBy = GlobalSetup.Userid,
                CreatedDate = DateTime.Now,
                ModifiedBy = GlobalSetup.Userid,
                ModifiedDate = DateTime.Now
            };

            if (_mode == "EDIT")
            {
                dto.VehicleBookingInsuranceAllotmentID = _insuranceAllotmentId;
            }

            int insuranceAllotmentId = obj.SaveInsuranceAllotment(dto, _mode);
            lblnsuranceAllotmentId.Text = insuranceAllotmentId.ToString();
            this.Close();
        }
    }
}
