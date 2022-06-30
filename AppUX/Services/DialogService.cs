using AppUX.Control.Window;
using AppUX.Graph;
using AppUX.Settings;
using AppUX.Settings.Navigation.Pages;
using AppUX.Settings.Navigation.Utils;
using AppUX.Settings.Navigation.ViewModels;
using Microsoft.Win32;
using System.Windows;

namespace AppUX.Services
{
    public class DialogService : IDialogService
    {
        private string _filePath;
        private Window _ownerWindow;

        public DialogService(Window ownerWindow)
        {
            _ownerWindow = ownerWindow;
        }

        public void ShowError(string error)
        {
            MessageBox.Show(error, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ShowInfo(string info)
        {
            var _info = new TextDialog("Info", info);
            _info.Owner = _ownerWindow;
            _info.ShowDialog();
        }

        public string FilePath 
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        public bool OpenFileDialog()
        {
            var _fileDialog = new OpenFileDialog();
            if(_fileDialog.ShowDialog() == true)
            {
                FilePath = _fileDialog.FileName;

                return true;
            }

            return false;
        }

        public bool OpenSettingsWindow()
        {
            var _window = new SettingsWindow();
            var _navigationManager = new NavigationManager(Application.Current.Dispatcher, _window.FrameContent);

            var _viewModel = new SettingsViewModel(_navigationManager);
            _window.DataContext = _viewModel;

            _navigationManager.Register<LanguageViewModel, LanguageView>(new LanguageViewModel(_navigationManager), "LanguagePage");
            _navigationManager.Register<ThemeViewModel, ThemeView>(new ThemeViewModel(_navigationManager), "ThemePage");
            _navigationManager.Register<FileViewModel, FileView>(new FileViewModel(_navigationManager), "FilePage");
            _navigationManager.Register<AboutViewModel, AboutView>(new AboutViewModel(_navigationManager), "AboutPage");
            _navigationManager.Navigate("AboutPage");

            _window.Owner = _ownerWindow;
            _window.ShowDialog();

            return true;
        }

        public bool OpenGraphWindow()
        {
            var _graph = new GraphicRepresentation();
            _graph.Owner = _ownerWindow;
            _graph.ShowDialog();

            return true;
        }
    }
}
