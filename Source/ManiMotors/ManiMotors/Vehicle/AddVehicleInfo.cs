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
    public partial class AddVehicleInfo : Form
    {
        public int _vehicleInfoID = 0;
        public string _mode = "";
        public AddVehicleInfo()
        {
            InitializeComponent();
        }

        public AddVehicleInfo(int VehicleInfoID, string mode)
        {
            InitializeComponent();
            this._vehicleInfoID = VehicleInfoID;
            this._mode = mode;
        }

        private void AddVehicleInfo_Load(object sender, EventArgs e)
        {
            //Load Default Values
            LoadDefaultValue();

            if(_mode == "EDIT")
            {
                PopulateVehicletype(_vehicleInfoID);
            }
        }

        private void LoadDefaultValue()
        {
            VehicleInfoBL viBL = new VehicleInfoBL();
            foreach (var vehicletypes in viBL.GetVehicleTypes())
            {
                ComboboxItem obj = new ComboboxItem();
                obj.Text = vehicletypes.Description;
                obj.Value = vehicletypes.VehicleTypeID;
                ddlVehicleType.Items.Add(obj);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            VehicleInfoDTO info = new VehicleInfoDTO();
            var selItem = (ComboboxItem)ddlVehicleType.SelectedItem;
            info.VehicleInfoID = _vehicleInfoID;
            info.VehicleTypeID = Convert.ToInt32(selItem.Value);
            info.ModelCode = txtModelCode.Text;
            info.ModelName = txtModelName.Text;
            info.ExShowRoomPrice = Convert.ToInt32(txtShowRoomPrice.Text);
            info.LT_RT_OtherExp = Convert.ToInt32(txtLTRTOtherExp.Text);
            info.InsurancePrice = Convert.ToInt32(txtInsurancePrice.Text);
            info.OnRoadPrice = Convert.ToInt32(txtOnRoadPrice.Text);
            info.MarginPrice = Convert.ToInt32(txtMarginPrice.Text);
            info.Margin50 = Convert.ToInt32(txt50Margin.Text);
            info.Margin70 = Convert.ToInt32(txt70Margin.Text);
            info.CreatedDate = System.DateTime.Now;
            info.CreatedBy = GlobalSetup.Userid;
            info.ModifiedDate = System.DateTime.Now;
            VehicleInfoBL viBL = new VehicleInfoBL();
            var flag = viBL.SaveVehicleInfo(info, _mode);
            if(flag)
            {
                MyMessageBox.ShowBox("Vehicle Information Saved", "Vehicle Info");
                Clear();
            }
            else
            {
                MyMessageBox.ShowBox("Vehicle Information Failed to Save", "Vehicle Info");
            }
        }

        private void PopulateVehicletype(int VehicleInfoID)
        {
            VehicleInfoBL obj = new VehicleInfoBL();
            var vehicleInfo = obj.GetVehicleInfo(VehicleInfoID);
            var vehicleType = obj.GetVehicleTypes().Where(vt => vt.VehicleTypeID == vehicleInfo.VehicleTypeID).FirstOrDefault();
            ComboboxItem selitem = new ComboboxItem();
            selitem.Text = vehicleType.Description;
            selitem.Value = vehicleType.VehicleTypeID;
            ddlVehicleType.Text = selitem.Text;
            txtModelCode.Text = vehicleInfo.ModelCode;
            txtModelName.Text = vehicleInfo.ModelName;
            txtShowRoomPrice.Text = vehicleInfo.ExShowRoomPrice.ToString();
            txtLTRTOtherExp.Text = vehicleInfo.LT_RT_OtherExp.ToString();
            txtInsurancePrice.Text = vehicleInfo.InsurancePrice.ToString();
            txtOnRoadPrice.Text = vehicleInfo.OnRoadPrice.ToString();
            txtMarginPrice.Text = vehicleInfo.MarginPrice.ToString();
            txt50Margin.Text = vehicleInfo.Margin50.ToString();
            txt70Margin.Text = vehicleInfo.Margin70.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear()
        {
            ddlVehicleType.SelectedIndex = -1;
            txtModelCode.Text = "";
            txtModelName.Text = "";
            txtShowRoomPrice.Text = "";
            txtLTRTOtherExp.Text = "";
            txtInsurancePrice.Text = "";
            txtOnRoadPrice.Text = "";
            txtMarginPrice.Text = "";
            txt50Margin.Text = "";
            txt70Margin.Text = "";
        }
    }
}
