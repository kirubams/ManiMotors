using MessageBoxExample;
using MM.BusinessLayer.Admin;
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
    public partial class SearchBankTranfrm : Form
    {
        public SearchBankTranfrm()
        {
            InitializeComponent();
        }

        private void LoadDefaultValues()
        {
            BankTransactionBL bl = new BankTransactionBL();
            var lstExpenseTran = bl.GetBankAccountTransaction().Where(et => Convert.ToDateTime(Convert.ToDateTime(et.TransactionDate).ToShortDateString()) >= Convert.ToDateTime(dtStartDate.Text) && Convert.ToDateTime(Convert.ToDateTime(et.TransactionDate).ToShortDateString()) <= Convert.ToDateTime(dtEndDate.Text)).ToList();
            dgBankTran.DataSource = lstExpenseTran;
            if (dgBankTran.RowCount > 0)
            {
                btnDownload.Visible = true;
            }
            //Load BankAccounType
            ddlBankAccount.Items.Clear();
            var bankTypelst = bl.GetBankAccountType();

            foreach (var bt in bankTypelst)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = bt.BankAccountTypeDescription;
                item.Value = bt.BankAccountTypeID;
                ddlBankAccount.Items.Add(item);
            }
        }

        private void SearchBankTranfrm_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BankTranfrm frm = new BankTranfrm();
            frm.ShowDialog();
            LoadDefaultValues();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BankTransactionBL bl = new BankTransactionBL();
            string searchText = ddlTranType.Text;
            if (ddlTranType.Text == "BOTH")
            {
                var lstBankTran = bl.GetBankAccountTransaction().Where(et => Convert.ToDateTime(Convert.ToDateTime(et.TransactionDate).ToShortDateString()) >= Convert.ToDateTime(dtStartDate.Text) && Convert.ToDateTime(Convert.ToDateTime(et.TransactionDate).ToShortDateString()) <= Convert.ToDateTime(dtEndDate.Text)).ToList();
                dgBankTran.DataSource = lstBankTran;
            }
            else
            {
                var lstBankTran = bl.GetBankAccountTransaction().Where(et => Convert.ToDateTime(Convert.ToDateTime(et.TransactionDate).ToShortDateString()) >= Convert.ToDateTime(dtStartDate.Text) && Convert.ToDateTime(Convert.ToDateTime(et.TransactionDate).ToShortDateString()) <= Convert.ToDateTime(dtEndDate.Text)).ToList()
                    .Where(
                    efu => efu.TransactionType.ToUpper().Contains(ddlTranType.Text.ToUpper())
                    ).ToList();
                dgBankTran.DataSource = lstBankTran;
            }
            if(dgBankTran.RowCount > 0)
            {
                btnDownload.Visible = true;
            }


        }

        private void btnEDIT_Click(object sender, EventArgs e)
        {
            var bankActTranID = Convert.ToInt32(dgBankTran.CurrentRow.Cells["BankAccountTransactionID"].Value.ToString());
            if (bankActTranID == 0)
            {
                MyMessageBox.ShowBox("Please select a value from the Bank Transaction!!!");
            }
            else
            {
                BankTranfrm obj = new BankTranfrm(bankActTranID, "EDIT");
                obj.ShowDialog();
                LoadDefaultValues();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var bankActTranID = Convert.ToInt32(dgBankTran.CurrentRow.Cells["BankAccountTransactionID"].Value.ToString());
            if (bankActTranID == 0)
            {
                MyMessageBox.ShowBox("Please select a value from the Bank Transaction!!!");
            }
            else
            {

                var retStr = MyMessageBoxYesorNo.ShowBox("Are you Sure You want to Delete??");
                if (retStr == "1")
                {
                    BankTransactionBL obj = new BankTransactionBL();
                    var flag = obj.DeleteBankAccountTransaction(bankActTranID);
                    LoadDefaultValues();
                    if (flag)
                    {
                        MyMessageBox.ShowBox("Bank Transaction Deleted");
                    }
                    else
                    {
                        MyMessageBox.ShowBox("Bank Transaction Failed to Delete.");
                    }
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Export obj = new Export();
            obj.ExportToExcel(dgBankTran);
        }
    }
}
