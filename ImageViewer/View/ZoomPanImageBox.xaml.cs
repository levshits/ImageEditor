using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ImageLibrary.Annotations;
using Image = System.Windows.Controls.Image;
using Point = System.Windows.Point;

namespace ImageViewer
{
	/// <summary>
	/// Interaction logic for ZoomPanImageBox.xaml
	/// </summary>
	public partial class ZoomPanImageBox : UserControl, INotifyPropertyChanged
	{
	    private Point start;
	    private Point origin;
	    private Image _image;


	    public ZoomPanImageBox()
		{
			this.InitializeComponent();
		}


	    private void ImageBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ImageBox.CaptureMouse();
            var tt = (TranslateTransform)((TransformGroup)ImageBox.RenderTransform)
                .Children.First(tr => tr is TranslateTransform);
            start = e.GetPosition(Viewer);
            origin = new Point(tt.X, tt.Y);
        }

        private void ImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (ImageBox.IsMouseCaptured)
            {
                var tt = (TranslateTransform)((TransformGroup)ImageBox.RenderTransform)
                    .Children.First(tr => tr is TranslateTransform);
                Vector v = start - e.GetPosition(Viewer);
                tt.X = origin.X - v.X;
                tt.Y = origin.Y - v.Y;
            }
        }

        private void ImageBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ImageBox.ReleaseMouseCapture();
        }

        private void ImageBox_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var st = (ScaleTransform)((TransformGroup)ImageBox.RenderTransform)
                .Children.First(tr => tr is ScaleTransform); ;
            double zoom = e.Delta > 0 ? .1 : -.1;
            if (st.ScaleX + zoom > 0.1)
            {
                st.ScaleX += zoom;
                st.ScaleY += zoom;
            }
        }

	    public event PropertyChangedEventHandler PropertyChanged;

	    [NotifyPropertyChangedInvocator]
	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	    {
	        var handler = PropertyChanged;
	        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
	    }
	}
}