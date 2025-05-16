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
            MovePanel(mainpanel, 10, new Point(555,361));
            

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
        public void RunAfterDelay(int delayMilliseconds, Action action)
        {
            new Thread(() =>
            {
                Thread.Sleep(delayMilliseconds);
                this.Invoke((MethodInvoker)(() =>
                {
                    action?.Invoke();
                }));
            }).Start();
        }

        private void Definition_Load(object sender, EventArgs e)
        {

        }
        public async void MovePanel(Panel mainpanel, int speed, Point targetLocation) // move the main table panel
        {

            while (mainpanel.Location != targetLocation)
            {
                int newX = Math.Abs(targetLocation.X - mainpanel.Location.X) < speed ? targetLocation.X : mainpanel.Location.X + Math.Sign(targetLocation.X - mainpanel.Location.X) * speed;
                int newY = Math.Abs(targetLocation.Y - mainpanel.Location.Y) < speed ? targetLocation.Y : mainpanel.Location.Y + Math.Sign(targetLocation.Y - mainpanel.Location.Y) * speed;
                mainpanel.Location = new Point(newX, newY);
                await Task.Delay(10);


            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
