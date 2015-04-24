using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace ImageViewerWinForms
{
    partial class ZoomAndPanImageBox
    {

        // zoom controls

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#region Construct, Dispose
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(3, 3);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(160, 121);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox.TabIndex = 6;
            this.imageBox.TabStop = false;
            this.imageBox.Click += new System.EventHandler(this.imageBox_Click);
            this.imageBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.image_MouseDown);
            this.imageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.image_MouseMove);
            this.imageBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.image_MouseUp);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.imageBox);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(352, 220);
            this.panel.TabIndex = 7;
            this.panel.SizeChanged += new System.EventHandler(this.panel_SizeChanged);
            // 
            // ZoomAndPanImageBox
            // 
            this.Controls.Add(this.panel);
            this.Name = "ZoomAndPanImageBox";
            this.Size = new System.Drawing.Size(352, 220);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public Image Image
		{
			get
			{
				return imageBox.Image;
			}
			set
			{
				// enable the zoom control if this is not a null image
				if (value != null)
				{
				    ComputeImageBoxSize(value);
				    CenterImage();
				}
				else
				{
					imageBox.Size = panel.Size;
				}
                // Set the image value
                imageBox.Image = value;
			}
		}
        private bool _isMousePressed = false;
        private int prevX = 0;
        private int prevY = 0;
        private void image_MouseDown(object sender, MouseEventArgs e)
        {
            _isMousePressed = true;
            prevX = e.Location.X;
            prevY = e.Location.Y;
        }
        private void image_MouseUp(object sender, MouseEventArgs e)
        {
            _isMousePressed = false;
        }
        private void image_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMousePressed)
            {
                imageBox.Location = new Point(imageBox.Left + e.Location.X - prevX,
                imageBox.Top + e.Location.Y - prevY);
                /////OPTIMIZE
                //int deltaX = (e.X - prevX);
                //int newValueX = panel.AutoScrollPosition.X;
                //if(Math.Abs(deltaX)>3)
                //    newValueX += deltaX;
                //int deltaY = (e.Y - prevY);
                //int newValueY = panel.AutoScrollPosition.Y;
                //if(Math.Abs(deltaY)>3)
                //    newValueY += deltaY;
                //if (panel.HorizontalScroll.Visible)
                //{

                //    if (newValueX >= 0 )
                //    {
                //        newValueX = 0;
                //    }
                //    else if (newValueX <=- panel.HorizontalScroll.Maximum)
                //    {
                //        newValueX = panel.HorizontalScroll.Maximum;
                //    }
                //    else
                //    {
                //        newValueX = Math.Abs(newValueX);
                //    }
                //}
                //prevX = e.X;
                //if (panel.VerticalScroll.Visible)
                //{
                //    if (newValueY >= 0 )
                //    {
                //        newValueY = 0;

                //    }
                //        else if (newValueY <= -panel.VerticalScroll.Maximum)
                //    {
                //        newValueX = panel.HorizontalScroll.Maximum;
                //    }
                //    else
                //    {
                //        newValueY = Math.Abs(newValueY);
                //    }
                //}
                //prevY = e.Y;
                //panel.AutoScrollPosition = new Point(newValueX, newValueY);
            }
        }
        private double _zoomValue = 1;
        public PictureBox imageBox;
        private Panel panel;

        public double ZoomValue
        {
            get
            {
                return _zoomValue;
            }
            set
            {
                _zoomValue = value;
                if (Image != null)
                {
                    imageBox.Width = Convert.ToInt32(imageBox.Image.Width*_zoomValue);
                    imageBox.Height = Convert.ToInt32(imageBox.Image.Height*_zoomValue);
                }
            }
        }
    }
}
