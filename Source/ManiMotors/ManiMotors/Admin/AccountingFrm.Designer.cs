namespace ManiMotors.Admin
{
    partial class AccountingFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountingFrm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.lblBankSales = new System.Windows.Forms.Label();
            this.lblCashSales = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCashService = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBankService = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(15, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 114);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(377, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(367, 115);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Elephant", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(240, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(311, 31);
            this.label15.TabIndex = 49;
            this.label15.Text = "Account Reconcilliation ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Elephant", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(154, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Funds as CASH (SALES):";
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.SystemColors.Window;
            this.pnlGrid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlGrid.BackgroundImage")));
            this.pnlGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlGrid.Controls.Add(this.lblBankService);
            this.pnlGrid.Controls.Add(this.label5);
            this.pnlGrid.Controls.Add(this.lblCashService);
            this.pnlGrid.Controls.Add(this.label4);
            this.pnlGrid.Controls.Add(this.lblBankSales);
            this.pnlGrid.Controls.Add(this.lblCashSales);
            this.pnlGrid.Controls.Add(this.label2);
            this.pnlGrid.Controls.Add(this.label15);
            this.pnlGrid.Controls.Add(this.label1);
            this.pnlGrid.Location = new System.Drawing.Point(15, 143);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(729, 318);
            this.pnlGrid.TabIndex = 11;
            // 
            // lblBankSales
            // 
            this.lblBankSales.AutoSize = true;
            this.lblBankSales.BackColor = System.Drawing.Color.Transparent;
            this.lblBankSales.Font = new System.Drawing.Font("Elephant", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankSales.ForeColor = System.Drawing.Color.Red;
            this.lblBankSales.Location = new System.Drawing.Point(571, 184);
            this.lblBankSales.Name = "lblBankSales";
            this.lblBankSales.Size = new System.Drawing.Size(54, 31);
            this.lblBankSales.TabIndex = 52;
            this.lblBankSales.Text = "NA";
            // 
            // lblCashSales
            // 
            this.lblCashSales.AutoSize = true;
            this.lblCashSales.BackColor = System.Drawing.Color.Transparent;
            this.lblCashSales.Font = new System.Drawing.Font("Elephant", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashSales.ForeColor = System.Drawing.Color.Red;
            this.lblCashSales.Location = new System.Drawing.Point(571, 66);
            this.lblCashSales.Name = "lblCashSales";
            this.lblCashSales.Size = new System.Drawing.Size(54, 31);
            this.lblCashSales.TabIndex = 51;
            this.lblCashSales.Text = "NA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Elephant", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(63, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(427, 31);
            this.label2.TabIndex = 50;
            this.label2.Text = "Funds In BankAccount (SALES):";
            // 
            // lblCashService
            // 
            this.lblCashService.AutoSize = true;
            this.lblCashService.BackColor = System.Drawing.Color.Transparent;
            this.lblCashService.Font = new System.Drawing.Font("Elephant", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashService.ForeColor = System.Drawing.Color.Red;
            this.lblCashService.Location = new System.Drawing.Point(571, 125);
            this.lblCashService.Name = "lblCashService";
            this.lblCashService.Size = new System.Drawing.Size(54, 31);
            this.lblCashService.TabIndex = 54;
            this.lblCashService.Text = "NA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Elephant", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(116, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(374, 31);
            this.label4.TabIndex = 53;
            this.label4.Text = "Funds as CASH (SERVICE):";
            // 
            // lblBankService
            // 
            this.lblBankService.AutoSize = true;
            this.lblBankService.BackColor = System.Drawing.Color.Transparent;
            this.lblBankService.Font = new System.Drawing.Font("Elephant", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankService.ForeColor = System.Drawing.Color.Red;
            this.lblBankService.Location = new System.Drawing.Point(571, 243);
            this.lblBankService.Name = "lblBankService";
            this.lblBankService.Size = new System.Drawing.Size(54, 31);
            this.lblBankService.TabIndex = 56;
            this.lblBankService.Text = "NA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Elephant", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(25, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(465, 31);
            this.label5.TabIndex = 55;
            this.label5.Text = "Funds In BankAccount (SERVICE):";
            // 
            // AccountingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(759, 473);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pnlGrid);
            this.Name = "AccountingFrm";
            this.Text = "AccountingFrm";
            this.Load += new System.EventHandler(this.AccountingFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBankSales;
        private System.Windows.Forms.Label lblCashSales;
        private System.Windows.Forms.Label lblCashService;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBankService;
        private System.Windows.Forms.Label label5;
    }
}