namespace SJF_Simulation
{
    partial class Definition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Definition));
            panel1 = new Panel();
            closebutton = new Button();
            label1 = new Label();
            kryptonTextBox1 = new Krypton.Toolkit.KryptonTextBox();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            kryptonTextBox2 = new Krypton.Toolkit.KryptonTextBox();
            gotoSimulate1 = new Button();
            GoBack = new Button();
            mainpanel = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            mainpanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(5, 168, 100);
            panel1.Controls.Add(closebutton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1484, 30);
            panel1.TabIndex = 6;
            // 
            // closebutton
            // 
            closebutton.BackColor = Color.Transparent;
            closebutton.BackgroundImage = Properties.Resources.image_removebg_preview__18_;
            closebutton.BackgroundImageLayout = ImageLayout.Stretch;
            closebutton.FlatAppearance.BorderSize = 0;
            closebutton.FlatStyle = FlatStyle.Flat;
            closebutton.Location = new Point(1435, 0);
            closebutton.Name = "closebutton";
            closebutton.Size = new Size(49, 29);
            closebutton.TabIndex = 13;
            closebutton.UseVisualStyleBackColor = false;
            closebutton.Click += closebutton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Poppins", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Lime;
            label1.Location = new Point(9, 4);
            label1.Name = "label1";
            label1.Size = new Size(1001, 56);
            label1.TabIndex = 7;
            label1.Text = "What is SJF (Shortest Job First) CPU Scheduling Algorithm ?";
            label1.Click += label1_Click;
            // 
            // kryptonTextBox1
            // 
            kryptonTextBox1.Location = new Point(26, 75);
            kryptonTextBox1.Multiline = true;
            kryptonTextBox1.Name = "kryptonTextBox1";
            kryptonTextBox1.ReadOnly = true;
            kryptonTextBox1.Size = new Size(1082, 326);
            kryptonTextBox1.StateActive.Back.Color1 = Color.FromArgb(7, 21, 15);
            kryptonTextBox1.StateCommon.Border.Draw = Krypton.Toolkit.InheritBool.False;
            kryptonTextBox1.StateCommon.Border.Rounding = 0F;
            kryptonTextBox1.StateCommon.Border.Width = 0;
            kryptonTextBox1.StateCommon.Content.Color1 = Color.White;
            kryptonTextBox1.StateCommon.Content.Font = new Font("Poppins", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            kryptonTextBox1.TabIndex = 8;
            kryptonTextBox1.Text = resources.GetString("kryptonTextBox1.Text");
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Image = Properties.Resources.cpuchip;
            pictureBox1.Location = new Point(1095, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(374, 424);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Poppins", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Lime;
            label2.Location = new Point(50, 469);
            label2.Name = "label2";
            label2.Size = new Size(342, 56);
            label2.TabIndex = 10;
            label2.Text = "How Does It Works?";
            label2.Click += label2_Click;
            // 
            // kryptonTextBox2
            // 
            kryptonTextBox2.Location = new Point(73, 566);
            kryptonTextBox2.Multiline = true;
            kryptonTextBox2.Name = "kryptonTextBox2";
            kryptonTextBox2.ReadOnly = true;
            kryptonTextBox2.Size = new Size(1367, 112);
            kryptonTextBox2.StateActive.Back.Color1 = Color.FromArgb(7, 21, 15);
            kryptonTextBox2.StateCommon.Border.Draw = Krypton.Toolkit.InheritBool.False;
            kryptonTextBox2.StateCommon.Border.Rounding = 0F;
            kryptonTextBox2.StateCommon.Border.Width = 0;
            kryptonTextBox2.StateCommon.Content.Color1 = Color.White;
            kryptonTextBox2.StateCommon.Content.Font = new Font("Poppins", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            kryptonTextBox2.TabIndex = 11;
            kryptonTextBox2.Text = resources.GetString("kryptonTextBox2.Text");
            // 
            // gotoSimulate1
            // 
            gotoSimulate1.BackColor = Color.Lime;
            gotoSimulate1.Font = new Font("Poppins", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gotoSimulate1.ImageAlign = ContentAlignment.TopRight;
            gotoSimulate1.Location = new Point(766, 813);
            gotoSimulate1.Margin = new Padding(3, 2, 3, 2);
            gotoSimulate1.Name = "gotoSimulate1";
            gotoSimulate1.Size = new Size(217, 53);
            gotoSimulate1.TabIndex = 13;
            gotoSimulate1.Text = "Go to Simulation";
            gotoSimulate1.UseVisualStyleBackColor = false;
            gotoSimulate1.Click += gotoSimulate1_Click;
            // 
            // GoBack
            // 
            GoBack.BackColor = Color.Lime;
            GoBack.Font = new Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GoBack.ImageAlign = ContentAlignment.TopRight;
            GoBack.Location = new Point(500, 814);
            GoBack.Margin = new Padding(3, 2, 3, 2);
            GoBack.Name = "GoBack";
            GoBack.Size = new Size(221, 53);
            GoBack.TabIndex = 14;
            GoBack.Text = "Go Back";
            GoBack.UseVisualStyleBackColor = false;
            GoBack.Click += GoBack_Click;
            // 
            // mainpanel
            // 
            mainpanel.Controls.Add(GoBack);
            mainpanel.Controls.Add(gotoSimulate1);
            mainpanel.Controls.Add(kryptonTextBox2);
            mainpanel.Controls.Add(label2);
            mainpanel.Controls.Add(pictureBox1);
            mainpanel.Controls.Add(kryptonTextBox1);
            mainpanel.Controls.Add(label1);
            mainpanel.Location = new Point(1470, 37);
            mainpanel.Name = "mainpanel";
            mainpanel.Size = new Size(1477, 888);
            mainpanel.TabIndex = 15;
            // 
            // Definition
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(7, 21, 15);
            ClientSize = new Size(1484, 961);
            ControlBox = false;
            Controls.Add(mainpanel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Definition";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Definition";
            Load += Definition_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            mainpanel.ResumeLayout(false);
            mainpanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button closebutton;
        private Label label1;
        private Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private PictureBox pictureBox1;
        private Label label2;
        private Krypton.Toolkit.KryptonTextBox kryptonTextBox2;
        private Button gotoSimulate1;
        private Button GoBack;
        private Panel mainpanel;
    }
}