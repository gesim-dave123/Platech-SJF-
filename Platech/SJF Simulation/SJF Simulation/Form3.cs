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
    public partial class Form3 : Form
    {

        public int ProcessCount { get; set; }
        private Panel mainpanel;
        private TextBox[,] textboxes;
        List<TextBox> textboxeslist;
        public Form3()
        {
            InitializeComponent();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            GeneratePanels(ProcessCount);
        }
        private void Add_Unit(object sender, EventArgs e) // add msec after enter
        {
            TextBox textbox = sender as TextBox;

            if (textbox != null && !string.IsNullOrWhiteSpace(textbox.Text))
            {
                bool isBurstTimeColumn = false;
                int rowIndex = -1, colIndex = -1;

               
                for (int i = 0; i < ProcessCount; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (textboxes[i, j] == textbox)
                        {
                            rowIndex = i;
                            colIndex = j;
                            break;
                        }
                    }
                    if (rowIndex != -1 && colIndex != -1)
                        break;
                }

                // Now check if it's in the burst time column (column index 1)
                if (colIndex == 1) // Burst Time Column
                {
                    isBurstTimeColumn = true;
                }

                if (float.TryParse(textbox.Text.Replace(" msec", "").Trim(), out float value))
                {
                    if (isBurstTimeColumn) // Burst Time Validation
                    {
                        if (value > 0 && value <= 15)
                        {
                            textbox.Text = $"{value} msec";
                        }
                        else
                        {
                            if (value <= 0)
                            {
                                MessageBox.Show("Burst time should be greater than 0 msec!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textbox.Text = "";  // Clear the invalid input
                                textbox.Focus(); // Refocus to correct the input
                            }
                            else if (value > 15)
                            {
                                MessageBox.Show("Burst time should not exceed 15 msec!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textbox.Text = "";  // Clear the invalid input
                                textbox.Focus(); // Refocus to correct the input
                            }
                        }
                    }
                    else // Arrival Time Validation (no restrictions)
                    {
                        if (value > 0 && value <= 20)
                        {
                            textbox.Text = $"{value} msec"; // Set the valid value for Arrival Time
                        }
                        else
                        {
                            if (value <= 0)
                            {
                                MessageBox.Show("Arrival time should be greater than 0 msec!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (value > 20)
                            {
                                MessageBox.Show("Arrival time should not exceed 20 msec!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            textbox.Text = "";  // Clear the invalid input
                            textbox.Focus(); // Refocus to correct the input
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid number!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textbox.Text = "";  // Clear the invalid input
                    textbox.Focus(); // Refocus to correct the input
                }
            }
            else
            {
                MessageBox.Show("Field should not be empty", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Text = "";  // Clear the invalid input
                textbox.Focus(); // Refocus to correct the input
            }
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)//press enter to go to next textbox
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private List<ProcessData> processList = new List<ProcessData>();

        private void ExtractData() // extract data from the textbox
        {
            processList.Clear(); 

            for (int i = 0; i < ProcessCount; i++)
            {
                string processID = textboxes[i, 0].Text;
                float burstTime, arrivalTime;

                if (float.TryParse(textboxes[i, 1].Text.Replace(" msec", "").Trim(), out burstTime) &&
                    float.TryParse(textboxes[i, 2].Text.Replace(" msec", "").Trim(), out arrivalTime))
                {
                    processList.Add(new ProcessData
                    {
                        ProcessID = processID,
                        BurstTime = burstTime,
                        ArrivalTime = arrivalTime,
                        RemainingTime =burstTime

                    });
                }
                else
                {
                    MessageBox.Show($"Invalid input in row {i + 1}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

           
        }
        private void ProcessData(List<Process>processes) {
            ExtractData();
            int currentTime = 0;
            int completion = 0;
            List<Process> readyQueue = new List<Process>();
           


        }


        private void GeneratePanels(int count) // create the components 
        {
            textboxes = new TextBox[count,3];

            String[] headers = { "Process ID", "CPU Burst Time", "Arrival Time" };

            int panelheight = 40;
            int panelwidth = 200;
            int spacing = 3;
            int mainpanelheight = (panelheight + spacing) * (count + 1) - spacing;
            int mainpanelwidth = 612;

            int totalHeight = (panelheight + spacing) * count - spacing;


            mainpanel = new Panel
            {
                Size = new Size(mainpanelwidth, mainpanelheight),
                Location = new Point(352, 188),
                BackColor = Color.FromArgb(5, 168, 100),
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = true,

            };
            Panel panelheader = new Panel
            {
                Size = new Size(mainpanelwidth - 6, panelheight),
                Location = new Point(3, 3),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.Black,
            };
            mainpanel.Controls.Add(panelheader);
            for (int j = 0; j < headers.Length; j++)
            {


                Label label = new Label
                {
                    Text = headers[j],
                    Width = (panelheader.Width / 3) - 3,
                    Location = new Point(j * (panelheader.Width / 3), 3),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Tahoma", 13.8f, FontStyle.Bold),
                    ForeColor = Color.Lime,
                };

                panelheader.Controls.Add(label);

            }

            for (int i = 0; i < count; i++)

            {

                
                
                Panel panelrows = new Panel
                {
                    Size = new Size(mainpanelwidth - 6, panelheight),
                    Location = new Point(3, (panelheight + 5) * (i + 1)),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.Black,

                };
                for (int j = 0; j < 3; j++)
                {
                    TextBox textbox = new TextBox
                    {
                        Multiline = true,
                        Size = new Size((panelrows.Width / 3) - 2, 32),
                        Font = new Font("Tahoma", 13.8f, FontStyle.Bold),
                        ForeColor = Color.Lime,
                        BackColor = Color.Black,
                        Width = (panelrows.Width / 3),
                        Location = new Point(j * (panelrows.Width / 3), 3),
                        Name = $"textbox_{i}_{j}",
                        TextAlign = HorizontalAlignment.Center,
                        BorderStyle = BorderStyle.FixedSingle,
                        
                
                    };

                    if (j == 0)
                    {
                        textbox.Text = $"P{i + 1}";
                        textbox.Enabled = false;
                        textbox.TextAlign = HorizontalAlignment.Center;
                        textbox.ForeColor = Color.Lime;
                        textbox.Font = new Font("Tahoma", 13.8f, FontStyle.Bold);

                        textbox.BackColor = Color.Black;


                    }
                    else
                    {

                           
                            textbox.Leave += Add_Unit;
                            textbox.KeyDown += TextBox_KeyDown;
                        


                    }
                    textboxes[i,j]= textbox;
                    panelrows.Controls.Add(textbox);
                }
                mainpanel.Controls.Add(panelrows);
            }
            this.Controls.Add(mainpanel);
            textboxes[0, 1].Focus();

        }

        private void button1_Click(object sender, EventArgs e) //continue button
        {
           
            foreach (var textbox in textboxes)
            {
                if (string.IsNullOrWhiteSpace(textbox.Text))
                {
                    MessageBox.Show("All fields should be filled!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // If all fields are filled, proceed
            MovePanel(new Point(12, 60));
            button1.Visible = false;

            // Set labels and buttons to visible
            labelGC.Visible = true;
            button2.Visible = true;

            // Disable all textboxes
            for (int i = 0; i < ProcessCount; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    textboxes[i, j].Enabled = false;
                }
            }
        }

        private async void MovePanel(Point targetLocation) // move the main table panel
        {
            int speed = 5; 
            while (mainpanel.Location != targetLocation)
            {
                int newX = Math.Abs(targetLocation.X - mainpanel.Location.X) < speed ? targetLocation.X : mainpanel.Location.X + Math.Sign(targetLocation.X - mainpanel.Location.X) * speed;
                int newY = Math.Abs(targetLocation.Y - mainpanel.Location.Y) < speed ? targetLocation.Y : mainpanel.Location.Y + Math.Sign(targetLocation.Y - mainpanel.Location.Y) * speed;
                mainpanel.Location = new Point(newX, newY);
                await Task.Delay(10); 


            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

       

    }
}
