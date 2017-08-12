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
using MM.BusinessLayer.SpareParts;
using ManiMotors.SpareParts;
using System.Collections.Generic;

namespace ManiMotors.Vehicle
{
    public partial class VehicleBookingfrm : Form
    {
        private int _vehicleEnquiryId = 0;
        string _mode = "";
        int _vehicleBookingId = 0;
        List<int> lstSPaltid = null;
        public VehicleBookingfrm()
        {
            InitializeComponent();
        }

        public VehicleBookingfrm(string mode, int vehicleBookingId)
        {
            InitializeComponent();
            _mode = mode;
            _vehicleBookingId = vehicleBookingId;
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
                    _vehicleEnquiryId = enquirydto.CustomerEnquiryID;
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
            ddlColor2.DataSource = GlobalSetup.colors2;
            ddlColor3.DataSource = GlobalSetup.colors3;

            //Load Status
            string searchMode = "";
            if(_mode != "" && _mode != "EDIT")
            {
                searchMode = "ALL";
            }
            var slist = v.GetVehicleSalesStatus(searchMode);
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

            if (_mode == "EDIT")
            {
                lblPrevRemark1.Visible = true;
                lbldisplayprevremark.Visible = true;
                btnSearchCustomer.Visible = false;
                pnlDelivery.Visible = false;
                PopulateVehicleBooking(_vehicleBookingId);
            }

            if(_mode == "ALLOTMENT")
            {
                lblPrevRemark1.Visible = true;
                lbldisplayprevremark.Visible = true;
                btnSearchCustomer.Visible = false;
                PopulateVehicleBooking(_vehicleBookingId);
                pnlAllotment.Visible = true;
                btnSave.Visible = false;
                btnCancel.Visible = false;
                //pnlCust.Enabled = false;
                pnlDealer.Enabled = false;
                pnlDelivery.Enabled = false;
                lblTitle.Text = "Allotment Form";
            }

            if (_mode == "DELIVERY")
            {
                lblPrevRemark1.Visible = true;
                lbldisplayprevremark.Visible = true;
                btnSearchCustomer.Visible = false;
                PopulateVehicleBooking(_vehicleBookingId);
                pnlAllotment.Enabled = false;
                pnlCust.Enabled = false;
                pnlDealer.Visible = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                lblTitle.Text = "Delivery Form";
                ddlStatus.SelectedIndex = 4;// Mark it as Delivered
            }
        }

