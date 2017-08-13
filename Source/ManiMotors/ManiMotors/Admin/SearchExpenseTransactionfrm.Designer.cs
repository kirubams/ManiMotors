namespace ManiMotors.Admin
{
    partial class SearchExpenseTransactionfrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchExpenseTransactionfrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ddlType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlDebitType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.btnSearch = new System.Windows.Forms.PictureBox();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.btnDownload = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.PictureBox();
            this.btnEDIT = new System.Windows.Forms.PictureBox();
            this.dgExpenseTransaction = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEDIT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgExpenseTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.ddlType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtEndDate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.ddlDebitType);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dtStartDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Location = new System.Drawing.Point(12, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 168);
            this.panel1.TabIndex = 4;
            // 
            // ddlType
            // 
            this.ddlType.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlType.ForeColor = System.Drawing.Color.Red;
            this.ddlType.FormattingEnabled = true;
            this.ddlType.Items.AddRange(new object[] {
            "BOTH",
            "SALES",
            "SERVICE"});
            this.ddlType.Location = new System.Drawing.Point(428, 72);
            this.ddlType.Name = "ddlType";
            this.ddlType.Size = new System.Drawing.Size(111, 24);
            this.ddlType.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(260, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 16);
            this.label1.TabIndex = 60;
            this.label1.Text = "Type(Sales/Service):";
            // 
            // dtEndDate
            // 
            this.dtEndDate.CalendarFont = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEndDate.CalendarForeColor = System.Drawing.Color.Red;
            this.dtEndDate.CalendarTitleForeColor = System.Drawing.Color.Red;
            this.dtEndDate.CalendarTrailingForeColor = System.Drawing.SystemColors.Window;
            this.dtEndDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtEndDate.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDate.Location = new System.Drawing.Point(428, 45);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(111, 22);
            this.dtEndDate.TabIndex = 57;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(335, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 16);
            this.label6.TabIndex = 56;
            this.label6.Text = "End Date:";
            // 
            // ddlDebitType
            // 
            this.ddlDebitType.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlDebitType.ForeColor = System.Drawing.Color.Red;
            this.ddlDebitType.FormattingEnabled = true;
            this.ddlDebitType.Location = new System.Drawing.Point(122, 72);
            this.ddlDebitType.Name = "ddlDebitType";
            this.ddlDebitType.Size = new System.Drawing.Size(119, 24);
            this.ddlDebitType.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(17, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 16);
            this.label5.TabIndex = 54;
            this.label5.Text = "Debit Type:";
            // 
            // dtStartDate
            // 
            this.dtStartDate.CalendarFont = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStartDate.CalendarForeColor = System.Drawing.Color.Red;
            this.dtStartDate.CalendarTitleForeColor = System.Drawing.Color.Red;
            this.dtStartDate.CalendarTrailingForeColor = System.Drawing.SystemColors.Window;
            this.dtStartDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtStartDate.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(122, 45);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(119, 22);
            this.dtStartDate.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(21, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 52;
            this.label4.Text = "Start Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(138, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Expense Transaction Search Screen";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Location = new System.Drawing.Point(472, 120);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(67, 30);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.TabStop = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(209, 120);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 30);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.TabStop = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.SystemColors.Window;
            this.pnlGrid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlGrid.BackgroundImage")));
            this.pnlGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlGrid.Controls.Add(this.btnDownload);
            this.pnlGrid.Controls.Add(this.btnDelete);
            this.pnlGrid.Controls.Add(this.btnEDIT);
            this.pnlGrid.Controls.Add(this.dgExpenseTransaction);
            this.pnlGrid.Location = new System.Drawing.Point(12, 253);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(556, 358);
            this.pnlGrid.TabIndex = 5;
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.Transparent;
            this.btnDownload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDownload.BackgroundImage")));
            this.btnDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownload.Location = new System.Drawing.Point(472, 16);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(67, 28);
            this.btnDownload.TabIndex = 19;
            this.btnDownload.TabStop = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Location = new System.Drawing.Point(472, 98);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(67, 25);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.TabStop = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEDIT
            // 
            this.btnEDIT.BackColor = System.Drawing.Color.Transparent;
            this.btnEDIT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEDIT.BackgroundImage")));
            this.btnEDIT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEDIT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEDIT.Location = new System.Drawing.Point(472, 61);
            this.btnEDIT.Name = "btnEDIT";
            this.btnEDIT.Size = new System.Drawing.Size(67, 22);
            this.btnEDIT.TabIndex = 14;
            this.btnEDIT.TabStop = false;
            this.btnEDIT.Click += new System.EventHandler(this.btnEDIT_Click);
            // 
            // dgExpenseTransaction
            // 
            this.dgExpenseTransaction.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgExpenseTransaction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgExpenseTransaction.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgExpenseTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgExpenseTransaction.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgExpenseTransaction.GridColor = System.Drawing.Color.Red;
            this.dgExpenseTransaction.Location = new System.Drawing.Point(14, 16);
            this.dgExpenseTransaction.MultiSelect = false;
            this.dgExpenseTransaction.Name = "dgExpenseTransaction";
            this.dgExpenseTransaction.RowTemplate.Height = 24;
            this.dgExpenseTransaction.Size = new System.Drawing.Size(443, 331);
            this.dgExpenseTransaction.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(396, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(172, 70);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 70);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // SearchExpenseTransactionfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(570, 614);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(588, 661);
            this.Name = "SearchExpenseTransactionfrm";
            this.Text = "SearchExpenseTransactionfrm";
            this.Load += new System.EventHandler(this.SearchExpenseTransactionfrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEDIT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgExpenseTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox btnAdd;
        private System.Windows.Forms.PictureBox btnSearch;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.PictureBox btnDelete;
        private System.Windows.Forms.PictureBox btnEDIT;
        private System.Windows.Forms.DataGridView dgExpenseTransaction;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlDebitType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox btnDownload;
        private System.Windows.Forms.ComboBox ddlType;
        private System.Windows.Forms.Label label1;
    }
}