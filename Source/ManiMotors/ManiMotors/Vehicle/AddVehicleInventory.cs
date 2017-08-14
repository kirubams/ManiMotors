using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MM.Model.Vehicle;
using MM.BusinessLayer.Vehicle;
using MM.Utilities;
using MessageBoxExample;

namespace ManiMotors.Vehicle
{
    public partial class AddVehicleInventory : Form
    {
        private int _vehicleInventoryID = 0;
        private string _mode = "";
        public AddVehicleInventory()
        {
            InitializeComponent();
        }

        public AddVehicleInventory(int vehicleInventoryID, string mode)
        {
            InitializeComponent();
            this._vehicleInventoryID = vehicleInventoryID;
            this._mode = mode;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlModelName.SelectedIndex == -1 || txtChasisNo.Text == "" || txtEngineNo.Text == "" || ddlColor.SelectedIndex == -1 || txtServiceBookNo.Text == "" || txtKeyNo.Text == "" || txtBatteryNo.Text == "" || txtBatteryMake.Text == "" || ddlInvStatus.SelectedIndex == -1 || txtShowRoomPrice.Text == "" || txtLTRTOtherExp.Text == "" || txtInsurancePrice.Text == "" || txtMarginPrice.Text == "" || txt50Margin.Text == "" || txt70Margin.Text == "" || txtWarranty.Text == "" || txtOnRoadPrice.Text == "" || (!rdn50Margin.Checked && !rdn70Margin.Checked && !rdnMarginPrice.Checked))
            {
                MyMessageBox.ShowBox("Please Select All Mandatory Fields !!!");
                return;
            }

            if(txtShowRoomPrice.Text == "0" || txtLTRTOtherExp.Text == "0" || txtInsurancePrice.Text == "0" || txtMarginPrice.Text == "0" || txt50Margin.Text == "0" || txt70Margin.Text == "0" || txtWarranty.Text == "0" || txtOnRoadPrice.Text == "0")
            {
                MyMessageBox.ShowBox("Price cannot be 0 !!!");
                return;
            }

            if (ddlInvStatus.SelectedIndex != 0 && txtRemarks.Text == "")
            {
                MyMessageBox.ShowBox("Remarks Cannot be Empty !!!");
                return;
            }
            VehicleInventoryDTO info = new VehicleInventoryDTO();
            var selItem = (ComboboxItem)ddlModelName.SelectedItem;
            info.VehicleInventoryID = _vehicleInventoryID;
            info.VehicleInfoID = Convert.ToInt32(selItem.Value);
            info.ChasisNo = txtChasisNo.Text;
            info.EngineNo = txtEngineNo.Text;
            info.Color = ddlColor.SelectedItem.ToString();
            info.MfgDate = Convert.ToDateTime(dtMfgDate.Text);
            info.KeyNo = txtKeyNo.Text;
            info.BatteryMake = txtBatteryMake.Text;
            info.BatteryNo = txtBatteryNo.Text;
            info.ServiceBookNo = txtServiceBookNo.Text;
            info.CreatedDate = System.DateTime.Now;
            info.CreatedBy = GlobalSetup.Userid;
            info.ModifiedDate = System.DateTime.Now;
            info.ModifiedBy = GlobalSetup.Userid;
            info.Is50PerMarginPrice = rdn50Margin.Checked;
            info.Is70PerMarginPrice = rdn70Margin.Checked;
            info.IsMarginPrice = rdnMarginPrice.Checked;
            info.ExShowRoomPrice = Convert.ToInt32(txtShowRoomPrice.Text);
            info.LT_RT_OtherExp = Convert.ToInt32(txtLTRTOtherExp.Text);
            info.InsurancePrice = Convert.ToInt32(txtInsurancePrice.Text);
            info.OnRoadPrice = Convert.ToInt32(txtOnRoadPrice.Text);
            info.MarginPrice = Convert.ToInt32(txtMarginPrice.Text);
            info.Margin50 = Convert.ToInt32(txt50Margin.Text);
            info.Margin70 = Convert.ToInt32(txt70Margin.Text);
            info.WarrantyPrice = Convert.ToInt32(txtWarranty.Text);
            info.Remarks = txtRemarks.Text;
            var invSelitem = (ComboboxItem)ddlInvStatus.SelectedItem;
            info.VehicleInventoryStatusTypeID = Convert.ToInt32(invSelitem.Value);
            info.Remarks = txtRemarks.Text;

            VehicleInventoryBL viBL = new VehicleInventoryBL();
            var flag = viBL.SaveInventoryVehicle(info, _mode);
            if (flag)
            {
                MyMessageBox.ShowBox("Vehicle Inventory Saved", "Vehicle Inventory");
                Clear();
            }
            else
            {
                MyMessageBox.ShowBox("Vehicle Inventory Failed to Save", "Vehicle Inventory");
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddVehicleInventory_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
            if (_mode == "EDIT")
            {
                PopulateInventoryVehicle(_vehicleInventoryID);
            }
        }