        private void PopulateVehicleBooking(int vehicleBookingId)
        {
            VehicleBookingBL vBl = new VehicleBookingBL();
            var vclBooking = vBl.GetVehicleBooking(vehicleBookingId);
            _vehicleEnquiryId = vclBooking.VehicleEnquiryID ?? 0;
            //Assign EnquiryInformation to form
            txtCustomerName.Text = vclBooking.CustomerName;
            txtCustomerId.Text = vclBooking.CustomerID.ToString();
            txtReferenceBy.Text = vclBooking.ReferenceBy;
            //Employees
            ComboboxItem empItem = new ComboboxItem();
            empItem.Text = vclBooking.SalesExecutiveName;
            empItem.Value = vclBooking.SalesExecutiveId;
            ddlEmployees.Text = empItem.Text;

            //Model1
            if (vclBooking.ModelID != 0)
            {
                ComboboxItem model1item = new ComboboxItem();
                model1item.Text = vclBooking.ModelName;
                model1item.Value = vclBooking.ModelID;
                ddlModel.Text = model1item.Text;
            }
            
            //Bind Colors
            ddlColor1.Text = vclBooking.Color1;
            ddlColor2.Text = vclBooking.Color2;
            ddlColor3.Text = vclBooking.Color3;

            txtCustomerRemark.Text = vclBooking.CustomerRemark;
            
            //Advance Amount assigning
            string advAmount = "";
            if (vclBooking.AdvanceAmount != null || vclBooking.AdvanceAmount != 0)
            {
                advAmount = vclBooking.AdvanceAmount.ToString();
            }

            txtAdvanceAmount.Text = advAmount;

            //Advance Mode
            if (vclBooking.AdvanceMode)
            {
                rdnAdvCash.Checked = true;
                rdnAdvCheque.Checked = false;
            }
            else
            {
                rdnAdvCash.Checked = false;
                rdnAdvCheque.Checked = true;
            }
            //Advance Cheque no assigning
            string cheqNo = "";
            if (vclBooking.AdvanceChequeNo != null || vclBooking.AdvanceChequeNo != 0)
            {
                cheqNo = vclBooking.AdvanceChequeNo.ToString();
            }

            txtChequeNo.Text = cheqNo;

            //Payment
            if(vclBooking.IsCash)
            {
                rdnPayCash.Checked = true;
                rdnPayFinance.Checked = false;
            }
            else
            {
                rdnPayCash.Checked = false;
                rdnPayFinance.Checked = true;
            }

            //Financier
            if (vclBooking.FinancierInfoId != 0)
            {
                ComboboxItem financeItem = new ComboboxItem();
                financeItem.Text = vclBooking.FinancierName;
                financeItem.Value = vclBooking.FinancierInfoId;
                ddlFinance.Text = financeItem.Text;
            }

            txtFinanceRemark.Text = vclBooking.FinancierRemark;

            if(vclBooking.ReadyToDeliver ?? false)
            {
                rdnRtoDYes.Checked = true;
            }
            else
            {
                rdnRToDNo.Checked = true;
            }

            //Status
            ComboboxItem statusItem = new ComboboxItem();
            statusItem.Text = vclBooking.StatusDescription;
            statusItem.Value = vclBooking.StatusId;
            ddlStatus.Text = statusItem.Text;

            dtCommittedDate.Text = vclBooking.CommittedDate.ToString();

            //Populate followup records
            VehicleBookingFollowUpBL vbfBL = new VehicleBookingFollowUpBL();
            var bookingFollowup = vbfBL.GetVehicleBookingFollowupbyId(vehicleBookingId);
            lblPrevRemark1.Text = bookingFollowup.Description;
            dtFollowupDate.Text = bookingFollowup.FollowUpDate.ToString();

            //Populate Allotments
            if (vclBooking.VehicleBookingAllotmentId != 0)
            {
               if (vclBooking.VehicleBookingAllotmentId.ToString() != "")
                {
                    VehicleAllotmentBL bl = new VehicleAllotmentBL();
                    int inventoryId = bl.GeInventoryId(vclBooking.VehicleBookingAllotmentId ?? 0);
                    if(inventoryId != 0)
                    {
                        txtVehicleAltInventoryId.Text = inventoryId.ToString();
                    }
                    EnableEditForVehicleAllotment();
                }
            }

            ////Populate Finance Allotment
            if (vclBooking.FinanceAllotmentId != 0)
            {
                txtFinanceAllotmentId.Text = vclBooking.FinanceAllotmentId.ToString();
                if (txtFinanceAllotmentId.Text != "")
                {
                    EnableEditForFinanceAllotment();
                }
            }

            //Populate Insurance Allotment
            if (vclBooking.InsuranceAllotmentId != 0)
            {
                txtInsuranceAllotmentId.Text = vclBooking.InsuranceAllotmentId.ToString();
                if (txtInsuranceAllotmentId.Text != "")
                {
                    EnableEditForInsuranceAllotment();
                }
            }

            // Populate RTO Allotment
            if (vclBooking.RTOAllotmentId != 0)
            {
                txtIRTOAllotmentId.Text = vclBooking.RTOAllotmentId.ToString();
                if (txtIRTOAllotmentId.Text != "")
                {
                    EnableEditForRTOAllotment();
                }
            }

            //Populate Spare Parts Allotment
            SparePartsAllotmentBL obj = new SparePartsAllotmentBL();
            var lst = obj.GetSparePartsAllotmentbyBookingId(vehicleBookingId);
            lstSPaltid = new List<int>();
            if(lst.Count > 0)
            {
                string spAltId = "";
                foreach(var alt in lst)
                {
                    lstSPaltid.Add(alt.SparePartsBookingAllotmentID);
                    spAltId = spAltId + alt.SparePartsBookingAllotmentID + "__" + alt.SparePartsInventoryID + "&&";
  
                }
                txtIRTOAllotmentId.Text = spAltId;
                EnableEditForSPAllotment();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtCustomerName.Text == "" || ddlEmployees.SelectedIndex == -1 || ddlModel.SelectedIndex == -1 || txtDealerRemark.Text == "" || ddlStatus.SelectedIndex == -1 || (!rdnPayCash.Checked && !rdnPayFinance.Checked))
            {
                MyMessageBox.ShowBox("Please enter all Mandatory Fields !!!");
                return;
            }

            //ReadyToDeliver
            bool flgRTOD = false;
            if (rdnRtoDYes.Checked)
            {
                flgRTOD = true;
                string result = MyMessageBoxYesorNo.ShowBox("Are you sure to Deliver the Vehicles?  Please validate Vehicle, Spare Parts, Insurance, Finance and RTO is Alloted");
                if(result != "1")
                {
                    return;
                }
            }

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
                VehicleEnquiryID = _vehicleEnquiryId,
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
                AdvanceChequeNo = advanceChequeNo ?? 0,
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
            if (_mode == "EDIT" || _mode == "DELIVERY")
            {
                dto.VehicleBookingID = _vehicleBookingId;
            }
            //Save VehicleBooking 
            VehicleBookingBL bl = new VehicleBookingBL();
            var flag = bl.SaveVehicleBooking(dto,_mode);

            if (flag)
            {
                MyMessageBox.ShowBox("Vehicle Booking Saved");
                Clear();
                this.Close();
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
            rdnRtoDYes.Checked = false;
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

        private void btnAddVehicleAlt_Click(object sender, EventArgs e)
        {
            VehicleInventoryfrm frm = new VehicleInventoryfrm("ADD", _vehicleBookingId);
            frm.ShowDialog();
            txtVehicleAltInventoryId.Text = frm.Controls["lblVehicleInventoryId"].Text;
            if(txtVehicleAltInventoryId.Text != "" && txtVehicleAltInventoryId.Text != "label7")
            {
                EnableEditForVehicleAllotment();
            }
        }

        private void EnableEditForVehicleAllotment()
        {
            btnEditVehicleAlt.Visible = true;
            btnAddVehicleAlt.Visible = false;
            rdnYesVehAlt.Checked = true;
            rdnNoVehAlt.Checked = false;
        }

        private void btnEditVehicleAlt_Click(object sender, EventArgs e)
        {
            VehicleInventoryfrm frm = new VehicleInventoryfrm("EDIT", _vehicleBookingId, Convert.ToInt32(txtVehicleAltInventoryId.Text));
            frm.ShowDialog();
            txtVehicleAltInventoryId.Text = frm.Controls["lblVehicleInventoryId"].Text;
            if (txtVehicleAltInventoryId.Text != "" && txtVehicleAltInventoryId.Text != "label7")
            {
                EnableEditForVehicleAllotment();
            }
        }

        private void btnAddFinAlt_Click(object sender, EventArgs e)
        {
            AddFinanceAllotmentfrm frm = new AddFinanceAllotmentfrm("ADD", _vehicleBookingId);
            frm.ShowDialog();
            txtFinanceAllotmentId.Text = frm.Controls["lblFinanceAllotmentId"].Text;
            if (txtFinanceAllotmentId.Text != "" && txtFinanceAllotmentId.Text != "lblFinanceAllotmentId")
            {
                EnableEditForFinanceAllotment();
            }
        }

        private void EnableEditForFinanceAllotment()
        {
            btnEditFinAlt.Visible = true;
            btnAddFinAlt.Visible = false;
            rdnYesFinAlt.Checked = true;
            rdnNoFinAlt.Checked = false;
        }

        private void btnEditFinAlt_Click(object sender, EventArgs e)
        {
            //FinanceAllotmentId 
            var _financeAllotmentId = 0;
            if(txtFinanceAllotmentId.Text != "" && txtFinanceAllotmentId.Text != "lblFinanceAllotmentId")
            {
                _financeAllotmentId = Convert.ToInt32(txtFinanceAllotmentId.Text);
            }
            AddFinanceAllotmentfrm frm = new AddFinanceAllotmentfrm("EDIT", _vehicleBookingId, _financeAllotmentId);
            frm.ShowDialog();
            txtFinanceAllotmentId.Text = frm.Controls["lblFinanceAllotmentId"].Text;
            if (txtFinanceAllotmentId.Text != "")
            {
                EnableEditForFinanceAllotment();
            }
        }

        private void btnAddInsAlt_Click(object sender, EventArgs e)
        {

            AddInsuranceAllotment frm = new AddInsuranceAllotment("ADD", _vehicleBookingId);
            frm.ShowDialog();
            txtInsuranceAllotmentId.Text = frm.Controls["lblnsuranceAllotmentId"].Text;
            if (txtInsuranceAllotmentId.Text != "" && txtInsuranceAllotmentId.Text != "lblnsuranceAllotmentId")
            {
                EnableEditForInsuranceAllotment();
            }

        }


        private void EnableEditForInsuranceAllotment()
        {
            btnEditInsAlt.Visible = true;
            btnAddInsAlt.Visible = false;
            rdnYesInsAlt.Checked = true;
            rdnNoInsAlt.Checked = false;
        }

        private void btnEditInsAlt_Click(object sender, EventArgs e)
        {
            //InsuranceAllotmentId
            var _insuranceAllotmentId = 0;
            if (txtInsuranceAllotmentId.Text != "")
            {
                _insuranceAllotmentId = Convert.ToInt32(txtInsuranceAllotmentId.Text);
            }
            AddInsuranceAllotment frm = new AddInsuranceAllotment("EDIT", _vehicleBookingId, _insuranceAllotmentId);
            frm.ShowDialog();
            txtInsuranceAllotmentId.Text = frm.Controls["lblnsuranceAllotmentId"].Text;
            if (txtInsuranceAllotmentId.Text != "" && txtInsuranceAllotmentId.Text != "lblnsuranceAllotmentId")
            {
                EnableEditForInsuranceAllotment();
            }
        }

        private void btnAddRTOAlt_Click(object sender, EventArgs e)
        {
            AddRTOAllotmentfrm frm = new AddRTOAllotmentfrm("ADD", _vehicleBookingId);
            frm.ShowDialog();
            txtIRTOAllotmentId.Text = frm.Controls["lblRTOAllotmentId"].Text;
            if (txtIRTOAllotmentId.Text != "" && txtIRTOAllotmentId.Text != "lblRTOAllotmentId")
            {
                EnableEditForRTOAllotment();
            }

        }

        private void EnableEditForRTOAllotment()
        {
            btnEditRTOAlt.Visible = true;
            btnAddRTOAlt.Visible = false;
            rdnYesRTOAlt.Checked = true;
            rdnNoRTOAlt.Checked = false;
        }

        private void btnEditRTOAlt_Click(object sender, EventArgs e)
        {
            //RTOAllotmentId
            var _rtoAllotmentId = 0;
            if (txtIRTOAllotmentId.Text != "" && txtIRTOAllotmentId.Text != "lblRTOAllotmentId")
            {
                _rtoAllotmentId = Convert.ToInt32(txtIRTOAllotmentId.Text);
            }
            AddRTOAllotmentfrm frm = new AddRTOAllotmentfrm("EDIT", _vehicleBookingId, _rtoAllotmentId);
            frm.ShowDialog();
            txtIRTOAllotmentId.Text = frm.Controls["lblRTOAllotmentId"].Text;
            if (txtIRTOAllotmentId.Text != "" && txtIRTOAllotmentId.Text != "lblRTOAllotmentId")
            {
                EnableEditForRTOAllotment();
            }
        }

        private void EnableEditForSPAllotment()
        {
            btnEditSPAlt.Visible = true;
            btnAddSPAlt.Visible = false;
            rdnYesSPAlt.Checked = true;
            rdnNoSPAlt.Checked = false;
        }

        private void btnAddSPAlt_Click(object sender, EventArgs e)
        {
            SparePartsInventoryfrm frm = new SparePartsInventoryfrm("ADD", _vehicleBookingId);
            frm.ShowDialog();
            txtSPAltInventoryId.Text = frm.Controls["lblSPInventoryId"].Text;
            if (txtSPAltInventoryId.Text != "" && txtSPAltInventoryId.Text != "lblSPInventoryId")
            {
                EnableEditForSPAllotment();
            }
        }

        private void btnEditSPAlt_Click(object sender, EventArgs e)
        {
            SparePartsInventoryfrm frm = new SparePartsInventoryfrm("EDIT", _vehicleBookingId, lstSPaltid);
            frm.ShowDialog();
            txtSPAltInventoryId.Text = frm.Controls["lblSPInventoryId"].Text;
            if (txtSPAltInventoryId.Text != "" && txtSPAltInventoryId.Text != "lblSPInventoryId")
            {
                EnableEditForSPAllotment();
            }
        }

        
    }
}
