using AppUX.Models;
using AppUX.ViewModel;
using AppUX.Constants;
using System;
using System.Windows;
using System.Windows.Threading;

namespace AppUX
{
    public partial class SplashScreen : Window
    {
        private UserSettings _setting;
        SettingsLoader _loader = SettingsLoader.GetInstance();

        private readonly DispatcherTimer _dispatcherTimer = new DispatcherTimer();

        public SplashScreen()
        {
            InitializeComponent();

            _dispatcherTimer.Tick += new EventHandler(TimerTick);
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 2);
            _dispatcherTimer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (!LoadSettings())
                MessageBox.Show("Error: Failed to load settings!",
                    "Error!", MessageBoxButton.OK, MessageBoxImage.Error);

            var main = new MainWindow();
            main.Show();

            _dispatcherTimer.Stop();
            this.Close();
        }

        private bool LoadSettings()
        {
            _loader.GetSettings();
            _setting = _loader.UserSettings;

            if (_setting is null)
                return false;

            ResourceApply(AppConstants.LanguagesDictionary[_loader.UserSettings.Language]);

            ResourceApply(_loader.UserSettings.ThemeStatus);

            return true;
        }

        private void ResourceApply(string file)
        {
            var _uri = new Uri(AppConstants.ResourcesFolder + file + ".xaml", UriKind.Relative);

            ResourceDictionary resourceDict = Application.LoadComponent(_uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
