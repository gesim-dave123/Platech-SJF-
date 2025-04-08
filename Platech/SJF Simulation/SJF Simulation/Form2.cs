using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SJF_Simulation
{
    public partial class Form2 : Form     
    {
        public static Form2 instance;
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Continuebtn2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Field should not be empty", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(textBox1.Text, out int processCount))
            {
                MessageBox.Show("Invalid input! Please enter a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
            }
            else if (processCount != 3 && processCount != 4 && processCount != 5)
            {
                MessageBox.Show("Minimum of 3 and maximum of 5 processes only", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
            }
            else
            {
                form3.ProcessCount = processCount;
                form3.Show();
                this.Hide();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
