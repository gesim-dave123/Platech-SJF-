using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SJF_Simulation
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            
            button1.Enabled = false;
            panel2.Width = 0;
            panel2.Left = 600 + 60;
            AnimatePanelGrowth(panel2, growWidth: true, targetSize: 453, speed: 10, growLeft: true);
            RunAfterDelay(1000, () =>
            {
              
                panel3.Width = 10;
                panel3.Height = 140;
                AnimatePanelUpward(panel3, targetHeight: 144, speed: 10);
            });
            RunAfterDelay(1300, () =>
            {
               
                panel4.Width = 0;
                panel4.Left = 205; // Starting X coordinate
                panel4.Top = 670; // Adjust Y if needed
                AnimatePanelGrowth(panel4, growWidth: true, targetSize: 1113, speed: 10);
            });
            RunAfterDelay(3250, () =>
            {
                
                panel5.Width = 10;
                panel5.Height = 98;
                AnimatePanelUpward(panel5, targetHeight: 98, speed: 10);
            });
            RunAfterDelay(3400, () =>
            {
               
                panel6.Width = 0;
                panel6.Left = 1315;
                AnimatePanelGrowth(panel6, growWidth: true, targetSize: 1112, speed: 10, growLeft: true);
            });
            RunAfterDelay(5200, () =>
            {
              
                panel7.Width = 10;
                panel7.Height = 98;
                AnimatePanelUpward(panel7, targetHeight: 220, speed: 10);
            });
            RunAfterDelay(5700, () =>
            {
               
                panel8.Width = 0;
                panel8.Left = 205; //  X coordinate
                panel8.Top = 358; //  Y 
                AnimatePanelGrowth(panel8, growWidth: true, targetSize: 180, speed: 10);

            });
           
            RunAfterDelay(6700, () =>
            {
                
                pictureBox2.Visible = true;
            });

            RunAfterDelay(7200, () =>
            {
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
         
                AnimateGrow(pictureBox2);
              
            });
            RunAfterDelay(8500, () =>
            {
                Form1 form1 = new Form1();
               form1.Show();
                this.Hide();
            });




        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }


        public void AnimatePanelGrowth(Panel panel, bool growWidth = true, int targetSize = 300, int speed = 5, bool growLeft = false)
        {
            new Thread(() =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    panel.Visible = true;
                });

                while (true)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (growWidth)
                        {
                            if (panel.Width < targetSize)
                            {
                                panel.Width += speed;

                                // If growing left, shift the panel's X position
                                if (growLeft)
                                {
                                    panel.Left -= speed;
                                }
                            }
                        }
                        else
                        {
                            if (panel.Height < targetSize)
                            {
                                panel.Height += speed;
                            }
                        }
                    });

                    Thread.Sleep(10); // Control speed of animation

                    bool isComplete = false;
                    this.Invoke((MethodInvoker)delegate
                    {
                        isComplete = panel.Width >= targetSize;
                    });

                    if (isComplete)
                        break;
                }
            }).Start();
        }
        private void AnimatePanelUpward(Panel panel, int targetHeight = 100, int speed = 5)
        {
            int startY = panel.Top + panel.Height; // Bottom position (where it ends)
            panel.Height = 0;
            panel.Top = startY;

            new Thread(() =>
            {
                this.Invoke((MethodInvoker)(() => panel.Visible = true));

                while (true)
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        if (panel.Height < targetHeight)
                        {
                            panel.Top -= speed;
                            panel.Height += speed;
                        }
                    }));

                    Thread.Sleep(10);

                    bool done = false;
                    this.Invoke((MethodInvoker)(() =>
                    {
                        done = panel.Height >= targetHeight;
                    }));

                    if (done) break;
                }
            }).Start();
        }
        public static void AnimateGrow(PictureBox picBox, int maxWidth = 1307,int maxHeight=857, int growStep = 10, int delay = 3)
        {
            Thread thread = new Thread(() =>
            {
                while (picBox.Width < maxWidth && picBox.Height < maxHeight)
                {
                    Thread.Sleep(delay);

                    if (picBox.InvokeRequired)
                    {
                        picBox.Invoke(new Action(() =>
                        {
                            picBox.Width += growStep;
                            picBox.Height += growStep;

                            // Optional: Keep image centered in its parent (like a Panel)
                            if (picBox.Parent != null)
                            {
                                picBox.Location = new Point(
                                    (picBox.Parent.Width - picBox.Width) / 2,
                                    (picBox.Parent.Height - picBox.Height) / 2
                                );
                            }
                        }));
                    }
                }
            });

            thread.IsBackground = true;
            thread.Start();
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Screen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CPU_Click(object sender, EventArgs e)
        {

        }
    }
}
