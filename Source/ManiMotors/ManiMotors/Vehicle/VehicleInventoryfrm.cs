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
    public partial class VehicleInventoryfrm : Form
    {
        private string _mode = "";
        private int _vehicleAllotmentId = 0;
        private int _vehicleBookingId = 0;
        public VehicleInventoryfrm()
        {
            InitializeComponent();
        }

        public VehicleInventoryfrm(string mode,int vehicleBookingId, int vehicleAllotmentId = 0)
        {
            InitializeComponent();
            _mode = mode;
            _vehicleAllotmentId = vehicleAllotmentId;
            _vehicleBookingId = vehicleBookingId;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddVehicleInventory frm = new AddVehicleInventory();
            frm.ShowDialog();
            LoadDefaultValues();
        }

        private void VehicleInventoryfrm_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();

            if(_mode == "ADD")
            {
                btnAdd.Visible = false;
                btnEDIT.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                lblTitle.Text = "Inventory Allotment Screen";
            }


            if (_mode == "EDIT")
            {
                btnAdd.Visible = false;
                btnEDIT.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                lblTitle.Text = "Inventory Allotment Screen";
                lblAllotmentID.Text = _vehicleAllotmentId.ToString();
                PopulateSelectedAllotment(_vehicleAllotmentId);
            }
        }

        private void PopulateSelectedAllotment(int vehicleAllotmentId)
        {
            VehicleAllotmentBL vaBl = new VehicleAllotmentBL();
            int vehicleInventoryId = vaBl.GeInventoryId(vehicleAllotmentId);

            VehicleInventoryBL obj = new VehicleInventoryBL();
            var filterefInfo = obj.GetAllVehicleInventory()
                .Where(
                    i => i.VehicleInventoryID == vehicleInventoryId
                    ).ToList();
            dgVehicleInventory.DataSource = filterefInfo;
        }

        private void btnEDIT_Click(object sender, EventArgs e)
        {
            var vehicleInventoryID = Convert.ToInt32(dgVehicleInventory.CurrentRow.Cells["VehicleInventoryID"].Value.ToString());
            if (vehicleInventoryID == 0)
            {
                MyMessageBox.ShowBox("Please select a value from the Vehicle Inventory!!!");
            }
            else
            {
                AddVehicleInventory obj = new AddVehicleInventory(vehicleInventoryID, "EDIT");
                obj.ShowDialog();
                LoadDefaultValues();
            }
        }

        private void LoadDefaultValues()
        {
            VehicleInventoryBL obj = new VehicleInventoryBL();
            var lst = obj.GetAllVehicleInventory();
            

            if(_mode == "ADD")
            {
                lst = lst.Where(i => i.VehicleInventoryStatusTypeID == 1).ToList();
            }
            dgVehicleInventory.DataSource = lst;
            //Get All Model Name
            VehicleInfoBL obj1 = new VehicleInfoBL();
            var allVehInfo = obj1.GetAllVehicleInfo();
            foreach (var vehInfo in allVehInfo)
            {
                //Load Model Name
                ComboboxItem itemModelName = new ComboboxItem();
                itemModelName.Text = vehInfo.ModelName;
                itemModelName.Value = vehInfo.VehicleInfoID;
                ddlModelName.Items.Add(itemModelName);

                //Load Model Code
                ComboboxItem itemModelcode = new ComboboxItem();
                itemModelcode.Text = vehInfo.ModelCode;
                itemModelcode.Value = vehInfo.VehicleInfoID;
                ddlModelCode.Items.Add(itemModelcode);
            } 


            //Load Inventory Status
            VehicleInventoryBL obj2 = new VehicleInventoryBL();
            foreach (var status in obj2.GetInventoryStatusType())
            {
                ComboboxItem itemInventoryStatus = new ComboboxItem();
                itemInventoryStatus.Text = status.Description;
                itemInventoryStatus.Value = status.VehicleInventoryStatusTypeID;
                ddlInventoryStatus.Items.Add(itemInventoryStatus);
            }

            //Load Colors
            ddlColor.DataSource = GlobalSetup.colors;
            ddlColor.SelectedIndex = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var vehicleInventoryID = Convert.ToInt32(dgVehicleInventory.CurrentRow.Cells["VehicleInventoryID"].Value.ToString());
            if (vehicleInventoryID == 0)
            {
                MyMessageBox.ShowBox("Please select a value from the Vehicle Invetory!!!");
            }
            else
            {
                var retStr = MyMessageBoxYesorNo.ShowBox("Are you Sure You want to Delete??");
                if (retStr == "1")
                {
                    VehicleInventoryBL obj = new VehicleInventoryBL();
                    var flag = obj.DeleteVehicleInventory(vehicleInventoryID);
                    LoadDefaultValues();
                    if (flag)
                    {
                        MyMessageBox.ShowBox("Vehicle Inventory Deleted");
                    }
                    else
                    {
                        MyMessageBox.ShowBox("Vehicle Inventory Failed to Delete.");
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //var modelCode = txtModelCode.Text;
            var modelName = ddlModelName.SelectedText;
            var modelCode = ddlModelCode.SelectedText;
            string color = "";
            if (ddlColor.SelectedItem != null)
            {
                color = ddlColor.SelectedItem.ToString();
            }
            string inventoryStatus = "";
            if (ddlInventoryStatus.SelectedItem != null)
            {
                inventoryStatus = ddlInventoryStatus.SelectedItem.ToString();
            }
            var chasisNo = txtChasisNo.Text;
            var engineNo = txtEngineNo.Text;
            VehicleInventoryBL obj = new VehicleInventoryBL();
            var filterefInfo = obj.GetAllVehicleInventory()
                .Where(
                    i => i.VehicleModelName.ToUpper().Contains(modelName.ToUpper()) 
                    &&
                    i.VehicleModelCode.ToUpper().Contains(modelCode.ToUpper())
                    &&
                    i.ChasisNo.ToUpper().Contains(chasisNo.ToUpper())
                    &&
                    i.EngineNo.ToUpper().Contains(engineNo.ToUpper())
                    &&
                    i.Color.ToUpper().Contains(color.ToUpper()) 
                    && 
                    i.VehicleInventoryStatusName.ToUpper().Contains(inventoryStatus.ToUpper())
                    ).ToList();
            dgVehicleInventory.DataSource = filterefInfo;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            lblVehicleInventoryId.Text = "";
            lblVehicleInventoryId.Text = dgVehicleInventory.CurrentRow.Cells["VehicleInventoryID"].Value.ToString();
            VehicleAllotmentBL obj = new VehicleAllotmentBL();
            _vehicleAllotmentId =  obj.SaveVehicleAllotment(Convert.ToInt32(lblVehicleInventoryId.Text), _vehicleBookingId, _mode, _vehicleAllotmentId);
            lblAllotmentID.Text = _vehicleAllotmentId.ToString();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
