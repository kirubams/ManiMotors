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
    public partial class AddSparePartsInventoryfrm : Form
    {
        private int _SparePartsInventoryID = 0;
        private string _mode = "";
        public AddSparePartsInventoryfrm()
        {
            InitializeComponent();
        }

        public AddSparePartsInventoryfrm(int SparePartsInventoryID, string mode)
        {
            InitializeComponent();
            this._SparePartsInventoryID = SparePartsInventoryID;
            this._mode = mode;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SparePartsInventoryDTO info = new SparePartsInventoryDTO();
            var selItem = (ComboboxItem)ddlModelName.SelectedItem;
            info.SparePartsInventoryID = _SparePartsInventoryID;
            info.SparePartsInfoID = Convert.ToInt32(selItem.Value);
            info.IdentificationNo = txtIdentificationNo.Text;
            info.OtherDescription = txtOtherDescription.Text;
            info.CreatedDate = System.DateTime.Now;
            info.CreatedBy = GlobalSetup.Userid;
            info.ModifiedDate = System.DateTime.Now;
            SparePartsInventoryBL viBL = new SparePartsInventoryBL();
            var flag = viBL.SaveInventorySpareParts(info, _mode);
            if (flag)
            {
                MyMessageBox.ShowBox("SpareParts Inventory Saved", "SpareParts Inventory");
                Clear();
            }
            else
            {
                MyMessageBox.ShowBox("SpareParts Inventory Failed to Save", "SpareParts Inventory");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddSparePartsInventory_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
            if (_mode == "EDIT")
            {
                PopulateInventorySpareParts(_SparePartsInventoryID);
            }
        }

        private void PopulateInventorySpareParts(int SparePartsInventoryID)
        {
            SparePartsInventoryBL obj = new SparePartsInventoryBL();
            var vehInv = obj.GetAllSparePartsInventory().Where(v => v.SparePartsInventoryID == SparePartsInventoryID).FirstOrDefault();
            ComboboxItem selitem = new ComboboxItem();
            selitem.Text = vehInv.SparePartsModelName;
            selitem.Value = vehInv.SparePartsInfoID;
            ddlModelName.Text = selitem.Text;
            txtIdentificationNo.Text = vehInv.IdentificationNo;
            txtOtherDescription.Text = vehInv.OtherDescription;
        }

        private void LoadDefaultValues()
        {
            //Load All Model Name
            SparePartsInfoBL viBL = new SparePartsInfoBL();
            foreach (var SparePartsInfo in viBL.GetAllSparePartsInfo())
            {
                ComboboxItem obj = new ComboboxItem();
                obj.Text = SparePartsInfo.ModelName;
                obj.Value = SparePartsInfo.SparePartsInfoID;
                ddlModelName.Items.Add(obj);
            }
        }

        private void Clear()
        {
            ddlModelName.SelectedIndex = -1;
            txtIdentificationNo.Text = "";
            txtOtherDescription.Text = "";
        }
    }
}
