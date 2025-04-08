namespace SJF_Simulation
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            continuebtn = new Button();
            titlepanel = new Panel();
            panel5 = new Panel();
            label8 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel6 = new Panel();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            titlepanel.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(5, 168, 100);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1301, 20);
            panel1.TabIndex = 0;
            // 
            // continuebtn
            // 
            continuebtn.BackColor = Color.Lime;
            continuebtn.ImageAlign = ContentAlignment.TopRight;
            continuebtn.Location = new Point(562, 670);
            continuebtn.Margin = new Padding(3, 2, 3, 2);
            continuebtn.Name = "continuebtn";
            continuebtn.Size = new Size(174, 53);
            continuebtn.TabIndex = 1;
            continuebtn.Text = "Continue";
            continuebtn.UseVisualStyleBackColor = false;
            continuebtn.Click += continuebtn_Click;
            // 
            // titlepanel
            // 
            titlepanel.BackColor = Color.FromArgb(5, 168, 100);
            titlepanel.Controls.Add(panel5);
            titlepanel.Location = new Point(448, 126);
            titlepanel.Margin = new Padding(3, 2, 3, 2);
            titlepanel.Name = "titlepanel";
            titlepanel.Size = new Size(418, 202);
            titlepanel.TabIndex = 2;
            titlepanel.Paint += titlepanel_Paint;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(13, 13, 13);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(label2);
            panel5.Controls.Add(label1);
            panel5.Location = new Point(3, 2);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(412, 198);
            panel5.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Black;
            label8.Font = new Font("Tahoma", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ButtonHighlight;
            label8.Location = new Point(33, 18);
            label8.Name = "label8";
            label8.Size = new Size(344, 35);
            label8.TabIndex = 5;
            label8.Text = "Simulator Program for";
            label8.Click += label8_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(33, 123);
            label2.Name = "label2";
            label2.Size = new Size(336, 29);
            label2.TabIndex = 1;
            label2.Text = "CPU Scheduling Simulation";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(61, 72);
            label1.Name = "label1";
            label1.Size = new Size(271, 27);
            label1.TabIndex = 0;
            label1.Text = "Shortest Job First (SJF)";
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(5, 168, 100);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(644, 330);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(20, 52);
            panel2.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Location = new Point(2, -9);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(15, 60);
            panel3.TabIndex = 0;
            panel3.Paint += panel3_Paint;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(5, 168, 100);
            panel4.Controls.Add(panel6);
            panel4.Location = new Point(451, 380);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(418, 211);
            panel4.TabIndex = 4;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(13, 13, 13);
            panel6.Controls.Add(label7);
            panel6.Controls.Add(label6);
            panel6.Controls.Add(label5);
            panel6.Controls.Add(label4);
            panel6.Controls.Add(label3);
            panel6.Location = new Point(3, 2);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(412, 207);
            panel6.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(122, 141);
            label7.Name = "label7";
            label7.Size = new Size(168, 19);
            label7.TabIndex = 5;
            label7.Text = "Saramosing, Ashley";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(110, 105);
            label6.Name = "label6";
            label6.Size = new Size(188, 19);
            label6.TabIndex = 4;
            label6.Text = "Gesim, Christian Dave";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(142, 68);
            label5.Name = "label5";
            label5.Size = new Size(127, 19);
            label5.TabIndex = 3;
            label5.Text = "Bardon, Yvone";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(127, 58);
            label4.Name = "label4";
            label4.Size = new Size(0, 19);
            label4.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(122, 15);
            label3.Name = "label3";
            label3.Size = new Size(163, 27);
            label3.TabIndex = 1;
            label3.Text = "Developed by";
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(7, 21, 15);
            ClientSize = new Size(1301, 857);
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel4);
            Controls.Add(titlepanel);
            Controls.Add(continuebtn);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            titlepanel.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button continuebtn;
        private Panel titlepanel;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Label label2;
        private Panel panel6;
        private Label label3;
        private Label label4;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label8;
    }
}
