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
        public VehicleInventoryfrm()
        {
            InitializeComponent();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //var modelCode = txtModelCode.Text;
            var modelName = ddlModelName.SelectedText;
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
            VehicleInventoryBL obj = new VehicleInventoryBL();
            var filterefInfo = obj.GetAllVehicleInventory()
                .Where(
                    i => i.VehicleModelName.ToUpper().Contains(modelName.ToUpper()) 
                    && 
                    i.Color.ToUpper().Contains(color.ToUpper()) 
                    && 
                    i.VehicleInventoryStatusName.ToUpper().Contains(inventoryStatus.ToUpper())
                    ).ToList();
            dgVehicleInventory.DataSource = filterefInfo;
        }
    }
}
