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
    public partial class AddExpenseTransactionfrm : Form
    {
        public int _expenseTransactionID = 0;
        public string _mode = "";
        public AddExpenseTransactionfrm()
        {
            InitializeComponent();
        }

        public AddExpenseTransactionfrm(int ExpenseTransactionID, string mode)
        {
            InitializeComponent();
            _expenseTransactionID = ExpenseTransactionID;
            _mode = mode;
        }

        private void AddExpenseTransactionfrm_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
            if(_mode == "EDIT")
            {
                PopulateValues();
            }
        }

        private void PopulateValues()
        {
            ExpenseTransactionBL bl = new ExpenseTransactionBL();
            var etr = bl.GetExpenseTransaction().FirstOrDefault(et => et.ExpenseTransactionID == _expenseTransactionID);

            ComboboxItem item = new ComboboxItem();
            item.Text = etr.ExpenseDescription;
            item.Value = etr.ExpenseID;
            ddlExpenses.Text = item.Text;
            ddlDebitType.Text = "";
            ddlDebitType.SelectedText = etr.DebitType;
            txtAmount.Text = etr.Amount.ToString();
            txtComments.Text = etr.Comments;
            dtExpDate.Text = etr.ExpenseDate.ToShortDateString();
        }

        private void LoadDefaultValues()
        {
            ExpensesBL bl = new ExpensesBL();
            ddlExpenses.Items.Clear();
            var expenseList = bl.GetExpenses();

            foreach (var expenses in expenseList)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = expenses.Description;
                item.Value = expenses.ExpenseID;
                ddlExpenses.Items.Add(item);
            }

            //Load debit type
            ddlDebitType.DataSource = GlobalSetup.debitTypes;
        }

        private bool validate()
        {
            var flag = true;
            if (ddlExpenses.Text == string.Empty || txtAmount.Text == "" || ddlDebitType.Text == "" || txtComments.Text == "")
            {
                flag = false;
            }
            return flag;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                //Populate ExpenseTransactionDTO
                var expense = (ComboboxItem)ddlExpenses.SelectedItem;
                var Amount = txtAmount.Text;
                var Comments = txtComments.Text;
                ExpenseTransactionDTO expenseTransactionDTO = new ExpenseTransactionDTO();
                expenseTransactionDTO.ExpenseID = Convert.ToInt32(expense.Value);
                expenseTransactionDTO.Comments = Comments;
                expenseTransactionDTO.Amount = Convert.ToInt32(Amount);
                expenseTransactionDTO.DebitType = ddlDebitType.Text;
                expenseTransactionDTO.ExpenseDate = Convert.ToDateTime(dtExpDate.Text);
                expenseTransactionDTO.CreatedBy = GlobalSetup.Userid;
                expenseTransactionDTO.CreatedDate = DateTime.Now;
                expenseTransactionDTO.ModifiedDate = null;
                expenseTransactionDTO.ModifiedBy = null;

                ExpenseTransactionBL obj = new ExpenseTransactionBL();
                bool result = false;
                if (_mode == "EDIT")
                {
                    expenseTransactionDTO.ExpenseTransactionID = _expenseTransactionID;
                    result = obj.UpdateExpenseTransaction(expenseTransactionDTO);
                }
                else
                {
                    result = obj.AddExpenseTransaction(expenseTransactionDTO);
                }

                if (result)
                {
                    MyMessageBox.ShowBox("Expense Transaction Saved!!!");
                }
                else
                {
                    MyMessageBox.ShowBox("Save Failed !!!");
                }
            }
            else
            {
                MyMessageBox.ShowBox("Please enter all mandatory fields!!!");
            }
            this.Clear();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear()
        {
            ddlExpenses.Items.Clear();
            LoadDefaultValues();
            txtAmount.Text = "";
            txtComments.Text = "";
        }
    }
}
