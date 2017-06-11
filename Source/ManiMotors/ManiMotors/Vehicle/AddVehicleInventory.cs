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
        }
    }
}
