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
    public partial class BankTranfrm : Form
    {
        public int _bankTransactionID = 0;
        public string _mode = "";
        public BankTranfrm()
        {
            InitializeComponent();
        }

        public BankTranfrm(int BankTranID, string mode)
        {
            InitializeComponent();
            _bankTransactionID = BankTranID;
            _mode = mode;
        }

        private void BankTranfrm_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
            if (_mode == "EDIT")
            {
                PopulateValues();
            }
        }

        private void PopulateValues()
        {
            BankTransactionBL bl = new BankTransactionBL();
            var etr = bl.GetBankAccountTransaction().FirstOrDefault(et => et.BankAccountTransactionID == _bankTransactionID);
            var bt = bl.GetBankAccountType().FirstOrDefault(x => x.BankAccountTypeID == etr.BankAccountTypeID);
            ComboboxItem item = new ComboboxItem();
            item.Text = bt.BankAccountTypeDescription;
            item.Value = bt.BankAccountTypeID;
            ddlBankAccount.Text = item.Text;
            ddlTranType.Text = "";
            ddlTranType.SelectedText = etr.TransactionType;
            txtAmount.Text = etr.Amount.ToString();
            txtComments.Text = etr.Description; ;
            dtTranDate.Text = etr.TransactionDate.ToShortDateString();
            ddlType.Text = "";
            ddlType.SelectedText = etr.Type;
        }

        private void LoadDefaultValues()
        {
            BankTransactionBL bl = new BankTransactionBL();
            ddlBankAccount.Items.Clear();
            var bankTypelst = bl.GetBankAccountType();

            foreach (var bt in bankTypelst)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = bt.BankAccountTypeDescription;
                item.Value = bt.BankAccountTypeID;
                ddlBankAccount.Items.Add(item);
            }
        }

        private bool validate()
        {
            var flag = true;
            if (ddlBankAccount.Text == string.Empty || txtAmount.Text == "" || ddlTranType.Text == "" || txtComments.Text == "" || ddlType.Text == "")
            {
                flag = false;
            }
            return flag;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                //Populate ExpenseTransactionDTO
                var bnk = (ComboboxItem)ddlBankAccount.SelectedItem;
                var Amount = txtAmount.Text;
                var Comments = txtComments.Text;
                BankAccountTransactionDTO bDTO = new BankAccountTransactionDTO();
                bDTO.BankAccountTypeID = Convert.ToInt32(bnk.Value);
                bDTO.Description = Comments;
                bDTO.Amount = Convert.ToInt32(Amount);
                bDTO.TransactionType = ddlTranType.Text;
                bDTO.TransactionDate = Convert.ToDateTime(dtTranDate.Text);
                bDTO.CreatedBy = GlobalSetup.Userid;
                bDTO.CreatedDate = DateTime.Now;
                bDTO.ModifiedDate = null;
                bDTO.ModifiedBy = null;
                bDTO.Type = ddlType.Text;

                BankTransactionBL obj = new BankTransactionBL();
                bool result = false;
                if (_mode == "EDIT")
                {
                    bDTO.BankAccountTransactionID = _bankTransactionID;
                    result = obj.UpdateBankAccountTransaction(bDTO);
                }
                else
                {
                    result = obj.AddBankAccountTransaction(bDTO);
                }

                if (result)
                {
                    MyMessageBox.ShowBox("Bank Account Transaction Saved!!!");
                }
                else
                {
                    MyMessageBox.ShowBox("Bank Account Failed !!!");
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
            ddlBankAccount.Items.Clear();
            LoadDefaultValues();
            txtAmount.Text = "";
            txtComments.Text = "";
        }
    }
}
