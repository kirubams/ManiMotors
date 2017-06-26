using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MM.BusinessLayer.Employee;
using MM.Utilities;
using MM.BusinessLayer.Vehicle;
using MM.Model.Customer;
using MM.BusinessLayer.Customer;
using MessageBoxExample;
namespace ManiMotors.Customer
{
    public partial class CustomerEnquiryfrm : Form
    {
        int ExchangeVehicleId = 0;
        string _mode = "";
        int _enquiryId = 0;
        public CustomerEnquiryfrm()
        {
            InitializeComponent();
        }

        public CustomerEnquiryfrm(string mode, int enquiryId)
        {
            InitializeComponent();
            _mode = mode;
            _enquiryId = enquiryId;
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            CustomerInfo frm = new CustomerInfo("SELECT");
            frm.ShowDialog();
            txtCustomerId.Text = frm.Controls["lblCustomerId"].Text;
            txtCustomerName.Text = frm.Controls["lblCustomerName"].Text;
            rdnEVYes.Enabled = true;
            rdnEVNo.Enabled = true;
        }

        public void LoadDefaultValues()
        {
            //Load employees
            EmployeeBL e = new EmployeeBL();
            var employeelist = e.GetEmployeelist();
            foreach(var elist in employeelist)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = elist.FirstName;
                item.Value = elist.EmployeeID;
                ddlEmployees.Items.Add(item);
            }

            //Load Vehicle Model Name
            VehicleInfoBL v = new VehicleInfoBL();
            var vlist = v.GetAllVehicleInfo();
            foreach(var vl in vlist)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = vl.ModelName; ;
                item.Value = vl.VehicleInfoID;
                ddlModel1.Items.Add(item);
                ddlModel2.Items.Add(item);
                ddlModel3.Items.Add(item);
            }

            //Load Colors
            ddlColor.DataSource = GlobalSetup.colors;

