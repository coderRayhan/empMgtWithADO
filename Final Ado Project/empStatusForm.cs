using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADOProject
{
    public partial class empStatusForm : UserControl
    {
        public empStatusForm()
        {

            InitializeComponent();
        }

        public void dataLoad()
        {
            SqlDataAdapter dadpter = new SqlDataAdapter("select * from personalInfo", @"server=.\SQLEXPRESS;database=EmpManagementSystem;Integrated Security = True");
            DataSet dset = new DataSet();
            dadpter.Fill(dset);
            empIDBox.DataSource = dset.Tables[0];
            empIDBox.DisplayMember = "empID";
            empIDBox.ValueMember = "Name";
            empNameBox.DataBindings.Add("Text", dset.Tables[0], "Name");
        }
        private void empStatusForm_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Department", @"server=.\SQLEXPRESS;database=EmpManagementSystem;Integrated Security = True");
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            departmentBox.DataSource = ds.Tables[0];
            departmentBox.DisplayMember = "Department";
            departmentBox.ValueMember = "Department";

            //departmentBox.DataBindings.Add("Text", ds.Tables[0], "DepartmentID");
        }

        private void btnSaveES_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlTransaction ts = con.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.Transaction = ts;
                       
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spInsertEmpInfo";
                        cmd.Parameters.AddWithValue("@empID", empIDBox.Text);
                        cmd.Parameters.AddWithValue("@Name", empNameBox.Text);
                        cmd.Parameters.AddWithValue("@Department", departmentBox.SelectedValue);
                        cmd.Parameters.AddWithValue("@Designation", designationBox.SelectedItem);
                        //MessageBox.Show(departmentBox.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@Salary", salaryBox.Text);
                        cmd.ExecuteNonQuery();



                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = con;
                        cmd1.Transaction = ts;
                       
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.CommandText = "spInsertRefInfo";
                        cmd1.Parameters.AddWithValue("@empID", empIDBox.Text);
                        cmd1.Parameters.AddWithValue("@ReferenceName", refNameBox.Text);
                        cmd1.Parameters.AddWithValue("@ReferenceContact", refContactBox.Text);
                        cmd1.ExecuteNonQuery();

                        ts.Commit();
                        MessageBox.Show("Employee status Recorded");

                    }
                    catch(Exception ex)
                    {
                        ts.Rollback();
                        MessageBox.Show("Employee status is not  Recorded");
                    }
                }
            }
            clear();
           
        }

        public void clear()
        {
            empIDBox.Text = "";
            empNameBox.Text = "";
            departmentBox.Text = "";
            designationBox.Text = "";
            refNameBox.Text = "";
            refContactBox.Text = "";
            salaryBox.Text = "";
        }

        private void btnClearES_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
