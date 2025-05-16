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

        public int ProcessCount { get; set; }// katu ni kung pila kabouk process ang ganahan sa user, gi pasa ni from form 2
        private Panel mainpanel; // gi declare ni nako diri para ni ma animate ang mainpanel sa Tables
        private Panel mainChartPanel;// gi declare sad ni nako diri para ma animate ang gantt chart
        private Panel chartPanel;// mao ni ang sub panel sa gantt chart na naay boxes
        private Panel timeLabelPanel;
        private TextBox[,] textboxes;// diri nako gi store anh textboxes nga naay BT, AT og Process ID para ma extract nako and contents nya mabutang sa prcesslist



        Color[] rgbaColors = new Color[] // Array of colors para sa gantt chart and proceses
                {
                    Color.FromArgb(212, 225, 87),
                    Color.FromArgb(156, 204, 101),
                    Color.FromArgb(102, 187, 106),
                    Color.FromArgb(38, 166, 154),
                    Color.FromArgb(38, 198, 218),
                };

        public List<ProcessData> processList = new List<ProcessData>();// naa diri gi store ang mga process nga gi extract from textboxes
        public List<float> endpoints = new List<float>();
        private List<ProcessData> readyQueue = new List<ProcessData>();// naa diri gi store ang mga proocesses nga mo arrive sa current time 
        Dictionary<string, ProcessData> processDict = new Dictionary<string, ProcessData>();// naa diri gi store ang mga processes together na with their TAT, CT,AND WAITING TIME
        public Form3()
        {
            InitializeComponent();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            GeneratePanels(ProcessCount);
        }

        // Funtion for Creating the Table for  Burst Time and Arrival Time Input
        private void GeneratePanels(int count)
        {
            textboxes = new TextBox[count, 3];// store the textbox in an array,(count = pila ka process, 3 => pila ka textbox sa rows)

            String[] headers = { "Process ID", "CPU Burst Time", "Arrival Time" };

            int panelheight = 40;
            int panelwidth = 200;
            int spacing = 3;
            int mainpanelheight = (panelheight + spacing) * (count + 1) - spacing;
            int mainpanelwidth = 612;

            int totalHeight = (panelheight + spacing) * count - spacing;


            mainpanel = new Panel // panel siya for the table
            {
                Size = new Size(mainpanelwidth, mainpanelheight),
                Location = new Point(481, 276),
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
            for (int j = 0; j < headers.Length; j++)// loop for the headers katung( ip add, bt og arrival time)
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

            for (int i = 0; i < count; i++)// loop para kung pila ka rows depending on user input

            {
                Panel panelrows = new Panel
                {
                    Size = new Size(mainpanelwidth - 6, panelheight),
                    Location = new Point(3, (panelheight + 5) * (i + 1)),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.Black,

                };
                for (int j = 0; j < 3; j++) // loop for three textbox in row
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

                    if (j == 0) // para sa process ID
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
                        textbox.KeyDown += Enter_nextTextBox;



                    }
                    textboxes[i, j] = textbox; // i add ang textbox sa array
                    panelrows.Controls.Add(textbox);
                }
                mainpanel.Controls.Add(panelrows);
            }
            this.Controls.Add(mainpanel);
            if (ProcessCount > 0)
            {
                textboxes[0, 1].Focus();
            }
            // ExtractData();// i sort  according to the arrival time

        }

        //Functions for the Shortest Job First Gantt Chart
        private void GenerateGanttChart(List<ProcessData> processList)
        {
            float CurrentTime = 0;
            int Completed = 0;
            float TargetWidth = 0;
            mainChartPanel = new Panel
            {
                Location = new Point(10, 400),
                BackColor = Color.Transparent,
                Height = 55,
                Width = 0,
                BorderStyle = BorderStyle.None,

                Visible = true,

            };

            chartPanel = new Panel
            {
                Location = new Point(3, 0),
                BackColor = Color.Gray,
                Height = 54,
                BorderStyle = BorderStyle.FixedSingle,

                Visible = true,
            };
            this.Controls.Add(mainChartPanel);
            mainChartPanel.Controls.Add(chartPanel);

            timeLabelPanel = new Panel
            {
                Location = new Point(8, 458),
                BackColor = Color.Transparent,
                Height = 20,
                Width = mainChartPanel.Width + 5,
                BorderStyle = BorderStyle.None,


                Visible = true,
            };
            this.Controls.Add(timeLabelPanel);


            Label startTimeLabel0 = new Label // if no process starts at zer0
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Location = new Point(0, 1),
                ForeColor = Color.Lime,
                Text = ("0"), // display actual time
                AutoSize = true,
            };

            timeLabelPanel.Controls.Add(startTimeLabel0);

            while (Completed < processList.Count)
            {
                // Add newly arrived processes to the ready queue
                foreach (var process in processList)
                {
                    if (process.ArrivalTime <= CurrentTime && !process.IsCompleted && !readyQueue.Contains(process))
                    {
                        readyQueue.Add(process);
                    }
                }

                // Sort readyQueue manually based on BurstTime (and ArrivalTime if equal)
                for (int i = 0; i < readyQueue.Count - 1; i++)
                {
                    for (int j = 0; j < readyQueue.Count - i - 1; j++)
                    {
                        if (readyQueue[j].BurstTime > readyQueue[j + 1].BurstTime ||
                            (readyQueue[j].BurstTime == readyQueue[j + 1].BurstTime &&
                             readyQueue[j].ArrivalTime > readyQueue[j + 1].ArrivalTime))
                        {
                            var temp = readyQueue[j];
                            readyQueue[j] = readyQueue[j + 1];
                            readyQueue[j + 1] = temp;
                        }
                    }
                }

                if (readyQueue.Count == 0)
                {

                    //AddGanttBox("", CurrentTime * 15, 1, Color.Transparent);
                    CurrentTime += 1;
                    chartPanel.Width = (int)CurrentTime * 15;
                    //mainChartPanel.Width = (int)CurrentTime * 15;
                    TargetWidth = (int)CurrentTime * 15;
                }
                else
                {
                    var currentProcess = readyQueue[0];// temporary
                    currentProcess.Color = rgbaColors[Completed];// set color
                    AddGanttBox(currentProcess.ProcessID, CurrentTime * 15, currentProcess.BurstTime, currentProcess.Color); // add gantbox
                    currentProcess.StartTime = CurrentTime;// add startTime
                    endpoints.Add(currentProcess.StartTime);
                    currentProcess.WaitingTime = currentProcess.StartTime - currentProcess.ArrivalTime;
                    CurrentTime += currentProcess.BurstTime;
                    currentProcess.CompletionTime = CurrentTime;
                    currentProcess.TurnAroundTime = currentProcess.CompletionTime - currentProcess.ArrivalTime;
                    currentProcess.IsCompleted = true;
                    Completed++;
                    processDict.Add(currentProcess.ProcessID, currentProcess);
                    chartPanel.Width = (int)CurrentTime * 15;
                    // mainChartPanel.Width = (int)CurrentTime * 15;
                    TargetWidth = (int)CurrentTime * 15;
                    readyQueue.Clear();
                }
            }
            // mainChartPanel.Width += 20;
            // AnimatePanelGrowth(Panel panel, bool growWidth = true, float targetSize = 0, float speed = 1, bool growLeft = false, List<float> pausePoints = null)
            // AnimatePanelGrowth(mainChartPanel, growWidth: true, targetSize: TargetWidth + 20, speed: 5);
            AnimatePanelGrowth2(mainChartPanel, growWidth: true, targetSize: TargetWidth + 20, speed: 10, growLeft: false, endpoints);
            var adjustedEndpoints = endpoints.Select(x => x + 3).ToList();
            AnimatePanelGrowth2(timeLabelPanel, growWidth: true, targetSize: TargetWidth + 20, speed: 10, growLeft: false, adjustedEndpoints);

        }

        //Add each processBox into the gannt Gantt Chart
        //private void AddGanttBox(String label, float Locx, float width, Color color)
        //{
        //    // Add Gantt bar
        //    Label ganttBox = new Label
        //    {
        //        Text = label,
        //        Size = new Size((int)(width * 15), 54),
        //        BackColor = color,
        //        ForeColor = Color.Black,
        //        TextAlign = ContentAlignment.MiddleCenter,
        //        Location = new Point((int)Locx, 0),
        //        Font = new Font("Arial Narrow", 10F, FontStyle.Bold),
        //        BorderStyle = BorderStyle.FixedSingle,
        //    };
        //    chartPanel.Controls.Add(ganttBox);

        //    // Start time label
        //    Label startTimeLabel = new Label
        //    {
        //        BackColor = Color.Transparent,
        //        Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
        //        Location = new Point((int)Locx, 1),
        //        Text = (Locx / 15f).ToString("0.##"), // display actual time
        //        AutoSize = true,
        //        ForeColor = Color.Lime,
        //    };
        //    timeLabelPanel.Controls.Add(startTimeLabel);
        //    //start if no process in 0 time


        //    // End time label
        //    float endX = Locx + width * 15;
        //    Label endTimeLabel = new Label
        //    {
        //        BackColor = Color.Transparent,
        //        Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
        //        Location = new Point((int)endX - 5, 1), // subtract to center under right edge
        //        Text = ((Locx / 15f) + width).ToString("0.##"), // CurrentTime + BurstTime
        //        AutoSize = true,
        //        ForeColor = Color.Lime,
        //    };
        //    timeLabelPanel.Controls.Add(endTimeLabel);
        //}
        private void AddGanttBox(string label, float Locx, float width, Color color)
        {
            // Add Gantt bar (process block)
            Label ganttBox = new Label
            {
                Text = label,
                Size = new Size((int)(width * 15), 54),
                BackColor = color,
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point((int)Locx, 0),
                Font = new Font("Arial Narrow", 10F, FontStyle.Bold),
                BorderStyle = BorderStyle.FixedSingle,
            };
            chartPanel.Controls.Add(ganttBox);

            // Calculate times
            float startTime = Locx / 15f;
            float endTime = startTime + width;

            // Start time label (only add if not duplicate)
            bool shouldAddStartLabel = true;
            foreach (Control c in timeLabelPanel.Controls)
            {
                if (c is Label lbl && Math.Abs(float.Parse(lbl.Text) - startTime) < 0.01f)
                {
                    shouldAddStartLabel = false;
                    break;
                }
            }

            if (shouldAddStartLabel)
            {
                Label startTimeLabel = new Label
                {
                    Text = startTime.ToString("0.##"),
                    Location = new Point((int)Locx + 5, 0), // Y=0 within timeLabelPanel
                    AutoSize = true,
                    Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                    ForeColor = Color.Lime,
                    BackColor = Color.Transparent,
                };
                timeLabelPanel.Controls.Add(startTimeLabel);
            }

            // End time label (always add)
            Label endTimeLabel = new Label
            {
                Text = endTime.ToString("0.##"),
                Location = new Point((int)(Locx + width * 15), 0), // Slightly left-adjusted
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                ForeColor = Color.Lime,
                BackColor = Color.Transparent,
            };
            timeLabelPanel.Controls.Add(endTimeLabel);
        }



        //Displaying the panels for the computed processes
        private void DisplayWaitingTime()
        {
            // float waitingTime = processDict[$"P{i+1}"].WaitingTime;
            int locy = 7;
            float TargetWidth = 500;
            Panel mainpanel = new Panel
            {
                Width = 0, // For animation
                Height = 0,
                Location = new Point(12, 570),
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = false,
            };
            this.Controls.Add(mainpanel);

            Panel panel = new Panel
            {
                Width = 500,
                Height = 0,
                Location = new Point(0, 0),
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.None,
                AutoSize = false,
            };

            Label labelWT = new Label
            {
                Text = "Waiting Time of",
                Size = new Size(187, 28),
                Location = new Point(5, 5),
                ForeColor = Color.Lime,
                BackColor = Color.Transparent,
                Font = new Font("Constantia", 17.25f, FontStyle.Bold),
            };

            panel.Controls.Add(labelWT);

            for (int i = 0; i < ProcessCount; i++)
            {
                Label label = new Label
                {
                    Size = new Size(292, 29),
                    Text = $"P{i + 1} = {processDict[$"P{i + 1}"].WaitingTime:0.##} msec",
                    Location = new Point(200, locy),
                    ForeColor = processDict[$"P{i + 1}"].Color,
                    BackColor = Color.Transparent,
                    Font = new Font("Consolas", 16.25F, FontStyle.Bold),
                    BorderStyle = BorderStyle.None,
                };
                locy += 30;
                panel.Height += 35;
                mainpanel.Height += 35;
                panel.Controls.Add(label);
            }

            mainpanel.Controls.Add(panel);
            AnimatePanelGrowth(mainpanel, growWidth: true, targetSize: 500, speed: 5);
        }
        private void DisplayCompletionTime()
        {
            // float waitingTime = processDict[$"P{i+1}"].WaitingTime;
            int locy = 7;
            Panel mainpanel = new Panel
            {
                Width = 0,
                Height = 0,
                Location = new Point(1490, 70),
                BackColor = Color.Transparent,
                // ForeColor = Color.Lime,
                BorderStyle = BorderStyle.FixedSingle,
                //  AutoSize = true,
            };
            this.Controls.Add(mainpanel);
            Panel panel = new Panel
            {
                Width = 500,
                Height = 0,
                Location = new Point(0, 0),
                BackColor = Color.Transparent,
                // ForeColor = Color.Lime,
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = true,
            };

            Label labelCT = new Label
            {
                Text = "Completion Time  of ",
                Size = new Size(240, 28),
                Location = new Point(5, 5),
                ForeColor = Color.Lime,
                BackColor = Color.Transparent,
                Font = new Font("Constantia", 17.25f, FontStyle.Bold),
                BorderStyle = BorderStyle.None,

            };

            panel.Controls.Add(labelCT);

            for (int i = 0; i < ProcessCount; i++)
            {
                Label label = new Label
                {
                    Size = new Size(200, 29),
                    Text = $"P{i + 1}" + "  = " + processDict[$"P{i + 1}"].CompletionTime.ToString("0.##") + " msec",
                    Location = new Point(280, locy),
                    ForeColor = processDict[$"P{i + 1}"].Color,
                    BackColor = Color.Transparent,
                    Font = new Font("Consolas", 16.25F, FontStyle.Bold),
                    BorderStyle = BorderStyle.None,


                };
                locy += 30;
                panel.Height += 35;
                mainpanel.Height += 35;

                panel.Controls.Add(label);

            }
            mainpanel.Controls.Add(panel);
            AnimatePanelGrowth(mainpanel, growWidth: true, targetSize: 500, speed: 5, growLeft: true);
        }
        private void DisplayTurnArroundTime()
        {
            // float waitingTime = processDict[$"P{i+1}"].WaitingTime;
            int locy = 7;
            Panel mainpanel = new Panel
            {
                Width = 0,
                Height = 0,
                Location = new Point(1490, 540),
                BackColor = Color.Transparent,
                // ForeColor = Color.Lime,
                BorderStyle = BorderStyle.FixedSingle,
                //AutoSize = true,
            };
            Panel panel = new Panel
            {
                Width = 500,
                Height = 0,
                Location = new Point(0, 0),
                BackColor = Color.Transparent,
                // ForeColor = Color.Lime,
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = true,
            };
            Label labelTAT = new Label
            {
                Text = "TurnAround Time of ",
                Size = new Size(240, 28),
                Location = new Point(5, 5),
                ForeColor = Color.Lime,
                BackColor = Color.Transparent,
                Font = new Font("Constantia", 17.25f, FontStyle.Bold),
                BorderStyle = BorderStyle.None,

            };
            this.Controls.Add(mainpanel);

            for (int i = 0; i < ProcessCount; i++)
            {
                Label label = new Label
                {
                    Size = new Size(200, 29),
                    Text = $"P{i + 1}" + "  = " + processDict[$"P{i + 1}"].TurnAroundTime.ToString("0.##") + " msec",
                    Location = new Point(280, locy),
                    ForeColor = processDict[$"P{i + 1}"].Color,
                    BackColor = Color.Transparent,
                    Font = new Font("Consolas", 16.25F, FontStyle.Bold),
                    BorderStyle = BorderStyle.None,


                };
                locy += 30;
                panel.Height += 35;
                mainpanel.Height += 35;
                panel.Controls.Add(labelTAT);
                panel.Controls.Add(label);
            }
            mainpanel.Controls.Add(panel);
            AnimatePanelGrowth(mainpanel, growWidth: true, targetSize: 500, speed: 5, growLeft: true);
        }
        private void DisplayAverageWaitingTime()
        {
            float totalWaitingTime = 0;
            for (int i = 0; i < ProcessCount; i++)
            {
                totalWaitingTime += processDict[$"P{i + 1}"].WaitingTime;
            }

            float AverageWT = totalWaitingTime / ProcessCount;

            Panel mainpanel = new Panel
            {
                Location = new Point(12, 800),
                Size = new Size(0, 82), // start with width 0 for animation
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = false // <- important for animation
            };

            Panel panel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(648, 82),
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.None,
                AutoSize = false
            };

            this.Controls.Add(mainpanel);

            Label labelAWT = new Label
            {
                Size = new Size(270, 31),
                Font = new Font("Constantia", 17.25f, FontStyle.Bold),
                Location = new Point(10, 7),
                ForeColor = Color.Lime,
                BackColor = Color.Transparent,
                Text = "Average Waiting Time = ",
            };

            Label label1 = new Label
            {
                Size = new Size(372, 38),
                Font = new Font("Consolas", 16.25F, FontStyle.Bold),
                Location = new Point(285, 10),
                ForeColor = Color.Lime,
                BackColor = Color.Transparent,
                Text = totalWaitingTime.ToString("0.##") + "/" + ProcessCount.ToString(),
            };

            Label label2 = new Label
            {
                Size = new Size(372, 38),
                Font = new Font("Consolas", 20.25F, FontStyle.Bold),
                Location = new Point(270, 50),
                ForeColor = Color.Lime,
                BackColor = Color.Transparent,
                Text = "= " + AverageWT.ToString("0.##") + " msec",
            };

            panel.Controls.Add(labelAWT);
            panel.Controls.Add(label1);
            panel.Controls.Add(label2);
            mainpanel.Controls.Add(panel);

            AnimatePanelGrowth(mainpanel, growWidth: true, targetSize: 650, speed: 5);
        }
        private void DisplayAverageTurnAroundTime()
        {
            float totalTurnAroundTime = 0;
            for (int i = 0; i < ProcessCount; i++)
            {
                totalTurnAroundTime += processDict[$"P{i + 1}"].TurnAroundTime;

            }
            float AverageTAT = totalTurnAroundTime / ProcessCount;
            Panel mainpanel = new Panel
            {
                Location = new Point(1490, 800),
                Size = new Size(0, 82),
                BackColor = Color.Transparent,
                // ForeColor = Color.Lime,
                BorderStyle = BorderStyle.FixedSingle,
                //AutoSize = true,


            };
            Panel panel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(550, 82),
                BackColor = Color.Transparent,
                // ForeColor = Color.Lime,
                BorderStyle = BorderStyle.None,
                AutoSize = true,


            };
            this.Controls.Add(mainpanel);
            Label labelAWT = new Label
            {
                Size = new Size(320, 31),
                Font = new Font("Constantia", 17.25f, FontStyle.Bold),
                Location = new Point(10, 7),
                ForeColor = Color.Lime,
                BackColor = Color.Transparent,
                Text = "Average TurnAround Time =",
            };
            panel.Controls.Add(labelAWT);
            Label label1 = new Label
            {
                Size = new Size(200, 38),
                Font = new Font("Consolas", 16.25F, FontStyle.Bold),
                Location = new Point(330, 10),
                ForeColor = Color.Lime,
                BackColor = Color.Transparent,
                Text = totalTurnAroundTime.ToString("0.##") + "/" + ProcessCount.ToString(),
            };
            Label label2 = new Label
            {
                Size = new Size(250, 38),
                Font = new Font("Consolas", 20.25F, FontStyle.Bold),
                Location = new Point(300, 50),
                ForeColor = Color.Lime,
                BackColor = Color.Transparent,
                Text = "= " + AverageTAT.ToString("0.##") + " msec",
            };
            panel.Controls.Add(label1);
            panel.Controls.Add(label2);
            mainpanel.Controls.Add(panel);
            AnimatePanelGrowth(mainpanel, growWidth: true, targetSize: 650, speed: 5, growLeft: true);
        }
        private void DisplayAverageCompletionTime()
        {
            float totalCompletionTime = 0;
            for (int i = 0; i < ProcessCount; i++)
            {
                totalCompletionTime += processDict[$"P{i + 1}"].CompletionTime;

            }
            float AverageCT = totalCompletionTime / ProcessCount;
            Panel mainpanel = new Panel
            {
                Location = new Point(1490, 300),
                Size = new Size(0, 82),
                BackColor = Color.Transparent,
                // ForeColor = Color.Lime,
                BorderStyle = BorderStyle.FixedSingle,
                // AutoSize = true,


            };
            Panel panel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(550, 82),
                BackColor = Color.Transparent,
                // ForeColor = Color.Lime,
                BorderStyle = BorderStyle.None,
                AutoSize = true,


            };
            this.Controls.Add(mainpanel);
            Label labelAWT = new Label
            {
                Size = new Size(320, 31),
                Font = new Font("Constantia", 17.25f, FontStyle.Bold),
                Location = new Point(10, 7),
                ForeColor = Color.Lime,
                BackColor = Color.Transparent,
                Text = "Average Completion Time =",
            };
            panel.Controls.Add(labelAWT);
            Label label1 = new Label
            {
                Size = new Size(200, 38),
                Font = new Font("Consolas", 16.25F, FontStyle.Bold),
                Location = new Point(330, 10),
                ForeColor = Color.Lime,
                BackColor = Color.Transparent,
                Text = totalCompletionTime.ToString("0.##") + "/" + ProcessCount.ToString(),
            };
            Label label2 = new Label
            {
                Size = new Size(200, 38),
                Font = new Font("Consolas", 20.25F, FontStyle.Bold),
                Location = new Point(300, 50),
                ForeColor = Color.Lime,
                BackColor = Color.Transparent,
                Text = "= " + AverageCT.ToString("0.##") + " msec",
            };
            panel.Controls.Add(label1);
            panel.Controls.Add(label2);
            mainpanel.Controls.Add(panel);
            AnimatePanelGrowth(mainpanel, growWidth: true, targetSize: 650, speed: 5, growLeft: true);
        }



        // Continue button
        private void button1_Click(object sender, EventArgs e)
        {

            foreach (var textbox in textboxes)//check if the textbox kay empty 
            {
                if (string.IsNullOrWhiteSpace(textbox.Text))
                {
                    MessageBox.Show("All fields should be filled!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            guidebox.Visible = false;

            ExtractData();
            // If all fields are filled, proceed
            MovePanel(new Point(12, 60));// animation para mo move ang table

            button1.Visible = false;

            // Set labels and buttons to visible
            labelGC.Visible = true;
            labelWT.Visible = true;
            labelAWT.Visible = true;
            labelCT.Visible = true;
            labelACT.Visible = true;
            labelTAT.Visible = true;
            labelATAT.Visible = true;
            button2.Visible = true;

            // Disable all textboxes
            for (int i = 0; i < ProcessCount; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    textboxes[i, j].Enabled = false;
                }
            }
            RunAfterDelay(2000, () =>
            {

                GenerateGanttChart(processList);
                DisplayWaitingTime();
                DisplayAverageWaitingTime();
                DisplayCompletionTime();
                DisplayAverageCompletionTime();
                DisplayTurnArroundTime();
                DisplayAverageTurnAroundTime();

            });
            RunAfterDelay(7000, () =>
            {

                button2.Enabled = true;

            });






        }
        //Function for Automatically add "msec" if the inputs are valid,add msec after enter
        private void Add_Unit(object sender, EventArgs e)
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
                    else
                    {
                        if (value >= 0 && value <= 20)
                        {
                            textbox.Text = $"{value} msec"; // Set the valid value for Arrival Time
                        }
                        else
                        {
                            if (value < 0)
                            {
                                MessageBox.Show("Arrival time should be greater or equal than 0 msec!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        //press enter to go to next textbox
        private void Enter_nextTextBox(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        //Function for extracting the data from the TextBoxes and then Store it into the porcesslist
        private void ExtractData()
        {


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

                        // RemainingTime =burstTime

                    });
                }

            }
            //  SortListByArrival(processList);    
        }



        //ANIMATIONS
        // Animation for the table to move if all input bixes are filled
        public async void MovePanel(Point targetLocation) // move the main table panel
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
        //Animation for the gantt chart and other panels, lkatung sa mga computed na nga process
        public void AnimatePanelGrowth(Panel panel, bool growWidth = true, float targetSize = 0, float speed = 1, bool growLeft = false)
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
                                panel.Width += (int)speed;

                                // If growing left, shift the panel's X position
                                if (growLeft)
                                {
                                    panel.Left -= (int)speed;
                                }
                            }
                        }
                        else
                        {
                            if (panel.Height < targetSize)
                            {
                                panel.Height += (int)speed;
                            }
                        }
                    });

                    Thread.Sleep(5); // Control speed of animation

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
        public void AnimatePanelGrowth2(Panel panel, bool growWidth = true, float targetSize = 0, float speed = 10, bool growLeft = false, List<float> pausePoints = null)
        {
            new Thread(() =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    panel.Visible = true;
                });

                if (pausePoints == null)
                {
                    pausePoints = new List<float>(); // Avoid null reference
                }

                // Sort pause points in ascending order
                pausePoints.Sort();

                int currentPauseIndex = 0;
                bool isPausing = false;
                int pauseDuration = 500; // Milliseconds to pause at each breakpoint

                while (true)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (growWidth)
                        {
                            if (panel.Width < targetSize && !isPausing)
                            {
                                panel.Width += (int)speed;

                                // If growing left, shift the panel's X position
                                if (growLeft)
                                {
                                    panel.Left -= (int)speed;
                                }

                                // Check if we reached a pause point
                                if (currentPauseIndex < pausePoints.Count && panel.Width >= pausePoints[currentPauseIndex] * 15)
                                {
                                    isPausing = true;
                                    currentPauseIndex++;
                                }
                            }
                        }
                        else
                        {
                            if (panel.Height < targetSize && !isPausing)
                            {
                                panel.Height += (int)speed;
                            }
                        }
                    });

                    if (isPausing)
                    {
                        Thread.Sleep(pauseDuration); // Pause for a moment
                        isPausing = false;
                    }
                    else
                    {
                        Thread.Sleep(5); // Normal animation speed
                    }

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
        //funtion ni siya for delayed 
        public void RunAfterDelay(float delayMilliseconds, Action action)
        {
            new Thread(() =>
            {
                Thread.Sleep((int)delayMilliseconds);
                this.Invoke((MethodInvoker)(() =>
                {
                    action?.Invoke();
                }));
            }).Start();
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        // Button that will take you back where you belong
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void labelACT_Click(object sender, EventArgs e)
        {

        }

        private void labelATAT_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
