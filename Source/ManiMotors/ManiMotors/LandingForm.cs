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
namespace ManiMotors
{
    public partial class LandingForm : Form
    {
        public LandingForm()
        {
            InitializeComponent();
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
    }
}
