namespace ImageViewerWinForms
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RedLevel = new System.Windows.Forms.TrackBar();
            this.contrastLevel = new System.Windows.Forms.TrackBar();
            this.brightnessLevel = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.saturationLevel = new System.Windows.Forms.TrackBar();
            this.ZoomOut = new System.Windows.Forms.Button();
            this.ZoomIn = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BlueLevel = new System.Windows.Forms.TrackBar();
            this.GreenLevel = new System.Windows.Forms.TrackBar();
            this.ImageBox = new ImageViewerWinForms.ZoomAndPanImageBox();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessLevel)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saturationLevel)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlueLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(706, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "MainMenu";
            // 
            // File
            // 
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(37, 20);
            this.File.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Brightness";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contrast";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Color";
            // 
            // RedLevel
            // 
            this.RedLevel.LargeChange = 20;
            this.RedLevel.Location = new System.Drawing.Point(26, 3);
            this.RedLevel.Maximum = 255;
            this.RedLevel.Minimum = -255;
            this.RedLevel.Name = "RedLevel";
            this.RedLevel.Size = new System.Drawing.Size(104, 38);
            this.RedLevel.SmallChange = 10;
            this.RedLevel.TabIndex = 5;
            this.RedLevel.ValueChanged += new System.EventHandler(this.ColorLevel_ValueChanged);
            // 
            // contrastLevel
            // 
            this.contrastLevel.LargeChange = 20;
            this.contrastLevel.Location = new System.Drawing.Point(19, 110);
            this.contrastLevel.Maximum = 255;
            this.contrastLevel.Minimum = -255;
            this.contrastLevel.Name = "contrastLevel";
            this.contrastLevel.Size = new System.Drawing.Size(104, 45);
            this.contrastLevel.SmallChange = 10;
            this.contrastLevel.TabIndex = 6;
            this.contrastLevel.ValueChanged += new System.EventHandler(this.contrastLevel_ValueChanged);
            // 
            // brightnessLevel
            // 
            this.brightnessLevel.LargeChange = 20;
            this.brightnessLevel.Location = new System.Drawing.Point(19, 62);
            this.brightnessLevel.Maximum = 255;
            this.brightnessLevel.Minimum = -255;
            this.brightnessLevel.Name = "brightnessLevel";
            this.brightnessLevel.Size = new System.Drawing.Size(104, 45);
            this.brightnessLevel.SmallChange = 10;
            this.brightnessLevel.TabIndex = 7;
            this.brightnessLevel.ValueChanged += new System.EventHandler(this.brightnessLevel_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ImageBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(706, 394);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.saturationLevel);
            this.groupBox1.Controls.Add(this.ZoomOut);
            this.groupBox1.Controls.Add(this.ZoomIn);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.brightnessLevel);
            this.groupBox1.Controls.Add(this.contrastLevel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 388);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Saturation";
            // 
            // saturationLevel
            // 
            this.saturationLevel.LargeChange = 20;
            this.saturationLevel.Location = new System.Drawing.Point(19, 158);
            this.saturationLevel.Maximum = 255;
            this.saturationLevel.Minimum = -255;
            this.saturationLevel.Name = "saturationLevel";
            this.saturationLevel.Size = new System.Drawing.Size(104, 45);
            this.saturationLevel.SmallChange = 10;
            this.saturationLevel.TabIndex = 17;
            this.saturationLevel.ValueChanged += new System.EventHandler(this.saturationLevel_ValueChanged);
            // 
            // ZoomOut
            // 
            this.ZoomOut.Location = new System.Drawing.Point(83, 20);
            this.ZoomOut.Name = "ZoomOut";
            this.ZoomOut.Size = new System.Drawing.Size(47, 23);
            this.ZoomOut.TabIndex = 15;
            this.ZoomOut.Text = "-";
            this.ZoomOut.UseVisualStyleBackColor = true;
            this.ZoomOut.Click += new System.EventHandler(this.ZoomOut_Click);
            // 
            // ZoomIn
            // 
            this.ZoomIn.Location = new System.Drawing.Point(26, 20);
            this.ZoomIn.Name = "ZoomIn";
            this.ZoomIn.Size = new System.Drawing.Size(47, 23);
            this.ZoomIn.TabIndex = 14;
            this.ZoomIn.Text = "+";
            this.ZoomIn.UseVisualStyleBackColor = true;
            this.ZoomIn.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.5F));
            this.tableLayoutPanel2.Controls.Add(this.RedLevel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.BlueLevel, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.GreenLevel, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 222);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(154, 132);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "R";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "G";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "B";
            // 
            // BlueLevel
            // 
            this.BlueLevel.LargeChange = 20;
            this.BlueLevel.Location = new System.Drawing.Point(26, 91);
            this.BlueLevel.Maximum = 255;
            this.BlueLevel.Minimum = -255;
            this.BlueLevel.Name = "BlueLevel";
            this.BlueLevel.Size = new System.Drawing.Size(104, 38);
            this.BlueLevel.SmallChange = 10;
            this.BlueLevel.TabIndex = 9;
            this.BlueLevel.ValueChanged += new System.EventHandler(this.ColorLevel_ValueChanged);
            // 
            // GreenLevel
            // 
            this.GreenLevel.LargeChange = 20;
            this.GreenLevel.Location = new System.Drawing.Point(26, 47);
            this.GreenLevel.Maximum = 255;
            this.GreenLevel.Minimum = -255;
            this.GreenLevel.Name = "GreenLevel";
            this.GreenLevel.Size = new System.Drawing.Size(104, 38);
            this.GreenLevel.SmallChange = 10;
            this.GreenLevel.TabIndex = 11;
            this.GreenLevel.ValueChanged += new System.EventHandler(this.ColorLevel_ValueChanged);
            // 
            // ImageBox
            // 
            this.ImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageBox.Image = null;
            this.ImageBox.Location = new System.Drawing.Point(163, 3);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(540, 388);
            this.ImageBox.TabIndex = 11;
            this.ImageBox.ZoomValue = 1D;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 418);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainView";
            this.Text = "ImageViewer";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessLevel)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saturationLevel)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlueLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar RedLevel;
        private System.Windows.Forms.TrackBar contrastLevel;
        private System.Windows.Forms.TrackBar brightnessLevel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ZoomAndPanImageBox ImageBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar GreenLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar BlueLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ZoomOut;
        private System.Windows.Forms.Button ZoomIn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar saturationLevel;
    }
}

