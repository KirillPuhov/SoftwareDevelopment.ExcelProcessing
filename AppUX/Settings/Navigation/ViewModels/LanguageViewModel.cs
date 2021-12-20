using AppUX.Settings.Navigation.Utils;
using AppUX.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace AppUX.Settings.Navigation.ViewModels
{
    public class LanguageViewModel : ViewModelBase, INavigationAware
    {
        #region Fields

        private readonly INavigationManager _navigationManager;
        private SettingsLoader _loader = SettingsLoader.GetInstance();

        #endregion

        #region Ctor

        public LanguageViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        #endregion

        #region Properties

        private string[] _languages = new string[] { "Русский", "English", "Français", "Deutsch" };
        public string[] Languages
        {
            get { return _languages; }
        }

        private string _selectLanguage;
        public string SelectLanguage
        {
            get { return _selectLanguage; }
            set
            {
                _selectLanguage = value;
                OnPropertyChanged("SelectLanguage");
            }
        }

        #endregion

        #region Commands

        private ICommand _applySettingsCommand;
        public ICommand ApplySettingsCommand
        {
            get { return _applySettingsCommand ?? (_applySettingsCommand = new DelegateCommand(АpplySettings)); }
        }

        private void АpplySettings(object obj)
        {
            if (SelectLanguage != null)
            {
                _loader.UserSettings.Language = SelectLanguage;
            }
            _loader.SetResourcesSettings();
        }

        private ICommand _backSettingsCommand;
        public ICommand BackSettingsCommand
        {
            get { return _backSettingsCommand ?? (_backSettingsCommand = new DelegateCommand(CloseWindow)); }
        }

        private void CloseWindow(object obj)
        {
            var window = Application.Current.Windows.OfType<SettingsWindow>().SingleOrDefault(w => w.IsActive);
            window.Close();
        }

        #endregion

        #region NavigationAware

        public void OnNavigatingFrom() { }

        public void OnNavigatingTo(object arg) { }

        #endregion
    }
}
