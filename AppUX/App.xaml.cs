using System;
using System.Runtime.ExceptionServices;
using System.Windows;

namespace AppUX
{
    public partial class App : Application
    {
        
        public App()
        {
            AppDomain.CurrentDomain.FirstChanceException += new EventHandler<System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs>(CurrentDomain_FirstChanceException);
        }

        public void CurrentDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => MessageBox.Show("Error Occurred \n\r" + e.Exception.Message + "\n\r" + e.Exception.StackTrace, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error)));
        }
    }
}
