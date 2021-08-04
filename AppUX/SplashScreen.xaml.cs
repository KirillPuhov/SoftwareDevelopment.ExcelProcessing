using System;
using System.Windows;
using System.Windows.Threading;

namespace AppUX
{
    public partial class SplashScreen : Window
    {
        DispatcherTimer _dispatcherTimer = new DispatcherTimer();

        public SplashScreen()
        {
            InitializeComponent();  
            _dispatcherTimer.Tick += new EventHandler(TimerTick);
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 2);
            _dispatcherTimer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            _dispatcherTimer.Stop();
            this.Close();
        }
    }
}
