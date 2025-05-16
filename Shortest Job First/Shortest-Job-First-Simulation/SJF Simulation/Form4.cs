using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SJF_Simulation
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            TransparentPanel semiTransparentPanel = new TransparentPanel();
            semiTransparentPanel.Size = new Size(200, 100);
            semiTransparentPanel.Location = new Point(12, 542);
           // semiTransparentPanel.BackColor= Color.White
            this.Controls.Add(semiTransparentPanel);
        }
    }
}
