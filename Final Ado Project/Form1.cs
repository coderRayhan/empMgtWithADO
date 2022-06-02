using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle=FormBorderStyle.None;
            empStatusForm1.Visible = false;
            regiForm1.Visible = false;
            submenuPanel.Visible = false;
            submenuPanel1.Visible = false;
            updateForm1.Visible = false;
            subMenu3.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainLabel.Text = "Employee Registration Form";
            regiForm1.Visible = true;
            empStatusForm1.Visible = false;
            updateForm1.Visible = false;
            
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
            
            
        }

        private void btnMaximise_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Maximized;
            btnMaximise.Visible=false;
            btnRestore.Location = btnMaximise.Location;
            btnRestore.Visible = true;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestore.Visible=false;
            btnMaximise.Visible = true;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            mainLabel.Text = "Employee Portal";
            empStatusForm1.Visible = false;
            regiForm1.Visible = false;
            submenuPanel.Visible = false;
            submenuPanel1.Visible = false;
            updateForm1.Visible = false;
            subMenu3.Visible= false;
        }

        private void employeeStatusForm1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                empStatusForm1.dataLoad();
            }
            catch(Exception)
            {
                MessageBox.Show("Data bind unsuccessful");
            }
            
            //empStatusForm1.Refresh();
            mainLabel.Text = "Employee Status Form";
            empStatusForm1.Visible = true;
            regiForm1.Visible = false;
            updateForm1.Visible = false;
        }

        private void btnForms_Click(object sender, EventArgs e)
        {
            submenuPanel.Visible = true;
            submenuPanel1.Visible = false;
            subMenu3.Visible = false;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            submenuPanel1.Visible = true;
            submenuPanel.Visible = false;
            subMenu3.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateForm1.Visible = true;
            regiForm1.Visible = false;
            empStatusForm1.Visible = false;
            mainLabel.Text = "Update and Delete Data";
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            dataFetch df = new dataFetch();
            
            df.fetch();
            df.Show();
        }

        private void regiForm1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            profile profile = new profile();
            profile.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            subMenu3.Visible = true;
            submenuPanel.Visible = false;
            submenuPanel1.Visible = false;
        }

        private void btnRpt_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
            report.FormBorderStyle = FormBorderStyle.Sizable;
        }
    }
}
