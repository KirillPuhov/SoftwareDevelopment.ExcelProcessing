using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AppUX.Control.Window
{
    public partial class WindowControlBox : UserControl
    {
        public static readonly DependencyProperty MinimizeBoxProperty = DependencyProperty.Register("MinimizeBox", typeof(bool), typeof(WindowControlBox), new PropertyMetadata(true));
        public bool MinimizeBox
        {
            get { return (bool)GetValue(MinimizeBoxProperty); }
            set { SetValue(MinimizeBoxProperty, value); }
        }

        public static readonly DependencyProperty MaximizeBoxProperty = DependencyProperty.Register("MaximizeBox", typeof(bool), typeof(WindowControlBox), new PropertyMetadata(true));
        public bool MaximizeBox
        {
            get { return (bool)GetValue(MaximizeBoxProperty); }
            set { SetValue(MaximizeBoxProperty, value); }
        }

        public readonly static DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(WindowControlBox), new PropertyMetadata(Brushes.Black));
        public Brush Fill
        {
            get
            {
                return (Brush)GetValue(FillProperty);
            }
            set
            {
                SetValue(FillProperty, value);
            }
        }

        public RoutedEventHandler OnMinimize;
        public RoutedEventHandler OnMaximize;
        public RoutedEventHandler OnClose;

        public WindowControlBox()
        {
            InitializeComponent();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (OnMinimize != null)
                OnMinimize(sender, e);
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (OnMaximize != null)
                OnMaximize(sender, e);

            RestoreIcon.Visibility = (MaximizeIcon.Visibility == Visibility.Visible) ? Visibility.Visible : Visibility.Hidden;

            MaximizeIcon.Visibility = (MaximizeIcon.Visibility != Visibility.Visible) ? Visibility.Visible : Visibility.Hidden;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (OnClose != null)
                OnClose(sender, e);
        }
    }
}
