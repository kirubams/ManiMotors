using MessageBoxExample;
using MM.BusinessLayer.Vehicle;
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
    public partial class VehicleBookingFollowupfrm : Form
    {
        private string _mode = "";
        public VehicleBookingFollowupfrm()
        {
            InitializeComponent();
        }

        public VehicleBookingFollowupfrm(string mode)
        {
            InitializeComponent();
            _mode = mode;
            if(_mode == "ALLOTMENT")
            {
                lblTitle.Text = "Search Booking For Allotment Screen";
            }

            if (_mode == "DELIVERY")
            {
                lblTitle.Text = "Search Booking For Delivery Screen";
            }

            if (_mode == "REPORTDELIVERY")
            {
                lblTitle.Text = "DELIVERY REGISTER";
               
            }

            if (_mode == "REPORTBOOKING")
            {
                lblTitle.Text = "BOOKING REGISTER";

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchEvent();
        }

        private void SearchEvent()
        {
            var customerName = txtName.Text;
            var mobileNo = txtMobileNo.Text;
            var followUpDate = Convert.ToDateTime(dtStartDate.Text);
            var status = ddlStatus.Text;
            var statusItem = (ComboboxItem)ddlStatus.SelectedItem;
            int statusId = Convert.ToInt32(statusItem.Value);
            VehicleBookingFollowUpBL ef = new VehicleBookingFollowUpBL();
            dgFollowup.DataSource = ef.GetVehicleBookingFollowUp(Convert.ToDateTime(dtStartDate.Text), Convert.ToDateTime(dtEndDate.Text), statusId)
                .Where(
                efu => efu.CustomerName.ToUpper().Contains(customerName.ToUpper())
                &&
                efu.CustomerMobileNo.ToUpper().Contains(mobileNo.ToUpper())
                &&
                efu.StatusDescription.ToUpper().Contains(status.ToUpper())
                ).ToList();
            if (dgFollowup.RowCount > 0)
            { btnEDIT.Enabled = true; }
            else
            {
                btnEDIT.Enabled = false;
            }
        }

        private void LoadDefaultValues()
        {
            //Load Status
            VehicleInfoBL v = new VehicleInfoBL();
            string searchMode = "";
            if(_mode != "")
            {
                searchMode = "ALL";
            }
            var slist = v.GetVehicleSalesStatus(searchMode);
            foreach (var vl in slist)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = vl.Description; ;
                item.Value = vl.VehicleSalesStatusID;
                ddlStatus.Items.Add(item);
            }
            if(ddlStatus.Items.Count > 0)
            {
                ddlStatus.SelectedIndex = 0;
            }

            VehicleBookingFollowUpBL ef = new VehicleBookingFollowUpBL();
            dgFollowup.DataSource = ef.GetVehicleBookingFollowUp(Convert.ToDateTime(dtStartDate.Text), Convert.ToDateTime(dtEndDate.Text), 1) //default status open
               .ToList();

            if (dgFollowup.RowCount > 0)
            { btnEDIT.Enabled = true; }
            else
            {
                btnEDIT.Enabled = false;
            }

            if(_mode == "REPORTDELIVERY" || _mode == "REPORTBOOKING")
            {
                if (_mode == "REPORTDELIVERY")
                {
                    ddlStatus.SelectedIndex = 4; //Delivery
                }
                else if(_mode == "REPORTBOOKING")
                {
                    ddlStatus.SelectedIndex = 0; //OPen - Booking Status
                }
                label5.Visible = false;
                ddlStatus.Visible = false;
                SearchEvent();
                btnEDIT.Visible = false;
                btnDownload.Visible = true;
            }

        }

        private void VehicleBookingFollowupfrm_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
        }

        private void btnEDIT_Click(object sender, EventArgs e)
        {
            var bookingId = Convert.ToInt32(dgFollowup.CurrentRow.Cells["VehicleBookingId"].Value.ToString());
            if (bookingId == 0)
            {
                MyMessageBox.ShowBox("Please select a record from the Follow up Grid!!");
            }
            else
            {
                if (_mode == "")
                {
                    _mode = "EDIT";
                }
                VehicleBookingfrm obj = new VehicleBookingfrm(_mode, bookingId);
                obj.ShowDialog();
                LoadDefaultValues();
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Export obj = new Export();
            obj.ExportToExcel(dgFollowup);
        }
    }
}
