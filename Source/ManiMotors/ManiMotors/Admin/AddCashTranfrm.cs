using MessageBoxExample;
using MM.BusinessLayer.Admin;
using MM.Model.Admin;
using MM.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManiMotors.Admin
{
    public partial class AddCashTranfrm : Form
    {
        public int _CashTransactionID = 0;
        public string _mode = "";
        public AddCashTranfrm()
        {
            InitializeComponent();
        }

        public AddCashTranfrm(int CashTranID, string mode)
        {
            InitializeComponent();
            _CashTransactionID = CashTranID;
            _mode = mode;
        }

        private void AddCashTranfrm_Load(object sender, EventArgs e)
        {
            if (_mode == "EDIT")
            {
                PopulateValues();
            }
        }

        private void PopulateValues()
        {
            CashTransactionBL bl = new CashTransactionBL();
            var etr = bl.GetCashTransaction().FirstOrDefault(et => et.CashTransactionID == _CashTransactionID);
            ddlTranType.Text = "";
            ddlTranType.SelectedText = etr.TransactionType;
            txtAmount.Text = etr.Amount.ToString();
            txtComments.Text = etr.Description; ;
            dtTranDate.Text = etr.TransactionDate.ToShortDateString();
            ddlType.Text = "";
            ddlType.SelectedText = etr.Type;
            ddlStatus.SelectedText = etr.Status;
        }

        private bool validate()
        {
            var flag = true;
            if (txtAmount.Text == "" || ddlTranType.Text == "" || txtComments.Text == "" || ddlType.Text == "" || ddlStatus.Text == "")
            {
                flag = false;
            }
            return flag;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                
                var Amount = txtAmount.Text;
                var Comments = txtComments.Text;
                CashTransactionDTO bDTO = new CashTransactionDTO();
                bDTO.Description = Comments;
                bDTO.Amount = Convert.ToInt32(Amount);
                bDTO.TransactionType = ddlTranType.Text;
                bDTO.TransactionDate = Convert.ToDateTime(dtTranDate.Text);
                bDTO.CreatedBy = GlobalSetup.Userid;
                bDTO.CreatedDate = DateTime.Now;
                bDTO.ModifiedDate = null;
                bDTO.ModifiedBy = null;
                bDTO.Type = ddlType.Text;
                bDTO.Status = ddlStatus.Text;

                CashTransactionBL obj = new CashTransactionBL();
                bool result = false;
                if (_mode == "EDIT")
                {
                    bDTO.CashTransactionID = _CashTransactionID;
                    result = obj.UpdateCashTransaction(bDTO);
                }
                else
                {
                    result = obj.AddCashTransaction(bDTO);
                }

                if (result)
                {
                    MyMessageBox.ShowBox("Cash Account Transaction Saved!!!");
                }
                else
                {
                    MyMessageBox.ShowBox("Cash Account Failed !!!");
                }
            }
            else
            {
                MyMessageBox.ShowBox("Please enter all mandatory fields!!!");
            }
            this.Clear();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear()
        {
            ddlTranType.SelectedIndex = -1;
            txtAmount.Text = "";
            txtComments.Text = "";
        }
    }
}
