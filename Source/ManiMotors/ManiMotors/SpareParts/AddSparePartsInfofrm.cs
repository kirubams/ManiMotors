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
    public partial class AddSparePartsInfofrm : Form
    {
        public int _SparePartsInfoID = 0;
        public string _mode = "";
        public AddSparePartsInfofrm()
        {
            InitializeComponent();
        }

        public AddSparePartsInfofrm(int SparePartsInfoID, string mode)
        {
            InitializeComponent();
            this._SparePartsInfoID = SparePartsInfoID;
            this._mode = mode;
        }

        private void AddSparePartsInfo_Load(object sender, EventArgs e)
        {
            //Load Default Values
            LoadDefaultValue();

            if (_mode == "EDIT")
            {
                PopulateSparePartstype(_SparePartsInfoID);
            }
        }

        private void LoadDefaultValue()
        {
            SparePartsInfoBL viBL = new SparePartsInfoBL();
            foreach (var SparePartstypes in viBL.GetSparePartsTypes())
            {
                ComboboxItem obj = new ComboboxItem();
                obj.Text = SparePartstypes.Description;
                obj.Value = SparePartstypes.SparePartsTypeID;
                ddlSparePartsType.Items.Add(obj);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ddlSparePartsType.SelectedIndex == -1 || txtModelCode.Text == "" || txtModelName.Text == "" || txtMarginPrice.Text  == "" || txt70Margin.Text == "" || txtShowRoomPrice.Text == "" || txt50Margin.Text == "")
            {
                MyMessageBox.ShowBox("Please Select All Mandatory Fields!!!");
                return;
            }
            SparePartsInfoDTO info = new SparePartsInfoDTO();
            var selItem = (ComboboxItem)ddlSparePartsType.SelectedItem;
            info.SparePartsInfoID = _SparePartsInfoID;
            info.SparePartsTypeID = Convert.ToInt32(selItem.Value);
            info.ModelCode = txtModelCode.Text;
            info.ModelName = txtModelName.Text;
            info.ShowRoomPrice = Convert.ToInt32(txtShowRoomPrice.Text);
            info.MarginPrice = Convert.ToInt32(txtMarginPrice.Text);
            info.Margin50 = Convert.ToInt32(txt50Margin.Text);
            info.Margin70 = Convert.ToInt32(txt70Margin.Text);
            info.CreatedDate = System.DateTime.Now;
            info.CreatedBy = GlobalSetup.Userid;
            info.ModifiedDate = System.DateTime.Now;
            SparePartsInfoBL viBL = new SparePartsInfoBL();
            var flag = viBL.SaveSparePartsInfo(info, _mode);
            if (flag)
            {
                MyMessageBox.ShowBox("SpareParts Information Saved", "SpareParts Info");
                Clear();
            }
            else
            {
                MyMessageBox.ShowBox("SpareParts Information Failed to Save", "SpareParts Info");
            }
        }

        private void PopulateSparePartstype(int SparePartsInfoID)
        {
            SparePartsInfoBL obj = new SparePartsInfoBL();
            var SparePartsInfo = obj.GetSparePartsInfo(SparePartsInfoID);
            var SparePartsType = obj.GetSparePartsTypes().Where(vt => vt.SparePartsTypeID == SparePartsInfo.SparePartsTypeID).FirstOrDefault();
            ComboboxItem selitem = new ComboboxItem();
            selitem.Text = SparePartsType.Description;
            selitem.Value = SparePartsType.SparePartsTypeID;
            ddlSparePartsType.Text = selitem.Text;
            txtModelCode.Text = SparePartsInfo.ModelCode;
            txtModelName.Text = SparePartsInfo.ModelName;
            txtShowRoomPrice.Text = SparePartsInfo.ShowRoomPrice.ToString();
            txtMarginPrice.Text = SparePartsInfo.MarginPrice.ToString();
            txt50Margin.Text = SparePartsInfo.Margin50.ToString();
            txt70Margin.Text = SparePartsInfo.Margin70.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear()
        {
            ddlSparePartsType.SelectedIndex = -1;
            txtModelCode.Text = "";
            txtModelName.Text = "";
            txtShowRoomPrice.Text = "";
            txtMarginPrice.Text = "";
            txt50Margin.Text = "";
            txt70Margin.Text = "";
        }
    }
}
