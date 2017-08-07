using MessageBoxExample;
using MM.BusinessLayer.Admin;
using MM.Model.Admin;
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

namespace ManiMotors.Admin
{
    public partial class SearchCashTranfrm : Form
    {
        public SearchCashTranfrm()
        {
            InitializeComponent();
        }

        private void LoadDefaultValues()
        {
            CashTransactionBL bl = new CashTransactionBL();
            var lstCashTran = bl.GetCashTransaction().Where(et => Convert.ToDateTime(Convert.ToDateTime(et.TransactionDate).ToShortDateString()) >= Convert.ToDateTime(dtStartDate.Text) && Convert.ToDateTime(Convert.ToDateTime(et.TransactionDate).ToShortDateString()) <= Convert.ToDateTime(dtEndDate.Text)).ToList();
            dgCashTran.DataSource = lstCashTran;
        }

        private void SearchCashTranfrm_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCashTranfrm frm = new AddCashTranfrm();
            frm.ShowDialog();
            LoadDefaultValues();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CashTransactionBL bl = new CashTransactionBL();
            string searchText = ddlTranType.Text;

            var lstCashTran = new List<CashTransactionDTO>();

            if (ddlTranType.Text == "BOTH")
            {
                lstCashTran = bl.GetCashTransaction().Where(et => Convert.ToDateTime(Convert.ToDateTime(et.TransactionDate).ToShortDateString()) >= Convert.ToDateTime(dtStartDate.Text) && Convert.ToDateTime(Convert.ToDateTime(et.TransactionDate).ToShortDateString()) <= Convert.ToDateTime(dtEndDate.Text)).ToList();
                dgCashTran.DataSource = lstCashTran;
            }
            else
            {
                lstCashTran = bl.GetCashTransaction().Where(et => Convert.ToDateTime(Convert.ToDateTime(et.TransactionDate).ToShortDateString()) >= Convert.ToDateTime(dtStartDate.Text) && Convert.ToDateTime(Convert.ToDateTime(et.TransactionDate).ToShortDateString()) <= Convert.ToDateTime(dtEndDate.Text)).ToList()
                    .Where(
                    efu => efu.TransactionType.ToUpper().Contains(ddlTranType.Text.ToUpper())
                    ).ToList();
                dgCashTran.DataSource = lstCashTran;
            }

            if(ddlType.Text != "" && ddlType.Text != "BOTH")
            {
                lstCashTran = lstCashTran.Where(efu => efu.Type.ToUpper().Contains(ddlType.Text.ToUpper())).ToList();
                dgCashTran.DataSource = lstCashTran;
            }
        }

        private void btnEDIT_Click(object sender, EventArgs e)
        {
            var cashTranID = Convert.ToInt32(dgCashTran.CurrentRow.Cells["CashTransactionID"].Value.ToString());
            if (cashTranID == 0)
            {
                MyMessageBox.ShowBox("Please select a value from the Cash Transaction!!!");
            }
            else
            {
                AddCashTranfrm obj = new AddCashTranfrm(cashTranID, "EDIT");
                obj.ShowDialog();
                LoadDefaultValues();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var cashTranID = Convert.ToInt32(dgCashTran.CurrentRow.Cells["CashTransactionID"].Value.ToString());
            if (cashTranID == 0)
            {
                MyMessageBox.ShowBox("Please select a value from the Cash Transaction!!!");
            }
            else
            {

                var retStr = MyMessageBoxYesorNo.ShowBox("Are you Sure You want to Delete??");
                if (retStr == "1")
                {
                    CashTransactionBL obj = new CashTransactionBL();
                    var flag = obj.DeleteCashAccountTransaction(cashTranID);
                    LoadDefaultValues();
                    if (flag)
                    {
                        MyMessageBox.ShowBox("Cash Transaction Deleted");
                    }
                    else
                    {
                        MyMessageBox.ShowBox("Cash Transaction Failed to Delete.");
                    }
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Export obj = new Export();
            obj.ExportToExcel(dgCashTran);
        }
    }
}
