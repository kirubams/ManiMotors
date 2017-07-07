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
    public partial class Expensesfrm : Form
    {
        private string btntext = "ADD";
        public Expensesfrm()
        {
            InitializeComponent();
        }

        private void Expensesfrm_Load(object sender, EventArgs e)
        {
            LoadExpenses();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                if (btntext == "ADD")
                {
                    ExpensesDTO expenseDTO = new ExpensesDTO();
                    expenseDTO.Description = txtDescription.Text;
                    expenseDTO.CreatedBy = GlobalSetup.Userid;
                    expenseDTO.CreatedDate = DateTime.Now;
                    expenseDTO.ModifiedDate = DateTime.Now;
                    ExpensesBL expen = new ExpensesBL();
                    var result = expen.AddExpenses(expenseDTO);
                    LoadExpenses();

                    if (result)
                    {
                        MyMessageBox.ShowBox("Expense is Saved", "Expense");
                    }
                    else
                    {
                        MyMessageBox.ShowBox("Expense Save is failed !!!");
                    }
                }
                else
                {
                    ExpensesDTO expenseDTO = new ExpensesDTO();
                    expenseDTO.Description = txtDescription.Text;
                    expenseDTO.ExpenseID = Convert.ToInt32(dgExpenses.CurrentRow.Cells["ExpenseID"].Value);
                    expenseDTO.ModifiedDate = DateTime.Now;
                    expenseDTO.ModifiedBy = GlobalSetup.Userid;
                    ExpensesBL exp = new ExpensesBL();
                    var result = exp.UpdateExpenses(expenseDTO);
                    btntext = "ADD";

                }
                clear();
                LoadExpenses();
            }
            else
            {
                MyMessageBox.ShowBox("Description cannot be Empty !!!");
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selectedName = dgExpenses.CurrentRow.Cells["Description"].Value.ToString();

            txtDescription.Text = selectedName;
            btntext = "Update";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = MyMessageBoxYesorNo.ShowBox("Are you sure to Delete??");
            if (id == "1")
            {
                var expenseID = dgExpenses.CurrentRow.Cells["ExpenseID"].Value.ToString();
                ExpensesBL expen = new ExpensesBL();
                var result = expen.DeleteExpenses(Convert.ToInt32(expenseID));
                if (result)
                {
                    MyMessageBox.ShowBox("Expenses Deleted");
                }
                else
                {
                    MyMessageBox.ShowBox("Failed");
                }
                clear();
                LoadExpenses();
            }

        }
        private void LoadExpenses()
        {
            ExpensesBL expenseBL = new ExpensesBL();

            dgExpenses.DataSource = expenseBL.GetExpenses().Select(o => new
            { ExpenseID = o.ExpenseID, Description = o.Description}).ToList();

            if (dgExpenses.Rows.Count == 0)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }

        }

        private void clear()
        {
            txtDescription.Text = "";
        }

        private bool validate()
        {
            var flag = true;
            if (txtDescription.Text == string.Empty)
            {
                flag = false;
            }
            return flag;
        }
    }
}
