using ManiMotors;
using MessageBoxExample;
using MM.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace MM.Login
{
    public partial class LoginControl : Form
    {

        static LoginControl newMessageBox;
        public Timer msgTimer;
        static string Button_id;
        int disposeFormTimer; 

        public LoginControl()
        {
            InitializeComponent();
        }

       
        private void LoginControl_Load(object sender, EventArgs e)
        {
            disposeFormTimer = 30;
            newMessageBox.lblTimer.Text = disposeFormTimer.ToString();
            msgTimer = new Timer();
            msgTimer.Interval = 1000;
            msgTimer.Enabled = true;
            msgTimer.Start();
            msgTimer.Tick += new System.EventHandler(this.timer_tick); 
        }

        private void MyMessageBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics mGraphics = e.Graphics;
            Pen pen1 = new Pen(Color.FromArgb(246, 6, 6), 1);
            
            Rectangle Area1 = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush LGB = new LinearGradientBrush(Area1, Color.FromArgb(238, 219, 219), Color.FromArgb(255, 255, 255), LinearGradientMode.Vertical);
            mGraphics.FillRectangle(LGB, Area1);
            mGraphics.DrawRectangle(pen1, Area1);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            newMessageBox.msgTimer.Stop();
            newMessageBox.msgTimer.Dispose();
            Button_id = "1";
            newMessageBox.Dispose(); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            newMessageBox.msgTimer.Stop();
            newMessageBox.msgTimer.Dispose();
            Button_id = "2"; 
            newMessageBox.Dispose();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            disposeFormTimer--;

            if (disposeFormTimer >= 0)
            {
                newMessageBox.lblTimer.Text = disposeFormTimer.ToString();
            }
            else
            {
                newMessageBox.msgTimer.Stop();
                newMessageBox.msgTimer.Dispose();
                newMessageBox.Dispose();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(txtuserName.Text == "" || txtPassword.Text == "")
            {
                MyMessageBox.ShowBox("UserName or PassWord cannot be Empty!!!");
                return;
            }
            string role = "";
            if(txtPassword.Text == GlobalSetup.AdminPassword)
            {
                role = "ADMIN";
            }
            else if(txtPassword.Text == GlobalSetup.StaffPassword)
            {
                role = "STAFF";
            }
            else
            {
                MyMessageBox.ShowBox("Password is Incorrect!!!");
                return;
            }

            LandingForm frm = new LandingForm(txtuserName.Text, role);
            this.Hide();
            frm.ShowDialog();
            txtuserName.Text = "";
            txtPassword.Text = "";
            this.Show();
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            newMessageBox.msgTimer.Stop();
            newMessageBox.msgTimer.Dispose();
            Button_id = "2";
            newMessageBox.Dispose();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}