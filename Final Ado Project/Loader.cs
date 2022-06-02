using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOProject
{
    public partial class Loader : Form
    {
        public Loader()
        {
            InitializeComponent();
        }


        int startPoint = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            startPoint += 1;
            loaderBar.Value = startPoint;
            if(loaderBar.Value == 30)
            {
                loaderBar.Value = 0;
                timer.Stop();
                this.Hide();

                Form1 main = new Form1();
                main.Show();
            }
        }

        private void Loader_Load(object sender, EventArgs e)
        {
            timer.Start();
        }
    }
}
