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
    public partial class SearchExpenseTransactionfrm : Form
    {
        public SearchExpenseTransactionfrm()
        {
            InitializeComponent();
        }

        private void LoadDefaultValues()
        {
            ExpenseTransactionBL bl = new ExpenseTransactionBL();
            var lstExpenseTran = bl.GetExpenseTransaction().Where(et => Convert.ToDateTime(Convert.ToDateTime(et.ExpenseDate).ToShortDateString()) >= Convert.ToDateTime(dtStartDate.Text) && Convert.ToDateTime(Convert.ToDateTime(et.ExpenseDate).ToShortDateString()) <= Convert.ToDateTime(dtEndDate.Text)).ToList();
            dgExpenseTransaction.DataSource = lstExpenseTran;
        }

        private void SearchExpenseTransactionfrm_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();

            //Load debit type
            ddlDebitType.DataSource = GlobalSetup.debitTypes;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddExpenseTransactionfrm frm = new AddExpenseTransactionfrm();
            frm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ExpenseTransactionBL bl = new ExpenseTransactionBL();
            string searchText = ddlDebitType.Text;
            var lstExpenseTran = new List<ExpenseTransactionDTO>();
            if (ddlDebitType.Text == "BOTH")
            {
                lstExpenseTran = bl.GetExpenseTransaction().Where(et => Convert.ToDateTime(Convert.ToDateTime(et.ExpenseDate).ToShortDateString()) >= Convert.ToDateTime(dtStartDate.Text) && Convert.ToDateTime(Convert.ToDateTime(et.ExpenseDate).ToShortDateString()) <= Convert.ToDateTime(dtEndDate.Text)).ToList();
                dgExpenseTransaction.DataSource = lstExpenseTran;
            }
            else
            {
                lstExpenseTran = bl.GetExpenseTransaction().Where(et => Convert.ToDateTime(Convert.ToDateTime(et.ExpenseDate).ToShortDateString()) >= Convert.ToDateTime(dtStartDate.Text) && Convert.ToDateTime(Convert.ToDateTime(et.ExpenseDate).ToShortDateString()) <= Convert.ToDateTime(dtEndDate.Text))
                    .Where(
                    efu => efu.DebitType.ToUpper().Contains(ddlDebitType.Text.ToUpper())
                    ).ToList();
                dgExpenseTransaction.DataSource = lstExpenseTran;
            }

            if (ddlType.Text != "" && ddlType.Text != "BOTH")
            {
                lstExpenseTran = lstExpenseTran.Where(efu => efu.Type.ToUpper().Contains(ddlType.Text.ToUpper())).ToList();
                dgExpenseTransaction.DataSource = lstExpenseTran;
            }

        }

        private void btnEDIT_Click(object sender, EventArgs e)
        {
            var expenseTranID = Convert.ToInt32(dgExpenseTransaction.CurrentRow.Cells["ExpenseTransactionID"].Value.ToString());
            if (expenseTranID == 0)
            {
                MyMessageBox.ShowBox("Please select a value from the Expense Transaction!!!");
            }
            else
            {
                AddExpenseTransactionfrm obj = new AddExpenseTransactionfrm(expenseTranID, "EDIT");
                obj.ShowDialog();
                LoadDefaultValues();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var expenseTranID = Convert.ToInt32(dgExpenseTransaction.CurrentRow.Cells["ExpenseTransactionID"].Value.ToString());
            if (expenseTranID == 0)
            {
                MyMessageBox.ShowBox("Please select a value from the Expense Transaction!!!");
            }
            else
            {

                var retStr = MyMessageBoxYesorNo.ShowBox("Are you Sure You want to Delete??");
                if (retStr == "1")
                {
                    ExpenseTransactionBL obj = new ExpenseTransactionBL();
                    var flag = obj.DeleteExpenseTransaction(expenseTranID);
                    LoadDefaultValues();
                    if (flag)
                    {
                        MyMessageBox.ShowBox("Expense Transaction Deleted");
                    }
                    else
                    {
                        MyMessageBox.ShowBox("Expense Transaction Failed to Delete.");
                    }
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Export obj = new Export();
            obj.ExportToExcel(dgExpenseTransaction);
        }
    }
}
