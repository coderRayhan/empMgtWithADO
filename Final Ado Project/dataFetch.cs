using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOProject
{
    public partial class dataFetch : Form
    {
        public dataFetch()
        {
            InitializeComponent();
        }

        private void dataFetch_Load(object sender, EventArgs e)
        {
            
        }

        public void fetch()
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select p.empID, p.Name, Phone, Email, DOB, Gender, Religion, Address, Division, District, Department, Designation, Salary, ReferenceName, ReferenceContact from dbo.personalInfo as p join dbo.empInfo as e on p.empID = e.empID join dbo.reference as r on p.empID = r.empID";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgv.DataSource = ds.Tables[0];
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
