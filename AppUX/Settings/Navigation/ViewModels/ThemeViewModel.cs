using AppUX.Settings.Navigation.Utils;
using AppUX.ViewModel;
using AppUX.Constants;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace AppUX.Settings.Navigation.ViewModels
{
    public class ThemeViewModel : ViewModelBase, INavigationAware
    {
        #region Fields

        private readonly INavigationManager _navigationManager;
        private readonly SettingsLoader _loader = SettingsLoader.GetInstance();

        #endregion

        #region Ctor

        public ThemeViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;

            int keyTheme = AppConstants.ThemeDictionary.FirstOrDefault(x => x.Value == _loader.UserSettings.ThemeStatus).Key;
            _modeArray[keyTheme] = true;
        }

        #endregion

        #region Properties

        private bool[] _modeArray = new bool[] { true, false };
        public bool[] ModeArray
        {
            get 
            { 
                return _modeArray; 
            }
        }

        public int SelectedMode
        {
            get 
            { 
                return Array.IndexOf(_modeArray, true); 
            }
        }

        #endregion

        #region Command

        private ICommand _applySettingsCommand;
        public ICommand ApplySettingsCommand
        {
            get { return _applySettingsCommand ?? (_applySettingsCommand = new DelegateCommand(АpplySettings)); }
        }

        private void АpplySettings(object obj)
        {
            _loader.UserSettings.ThemeStatus = AppConstants.ThemeDictionary[SelectedMode];
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
