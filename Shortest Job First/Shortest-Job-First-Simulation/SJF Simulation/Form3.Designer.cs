﻿namespace SJF_Simulation
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            labelGC = new Label();
            labelWT = new Label();
            labelAWT = new Label();
            labelCT = new Label();
            labelACT = new Label();
            labelTAT = new Label();
            labelATAT = new Label();
            button2 = new Button();
            guidebox = new Krypton.Toolkit.KryptonTextBox();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(5, 168, 100);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1500, 30);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.Lime;
            button1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(724, 861);
            button1.Name = "button1";
            button1.Size = new Size(172, 44);
            button1.TabIndex = 1;
            button1.Text = "Continue";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(0, 32);
            label1.Name = "label1";
            label1.Size = new Size(186, 18);
            label1.TabIndex = 2;
            label1.Text = "Shortest Job First (SJF)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(183, 32);
            label2.Name = "label2";
            label2.Size = new Size(209, 18);
            label2.TabIndex = 3;
            label2.Text = "CPU Scheduling Simulation";
            // 
            // labelGC
            // 
            labelGC.AutoSize = true;
            labelGC.Font = new Font("Tahoma", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelGC.ForeColor = SystemColors.ButtonHighlight;
            labelGC.Location = new Point(0, 351);
            labelGC.Name = "labelGC";
            labelGC.Size = new Size(124, 18);
            labelGC.TabIndex = 4;
            labelGC.Text = "1.) Gantt  Chart";
            labelGC.Visible = false;
            // 
            // labelWT
            // 
            labelWT.AutoSize = true;
            labelWT.Font = new Font("Tahoma", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelWT.ForeColor = SystemColors.ButtonHighlight;
            labelWT.Location = new Point(12, 517);
            labelWT.Name = "labelWT";
            labelWT.Size = new Size(132, 18);
            labelWT.TabIndex = 5;
            labelWT.Text = "2.) Waiting Time";
            labelWT.Visible = false;
            // 
            // labelAWT
            // 
            labelAWT.AutoSize = true;
            labelAWT.Font = new Font("Tahoma", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAWT.ForeColor = SystemColors.ButtonHighlight;
            labelAWT.Location = new Point(12, 764);
            labelAWT.Name = "labelAWT";
            labelAWT.Size = new Size(198, 18);
            labelAWT.TabIndex = 6;
            labelAWT.Text = "3.) Average Waiting Time";
            labelAWT.Visible = false;
            // 
            // labelCT
            // 
            labelCT.AutoSize = true;
            labelCT.Font = new Font("Tahoma", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelCT.ForeColor = SystemColors.ButtonHighlight;
            labelCT.Location = new Point(993, 45);
            labelCT.Name = "labelCT";
            labelCT.Size = new Size(158, 18);
            labelCT.TabIndex = 7;
            labelCT.Text = "4.) Completion Time";
            labelCT.Visible = false;
            labelCT.Click += label6_Click;
            // 
            // labelACT
            // 
            labelACT.AutoSize = true;
            labelACT.Font = new Font("Tahoma", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelACT.ForeColor = SystemColors.ButtonHighlight;
            labelACT.Location = new Point(927, 269);
            labelACT.Name = "labelACT";
            labelACT.Size = new Size(224, 18);
            labelACT.TabIndex = 8;
            labelACT.Text = "5.) Average Completion Time";
            labelACT.Visible = false;
            labelACT.Click += labelACT_Click;
            // 
            // labelTAT
            // 
            labelTAT.AutoSize = true;
            labelTAT.Font = new Font("Tahoma", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelTAT.ForeColor = SystemColors.ButtonHighlight;
            labelTAT.Location = new Point(993, 515);
            labelTAT.Name = "labelTAT";
            labelTAT.Size = new Size(165, 18);
            labelTAT.TabIndex = 9;
            labelTAT.Text = "6.) Turn Around Time";
            labelTAT.Visible = false;
            labelTAT.Click += label8_Click;
            // 
            // labelATAT
            // 
            labelATAT.AutoSize = true;
            labelATAT.Font = new Font("Tahoma", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelATAT.ForeColor = SystemColors.ButtonHighlight;
            labelATAT.Location = new Point(934, 770);
            labelATAT.Name = "labelATAT";
            labelATAT.Size = new Size(231, 18);
            labelATAT.TabIndex = 10;
            labelATAT.Text = "7.) Average Turn Around Time";
            labelATAT.Visible = false;
            labelATAT.Click += labelATAT_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Lime;
            button2.Enabled = false;
            button2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(724, 911);
            button2.Name = "button2";
            button2.Size = new Size(172, 44);
            button2.TabIndex = 11;
            button2.Text = "Go back";
            button2.UseVisualStyleBackColor = false;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // guidebox
            // 
            guidebox.Location = new Point(420, 144);
            guidebox.Multiline = true;
            guidebox.Name = "guidebox";
            guidebox.ReadOnly = true;
            guidebox.Size = new Size(724, 122);
            guidebox.StateActive.Back.Color1 = Color.FromArgb(7, 21, 15);
            guidebox.StateActive.Border.Draw = Krypton.Toolkit.InheritBool.True;
            guidebox.StateActive.Content.Font = new Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guidebox.StateCommon.Border.Draw = Krypton.Toolkit.InheritBool.False;
            guidebox.StateCommon.Border.Rounding = 0F;
            guidebox.StateCommon.Border.Width = 0;
            guidebox.StateCommon.Content.Color1 = Color.White;
            guidebox.StateCommon.Content.Font = new Font("Poppins", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guidebox.TabIndex = 12;
            guidebox.Text = " Burst Time must be greater than 0 and does not exceed 15 msec\r\nArrival Time must be not less than 0 and must not exceed 20 msec\r\n Press Enter to move to another textbox";
            guidebox.TextAlign = HorizontalAlignment.Center;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(7, 21, 15);
            ClientSize = new Size(1500, 1000);
            Controls.Add(guidebox);
            Controls.Add(button2);
            Controls.Add(labelATAT);
            Controls.Add(labelTAT);
            Controls.Add(labelACT);
            Controls.Add(labelCT);
            Controls.Add(labelAWT);
            Controls.Add(labelWT);
            Controls.Add(labelGC);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form3";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label labelGC;
        private Label labelWT;
        private Label labelAWT;
        private Label labelCT;
        private Label labelACT;
        private Label labelTAT;
        private Label labelATAT;
        private Button button2;
        private Krypton.Toolkit.KryptonTextBox guidebox;
        //private Panel mainpanel;
    }
}