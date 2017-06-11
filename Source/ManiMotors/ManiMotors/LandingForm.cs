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
    }
}
