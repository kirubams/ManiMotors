using ManiMotors.Customer;
using System;
using System.Windows.Forms;
using MM.BusinessLayer.Customer;
using MessageBoxExample;
using MM.Utilities;
using MM.Model.Customer;
using MM.Model.Vehicle;
using MM.BusinessLayer.Employee;
using MM.BusinessLayer.Vehicle;
using MM.BusinessLayer.Finance;

namespace ManiMotors.Vehicle
{
    public partial class VehicleBookingfrm : Form
    {
        public VehicleBookingfrm()
        {
            InitializeComponent();
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            CustomerInfo frm = new CustomerInfo("SELECT");
            frm.ShowDialog();
            txtCustomerId.Text = frm.Controls["lblCustomerId"].Text;
            txtCustomerName.Text = frm.Controls["lblCustomerName"].Text;
            CustomerBL obj = new CustomerBL();
            if(txtCustomerId.Text != "")
            {
                var lst = obj.GetCustomerEnquiryforCustomerId(Convert.ToInt32(txtCustomerId.Text));
                if(lst.Count > 1)
                {
                    MyMessageBox.ShowBox("Two Enquiries cannot be created for same customer!!!","Error in Enquiry");
                }
                else if(lst.Count == 1)
                {
                    var enquirydto = lst[0];
                    PopulateEnquiry(enquirydto);
                }
            }
        }

        private void PopulateEnquiry(CustomerEnquiryDTO dto)
        {
            txtReferenceBy.Text = dto.ReferenceBy;
            //Employees
            ComboboxItem empItem = new ComboboxItem();
            empItem.Text = dto.SalesExecutiveName;
            empItem.Value = dto.SalesExecutiveId;
            ddlEmployees.Text = empItem.Text;

            //Model1
            if (dto.Model1 != 0)
            {
                ComboboxItem model1item = new ComboboxItem();
                model1item.Text = dto.ModelName1;
                model1item.Value = dto.Model1;
                ddlModel.Text = model1item.Text;
            }
            //Color1
            ddlColor1.Text = dto.Color;

        }

        public void LoadDefaultValues()
        {
            //Load employees
            EmployeeBL e = new EmployeeBL();
            var employeelist = e.GetEmployeelist();
            foreach (var elist in employeelist)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = elist.FirstName;
                item.Value = elist.EmployeeID;
                ddlEmployees.Items.Add(item);
            }

            //Load Vehicle Model Name
            VehicleInfoBL v = new VehicleInfoBL();
            var vlist = v.GetAllVehicleInfo();
            foreach (var vl in vlist)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = vl.ModelName; ;
                item.Value = vl.VehicleInfoID;
                ddlModel.Items.Add(item);
            }

            //Load Colors
            ddlColor1.DataSource = GlobalSetup.colors;
            ddlColor2.DataSource = GlobalSetup.colors;
            ddlColor3.DataSource = GlobalSetup.colors;

