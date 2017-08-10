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
using System.Transactions;

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
            if(ddlModelName.SelectedIndex == -1 || txtIdentificationNo.Text == "" || txtOtherDescription.Text == "" || ddlQuantity.SelectedIndex == -1)
            {
                MyMessageBox.ShowBox("Please Select All Mandatory Fields !!!");
                return;
            }

            if(Convert.ToInt32(ddlQuantity.Text) > 5)
            {
                string ok = MyMessageBoxYesorNo.ShowBox("Are you sure you want to add " + ddlQuantity.Text + " Quantity");
                if(ok != "1")
                {
                    return;
                }
            }
            SparePartsInventoryDTO info = new SparePartsInventoryDTO();
            var selItem = (ComboboxItem)ddlModelName.SelectedItem;
            info.SparePartsInventoryID = _SparePartsInventoryID;
            info.SparePartsInfoID = Convert.ToInt32(selItem.Value);
            info.IdentificationNo = txtIdentificationNo.Text;
            info.OtherDescription = txtOtherDescription.Text;
            info.CreatedDate = System.DateTime.Now;
            info.CreatedBy = GlobalSetup.Userid;
            info.ModifiedDate = System.DateTime.Now;
            info.MarginPrice = Convert.ToInt32(txtMarginPrice.Text);
            info.ShowRoomPrice = Convert.ToInt32(txtShowRoomPrice.Text);
            var invSelitem = (ComboboxItem)ddlInvStatus.SelectedItem;
            info.SparePartsInventoryStatusTypeID = Convert.ToInt32(invSelitem.Value);
            int quantity = Convert.ToInt32(ddlQuantity.Text);
            SparePartsInventoryBL viBL = new SparePartsInventoryBL();
            var flag = false;
            var identno = info.IdentificationNo;
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    for (int i = 1; i <= quantity; i++)
                    {
                        info.IdentificationNo = identno + " --" + i.ToString() + " -" + System.DateTime.Now.ToShortDateString();
                        viBL.SaveInventorySpareParts(info, _mode);
                    }
                    flag = true;
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    flag = false;
                }
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
                label8.Visible = false;
                label9.Visible = false;
                ddlQuantity.Visible = false;
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
            txtShowRoomPrice.Text = vehInv.ShowRoomPrice.ToString();
            txtMarginPrice.Text = vehInv.MarginPrice.ToString();
            //InventoryStatus Populate
            var vehInvStatus = obj.GetInventoryStatusType().Where(iv => iv.SparePartsInventoryStatusTypeID == vehInv.SparePartsInventoryStatusTypeID).FirstOrDefault();
            ComboboxItem selInvitem = new ComboboxItem();
            selInvitem.Text = vehInvStatus.Description;
            selInvitem.Value = vehInvStatus.SparePartsInventoryStatusTypeID;
            ddlInvStatus.Text = selInvitem.Text;
            ddlQuantity.SelectedIndex = 0;
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

            //Load Inventory Status
            ddlInvStatus.Items.Clear();
            SparePartsInventoryBL obj2 = new SparePartsInventoryBL();
            foreach (var status in obj2.GetInventoryStatusType())
            {
                ComboboxItem itemInventoryStatus = new ComboboxItem();
                itemInventoryStatus.Text = status.Description;
                itemInventoryStatus.Value = status.SparePartsInventoryStatusTypeID;
                ddlInvStatus.Items.Add(itemInventoryStatus);
            }
        }

        private void Clear()
        {
            ddlModelName.SelectedIndex = -1;
            txtIdentificationNo.Text = "";
            txtOtherDescription.Text = "";
        }

        private void ddlModelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlModelName.SelectedIndex != -1)
            {
                SparePartsInfoBL bl = new SparePartsInfoBL();
                ComboboxItem item = (ComboboxItem)ddlModelName.SelectedItem;
                if (item != null)
                {
                    var vehicleinfo = bl.GetSparePartsInfo(Convert.ToInt32(item.Value));
                    txtShowRoomPrice.Text = vehicleinfo.ShowRoomPrice.ToString();
                    txtMarginPrice.Text = vehicleinfo.MarginPrice.ToString();
                    
                }
            }
        }
    }
}
