using System;
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
            int deliveredCount = allvehicleBookingList.Where(x => x.CreatedDate.Month == DateTime.Now.Month && x.StatusDescription.ToUpper() == "DELIVERED").Count();
            lblNoDelivered.Text = deliveredCount.ToString();
            int BookedCount = allvehicleBookingList.Where(x => x.CreatedDate.Month == DateTime.Now.Month && x.StatusDescription.ToUpper() == "OPEN").Count();
            lblNoBookings.Text = BookedCount.ToString();

            //VehicleEnquiry
            CustomerEnquiryReportBL eBl = new CustomerEnquiryReportBL();
            var enquiryLit = eBl.GetAllCustomerEnquiry();
            int allEnquiries = enquiryLit.Where(x => x.CreatedDate.Month == DateTime.Now.Month).Count();
            lblNoofEnquiry.Text = allEnquiries.ToString();
            int bookedEnquiries = enquiryLit.Where(x => x.CreatedDate.Month == DateTime.Now.Month && x.VehicleStatusDescription.ToUpper() == "BOOKED").Count();
            lblNoEnquiryToBookings.Text = bookedEnquiries.ToString();
            int deliveredEnquiries = enquiryLit.Where(x => x.CreatedDate.Month == DateTime.Now.Month && x.VehicleStatusDescription.ToUpper() == "DELIVERED").Count();
            lblEnquiryToDelivery.Text = deliveredEnquiries.ToString();

            //VehicleEnquiryFollowUpForToday
            CustomerEnquiryFollowupBL efBL = new CustomerEnquiryFollowupBL();
            var todayEnquiryfollowup = efBL.GetCustomerEnquiryFollowup(DateTime.Now, DateTime.Now, 1); //Open Status id for today
            lblEnquiryFollowUpToday.Text = todayEnquiryfollowup.Count().ToString();

            //VehicleBookingFollowUpForToday
            VehicleBookingFollowUpBL vbfBL = new VehicleBookingFollowUpBL();
            var todayBookingfollowup = vbfBL.GetVehicleBookingFollowUp(DateTime.Now, DateTime.Now, 1);
            lblBookingFollowUpToday.Text = todayBookingfollowup.Count().ToString();

            if(_userName != "")
            {
                lblUserName.Text = _userName;
            }

            if(_role != "ADMIN")
            {
                administrationToolStripMenuItem.Visible = false;
                salesToolStripMenuItem.Visible = false;
                configurationToolStripMenuItem.Visible = false;
            }
        }

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            LoginControl frm = new LoginControl();
            frm.Show();
            this.Close();
        }
    }
}
