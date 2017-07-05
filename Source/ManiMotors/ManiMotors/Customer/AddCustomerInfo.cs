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
    public partial class AddCustomerInfo : Form
    {
        public AddCustomerInfo()
        {
            InitializeComponent();
        }

        private int _customerID = 0;
        private string _mode = "";
       
        public AddCustomerInfo(int CustomerID, string mode)
        {
            InitializeComponent();
            this._customerID = CustomerID;
            this._mode = mode;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtAddress1.Text == "" || txtContactNo.Text == "" || txtGender.Text == "" || txtOccupation.Text == "" || txtAreaName.Text == "")
            {
                MyMessageBox.ShowBox("Please Enter All the Mandatory Fields", "Customer Information");
            }
            else
            {
                CustomerDTO info = new CustomerDTO();
                info.CustomerID = _customerID;
                info.Name = txtName.Text;
                info.Address1 = txtAddress1.Text;
                info.Address2 = txtAddress2.Text;
                info.Email = txtEmail.Text;
                info.ContactNo = txtContactNo.Text;
                info.DOB = dtDOB.Value;
                info.Age = Convert.ToInt32(txtAge.Text);
                info.Gender = txtGender.Text;
                info.Occupation = txtOccupation.Text;
                info.AreaName = txtAreaName.Text;
                info.CreatedBy = GlobalSetup.Userid;
                info.CreatedDate = DateTime.Now;
                info.ModifiedDate = DateTime.Now;
                CustomerBL cBL = new CustomerBL();
                var flag = cBL.SaveCustomer(info, _mode);
                if (flag)
                {
                    MyMessageBox.ShowBox("Customer Information Saved", "Customer Information");
                    Clear();
                }
                else
                {
                    MyMessageBox.ShowBox("Customer Information Failed to Save", "Customer Information");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCustomerInfo_Load(object sender, EventArgs e)
        {
            if (_mode == "EDIT")
            {
                PopulateCustomerInfo(_customerID);
            }
        }

        private void PopulateCustomerInfo(int customerId)
        {
            CustomerBL cBL = new CustomerBL();
            var cusInfo = cBL.GetCustomer(customerId);
            txtName.Text = cusInfo.Name;
            txtAddress1.Text = cusInfo.Address1;
            txtAddress2.Text = cusInfo.Address2;
            txtEmail.Text = cusInfo.Email;
            txtContactNo.Text = cusInfo.ContactNo;
            dtDOB.Value = cusInfo.DOB;
            txtAge.Text = cusInfo.Age.ToString();
            txtGender.Text = cusInfo.Gender;
            txtOccupation.Text = cusInfo.Occupation;
            txtAreaName.Text = cusInfo.AreaName;
        }

        private void Clear()
        {
            txtName.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtEmail.Text = "";
            txtContactNo.Text = "";
            dtDOB.Value = DateTime.Now;
            txtAge.Text = "";
            txtGender.Text = "";
            txtOccupation.Text = "";
            txtAreaName.Text = "";
        }
    }
}
