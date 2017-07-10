using MM.BusinessLayer.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManiMotors.Admin
{
    public partial class AccountingFrm : Form
    {
        public AccountingFrm()
        {
            InitializeComponent();
        }

        private void AccountingFrm_Load(object sender, EventArgs e)
        {
            AccountsBL bl = new AccountsBL();
            lblBank.Text = bl.GetCashInBank().ToString();
            lblCash.Text = bl.GetCashInHand().ToString();
        }
    }
}
