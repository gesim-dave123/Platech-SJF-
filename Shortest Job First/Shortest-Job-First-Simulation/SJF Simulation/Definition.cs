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
    public partial class Definition : Form
    {
        public Definition()
        {
            InitializeComponent();

            MovePanel(mainpanel, 10, new Point(3, 37));
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void GoBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void gotoSimulate1_Click(object sender, EventArgs e)
        {

            MovePanel(mainpanel, 20, new Point(-1500, 37));
            RunAfterDelay(1500, () =>
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            });


            
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
    }
}
