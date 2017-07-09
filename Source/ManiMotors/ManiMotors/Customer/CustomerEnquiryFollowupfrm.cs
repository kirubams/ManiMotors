﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MM.BusinessLayer.Vehicle;
using MM.Model.Customer;
using MM.BusinessLayer.Customer;
using MessageBoxExample;
using MM.Utilities;

namespace ManiMotors.Customer
{
    public partial class CustomerEnquiryFollowupfrm : Form
    {
        public CustomerEnquiryFollowupfrm()
        {
            InitializeComponent();
        }

        private void LoadDefaultValues()
        {
            //Load Status
            VehicleInfoBL v = new VehicleInfoBL();
            var slist = v.GetVehicleSalesStatus(string.Empty);
            foreach (var vl in slist)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = vl.Description; ;
                item.Value = vl.VehicleSalesStatusID;
                ddlStatus.Items.Add(item);
            }

            if (ddlStatus.Items.Count > 0)
            {
                ddlStatus.SelectedIndex = 0;
            }

            CustomerEnquiryFollowupBL ef = new CustomerEnquiryFollowupBL();
            dgFollowup.DataSource = ef.GetCustomerEnquiryFollowup(Convert.ToDateTime(dtStartDate.Text), Convert.ToDateTime(dtEndDate.Text), 1) //default status open
                .Select(c => new
                {
                    CustomerName = c.CustomerName,
                    MobileNumber = c.CustomerMobileNo,
                    ModelName = c.ModelName,
                    FollowUpDate = c.FollowUpDate,
                    Status = c.StatusDescription,
                    StatusId = c.StatusId,
                    EnquiryId = c.CustomerEnquiryId
                }).ToList();
            if(dgFollowup.RowCount > 0)
            {
                btnEDIT.Enabled = true;
            }
            else
            {
                btnEDIT.Enabled = false;
            }
        }

        private void CustomerEnquiryFollowupfrm_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var customerName = txtName.Text;
            var mobileNo = txtMobileNo.Text;
            var followUpDate = Convert.ToDateTime(dtStartDate.Text);
            var status = ddlStatus.Text;
            var statusItem = (ComboboxItem) ddlStatus.SelectedItem;
            int statusId = Convert.ToInt32(statusItem.Value);
            CustomerEnquiryFollowupBL ef = new CustomerEnquiryFollowupBL();
            dgFollowup.DataSource = ef.GetCustomerEnquiryFollowup(Convert.ToDateTime(dtStartDate.Text), Convert.ToDateTime(dtEndDate.Text), statusId)
                .Select(c => new
                {
                    CustomerName = c.CustomerName,
                    MobileNumber = c.CustomerMobileNo,
                    ModelName = c.ModelName,
                    FollowUpDate = c.FollowUpDate,
                    Status = c.StatusDescription,
                    StatusId = c.StatusId,
                    EnquiryId = c.CustomerEnquiryId
                }).Where(
                efu => efu.CustomerName.ToUpper().Contains(customerName.ToUpper())
                &&
                efu.MobileNumber.ToUpper().Contains(mobileNo.ToUpper())
                && 
                efu.Status.ToUpper().Contains(status.ToUpper())
                ).ToList();
             if(dgFollowup.RowCount > 0)
            {
                btnEDIT.Enabled = true;
            }
            else
            {
                btnEDIT.Enabled = false;
            }

        }

        private void btnEDIT_Click(object sender, EventArgs e)
        {
            var enquiryId = Convert.ToInt32(dgFollowup.CurrentRow.Cells["EnquiryId"].Value.ToString());
            if (enquiryId == 0)
            {
                MyMessageBox.ShowBox("Please select a record from the Follow up Grid!!");
            }
            else
            {
                CustomerEnquiryfrm obj = new CustomerEnquiryfrm( "EDIT", enquiryId);
                obj.ShowDialog();
                LoadDefaultValues();
            }
        }
    }
}