            //Load Status
            var slist = v.GetVehicleSalesStatus();
            foreach (var vl in slist)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = vl.Description; ;
                item.Value = vl.VehicleSalesStatusID;
                ddlStatus.Items.Add(item);

            }

            //Load finance
            FinanceInfoBL fBL = new FinanceInfoBL();
            foreach (var vl in fBL.GetAllFinanceInfo())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = vl.Name; 
                item.Value = vl.FinanceInfoID;
                ddlFinance.Items.Add(item);
            }
         

        }

        private void VehicleBookingfrm_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Get Sales Executive Id
            int SalesExecutiveId = 0;
            if (ddlEmployees.SelectedIndex != -1)
            {
                var salesItem = (ComboboxItem)ddlEmployees.SelectedItem;
                SalesExecutiveId = Convert.ToInt32(salesItem.Value);

            }


            int Model=0;
            if (ddlModel.SelectedIndex != -1)
            {
                var modelItem = (ComboboxItem)ddlModel.SelectedItem;
                Model = Convert.ToInt32(modelItem.Value);

            }

            //Get StatusId
            int StatusId = 0;
            if (ddlStatus.SelectedIndex != -1)
            {
                var statusitem = (ComboboxItem)ddlStatus.SelectedItem;
                StatusId = Convert.ToInt32(statusitem.Value);

            }

            //ReadyToDeliver
            bool flgRTOD = false;
            if(rdnRtoDYes.Checked)
            {
                flgRTOD = true;
            }

            //AdvanceAmountMode
            bool flgAdvCash = false;
            if(rdnAdvCash.Checked)
            {
                flgAdvCash = true;
            }

            //CashOrFinance
            bool flagCash = false;
            if(rdnPayCash.Checked)
            {
                flagCash = true;
            }

            //FinancierId

            int? financierId = null;
            if (ddlFinance.SelectedIndex != -1)
            {
                var financeItem = (ComboboxItem)ddlFinance.SelectedItem;
                financierId = Convert.ToInt32(financeItem.Value);

            }

            int? advanceChequeNo = null;
            if(txtChequeNo.Text != "")
            {
                advanceChequeNo = Convert.ToInt32(txtChequeNo.Text);
            }

            //Populate VehicleBookingDTO
            VehicleBookingDTO dto = new VehicleBookingDTO()
            {
                CustomerID = Convert.ToInt32(txtCustomerId.Text),
                ReferenceBy = txtReferenceBy.Text,
                SalesExecutiveId = SalesExecutiveId,
                ModelID = Model,
                Color1 = ddlColor1.Text,
                Color2 = ddlColor2.Text,
                Color3 = ddlColor3.Text,
                CustomerRemark = txtCustomerRemark.Text,
                ClosingRemark = txtDealerRemark.Text,
                ReadyToDeliver = flgRTOD,
                AdvanceAmount = Convert.ToInt32(txtAdvanceAmount.Text),
                AdvanceMode = flgAdvCash,
                AdvanceChequeNo = advanceChequeNo,
                IsCash = flagCash,
                FinancierInfoId = financierId,
                FinancierRemark = txtFinanceRemark.Text,
                StatusId = StatusId,
                FollowupDescription = txtDealerRemark.Text,
                FollowupIsActive = true,
                FollowupDate = Convert.ToDateTime(dtFollowupDate.Text),
                CommittedDate = Convert.ToDateTime(dtCommittedDate.Text),
                CreatedBy = GlobalSetup.Userid,
                CreatedDate = DateTime.Now,
                ModifiedBy = GlobalSetup.Userid,
                ModifiedDate = DateTime.Now
            };

            //Save VehicleBooking 
            VehicleBookingBL bl = new VehicleBookingBL();
            var flag = bl.SaveVehicleBooking(dto);

            if (flag)
            {
                MyMessageBox.ShowBox("Vehicle Booking Saved");
                Clear();
            }
            else
            {
                MyMessageBox.ShowBox("Vehicle Booking Failed to Save");
            }

        }

        private void Clear()
        {
            txtCustomerId.Text = "";
            txtCustomerName.Text = "";
            txtReferenceBy.Text = "";
            ddlEmployees.SelectedIndex = -1;
            ddlModel.SelectedIndex = -1;
            ddlColor1.SelectedIndex = -1;
            ddlColor2.SelectedIndex = -1;
            ddlColor3.SelectedIndex = -1;
            txtCustomerRemark.Text = "";
            txtDealerRemark.Text = "";
            rdnRToDNo.Checked = false;
            rdnRtoDYes.Checked = true;
            txtAdvanceAmount.Text = "";
            rdnAdvCash.Checked = false;
            rdnAdvCheque.Checked = false;
            txtChequeNo.Text = "";
            rdnPayCash.Checked = false;
            rdnPayFinance.Checked = false;
            ddlFinance.SelectedIndex = -1;
            txtFinanceRemark.Text = "";
            ddlStatus.SelectedIndex = -1;
            dtFollowupDate.Text = DateTime.Now.ToString();
            dtCommittedDate.Text = DateTime.Now.ToString();
        }
    }
}
