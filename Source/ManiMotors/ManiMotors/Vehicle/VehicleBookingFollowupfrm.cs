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
        public VehicleBookingFollowupfrm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var customerName = txtName.Text;
            var mobileNo = txtMobileNo.Text;
            var followUpDate = Convert.ToDateTime(dtStartDate.Text);
            var status = ddlStatus.Text;
            var statusItem = (ComboboxItem)ddlStatus.SelectedItem;
            int statusId = Convert.ToInt32(statusItem.Value);
            VehicleBookingFollowUpBL ef = new VehicleBookingFollowUpBL();
            dgFollowup.DataSource = ef.GetVehicleBookingFollowUp(Convert.ToDateTime(dtStartDate.Text), Convert.ToDateTime(dtEndDate.Text), statusId)
                .Select(c => new
                {
                    CustomerName = c.CustomerName,
                    MobileNumber = c.CustomerMobileNo,
                    ModelName = c.ModelName,
                    FollowUpDate = c.FollowUpDate,
                    Status = c.StatusDescription,
                    StatusId = c.StatusId,
                    VehicleBookingId = c.VehicleBookingID
                }).Where(
                efu => efu.CustomerName.ToUpper().Contains(customerName.ToUpper())
                &&
                efu.MobileNumber.ToUpper().Contains(mobileNo.ToUpper())
                &&
                efu.Status.ToUpper().Contains(status.ToUpper())
                ).ToList();
        }

        private void LoadDefaultValues()
        {
            //Load Status
            VehicleInfoBL v = new VehicleInfoBL();
            var slist = v.GetVehicleSalesStatus();
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
                .Select(c => new
                {
                    CustomerName = c.CustomerName,
                    MobileNumber = c.CustomerMobileNo,
                    ModelName = c.ModelName,
                    FollowUpDate = c.FollowUpDate,
                    Status = c.StatusDescription,
                    StatusId = c.StatusId,
                    VehicleBookingId = c.VehicleBookingID
                }).ToList();

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
                VehicleBookingfrm obj = new VehicleBookingfrm("EDIT", bookingId);
                obj.ShowDialog();
                LoadDefaultValues();
            }
        }
    }
}
