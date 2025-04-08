namespace SJF_Simulation
{
    partial class SplashScreen
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
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(5, 168, 100);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1500, 22);
            panel1.TabIndex = 0;
            panel1.Visible = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Lime;
            button1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(664, 786);
            button1.Name = "button1";
            button1.Size = new Size(244, 69);
            button1.TabIndex = 1;
            button1.Text = "Power On";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Lime;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(600, 820);
            panel2.Name = "panel2";
            panel2.Size = new Size(0, 8);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Lime;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Location = new Point(200, 680);
            panel3.Name = "panel3";
            panel3.Size = new Size(10, 0);
            panel3.TabIndex = 3;
            panel3.Visible = false;
            panel3.Paint += panel3_Paint;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Lime;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Location = new Point(205, 6);
            panel4.Name = "panel4";
            panel4.Size = new Size(0, 8);
            panel4.TabIndex = 4;
            panel4.Visible = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Lime;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Location = new Point(1315, 575);
            panel5.Name = "panel5";
            panel5.Size = new Size(10, 0);
            panel5.TabIndex = 5;
            panel5.Visible = false;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Lime;
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Location = new Point(205, 575);
            panel6.Name = "panel6";
            panel6.Size = new Size(1113, 8);
            panel6.TabIndex = 6;
            panel6.Visible = false;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Lime;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Location = new Point(195, 481);
            panel7.Name = "panel7";
            panel7.Size = new Size(10, 117);
            panel7.TabIndex = 7;
            panel7.Visible = false;
            // 
            // panel8
            // 
            panel8.BackColor = Color.Lime;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Location = new Point(205, 358);
            panel8.Name = "panel8";
            panel8.Size = new Size(0, 8);
            panel8.TabIndex = 8;
            panel8.Visible = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.saddsa;
            pictureBox2.Location = new Point(653, 248);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(262, 148);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // SplashScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1500, 921);
            Controls.Add(pictureBox2);
            Controls.Add(panel8);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(button1);
            Controls.Add(panel1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "SplashScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SplashScreen";
            Load += SplashScreen_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private PictureBox pictureBox2;
        private Panel Screen;
    }
}