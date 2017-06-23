﻿namespace ManiMotors
{
    partial class LandingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LandingForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehicleInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerEnquiryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehicleInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehicleInformationToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.vehicleInventoryToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.sparePartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sparePartsInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sparePartsInventoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventoryToolStripMenuItem,
            this.administrationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1355, 46);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("inventoryToolStripMenuItem.BackgroundImage")));
            this.inventoryToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.inventoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vehicleInventoryToolStripMenuItem,
            this.customerEnquiryToolStripMenuItem});
            this.inventoryToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(155, 42);
            this.inventoryToolStripMenuItem.Text = "Customer";
            // 
            // vehicleInventoryToolStripMenuItem
            // 
            this.vehicleInventoryToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vehicleInventoryToolStripMenuItem.BackgroundImage")));
            this.vehicleInventoryToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.vehicleInventoryToolStripMenuItem.Name = "vehicleInventoryToolStripMenuItem";
            this.vehicleInventoryToolStripMenuItem.Size = new System.Drawing.Size(335, 42);
            this.vehicleInventoryToolStripMenuItem.Text = "Customer Info";
            this.vehicleInventoryToolStripMenuItem.Click += new System.EventHandler(this.vehicleInventoryToolStripMenuItem_Click);
            // 
            // customerEnquiryToolStripMenuItem
            // 
            this.customerEnquiryToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("customerEnquiryToolStripMenuItem.BackgroundImage")));
            this.customerEnquiryToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.customerEnquiryToolStripMenuItem.Name = "customerEnquiryToolStripMenuItem";
            this.customerEnquiryToolStripMenuItem.Size = new System.Drawing.Size(335, 42);
            this.customerEnquiryToolStripMenuItem.Text = "Customer Enquiry";
            this.customerEnquiryToolStripMenuItem.Click += new System.EventHandler(this.customerEnquiryToolStripMenuItem_Click);
            // 
            // administrationToolStripMenuItem
            // 
            this.administrationToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("administrationToolStripMenuItem.BackgroundImage")));
            this.administrationToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.administrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vehicleInformationToolStripMenuItem,
            this.sparePartsToolStripMenuItem});
            this.administrationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.administrationToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            this.administrationToolStripMenuItem.Size = new System.Drawing.Size(227, 42);
            this.administrationToolStripMenuItem.Text = "Administration";
            // 
            // vehicleInformationToolStripMenuItem
            // 
            this.vehicleInformationToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vehicleInformationToolStripMenuItem.BackgroundImage")));
            this.vehicleInformationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vehicleInformationToolStripMenuItem2,
            this.vehicleInventoryToolStripMenuItem2});
            this.vehicleInformationToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.vehicleInformationToolStripMenuItem.Name = "vehicleInformationToolStripMenuItem";
            this.vehicleInformationToolStripMenuItem.Size = new System.Drawing.Size(248, 42);
            this.vehicleInformationToolStripMenuItem.Text = "Vehicles";
            // 
            // vehicleInformationToolStripMenuItem2
            // 
            this.vehicleInformationToolStripMenuItem2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vehicleInformationToolStripMenuItem2.BackgroundImage")));
            this.vehicleInformationToolStripMenuItem2.ForeColor = System.Drawing.SystemColors.Window;
            this.vehicleInformationToolStripMenuItem2.Name = "vehicleInformationToolStripMenuItem2";
            this.vehicleInformationToolStripMenuItem2.Size = new System.Drawing.Size(360, 42);
            this.vehicleInformationToolStripMenuItem2.Text = "Vehicle Information";
            this.vehicleInformationToolStripMenuItem2.Click += new System.EventHandler(this.vehicleInformationToolStripMenuItem2_Click);
            // 
            // vehicleInventoryToolStripMenuItem2
            // 
            this.vehicleInventoryToolStripMenuItem2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vehicleInventoryToolStripMenuItem2.BackgroundImage")));
            this.vehicleInventoryToolStripMenuItem2.ForeColor = System.Drawing.SystemColors.Window;
            this.vehicleInventoryToolStripMenuItem2.Name = "vehicleInventoryToolStripMenuItem2";
            this.vehicleInventoryToolStripMenuItem2.Size = new System.Drawing.Size(360, 42);
            this.vehicleInventoryToolStripMenuItem2.Text = "Vehicle Inventory";
            this.vehicleInventoryToolStripMenuItem2.Click += new System.EventHandler(this.vehicleInventoryToolStripMenuItem2_Click);
            // 
            // sparePartsToolStripMenuItem
            // 
            this.sparePartsToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sparePartsToolStripMenuItem.BackgroundImage")));
            this.sparePartsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sparePartsInformationToolStripMenuItem,
            this.sparePartsInventoryToolStripMenuItem1});
            this.sparePartsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.sparePartsToolStripMenuItem.Name = "sparePartsToolStripMenuItem";
            this.sparePartsToolStripMenuItem.Size = new System.Drawing.Size(248, 42);
            this.sparePartsToolStripMenuItem.Text = "Spare Parts";
            // 
            // sparePartsInformationToolStripMenuItem
            // 
            this.sparePartsInformationToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sparePartsInformationToolStripMenuItem.BackgroundImage")));
            this.sparePartsInformationToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.sparePartsInformationToolStripMenuItem.Name = "sparePartsInformationToolStripMenuItem";
            this.sparePartsInformationToolStripMenuItem.Size = new System.Drawing.Size(415, 42);
            this.sparePartsInformationToolStripMenuItem.Text = "Spare Parts Information";
            this.sparePartsInformationToolStripMenuItem.Click += new System.EventHandler(this.sparePartsInformationToolStripMenuItem_Click);
            // 
            // sparePartsInventoryToolStripMenuItem1
            // 
            this.sparePartsInventoryToolStripMenuItem1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sparePartsInventoryToolStripMenuItem1.BackgroundImage")));
            this.sparePartsInventoryToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Window;
            this.sparePartsInventoryToolStripMenuItem1.Name = "sparePartsInventoryToolStripMenuItem1";
            this.sparePartsInventoryToolStripMenuItem1.Size = new System.Drawing.Size(415, 42);
            this.sparePartsInventoryToolStripMenuItem1.Text = "Spare Parts Inventory";
            this.sparePartsInventoryToolStripMenuItem1.Click += new System.EventHandler(this.sparePartsInventoryToolStripMenuItem1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(33, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(737, 328);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(791, 134);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(526, 272);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // LandingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1355, 484);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "LandingForm";
            this.Text = "LandingForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehicleInventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehicleInformationToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem vehicleInformationToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem vehicleInventoryToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem sparePartsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sparePartsInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sparePartsInventoryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem customerEnquiryToolStripMenuItem;
    }
}