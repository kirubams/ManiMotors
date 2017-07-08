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
    public partial class VehicleInfo : Form
    {
        public VehicleInfo()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddVehicleInfo obj = new AddVehicleInfo();
            obj.ShowDialog();
            LoadDefaultValues();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var modelCode = txtContactNo.Text;
            var modelName = txtName.Text;
            VehicleInfoBL obj = new VehicleInfoBL();
            var filterefInfo = obj.GetAllVehicleInfo().Where(i => i.ModelCode.ToUpper().Contains(modelCode.ToUpper()) && i.ModelName.ToUpper().Contains(modelName.ToUpper())).ToList();
            dgCutomerInfo.DataSource = filterefInfo;
        }

        private void VehicleInfo_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
        }

        private void btnEDIT_Click(object sender, EventArgs e)
        {
            var vehicleInfoID = Convert.ToInt32(dgCutomerInfo.CurrentRow.Cells["VehicleInfoID"].Value.ToString());
            if(vehicleInfoID == 0)
            {
                MyMessageBox.ShowBox("Please select a value from the Vehicle Info!!!");
            }
            else
            {
                AddVehicleInfo obj = new AddVehicleInfo(vehicleInfoID, "EDIT");
                obj.ShowDialog();
                LoadDefaultValues();
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var vehicleInfoID = Convert.ToInt32(dgCutomerInfo.CurrentRow.Cells["VehicleInfoID"].Value.ToString());
            if (vehicleInfoID == 0)
            {
                MyMessageBox.ShowBox("Please select a value from the Vehicle Info!!!");
            }
            else
            {

                var retStr = MyMessageBoxYesorNo.ShowBox("Are you Sure You want to Delete??");
                if (retStr == "1")
                {
                    VehicleInfoBL obj = new VehicleInfoBL();
                    var flag = obj.DeleteVehicleInfo(vehicleInfoID);
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
        }

        private void LoadDefaultValues()
        {
            VehicleInfoBL obj = new VehicleInfoBL();
            dgCutomerInfo.DataSource = obj.GetAllVehicleInfo();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pnlGrid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgCutomerInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
