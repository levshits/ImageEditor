using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ImageLibrary.Annotations;

namespace ImageViewer.View
{
	/// <summary>
	/// Interaction logic for ZoomPanImageBox.xaml
	/// </summary>
	public partial class ZoomPanImageBox : UserControl, INotifyPropertyChanged
	{
	    private Point _start;
	    private Point _origin;


	    public ZoomPanImageBox()
		{
			InitializeComponent();
		}


	    private void ImageBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ImageBox.CaptureMouse();
            var tt = (TranslateTransform)((TransformGroup)ImageBox.RenderTransform)
                .Children.First(tr => tr is TranslateTransform);
            _start = e.GetPosition(Viewer);
            _origin = new Point(tt.X, tt.Y);
        }

        private void ImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (ImageBox.IsMouseCaptured)
            {
                var tt = (TranslateTransform)((TransformGroup)ImageBox.RenderTransform)
                    .Children.First(tr => tr is TranslateTransform);
                Vector v = _start - e.GetPosition(Viewer);
                tt.X = _origin.X - v.X;
                tt.Y = _origin.Y - v.Y;
            }
        }

        private void ImageBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ImageBox.ReleaseMouseCapture();
        }

        private void ImageBox_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var st = (ScaleTransform)((TransformGroup)ImageBox.RenderTransform)
                .Children.First(tr => tr is ScaleTransform);
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