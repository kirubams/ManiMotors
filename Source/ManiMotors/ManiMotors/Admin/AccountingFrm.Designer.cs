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
            this.lblBank = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.label15.Location = new System.Drawing.Point(179, 14);
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
            this.label1.Location = new System.Drawing.Point(125, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Funds as CASH :";
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.SystemColors.Window;
            this.pnlGrid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlGrid.BackgroundImage")));
            this.pnlGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlGrid.Controls.Add(this.lblBank);
            this.pnlGrid.Controls.Add(this.lblCash);
            this.pnlGrid.Controls.Add(this.label2);
            this.pnlGrid.Controls.Add(this.label15);
            this.pnlGrid.Controls.Add(this.label1);
            this.pnlGrid.Location = new System.Drawing.Point(15, 143);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(729, 268);
            this.pnlGrid.TabIndex = 11;
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.BackColor = System.Drawing.Color.Transparent;
            this.lblBank.Font = new System.Drawing.Font("Elephant", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBank.ForeColor = System.Drawing.Color.Red;
            this.lblBank.Location = new System.Drawing.Point(356, 180);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(54, 31);
            this.lblBank.TabIndex = 52;
            this.lblBank.Text = "NA";
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.BackColor = System.Drawing.Color.Transparent;
            this.lblCash.Font = new System.Drawing.Font("Elephant", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.ForeColor = System.Drawing.Color.Red;
            this.lblCash.Location = new System.Drawing.Point(356, 98);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(54, 31);
            this.lblCash.TabIndex = 51;
            this.lblCash.Text = "NA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Elephant", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(40, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(306, 31);
            this.label2.TabIndex = 50;
            this.label2.Text = "Funds In BankAccount:";
            // 
            // AccountingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(759, 422);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pnlGrid);
            this.MaximumSize = new System.Drawing.Size(777, 469);
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
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label lblCash;
    }
}