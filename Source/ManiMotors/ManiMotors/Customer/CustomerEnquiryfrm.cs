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
        public CustomerEnquiryfrm()
        {
            InitializeComponent();
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            CustomerInfo frm = new CustomerInfo("SELECT");
            frm.ShowDialog();
            txtCustomerId.Text = frm.Controls["lblCustomerId"].Text;
            txtCustomerName.Text = frm.Controls["lblCustomerName"].Text;
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

            string color = ddlColor.SelectedText;
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
            var flag = obj.SaveCustomerEnquiry(dto, efdto, new CustomerExchangeDTO());
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
    }
}
