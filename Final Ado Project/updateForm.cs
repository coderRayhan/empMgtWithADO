using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOProject
{
    public partial class updateForm : UserControl
    {
        public updateForm()
        {
            InitializeComponent();
        }

        private void loadDivision()
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            SqlDataAdapter adapter = new SqlDataAdapter("select * from Division", cs);
            DataSet ds = new DataSet();
            //UdivBox.Items.Clear();
            adapter.Fill(ds);
            UdivBox.DataSource = ds.Tables[0];
            UdivBox.DisplayMember = "DivName";
            UdivBox.ValueMember = "DivID";

        }

        private void loadDistrict()
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            SqlDataAdapter adapter1 = new SqlDataAdapter($@"select * from District where DivID = {UdivBox.SelectedValue}", cs);
            DataSet ds1 = new DataSet();
            //districtBox.Items.Clear();
            adapter1.Fill(ds1);
            UDisBox.DataSource = ds1.Tables[0];
            UDisBox.DisplayMember = "DistrictName";
            UDisBox.ValueMember = "DistrictName";

        }

        private void loadDepartment()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Department", @"server=.\SQLEXPRESS;database=EmpManagementSystem;Integrated Security = True");
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            UdepartmentBox.DataSource = ds.Tables[0];
            UdepartmentBox.DisplayMember = "Department";
            UdepartmentBox.ValueMember = "Department";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"Select * from dbo.personalInfo where empID = {UidBox.Text}";
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    UnameBox.Text = sdr["Name"].ToString();
                    UphoneBox.Text = sdr["Phone"].ToString();
                    UemailBox.Text = sdr["Email"].ToString();
                    UdobBox.Text = sdr["DOB"].ToString();
                    UreligionBox.Text = sdr["Religion"].ToString();
                    UaddressBox.Text = sdr["Address"].ToString();
                    UdivBox.SelectedIndexChanged -= UdivBox_SelectedIndexChanged;
                    loadDivision();
                    UdivBox.SelectedIndexChanged += UdivBox_SelectedIndexChanged;
                    if (sdr["Gender"].ToString() == "Male")
                    {
                        UrdMale.Checked = true;
                    }
                    else
                    {
                        UrdFemale.Checked = true;
                    }

                    string path = sdr["Imagepath"].ToString();
                    UimageBox.Image = Image.FromFile(path);


                }
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"Select * from dbo.empInfo where empID = {UidBox.Text}";
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    UdepartmentBox.SelectedIndexChanged -= UdepartmentBox_SelectedIndexChanged;
                    loadDepartment();
                    UdepartmentBox.SelectedIndexChanged += UdepartmentBox_SelectedIndexChanged;
                    UdeginationBox.Text = sdr["Designation"].ToString();
                    UsalaryBox.Text = sdr["Salary"].ToString();
                }
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"Select * from dbo.reference where empID = {UidBox.Text}";
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    UrefNameBox.Text = sdr["ReferenceName"].ToString();
                    UrefPhoneBox.Text = sdr["ReferenceContact"].ToString();
                }
            }
        }
 

        private void UbtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spUpdatePersonalInfo";
                    cmd.Parameters.AddWithValue("@empID", UidBox.Text);
                    cmd.Parameters.AddWithValue("@Name", UnameBox.Text);
                    cmd.Parameters.AddWithValue("@Phone", UphoneBox.Text);
                    cmd.Parameters.AddWithValue("@Email", UemailBox.Text);
                    cmd.Parameters.AddWithValue("@DOB", UdobBox.Value);
                    cmd.Parameters.AddWithValue("@Gender", UrdMale.Checked ? UrdMale.Text : UrdFemale.Text);
                    cmd.Parameters.AddWithValue("@Religion", UreligionBox.SelectedItem);
                    cmd.Parameters.AddWithValue("@Address", UaddressBox.Text);
                    cmd.Parameters.AddWithValue("@Division", UdivBox.Text);
                    cmd.Parameters.AddWithValue("@District", UDisBox.Text);
                    cmd.Parameters.AddWithValue("@ImagePath", pathWithFile);
                    //Image img = UimageBox.Image;
                    //img.Save(path);
                    cmd.ExecuteNonQuery();



                }

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spUpdateEmpInfo";
                    cmd.Parameters.AddWithValue("@empID", UidBox.Text);
                    cmd.Parameters.AddWithValue("@Name", UnameBox.Text);
                    cmd.Parameters.AddWithValue("@Department", UdepartmentBox.SelectedValue);
                    cmd.Parameters.AddWithValue("@Designation", UdeginationBox.SelectedItem);
                    cmd.Parameters.AddWithValue("@Salary", UsalaryBox.Text);
                    cmd.ExecuteNonQuery();

                }

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spUpadteRefInfo";
                    cmd.Parameters.AddWithValue("@empID", UidBox.Text);
                    cmd.Parameters.AddWithValue("@ReferenceName", UrefNameBox.Text);
                    cmd.Parameters.AddWithValue("@ReferenceContact", UrefPhoneBox.Text);
                    cmd.ExecuteNonQuery();

                }

                clear();
                MessageBox.Show("Record Updated");
            }
            catch(Exception)
            {
                MessageBox.Show("Incorrect Information");
            }

        }


        string UimagePath = "";
        string pathWithFile;
        private void UbtnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Image Files(*.jpg; *.jpeg; .*.gif;)|*.jpg; *.jpeg; .*.gif; ";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {

                    string directoryPath = AppDomain.CurrentDomain.BaseDirectory + "Emp Image";
                    string imageFile = System.IO.Path.GetFileName(fileDialog.FileName);
                    UimagePath = imageFile;
                    UimageBox.Image = new Bitmap(fileDialog.FileName);

                    pathWithFile = directoryPath + "\\" + imageFile;
                    if (File.Exists(pathWithFile))
                    {
                        File.Delete(pathWithFile);
                    }
                    File.Copy(fileDialog.FileName, pathWithFile);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Insert Correct Image");
            }
            
        }

        private void updateForm_Load(object sender, EventArgs e)
        {
            loadDepartment();
        }

        private void UbtnDelete_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spDeleteRefInfo";
                cmd.Parameters.AddWithValue("@empID", UidBox.Text);
                cmd.ExecuteNonQuery();
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spDeleteEmpInfo";
                cmd.Parameters.AddWithValue("@empID", UidBox.Text);
                cmd.ExecuteNonQuery();
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spDeletePersonalInfo";
                cmd.Parameters.AddWithValue("@empID", UidBox.Text);
                cmd.ExecuteNonQuery();
            }
            clear();
            MessageBox.Show("Record Deleted");
        }

        private void UdivBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDistrict();
        }

        private void UdepartmentBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDepartment();
        }

        public void clear()
        {
            UidBox.Text = "";
            UnameBox.Text = "";
            UphoneBox.Text = "";
            UemailBox.Text = "";
            UdobBox.Value = DateTime.Now;
            if (UrdMale.Checked == true)
            {
                UrdMale.Checked = false;
            }
            else
            {
                UrdFemale.Checked = false;
            }
            UreligionBox.Text = "";
            UaddressBox.Text = "";
            UdivBox.Text = "";
            UDisBox.Text = "";
            UimageBox.Image = null;
            UdepartmentBox.Text = "";
            UdeginationBox.Text = "";
            UsalaryBox.Text = "";
            UrefNameBox.Text = "";
            UrefPhoneBox.Text = "";
        }

    }
}