            //Load Status
            var slist = v.GetVehicleSalesStatus();
            foreach (var vl in slist)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = vl.Description; ;
                item.Value = vl.VehicleSalesStatusID;
                ddlStatus.Items.Add(item);
               
            }

        }

        private void CustomerEnquiryfrm_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();

            if(_mode == "EDIT")
            {
                lblPrevRemarks.Visible = true;
                lbldisplayprevremark.Visible = true;
                btnSearchCustomer.Visible = false;
                rdnEVYes.Enabled = true;
                rdnEVNo.Enabled = false;
                PopulateCustomerEnquiry(_enquiryId);
            }
        }

        private void PopulateCustomerEnquiry(int enquiryId)
        {
            CustomerBL cBl = new CustomerBL();
            var customerEnquiry =  cBl.GetCustomerEnquiry(enquiryId);
            //Assign EnquiryInformation to form
            txtCustomerName.Text = customerEnquiry.CustomerName;
            txtCustomerId.Text = customerEnquiry.CustomerID.ToString();
            txtReferenceBy.Text = customerEnquiry.ReferenceBy;
            //Employees
            ComboboxItem empItem = new ComboboxItem();
            empItem.Text = customerEnquiry.SalesExecutiveName;
            empItem.Value = customerEnquiry.SalesExecutiveId;
            ddlEmployees.Text = empItem.Text;

            //Model1
            if (customerEnquiry.Model1 != 0)
            {
                ComboboxItem model1item = new ComboboxItem();
                model1item.Text = customerEnquiry.ModelName1;
                model1item.Value = customerEnquiry.Model1;
                ddlModel1.Text = model1item.Text;
            }
            //Model2
            if (customerEnquiry.Model2 != 0)
            {
                ComboboxItem model2item = new ComboboxItem();
                model2item.Text = customerEnquiry.ModelName2;
                model2item.Value = customerEnquiry.Model2;
                ddlModel2.Text = model2item.Text;
            }
            //Model3
            if (customerEnquiry.Model3 != 0)
            {
                ComboboxItem model3item = new ComboboxItem();
                model3item.Text = customerEnquiry.ModelName3;
                model3item.Value = customerEnquiry.Model3;
                ddlModel3.Text = model3item.Text;
            }
            ddlColor.Text = customerEnquiry.Color;
            if(customerEnquiry.TestDrive)
            {
                rdnTDNo.Checked = false;
                rdnTDYes.Checked = true;
            }

            if (customerEnquiry.IsExchangeVehicle)
            {
                rdnEVNo.Checked = false;
                rdnEVYes.Checked = true;
            }
            if (customerEnquiry.CashorFinance.ToUpper() == "CASH")
            {
                rdnCash.Checked = true;
                rdnFinance.Checked = false;
            }
            else
            {
                rdnCash.Checked = false;
                rdnFinance.Checked = true;
            }
            txtCompetitiveModel.Text = customerEnquiry.CompetitiveModel;

            //Status
            ComboboxItem statusItem = new ComboboxItem();
            statusItem.Text = customerEnquiry.VehicleStatusDescription;
            statusItem.Value = customerEnquiry.VehicleStatusId;
            ddlStatus.Text = statusItem.Text;

            //Populate followup records
            CustomerEnquiryFollowupBL efBl = new CustomerEnquiryFollowupBL();
            var enquityfollowup = efBl.GetCustomerEnquiryFollowupbyId(enquiryId);
            lblPrevRemarks.Text = enquityfollowup.Description;
            dtFollowupDate.Text = enquityfollowup.FollowUpDate.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Get ModelId
            int Model1 = 0;
            if (ddlModel1.SelectedIndex != -1)
            {
                var model1Item = (ComboboxItem)ddlModel1.SelectedItem;
                Model1 = Convert.ToInt32(model1Item.Value);

            }

            int? Model2 = null;
            if (ddlModel2.SelectedIndex != -1)
            {
                var model2Item = (ComboboxItem)ddlModel2.SelectedItem;
                Model2 = Convert.ToInt32(model2Item.Value);

            }

            int? Model3 = null;
            if (ddlModel3.SelectedIndex != -1)
            {
                var model3Item = (ComboboxItem)ddlModel3.SelectedItem;
                Model3 = Convert.ToInt32(model3Item.Value);

            }

            string color = ddlColor.Text;
            bool testDrive = rdnTDYes.Checked;
            bool exchangeVehicle = rdnEVYes.Checked;
            string payment;
            if (rdnCash.Checked) { payment = "Cash"; } else { payment = "Finance"; }

            //Get Sales Executive Id
            int SalesExecutiveId = 0;
            if (ddlEmployees.SelectedIndex != -1)
            {
                var salesItem = (ComboboxItem)ddlEmployees.SelectedItem;
                SalesExecutiveId = Convert.ToInt32(salesItem.Value);

            }

            //Get StatusId
            int StatusId = 0;
            if (ddlStatus.SelectedIndex != -1)
            {
                var statusitem = (ComboboxItem)ddlStatus.SelectedItem;
                StatusId = Convert.ToInt32(statusitem.Value);

            }

            CustomerEnquiryDTO dto = new CustomerEnquiryDTO()
            {
                CustomerID = Convert.ToInt32(txtCustomerId.Text),
                ReferenceBy = txtReferenceBy.Text,
                SalesExecutiveId = SalesExecutiveId,
                Model1 = Model1,
                Model2 = Model2,
                Model3 = Model3,
                Color = color,
                TestDrive = testDrive,
                IsExchangeVehicle = exchangeVehicle,
                CashorFinance = payment,
                CompetitiveModel = txtCompetitiveModel.Text,
                VehicleStatusId = StatusId,
                CreatedBy = GlobalSetup.Userid,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now
            };

            CustomerEnquiryFollowupDTO efdto = new CustomerEnquiryFollowupDTO()
            {
                CustomerId = Convert.ToInt32(txtCustomerId.Text),
                Description = txtRemarks.Text,
                FollowUpDate =  Convert.ToDateTime(dtFollowupDate.Text),
                CreatedBy = GlobalSetup.Userid,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now
            };

            CustomerBL obj = new CustomerBL();
            if(_mode == "EDIT")
            {
                dto.CustomerEnquiryID = _enquiryId;
            }
            var flag = obj.SaveCustomerEnquiry(dto, efdto, ExchangeVehicleId, _mode);
            if (flag)
            {
                MyMessageBox.ShowBox("Vehicle Enquiry Saved");
                Clear();
            }
            else
            {
                MyMessageBox.ShowBox("Vehicle Enquiry Failed to Save");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear()
        {
            txtCustomerId.Text = "";
            txtCustomerName.Text = "";
            txtReferenceBy.Text = "";
            ddlEmployees.SelectedIndex = -1;
            ddlModel1.SelectedIndex = -1;
            ddlModel2.SelectedIndex = -1;
            ddlModel3.SelectedIndex = -1;
            txtRemarks.Text = "";
            ddlColor.SelectedIndex = 0;
            rdnTDNo.Checked = true;
            rdnTDYes.Checked = false;
            rdnEVNo.Checked = true;
            rdnEVYes.Checked = false;
            rdnFinance.Checked = false;
            rdnCash.Checked = false;
            txtCompetitiveModel.Text = "";
            ddlStatus.SelectedIndex = -1;
            dtFollowupDate.Text = DateTime.Now.ToString();
        }

        private void rdnEVYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnEVYes.Checked && _mode != "EDIT")
            {
                CustomerExchangefrm frm = new CustomerExchangefrm("SELECT",txtCustomerName.Text, txtCustomerId.Text);
                frm.ShowDialog();
                if (frm.Controls["txtExchangeVehilceId"].Text != null && frm.Controls["txtExchangeVehilceId"].Text != "")
                {
                    ExchangeVehicleId = Convert.ToInt32(frm.Controls["txtExchangeVehilceId"].Text);
                }
                else
                {
                    rdnEVNo.Checked = true;
                    rdnEVYes.Checked = false;
                }
            }
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dtFollowupDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtCompetitiveModel_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rdnEVNo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rdnTDNo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdnTDYes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void ddlColor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void ddlModel3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void ddlModel2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void ddlModel1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ddlEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rdnFinance_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdnCash_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pnlGrid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblMarginPrice_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblModelName_Click(object sender, EventArgs e)
        {

        }

        private void txtReferenceBy_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtCustomerId_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbldisplayprevremark_Click(object sender, EventArgs e)
        {

        }

        private void lblPrevRemarks_Click(object sender, EventArgs e)
        {

        }
    }
}
