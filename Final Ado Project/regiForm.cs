using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADOProject
{
    public partial class regiForm : UserControl
    {

        public regiForm()
        {
            InitializeComponent();
        }

        private void regiForm_Load(object sender, EventArgs e)
        {
            divisionBox.SelectedIndexChanged -= divisionBox_SelectedIndexChanged;
            loadDivision();
            divisionBox.SelectedIndexChanged += divisionBox_SelectedIndexChanged;
        }

        private void loadDivision()
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            SqlDataAdapter adapter = new SqlDataAdapter("select * from Division", cs);
            DataSet ds = new DataSet();
            divisionBox.Items.Clear();
            adapter.Fill(ds);
            divisionBox.DataSource = ds.Tables[0];
            divisionBox.DisplayMember = "DivName";
            divisionBox.ValueMember = "DivID";

        }

        private void loadDistrict()
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            SqlDataAdapter adapter1 = new SqlDataAdapter($@"select * from District where DivID = {divisionBox.SelectedValue}", cs);
            DataSet ds1 = new DataSet();
            //districtBox.Items.Clear();
            adapter1.Fill(ds1);
            districtBox.DataSource = ds1.Tables[0];
            districtBox.DisplayMember = "DistrictName";
            districtBox.ValueMember = "DistrictName";

        }

        //string path
        private void btnSave_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            //string directory = @"C:\Users\Ami Rana Gully Boy\Desktop\Ado Project Final\ADOProject\bin\Debug\Emp Image";
            //string path = Path.Combine(directory, imagePath);

            if(nameBox.Text == "" || phoneBox.Text == "" || emailBox.Text == "" || ReligionBox.Text == "" || addressBox.Text == "" || divisionBox.Text == "" || districtBox.Text == "" )
            {
                MessageBox.Show("Information Missing");
            }
            else
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spInsertPersonalInfo";
                    cmd.Parameters.AddWithValue("@Name", nameBox.Text);
                    cmd.Parameters.AddWithValue("@Phone", phoneBox.Text);
                    cmd.Parameters.AddWithValue("@Email", emailBox.Text);
                    cmd.Parameters.AddWithValue("@DOB", dobBox.Value);
                    cmd.Parameters.AddWithValue("@Gender", rdMale.Checked ? rdMale.Text : rdFemale.Text);
                    cmd.Parameters.AddWithValue("@Religion", ReligionBox.SelectedItem);
                    cmd.Parameters.AddWithValue("@Address", addressBox.Text);
                    cmd.Parameters.AddWithValue("@Division", divisionBox.Text);
                    cmd.Parameters.AddWithValue("@District", districtBox.Text);
                    cmd.Parameters.AddWithValue("@ImagePath", pathWithFile);
                    //Image img = imageBox.Image;
                    //img.Save(path);
                    cmd.ExecuteNonQuery();


                }

                clear();
                MessageBox.Show("New record inserted");
            }
        }


        string pathWithFile;
        public static string imagePath = "";
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files(*.jpg; *.jpeg; .*.gif;)|*.jpg; *.jpeg; .*.gif; ";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {

                string directoryPath = AppDomain.CurrentDomain.BaseDirectory + "Emp Image";
                string imageFile = System.IO.Path.GetFileName(fileDialog.FileName);
                imagePath = imageFile;
                imageBox.Image = new Bitmap(fileDialog.FileName);

                pathWithFile = directoryPath + "\\" + imageFile;
                if (File.Exists(pathWithFile))
                {
                    File.Delete(pathWithFile);
                }
                File.Copy(fileDialog.FileName, pathWithFile);
                //MessageBox.Show(pathWithFile);
            }
        }



        public void clear()
        {
            nameBox.Text = "";
            phoneBox.Text = "";
            emailBox.Text = "";
            addressBox.Text = "";
            imageBox.Image = null;
            dobBox.Value = DateTime.Now;
            ReligionBox.SelectedItem = null;
            if(rdMale.Checked == true)
            {
                rdMale.Checked = false;
            }
            else
            {
                rdFemale.Checked = false;
            }
            imageBox.Image = null;
            //divisionBox.SelectedItem = null;
            districtBox.SelectedItem = null;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void divisionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDistrict();
        }
    }
}
