namespace SJF_Simulation
{
    partial class Form2
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            textBox1 = new TextBox();
            Continuebtn2 = new Button();
            panel1 = new Panel();
            closebutton = new Button();
            mainpanel = new Panel();
            label4 = new Label();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            mainpanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(0, 34);
            label1.Name = "label1";
            label1.Size = new Size(186, 18);
            label1.TabIndex = 1;
            label1.Text = "Shortest Job First (SJF)";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(181, 34);
            label2.Name = "label2";
            label2.Size = new Size(209, 18);
            label2.TabIndex = 2;
            label2.Text = "CPU Scheduling Simulation";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(72, 13);
            label3.Name = "label3";
            label3.Size = new Size(284, 23);
            label3.TabIndex = 3;
            label3.Text = "Enter the Number of Process";
            label3.Click += label3_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(5, 168, 100);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(20, 96);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(379, 49);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Controls.Add(textBox1);
            panel3.Location = new Point(3, 2);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(374, 44);
            panel3.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = SystemColors.InfoText;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = SystemColors.InactiveBorder;
            textBox1.Location = new Point(176, 9);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Enter 3 to 5 only";
            textBox1.Size = new Size(35, 36);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Continuebtn2
            // 
            Continuebtn2.BackColor = Color.Lime;
            Continuebtn2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Continuebtn2.Location = new Point(111, 310);
            Continuebtn2.Margin = new Padding(3, 2, 3, 2);
            Continuebtn2.Name = "Continuebtn2";
            Continuebtn2.Size = new Size(204, 48);
            Continuebtn2.TabIndex = 5;
            Continuebtn2.Text = "Continue";
            Continuebtn2.UseVisualStyleBackColor = false;
            Continuebtn2.Click += Continuebtn2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(5, 168, 100);
            panel1.Controls.Add(closebutton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1500, 30);
            panel1.TabIndex = 6;
            // 
            // closebutton
            // 
            closebutton.BackColor = Color.Transparent;
            closebutton.BackgroundImage = Properties.Resources.image_removebg_preview__18_;
            closebutton.BackgroundImageLayout = ImageLayout.Stretch;
            closebutton.FlatAppearance.BorderSize = 0;
            closebutton.FlatStyle = FlatStyle.Flat;
            closebutton.Location = new Point(1451, -2);
            closebutton.Name = "closebutton";
            closebutton.Size = new Size(49, 29);
            closebutton.TabIndex = 13;
            closebutton.UseVisualStyleBackColor = false;
            closebutton.Click += button1_Click;
            // 
            // mainpanel
            // 
            mainpanel.Controls.Add(label4);
            mainpanel.Controls.Add(Continuebtn2);
            mainpanel.Controls.Add(panel2);
            mainpanel.Controls.Add(label3);
            mainpanel.Location = new Point(1493, 361);
            mainpanel.Name = "mainpanel";
            mainpanel.Size = new Size(415, 422);
            mainpanel.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(49, 157);
            label4.Name = "label4";
            label4.Size = new Size(307, 28);
            label4.TabIndex = 6;
            label4.Text = "Minimum of 3 and Maximum of 5 only";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(7, 21, 15);
            ClientSize = new Size(1500, 1000);
            ControlBox = false;
            Controls.Add(mainpanel);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            Load += Form2_Load;
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            mainpanel.ResumeLayout(false);
            mainpanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panel2;
        private Panel panel3;
        private TextBox textBox1;
        private Button Continuebtn2;
        private Panel panel1;
        private Button closebutton;
        private Panel mainpanel;
        private Label label4;
    }
}