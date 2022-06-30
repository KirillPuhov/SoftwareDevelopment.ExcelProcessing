using System.Windows;

namespace AppUX
{
    public partial class App : Application
    {
        public App()
        {
            ShutdownMode = ShutdownMode.OnLastWindowClose;
        }
    }
}
