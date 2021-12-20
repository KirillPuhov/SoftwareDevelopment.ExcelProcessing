using AppUX.Settings.Navigation.Utils;
using System.Windows.Input;

namespace AppUX.Settings.Navigation.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        #region Fields

        private readonly INavigationManager _navigationManager;

        #endregion

        #region Ctor

        public SettingsViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        #endregion

        #region Commands

        private ICommand _showLanguageCommand;
        public ICommand ShowLanguageCommand
        {
            get { return _showLanguageCommand ?? (_showLanguageCommand = new DelegateCommand(ShowLanguagePage)); }
        }

        private void ShowLanguagePage(object arg)
        {
            _navigationManager.Navigate("LanguagePage");
        }


        private ICommand _showThemeCommand;
        public ICommand ShowThemeCommand
        {
            get { return _showThemeCommand ?? (_showThemeCommand = new DelegateCommand(ShowThemePage)); }
        }

        private void ShowThemePage(object arg)
        {
            _navigationManager.Navigate("ThemePage");
        }

        private ICommand _showFileCommand;
        public ICommand ShowFileCommand
        {
            get { return _showFileCommand ?? (_showFileCommand = new DelegateCommand(ShowFilePage)); }
        }

        private void ShowFilePage(object arg)
        {
            _navigationManager.Navigate("FilePage");
        }

        private ICommand _showAboutCommand;
        public ICommand ShowAboutCommand
        {
            get { return _showAboutCommand ?? (_showAboutCommand = new DelegateCommand(ShowAboutPage)); }
        }

        private void ShowAboutPage(object arg)
        {
            _navigationManager.Navigate("AboutPage");
        }

        #endregion
    }
}
