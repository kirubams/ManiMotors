using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MM.Model.SpareParts;
using MM.BusinessLayer.SpareParts;
using MM.Utilities;
using MessageBoxExample;

namespace ManiMotors.SpareParts
{
    public partial class SparePartsInventoryfrm : Form
    {
        public SparePartsInventoryfrm()
        {
            InitializeComponent();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSparePartsInventoryfrm frm = new AddSparePartsInventoryfrm();
            frm.ShowDialog();
            LoadDefaultValues();
        }

        private void SparePartsInventoryfrm_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
        }

        private void btnEDIT_Click(object sender, EventArgs e)
        {
            var SparePartsInventoryID = Convert.ToInt32(dgSparePartsInventory.CurrentRow.Cells["SparePartsInventoryID"].Value.ToString());
            if (SparePartsInventoryID == 0)
            {
                MyMessageBox.ShowBox("Please select a value from the SpareParts Inventory!!!");
            }
            else
            {
                AddSparePartsInventoryfrm obj = new AddSparePartsInventoryfrm(SparePartsInventoryID, "EDIT");
                obj.ShowDialog();
                LoadDefaultValues();
            }
        }

        private void LoadDefaultValues()
        {
            SparePartsInventoryBL obj = new SparePartsInventoryBL();
            var lst = obj.GetAllSparePartsInventory();
            dgSparePartsInventory.DataSource = lst;

            //Get All Model Name
            SparePartsInfoBL obj1 = new SparePartsInfoBL();
            var allVehInfo = obj1.GetAllSparePartsInfo();
            foreach (var vehInfo in allVehInfo)
            {
                //Load Model Name
                ComboboxItem itemModelName = new ComboboxItem();
                itemModelName.Text = vehInfo.ModelName;
                itemModelName.Value = vehInfo.SparePartsInfoID;
                ddlModelName.Items.Add(itemModelName);
            }


            //Load Inventory Status
            SparePartsInventoryBL obj2 = new SparePartsInventoryBL();
            foreach (var status in obj2.GetInventoryStatusType())
            {
                ComboboxItem itemInventoryStatus = new ComboboxItem();
                itemInventoryStatus.Text = status.Description;
                itemInventoryStatus.Value = status.SparePartsInventoryStatusTypeID;
                ddlInventoryStatus.Items.Add(itemInventoryStatus);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var SparePartsInventoryID = Convert.ToInt32(dgSparePartsInventory.CurrentRow.Cells["SparePartsInventoryID"].Value.ToString());
            if (SparePartsInventoryID == 0)
            {
                MyMessageBox.ShowBox("Please select a value from the SpareParts Invetory!!!");
            }
            else
            {
                SparePartsInventoryBL obj = new SparePartsInventoryBL();
                var flag = obj.DeleteSparePartsInventory(SparePartsInventoryID);
                LoadDefaultValues();
                if (flag)
                {
                    MyMessageBox.ShowBox("SpareParts Inventory Deleted");
                }
                else
                {
                    MyMessageBox.ShowBox("SpareParts Inventory Failed to Delete.");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //var modelCode = txtModelCode.Text;
            var modelName = ddlModelName.SelectedText;
            string inventoryStatus = "";
            if (ddlInventoryStatus.SelectedItem != null)
            {
                inventoryStatus = ddlInventoryStatus.SelectedItem.ToString();
            }
            string identificationNo = txtIdentificationNo.Text;
            SparePartsInventoryBL obj = new SparePartsInventoryBL();
            var filterefInfo = obj.GetAllSparePartsInventory()
                .Where(
                    i => i.SparePartsModelName.ToUpper().Contains(modelName.ToUpper())
                    &&
                    i.IdentificationNo.ToUpper().Contains(identificationNo.ToUpper())
                    &&
                    i.SparePartsInventoryStatusName.ToUpper().Contains(inventoryStatus.ToUpper())
                    ).ToList();
            dgSparePartsInventory.DataSource = filterefInfo;
        }
    }
}
