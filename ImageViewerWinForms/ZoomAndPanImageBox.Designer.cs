using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ImageViewerWinForms
{
    partial class ZoomAndPanImageBox
    {

        // zoom controls

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

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
			    Image b = value;
				// enable the zoom control if this is not a null image
				if (value != null)
				{
				    if (imageBox.Image == null)
				    {
				        ComputeImageBoxSize(value);
				        CenterImage();
				    }
				}
				else
				{
					imageBox.Size = panel.Size;
				}
                imageBox.Image = b;
			}
		}

        public bool SelectionIsActive = false;
        private bool _isMousePressed = false;
        private int prevX = 0;
        private int prevY = 0;
        private void image_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (!SelectionIsActive)
            {
                _isMousePressed = true;
                prevX = e.Location.X;
                prevY = e.Location.Y;
            }
            else
            {
                prevX = Convert.ToInt32(e.Location.X / zoomValue);
                prevY = Convert.ToInt32(e.Location.Y / zoomValue);
                var pos = new Point { X = Convert.ToInt32(e.X / ZoomValue), Y = Convert.ToInt32(e.Y / ZoomValue) };
                if (prevX < e.X && prevY < e.Y)
                {
                    EditableImage.Rectangle = new Rectangle(prevX, prevY, pos.X - prevX, pos.Y - prevY);
                    Image = EditableImage.ImageView;
                }
                else
                {
                    EditableImage.Rectangle = Rectangle.Empty;
                } 
            }
        }
        private void image_MouseUp(object sender, MouseEventArgs e)
        {
            if (SelectionIsActive)
            {
                var pos = new Point { X = Convert.ToInt32(e.X / ZoomValue), Y = Convert.ToInt32(e.Y / ZoomValue) };
                if (prevX < pos.X && prevY < pos.Y)
                {
                    EditableImage.Rectangle = new Rectangle(prevX, prevY, pos.X - prevX, pos.Y - prevY);
                    Image = EditableImage.ImageView;
                }
                else
                {
                    EditableImage.Rectangle = Rectangle.Empty;
                    Image = EditableImage.ImageView;
                } 
            }
            _isMousePressed = false;
        }
        private void image_MouseMove(object sender, MouseEventArgs e)
        {
            if (SelectionIsActive && e.Button == MouseButtons.Left)
            {
                var pos = new Point { X = Convert.ToInt32(e.X / ZoomValue), Y = Convert.ToInt32(e.Y / ZoomValue) };
                if (prevX < pos.X && prevY < pos.Y)
                {
                    EditableImage.Rectangle = new Rectangle(prevX, prevY, pos.X - prevX, pos.Y - prevY);
                    Image = EditableImage.ImageView;
                }
                else
                {
                    EditableImage.Rectangle = Rectangle.Empty;
                    Image = EditableImage.ImageView;
                }
            }
            if (_isMousePressed)
            {
                imageBox.Location = new Point(imageBox.Left + e.Location.X - prevX,
                imageBox.Top + e.Location.Y - prevY);
            }
        }
        private double zoomValue = 1;
        public PictureBox imageBox;
        private Panel panel;

        public double ZoomValue
        {
            get
            {
                return zoomValue;
            }
            set
            {
                zoomValue = value;
                if (Image != null)
                {
                    imageBox.Width = Convert.ToInt32(imageBox.Image.Width*zoomValue);
                    imageBox.Height = Convert.ToInt32(imageBox.Image.Height*zoomValue);
                }
            }
        }
    }
}
