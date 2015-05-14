using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ImageLibrary.Annotations;
using ImageViewer.ViewModel;
using Point = System.Windows.Point;

namespace ImageViewer.View
{
	/// <summary>
	/// Interaction logic for ZoomPanImageBox.xaml
	/// </summary>
	public partial class ZoomPanImageBox : UserControl, INotifyPropertyChanged
	{
	    private Point start;
	    private Point origin;

	    public ZoomPanImageBox()
		{
			InitializeComponent();
		}


	    private void ImageBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	    {
	        var model = DataContext as EditableImageViewModel;
	        if (model != null && model.SelectionActivated)
	        {
	            Pan = false;
	            isSelectionActivated = true;
                start = e.GetPosition(Viewer);
                var st = (ScaleTransform)((TransformGroup)ImageBox.RenderTransform)
                .Children.First(tr => tr is ScaleTransform);
                var tt = (TranslateTransform)((TransformGroup)ImageBox.RenderTransform)
                    .Children.First(tr => tr is TranslateTransform);
	            var coefX = ImageBox.Source.Width / (ImageBox.ActualWidth * st.ScaleX);
                var coefY = ImageBox.Source.Height / (ImageBox.ActualHeight * st.ScaleY);
                start.X = (start.X - tt.X)*coefX;
                start.Y = (start.Y - tt.Y)*coefY;
	        }
	        else
	        {
	            Pan = true;
	            isSelectionActivated = false;
	            ImageBox.CaptureMouse();
	            var tt = (TranslateTransform) ((TransformGroup) ImageBox.RenderTransform)
	                .Children.First(tr => tr is TranslateTransform);
                start = e.GetPosition(Viewer);
	            origin = new Point(tt.X, tt.Y);
	        }
	    }

	    public bool Pan { get; set; }
	    private bool isSelectionActivated = false;

	    private void ImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (Pan && e.LeftButton == MouseButtonState.Pressed)
            {
                var tt = (TranslateTransform) ((TransformGroup) ImageBox.RenderTransform)
                    .Children.First(tr => tr is TranslateTransform);
                Vector v = start - e.GetPosition(Viewer);
                tt.X = origin.X - v.X;
                tt.Y = origin.Y - v.Y;
            }
            else
            {
                var model = DataContext as EditableImageViewModel;
                if (model != null && e.LeftButton == MouseButtonState.Pressed && isSelectionActivated)
                {
                    var pos = e.GetPosition(Viewer);
                    var st = (ScaleTransform)((TransformGroup)ImageBox.RenderTransform)
                .Children.First(tr => tr is ScaleTransform);
                    var coefX = ImageBox.Source.Width / (ImageBox.ActualWidth * st.ScaleX);
                    var coefY = ImageBox.Source.Height / (ImageBox.ActualHeight * st.ScaleY);
                    var tt = (TranslateTransform)((TransformGroup)ImageBox.RenderTransform)
                    .Children.First(tr => tr is TranslateTransform);
                    pos.X = (pos.X - tt.X) * coefX;
                    pos.Y = (pos.Y - tt.Y) * coefY;
                    if (pos.X - start.X > 0 && pos.Y - start.Y > 0)
                    {
                        model.Image.Rectangle = new Rectangle(Convert.ToInt32(start.X), Convert.ToInt32(start.Y),
                            Convert.ToInt32(pos.X - start.X), Convert.ToInt32(pos.Y - start.Y));
                    }
                    else
                    {
                        model.Image.Rectangle = Rectangle.Empty;
                    }
                }
            }
        }

        private void ImageBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Pan)
                ImageBox.ReleaseMouseCapture();
            else
            {
                var model = DataContext as EditableImageViewModel;
                if (model != null && isSelectionActivated)
                {
                    var pos = e.GetPosition(Viewer);
                    var st = (ScaleTransform)((TransformGroup)ImageBox.RenderTransform)
                                     .Children.First(tr => tr is ScaleTransform);
                    var coefX = ImageBox.Source.Width / (ImageBox.ActualWidth * st.ScaleX);
                    var coefY = ImageBox.Source.Height / (ImageBox.ActualHeight * st.ScaleY);
                    var tt = (TranslateTransform)((TransformGroup)ImageBox.RenderTransform)
                    .Children.First(tr => tr is TranslateTransform);
                    pos.X = (pos.X - tt.X) * coefX;
                    pos.Y = (pos.Y - tt.Y) * coefY;
                    if (pos.X - start.X > 0 && pos.Y - start.Y > 0)
                    {
                        model.Image.Rectangle = new Rectangle(Convert.ToInt32(start.X), Convert.ToInt32(start.Y), Convert.ToInt32(pos.X - start.X), Convert.ToInt32(pos.Y - start.Y));
                    }
                    else model.Image.Rectangle = Rectangle.Empty;
                }
            }
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