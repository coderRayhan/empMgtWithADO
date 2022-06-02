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
    public partial class profile : Form
    {
        public profile()
        {
            InitializeComponent();
        }

        private void visibility()
        {
            lblName.Visible = true;
            lblPhone.Visible = true;
            lblEmail.Visible = true;
            lblDob.Visible = true;
            lblGender.Visible = true;
            lblReligion.Visible = true;
            lblAddress.Visible = true;
            lblDivision.Visible = true;
            lblDistrict.Visible = true;
            lblDepartment.Visible = true;
            lblDesignation.Visible = true;
            lblSalary.Visible = true;
            lblRefName.Visible = true;
            lblRefContact.Visible = true;
            lblPic.Visible = true;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            try
            {
                visibility();
                string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"select p.empID, p.Name, Phone, Email, DOB, Gender, Religion, Address, Division, District, Department, Designation, Salary,Imagepath, ReferenceName, ReferenceContact from dbo.personalInfo as p join dbo.empInfo as e on p.empID = e.empID join dbo.reference as r on p.empID = r.empID where p.empID = {Convert.ToInt32(idBox.Text)}";
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        lblName.Text = sdr["Name"].ToString();
                        lblPhone.Text = sdr["Phone"].ToString();
                        lblEmail.Text = sdr["Email"].ToString();
                        lblDob.Text = sdr["DOB"].ToString();
                        lblGender.Text = sdr["Gender"].ToString();
                        lblReligion.Text = sdr["Religion"].ToString();
                        lblAddress.Text = sdr["Address"].ToString();
                        lblDivision.Text = sdr["Division"].ToString();
                        lblDistrict.Text = sdr["District"].ToString();
                        lblDepartment.Text = sdr["Department"].ToString();
                        lblDesignation.Text = sdr["Designation"].ToString();
                        lblSalary.Text = sdr["Salary"].ToString();
                        lblRefName.Text = sdr["ReferenceName"].ToString();
                        lblRefContact.Text = sdr["ReferenceContact"].ToString();
                        string path = sdr["Imagepath"].ToString();
                        picBox.Image = Image.FromFile(path);
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Incorrect ID");
            }
            
        }
    }
}
