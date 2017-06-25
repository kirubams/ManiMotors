using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MM.Model.Customer;
using MM.BusinessLayer.Customer;
using MM.Utilities;
namespace ManiMotors.Customer
{
    public partial class CustomerExchangefrm : Form
    {
        public CustomerExchangefrm()
        {
            InitializeComponent();
        }

        public CustomerExchangefrm(string mode, string CustomerName, string CustomerId)
        {
            
            InitializeComponent();
            if (mode == "SELECT")
            {
                btnSearchCustomer.Visible = false;
                txtCustomerName.Text = CustomerName;
                txtCustomerId.Text = CustomerId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var dto = new CustomerExchangeDTO()
            {
                CustomerId = Convert.ToInt32(txtCustomerId.Text),
                Model = txtModel.Text,
                Color = txtColor.Text,
                MfgDate = Convert.ToDateTime(dtMfgDate.Text),
                EngineCondition = txtEngCondition.Text,
                OutlookCondition = txtOutlookCondition.Text,
                CustomerRate = Convert.ToInt32(txtCustomerRate.Text),
                BrokerName1 = txtBN1.Text,
                Rate1 = Convert.ToInt32(txtRate1.Text),
                MobileNo1 = txtMNo1.Text,
                DifferenceAmount1 = Convert.ToInt32(txtDA1.Text),
                BrokerName2 = txtBN2.Text,
                Rate2 = Convert.ToInt32(txtRate2.Text),
                MobileNo2 = txtMNo2.Text,
                DifferenceAmount2 = Convert.ToInt32(txtDA2.Text),
                ExchangeRemark = txtRemarks.Text,
                FinalAmount = Convert.ToInt32(txtFinalAmount.Text),
                CreatedBy = GlobalSetup.Userid,
                CreatedDate = DateTime.Now,
                ModifiedBy = GlobalSetup.Userid,
                ModifiedDate = DateTime.Now
            };

            CustomerBL obj = new CustomerBL();
            var exchangeVehicleId = obj.SaveExchangeVehicle(dto);
            txtExchangeVehilceId.Text = exchangeVehicleId.ToString();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
