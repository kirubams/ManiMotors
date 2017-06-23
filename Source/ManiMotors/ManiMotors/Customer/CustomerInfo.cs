using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MM.Model.Customer;
using MM.BusinessLayer.Customer;
using MM.Utilities;
using MessageBoxExample;

namespace ManiMotors.Customer
{
    public partial class CustomerInfo : Form
    {
        public CustomerInfo()
        {
            InitializeComponent();
        }

        public CustomerInfo(string mode)
        {
            InitializeComponent();
            if(mode == "SELECT")
            {
                btnSelect.Visible = true;
                btnEDIT.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void LoadDefaultForSelect()
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCustomerInfo frm = new AddCustomerInfo();
            frm.ShowDialog();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var name = txtName.Text;
            var contactNo = txtContactNo.Text;
            CustomerBL obj = new CustomerBL();
            var filterefInfo = obj.GetAllCustomers().Where(i => i.Name.ToUpper().Contains(name.ToUpper()) && i.ContactNo.ToUpper().Contains(contactNo.ToUpper())).ToList();
            dgCustomerInfo.DataSource = filterefInfo;
        }

        private void CustomerInfo_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
        }

        private void btnEDIT_Click(object sender, EventArgs e)
        {
            var customerID = Convert.ToInt32(dgCustomerInfo.CurrentRow.Cells["CustomerID"].Value.ToString());
            if (customerID == 0)
            {
                MyMessageBox.ShowBox("Please select a value from the Customer Info!!!");
            }
            else
            {
                AddCustomerInfo obj = new AddCustomerInfo(customerID, "EDIT");
                obj.ShowDialog();
                LoadDefaultValues();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var customerID = Convert.ToInt32(dgCustomerInfo.CurrentRow.Cells["CustomerID"].Value.ToString());
            if (customerID == 0)
            {
                MyMessageBox.ShowBox("Please select a value from the Vehicle Info!!!");
            }
            else
            {
                CustomerBL obj = new CustomerBL();
                var flag = obj.DeleteCustomer(customerID);
                LoadDefaultValues();
                if (flag)
                {
                    MyMessageBox.ShowBox("Vehicle Information Deleted");
                }
                else
                {
                    MyMessageBox.ShowBox("Vehicle Information Failed to Delete.");
                }
            }
        }

        private void LoadDefaultValues()
        {
            CustomerBL obj = new CustomerBL();
            dgCustomerInfo.DataSource = obj.GetAllCustomers();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            lblCustomerId.Text = dgCustomerInfo.CurrentRow.Cells["CustomerID"].Value.ToString();
            lblCustomerName.Text = dgCustomerInfo.CurrentRow.Cells["Name"].Value.ToString();
            this.Close();
        }
    }
}
