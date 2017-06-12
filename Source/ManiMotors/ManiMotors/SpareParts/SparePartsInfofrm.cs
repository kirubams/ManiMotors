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
    public partial class SparePartsInfofrm : Form
    {
        public SparePartsInfofrm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSparePartsInfofrm obj = new AddSparePartsInfofrm();
            obj.ShowDialog();
            LoadDefaultValues();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var modelCode = txtModelCode.Text;
            var modelName = txtModelName.Text;
            SparePartsInfoBL obj = new SparePartsInfoBL();
            var filterefInfo = obj.GetAllSparePartsInfo().Where(i => i.ModelCode.ToUpper().Contains(modelCode.ToUpper()) && i.ModelName.ToUpper().Contains(modelName.ToUpper())).ToList();
            dgSparePartsInfo.DataSource = filterefInfo;
        }

        private void SparePartsInfo_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
        }

        private void btnEDIT_Click(object sender, EventArgs e)
        {
            var SparePartsInfoID = Convert.ToInt32(dgSparePartsInfo.CurrentRow.Cells["SparePartsInfoID"].Value.ToString());
            if (SparePartsInfoID == 0)
            {
                MyMessageBox.ShowBox("Please select a value from the SpareParts Info!!!");
            }
            else
            {
                AddSparePartsInfofrm obj = new AddSparePartsInfofrm(SparePartsInfoID, "EDIT");
                obj.ShowDialog();
                LoadDefaultValues();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var SparePartsInfoID = Convert.ToInt32(dgSparePartsInfo.CurrentRow.Cells["SparePartsInfoID"].Value.ToString());
            if (SparePartsInfoID == 0)
            {
                MyMessageBox.ShowBox("Please select a value from the SpareParts Info!!!");
            }
            else
            {
                SparePartsInfoBL obj = new SparePartsInfoBL();
                var flag = obj.DeleteSparePartsInfo(SparePartsInfoID);
                LoadDefaultValues();
                if (flag)
                {
                    MyMessageBox.ShowBox("SpareParts Information Deleted");
                }
                else
                {
                    MyMessageBox.ShowBox("SpareParts Information Failed to Delete.");
                }
            }
        }

        private void LoadDefaultValues()
        {
            SparePartsInfoBL obj = new SparePartsInfoBL();
            dgSparePartsInfo.DataSource = obj.GetAllSparePartsInfo();
        }
    }
}
