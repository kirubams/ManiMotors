using MM.BusinessLayer.RTO;
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
    public partial class AddRTOAllotmentfrm : Form
    {
        private int _vehicleBookingId;
        private string _mode = "";
        private int _rtoAllotmentId;

        public AddRTOAllotmentfrm(string mode, int vehicleBookingId, int rtoAllotmentId = 0)
        {
            InitializeComponent();
            _vehicleBookingId = vehicleBookingId;
            _rtoAllotmentId = rtoAllotmentId;
            lblVehicleBookingId.Text = vehicleBookingId.ToString();
            _mode = mode;
        }

        private void AddInsuranceAllotment_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
            if (_mode == "EDIT")
            {
                PopulateRTO();
            }
        }

        private void PopulateRTO()
        {
            RTOAllotmentBL bl = new RTOAllotmentBL();
            var rAllot = bl.GetRTOAllotment(_rtoAllotmentId);

            //RTO
            if (rAllot.RTOInfoID != 0)
            {
                ComboboxItem rtoItem = new ComboboxItem();
                rtoItem.Text = rAllot.RTOName;
                rtoItem.Value = rAllot.RTOInfoID;
                ddlRTO.Text = rtoItem.Text;
            }
            lblVehicleBookingId.Text = _vehicleBookingId.ToString();
            txtTempRegNo.Text = rAllot.TempRegNo;
            txtRegNo.Text = rAllot.RegNo;
            dtRegDate.Text = rAllot.RegDate.ToString();
            txtAmount.Text = (rAllot.Amount ?? 0).ToString();
            txtAgentName.Text = rAllot.AgentName;
            txtRCBookNo.Text = rAllot.RCBookNo;
            dtRCDeliveredDate.Text = rAllot.RCDeliveredDate.ToString();
            txtRemarks.Text = rAllot.Remark;
        }

        private void LoadDefaultValues()
        {
            //Load finance
            RTOInfoBL fBL = new RTOInfoBL();
            foreach (var vl in fBL.GetAllRTOInfo())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = vl.Name;
                item.Value = vl.RTOInfoID;
                ddlRTO.Items.Add(item);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RTOAllotmentBL obj = new RTOAllotmentBL();
            
            //RTOId
            int rtoId = 0;
            if (ddlRTO.SelectedIndex != -1)
            {
                var rtoITEM = (ComboboxItem)ddlRTO.SelectedItem;
                rtoId = Convert.ToInt32(rtoITEM.Value);

            }

            int _amount = 0;
            if(txtAmount.Text != "")
            {
                _amount = Convert.ToInt32(txtAmount.Text);
            }

            //Populate dto
            RTOAllotmentDTO dto = new RTOAllotmentDTO()
            {
                VehicleBookingId = Convert.ToInt32(lblVehicleBookingId.Text),
                RTOInfoID = rtoId,
                TempRegNo = txtTempRegNo.Text,
                RegNo = txtRegNo.Text,
                RegDate = Convert.ToDateTime(dtRegDate.Text),
                Amount = _amount,
                AgentName = txtAgentName.Text,
                RCBookNo = txtRCBookNo.Text,
                RCDeliveredDate = Convert.ToDateTime(dtRCDeliveredDate.Text),
                Remark = txtRemarks.Text,
                CreatedBy = GlobalSetup.Userid,
                CreatedDate = DateTime.Now,
                ModifiedBy = GlobalSetup.Userid,
                ModifiedDate = DateTime.Now
            };

            if (_mode == "EDIT")
            {
                dto.VehicleBookingRTOAllotmentID = _rtoAllotmentId;
            }

            int rtoallotmentId = obj.SaveRTOAllotment(dto, _mode);
            lblRTOAllotmentId.Text = rtoallotmentId.ToString();
            this.Close();
        }
    }
}
