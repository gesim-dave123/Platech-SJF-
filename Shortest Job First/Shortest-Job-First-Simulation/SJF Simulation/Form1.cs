using System;

namespace SJF_Simulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void titlepanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void continuebtn_Click(object sender, EventArgs e)
        {
            MovePanel(mainpanel, 10, new Point(-500,208));
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

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            MovePanel(mainpanel, 10, new Point(-500, 208));
            RunAfterDelay(1500, () =>
            {
                Definition diff = new Definition();
                diff.Show();
                this.Hide();
            });

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
