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

namespace ManiMotors.SpareParts
{
    public partial class SparePartsTypefrm : Form
    {
        private string btntext = "ADD";
        public SparePartsTypefrm()
        {
            InitializeComponent();
        }

        private void SparePartsTypefrm_Load(object sender, EventArgs e)
        {
            LoadSparePartsType();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                if (btntext == "ADD")
                {
                    SparePartsTypeDTO spDTO = new SparePartsTypeDTO();
                    spDTO.Description = txtDescription.Text;
                    spDTO.CreatedBy = GlobalSetup.Userid;
                    spDTO.CreatedDate = DateTime.Now;
                    spDTO.ModifiedDate = DateTime.Now;
                    SparePartsTypeBL expen = new SparePartsTypeBL();
                    var result = expen.AddSpareParts(spDTO);
                    LoadSparePartsType();

                    if (result)
                    {
                        MyMessageBox.ShowBox("SpareParts Type is Saved", "SpareParts");
                    }
                    else
                    {
                        MyMessageBox.ShowBox("SpareParts Save is failed !!!");
                    }
                }
                else
                {
                    SparePartsTypeDTO expenseDTO = new SparePartsTypeDTO();
                    expenseDTO.Description = txtDescription.Text;
                    expenseDTO.SparePartsTypeID = Convert.ToInt32(dgSparePartsType.CurrentRow.Cells["SparePartsTypeID"].Value);
                    expenseDTO.ModifiedDate = DateTime.Now;
                    expenseDTO.ModifiedBy = GlobalSetup.Userid;
                    SparePartsTypeBL exp = new SparePartsTypeBL();
                    var result = exp.UpdateSpareParts(expenseDTO);
                    btntext = "ADD";

                }
                clear();
                LoadSparePartsType();
            }
            else
            {
                MyMessageBox.ShowBox("Description cannot be Empty !!!");
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selectedName = dgSparePartsType.CurrentRow.Cells["Description"].Value.ToString();

            txtDescription.Text = selectedName;
            btntext = "Update";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = MyMessageBoxYesorNo.ShowBox("Are you sure to Delete??");
            if (id == "1")
            {
                var expenseID = dgSparePartsType.CurrentRow.Cells["SparePartsTypeID"].Value.ToString();
                SparePartsTypeBL expen = new SparePartsTypeBL();
                var result = expen.DeleteSpareParts(Convert.ToInt32(expenseID));
                if (result)
                {
                    MyMessageBox.ShowBox("Expenses Deleted");
                }
                else
                {
                    MyMessageBox.ShowBox("Failed");
                }
                clear();
                LoadSparePartsType();
            }

        }
        private void LoadSparePartsType()
        {
            SparePartsTypeBL expenseBL = new SparePartsTypeBL();

            dgSparePartsType.DataSource = expenseBL.GetSparePartsTypes().Select(o => new
            { SparePartsTypeID = o.SparePartsTypeID, Description = o.Description }).ToList();

            if (dgSparePartsType.Rows.Count == 0)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }

        }

        private void clear()
        {
            txtDescription.Text = "";
        }

        private bool validate()
        {
            var flag = true;
            if (txtDescription.Text == string.Empty)
            {
                flag = false;
            }
            return flag;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Export obj = new Export();
            obj.ExportToExcel(dgSparePartsType);
        }
    }
}
