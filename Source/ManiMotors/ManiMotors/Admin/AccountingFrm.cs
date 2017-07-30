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
            lblBankSales.Text = bl.GetCashInBankForSales().ToString();
            lblBankService.Text = bl.GetCashInBankForService().ToString();
            lblCashSales.Text = bl.GetCashInHandForSales().ToString();
            lblCashService.Text = bl.GetCashInHandForService().ToString();
        }
    }
}
