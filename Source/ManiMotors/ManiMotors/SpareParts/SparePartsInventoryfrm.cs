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
using MM.Model.Vehicle;

namespace ManiMotors.SpareParts
{
    public partial class SparePartsInventoryfrm : Form
    {
        private string _mode = "";
        private List<int> _lstSPAllotmentId = new List<int>();
        private int _vehicleBookingId = 0;
        public SparePartsInventoryfrm()
        {
            InitializeComponent();
        }

        public SparePartsInventoryfrm(string mode, int vehicleBookingId, List<int> lstSPAllotment = null)
        {
            InitializeComponent();
            _mode = mode;
            _lstSPAllotmentId = lstSPAllotment;
            _vehicleBookingId = vehicleBookingId;
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

            if (_mode == "ADD")
            {
                btnAdd.Visible = false;
                btnEDIT.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                lstBoxSPInvlist.Visible = true;
                btnSelect.Visible = true;
                btnRemove.Visible = true;
                btnDownload.Visible = false;
                lblTitle.Text = "SpareParts Allotment Screen";
            }


            if (_mode == "EDIT")
            {
                btnAdd.Visible = false;
                btnEDIT.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                lstBoxSPInvlist.Visible = true;
                btnSelect.Visible = true;
                btnRemove.Visible = true;
                btnDownload.Visible = false;
                lblTitle.Text = "SpareParts Allotment Screen";
                foreach (var altid in _lstSPAllotmentId)
                {
                    lblAllotmentID.Text = lblAllotmentID.Text + altid.ToString()+ "__";
                }
                PopulateSelectedAllotment(_lstSPAllotmentId);
            }
        }

        private void PopulateSelectedAllotment(List<int> spAllotmentID)
        {
            List<int> lstSPInventory = new List<int>();
            SparePartsAllotmentBL vaBl = new SparePartsAllotmentBL();
            SparePartsInventoryBL obj = new SparePartsInventoryBL();
            var allinventory = obj.GetAllSparePartsInventory();
            var filterefInfo = allinventory.Where(i => i.SparePartsInventoryStatusTypeID == 1).ToList();//.Where(x => lstSPInventory.Contains(x.SparePartsInventoryID));
            dgSparePartsInventory.DataSource = filterefInfo;
            foreach (var spaltid in spAllotmentID)
            {
                ComboboxItem item = new ComboboxItem();
                var inventoryId = vaBl.GetSPInventoryId(spaltid);
                item.Value = inventoryId;
                var inventorydto = allinventory.Where(x => x.SparePartsInventoryID == inventoryId).FirstOrDefault();
                item.Text = inventorydto.SparePartsModelName;
                lstBoxSPInvlist.Items.Add(item);
            }

            
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

            if (_mode == "ADD")
            {
                lst = lst.Where(i => i.SparePartsInventoryStatusTypeID == 1).ToList();
            }
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
                var retStr = MyMessageBoxYesorNo.ShowBox("Are you Sure You want to Delete??");
                if (retStr == "1")
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblSPInventoryId.Text = "";
            List<SparePartsAllotmentDTO> lstSpalt = new List<SparePartsAllotmentDTO>();
            foreach(var spitem in lstBoxSPInvlist.Items)
            {
                var item = (ComboboxItem)spitem;
                lblSPInventoryId.Text = lblSPInventoryId.Text + item.Value.ToString() + "__";
                SparePartsAllotmentDTO dto = new SparePartsAllotmentDTO();
                dto.SparePartsInventoryID = Convert.ToInt32(item.Value);
                dto.VehicleBookingID = _vehicleBookingId;
                lstSpalt.Add(dto);
            }

            SparePartsAllotmentBL obj = new SparePartsAllotmentBL();
            var lstAllotmentIDs = obj.SaveSparePartsAllotment(lstSpalt, _mode, _lstSPAllotmentId);
            lblAllotmentID.Text = "";
            foreach (var altId in lstAllotmentIDs)
            {
                lblAllotmentID.Text = lblAllotmentID.Text + altId.ToString() + "__";
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var sparePartsInventoryid = dgSparePartsInventory.CurrentRow.Cells["SparePartsInventoryID"].Value.ToString();
            if (sparePartsInventoryid == "")
            {
                MyMessageBox.ShowBox("Please Select SpareParts Inventory from left grid");
            }
            else
            {
                string sparePartsModelName = dgSparePartsInventory.CurrentRow.Cells["SparePartsModelName"].Value.ToString();
                ComboboxItem item = new ComboboxItem();
                item.Value = Convert.ToInt32(sparePartsInventoryid);
                item.Text = sparePartsModelName;
                lstBoxSPInvlist.Items.Add(item);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var retStr = MyMessageBoxYesorNo.ShowBox("Are you Sure You want to Remove??");
            if (retStr == "1")
            {
                if (lstBoxSPInvlist.SelectedIndex != -1)
                {
                    lstBoxSPInvlist.Items.RemoveAt(lstBoxSPInvlist.SelectedIndex);
                }
                else
                {
                    MyMessageBox.ShowBox("Please Select SpareParts Inventory from Right grid to Remove");
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Export obj = new Export();
            obj.ExportToExcel(dgSparePartsInventory);
        }
    }
}