        private void PopulateInventoryVehicle(int vehicleInventoryID)
        {
            VehicleInventoryBL obj = new VehicleInventoryBL();
            var vehInv = obj.GetAllVehicleInventory().Where(v => v.VehicleInventoryID == vehicleInventoryID).FirstOrDefault();
            ComboboxItem selitem = new ComboboxItem();
            selitem.Text = vehInv.VehicleModelName;
            selitem.Value = vehInv.VehicleInfoID;
            ddlModelName.Text = selitem.Text;
            txtChasisNo.Text = vehInv.ChasisNo;
            txtEngineNo.Text = vehInv.EngineNo;
            ddlColor.SelectedItem = vehInv.Color;
            dtMfgDate.Value = vehInv.MfgDate;
            txtKeyNo.Text = vehInv.KeyNo;
            txtBatteryMake.Text = vehInv.BatteryMake;
            txtBatteryNo.Text = vehInv.BatteryNo;
            txtServiceBookNo.Text = vehInv.ServiceBookNo;
            rdnMarginPrice.Checked = vehInv.IsMarginPrice;
            rdn50Margin.Checked = vehInv.Is50PerMarginPrice;
            rdn70Margin.Checked = vehInv.Is70PerMarginPrice;
            //InventoryStatus Populate
            var vehInvStatus = obj.GetInventoryStatusType().Where(iv => iv.VehicleInventoryStatusTypeID == vehInv.VehicleInventoryStatusTypeID).FirstOrDefault();
            ComboboxItem selInvitem = new ComboboxItem();
            selInvitem.Text = vehInvStatus.Description;
            selInvitem.Value = vehInvStatus.VehicleInventoryStatusTypeID;
            ddlInvStatus.Text = selInvitem.Text;

            txtShowRoomPrice.Text = vehInv.ExShowRoomPrice.ToString();
            txtLTRTOtherExp.Text = vehInv.LT_RT_OtherExp.ToString();
            txtInsurancePrice.Text = vehInv.InsurancePrice.ToString();
            txtMarginPrice.Text = vehInv.MarginPrice.ToString();
            txt50Margin.Text = vehInv.Margin50.ToString();
            txt70Margin.Text = vehInv.Margin70.ToString();
            txtWarranty.Text = vehInv.WarrantyPrice.ToString();
            txtOnRoadPrice.Text = vehInv.OnRoadPrice.ToString();
            txtRemarks.Text = vehInv.Remarks;
        }

        private void LoadDefaultValues()
        {
            //Load All Model Name
            VehicleInfoBL viBL = new VehicleInfoBL();
            foreach (var vehicleInfo in viBL.GetAllVehicleInfo())
            {
                ComboboxItem obj = new ComboboxItem();
                obj.Text = vehicleInfo.ModelName;
                obj.Value = vehicleInfo.VehicleInfoID;
                ddlModelName.Items.Add(obj);
            }

            //Load Default Colors
            ddlColor.DataSource = GlobalSetup.colors;

            //Load Inventory Status
            ddlInvStatus.Items.Clear();
            VehicleInventoryBL obj2 = new VehicleInventoryBL();
            foreach (var status in obj2.GetInventoryStatusType())
            {
                ComboboxItem itemInventoryStatus = new ComboboxItem();
                itemInventoryStatus.Text = status.Description;
                itemInventoryStatus.Value = status.VehicleInventoryStatusTypeID;
                ddlInvStatus.Items.Add(itemInventoryStatus);
            }
        }

        private void Clear()
        {
            ddlModelName.SelectedIndex = -1;
            txtChasisNo.Text = "";
            txtEngineNo.Text = "";
            ddlColor.SelectedIndex = -1;
            txtKeyNo.Text = "";
            txtBatteryMake.Text = "";
            txtBatteryNo.Text = "";
            txtServiceBookNo.Text = "";
            ddlInvStatus.SelectedIndex = -1;
            txtRemarks.Text = "";
            txtShowRoomPrice.Text  = "";
            txtLTRTOtherExp.Text = "";
            txtInsurancePrice.Text = "";
            txtMarginPrice.Text = "";
            txt50Margin.Text = "";
            txt70Margin.Text = "";
            txtWarranty.Text = "";
            txtOnRoadPrice.Text = "";
        }

        private void ddlModelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlModelName.SelectedIndex != -1)
            {
                VehicleInfoBL bl = new VehicleInfoBL();
                ComboboxItem item = (ComboboxItem)ddlModelName.SelectedItem;
                if (item != null)
                {
                    var vehicleinfo = bl.GetVehicleInfo(Convert.ToInt32(item.Value));
                    txtShowRoomPrice.Text = vehicleinfo.ExShowRoomPrice.ToString();
                    txtLTRTOtherExp.Text = vehicleinfo.LT_RT_OtherExp.ToString();
                    txtInsurancePrice.Text = vehicleinfo.InsurancePrice.ToString();
                    txtMarginPrice.Text = vehicleinfo.MarginPrice.ToString();
                    txt50Margin.Text = vehicleinfo.Margin50.ToString();
                    txt70Margin.Text = vehicleinfo.Margin70.ToString();
                    txtWarranty.Text = vehicleinfo.WarrantyPrice.ToString();
                    txtOnRoadPrice.Text = vehicleinfo.OnRoadPrice.ToString();
                }
            }
        }
    }
}
