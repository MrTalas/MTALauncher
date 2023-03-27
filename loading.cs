using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTALauncher
{
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 2;
            if(panel2.Width > 380) {
                timer1.Stop();
                launcher launch= new launcher();
                launch.Show();
                Hide();


            }
        }
    }
}
