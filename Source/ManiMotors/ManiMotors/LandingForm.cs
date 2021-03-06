﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MM.Utilities;
using ManiMotors.Vehicle;
using ManiMotors.SpareParts;
using ManiMotors.Customer;
using ManiMotors.Admin;
using System.Globalization;
using MM.BusinessLayer.Reports;
using MM.BusinessLayer.Customer;
using MM.BusinessLayer.Vehicle;
using MM.Login;
using MM.BusinessLayer.Admin;

namespace ManiMotors
{
    public partial class LandingForm : Form
    {
        string _userName = "";
        string _role = "";
        public LandingForm()
        {
            InitializeComponent();
        }

        public LandingForm(string UserName, string Role)
        {
            InitializeComponent();
            _userName = UserName;
            _role = Role;
        }

        private void vehicleInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerInfo frm = new CustomerInfo();
            frm.ShowDialog();
        }

        private void vehicleInformationToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            VehicleInfo frm = new VehicleInfo();
            frm.ShowDialog();
        }

        private void vehicleInventoryToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            VehicleInventoryfrm frm = new VehicleInventoryfrm();
            frm.ShowDialog();
        }

        private void sparePartsInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SparePartsInfofrm frm = new SparePartsInfofrm();
            frm.ShowDialog();
        }

        private void sparePartsInventoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SparePartsInventoryfrm frm = new SparePartsInventoryfrm();
            frm.ShowDialog();
        }

        private void vehicleInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void customerEnquiryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerEnquiryfrm frm = new CustomerEnquiryfrm();
            frm.ShowDialog();
        }

        private void vehicleEnquityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerEnquiryFollowupfrm frm = new CustomerEnquiryFollowupfrm();
            frm.ShowDialog();
        }

        private void bookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VehicleBookingfrm frm = new VehicleBookingfrm();
            frm.ShowDialog();
        }

        private void customerBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VehicleBookingFollowupfrm frm = new VehicleBookingFollowupfrm();
            frm.ShowDialog();
        }

        private void allotmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VehicleBookingFollowupfrm frm = new VehicleBookingFollowupfrm("ALLOTMENT");
            frm.ShowDialog();
        }

        private void dELIVERYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VehicleBookingFollowupfrm frm = new VehicleBookingFollowupfrm("DELIVERY");
            frm.ShowDialog();
        }

        private void expenseTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expensesfrm frm = new Expensesfrm( );
            frm.ShowDialog();
        }

        private void vehicleInformationToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            VehicleInfo frm = new VehicleInfo();
            frm.ShowDialog();
        }

        private void sparePartsInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SparePartsInfofrm frm = new SparePartsInfofrm();
            frm.ShowDialog();
        }

        private void vehicleInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VehicleInventoryfrm frm = new VehicleInventoryfrm();
            frm.ShowDialog();
        }

        private void sparePartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SparePartsInventoryfrm frm = new SparePartsInventoryfrm();
            frm.ShowDialog();
        }

        private void expenseTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchExpenseTransactionfrm frm = new SearchExpenseTransactionfrm();
            frm.ShowDialog();
        }

        private void bankAccountTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBankTranfrm frm = new SearchBankTranfrm();
            frm.ShowDialog();
        }

        private void cashTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchCashTranfrm frm = new SearchCashTranfrm();
            frm.ShowDialog();
        }

        private void LandingForm_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
        }

        private void LoadDefaultValues()
        {
            //Get Current Month
            lblMonth.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month).ToString();
            lblTodayDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            //VehicleBookingReport
            VehicleBookingReportBL bl = new VehicleBookingReportBL();
            var allvehicleBookingList = bl.GetAllVehicleBooking();
            int deliveredCount = allvehicleBookingList.Where(x => x.CommittedDate.Month == DateTime.Now.Month && x.StatusDescription.ToUpper() == "DELIVERED").Count();
            lblNoDelivered.Text = deliveredCount.ToString();
            int BookedCount = allvehicleBookingList.Where(x => x.StatusDescription.ToUpper() == "OPEN").Count();
            lblNoBookings.Text = BookedCount.ToString();

            //VehicleEnquiry
            CustomerEnquiryReportBL eBl = new CustomerEnquiryReportBL();
            var enquiryLit = eBl.GetAllCustomerEnquiry();
            //int allEnquiries = enquiryLit.Where(x => x.CreatedDate.Month == DateTime.Now.Month).Count();
            lblNoofEnquiry.Text = enquiryLit.Where(x => x.VehicleStatusDescription.ToUpper() == "OPEN").Count().ToString();
            int bookedEnquiries = enquiryLit.Where(x => x.VehicleStatusDescription.ToUpper() == "BOOKED").Count();
            lblNoEnquiryToBookings.Text = bookedEnquiries.ToString();
            int deliveredEnquiries = enquiryLit.Where(x => x.VehicleStatusDescription.ToUpper() == "DELIVERED").Count();
            lblEnquiryToDelivery.Text = deliveredEnquiries.ToString();

            //VehicleEnquiryFollowUpForToday
            CustomerEnquiryFollowupBL efBL = new CustomerEnquiryFollowupBL();
            var todayEnquiryfollowup = efBL.GetCustomerEnquiryFollowup(Convert.ToDateTime(DateTime.Now.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToShortDateString()), 1); //Open Status id for today
            lblEnquiryFollowUpToday.Text = todayEnquiryfollowup.Count().ToString();

            //VehicleEnquiryFollowUpForPastDays
            CustomerEnquiryFollowupBL efBLpast = new CustomerEnquiryFollowupBL();
            var pastEnquiryfollowup = efBL.GetCustomerEnquiryFollowup(Convert.ToDateTime(DateTime.MinValue.ToShortDateString()), Convert.ToDateTime(DateTime.Now.AddDays(-1).ToShortDateString()), 1); //Open Status id for today
            lblPrevEnquiryFollowup.Text = pastEnquiryfollowup.Count().ToString();
                      

            //VehicleBookingFollowUpForToday
            VehicleBookingFollowUpBL vbfBL = new VehicleBookingFollowUpBL();
            var todayBookingfollowup = vbfBL.GetVehicleBookingFollowUp(Convert.ToDateTime(DateTime.Now.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToShortDateString()), 1);
            lblBookingFollowUpToday.Text = todayBookingfollowup.Count().ToString();

            //BookingFollowUpForPastDays
            var pastBookingfollowup = vbfBL.GetVehicleBookingFollowUp(Convert.ToDateTime(DateTime.MinValue.ToShortDateString()), Convert.ToDateTime(DateTime.Now.AddDays(-1).ToShortDateString()), 1);
            lblPrevBookingFollowup.Text = pastBookingfollowup.Count().ToString();

            //Populate Invoice Generated
            MM.BusinessLayer.Admin.InvoiceBL iBL = new MM.BusinessLayer.Admin.InvoiceBL();
            var invoiceGenerated = iBL.InvoiceMarginGenerated();
            lblNoofMarginGen.Text = invoiceGenerated.ToString();

            var invoiceGenerationPending = iBL.InvoiceMarginPending();
            lblNoofMarginpending.Text = invoiceGenerationPending.ToString();


            if (_userName != "")
            {
                lblUserName.Text = _userName;
            }

            if(_role != "ADMIN")
            {
                accountingToolStripMenuItem.Visible = false;
                expenseTypeToolStripMenuItem.Visible = false;
                accountingToolStripMenuItem1.Visible = false;
                invoiceToolStripMenuItem.Visible = false;
                vehicleMarginToolStripMenuItem.Visible = false;
            }
        }

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            LoginControl frm = new LoginControl();
            frm.Show();
            this.Close();
        }

        private void deliveryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VehicleBookingFollowupfrm frm = new VehicleBookingFollowupfrm("REPORTDELIVERY");
            frm.ShowDialog();
        }

        private void bookingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VehicleBookingFollowupfrm frm = new VehicleBookingFollowupfrm("REPORTBOOKING");
            frm.ShowDialog();
        }

        private void enquiryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerEnquiryFollowupfrm frm = new CustomerEnquiryFollowupfrm("REPORTENQUIRY");
            frm.ShowDialog();
        }

        private void accountingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AccountingFrm frm = new AccountingFrm();
            frm.ShowDialog();
        }

        private void sparePartsTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SparePartsTypefrm frm = new SparePartsTypefrm();
            frm.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LoadDefaultValues();
        }

        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VehicleBookingFollowupfrm frm = new VehicleBookingFollowupfrm("INVOICE");
            frm.ShowDialog();
        }

        private void vehicleMarginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VehicleBookingFollowupfrm frm = new VehicleBookingFollowupfrm("MARGIN");
            frm.ShowDialog();
        }
    }
}
