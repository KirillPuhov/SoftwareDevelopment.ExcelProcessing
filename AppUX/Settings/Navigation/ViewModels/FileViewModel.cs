using AppUX.Settings.Navigation.Utils;
using AppUX.ViewModel;
using AppUX.Constants;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace AppUX.Settings.Navigation.ViewModels
{
    public class FileViewModel : ViewModelBase, INavigationAware
    {
        #region Fields

        private readonly INavigationManager _navigationManager;
        private SettingsLoader _loader = SettingsLoader.GetInstance();

        #endregion

        #region Ctor

        public FileViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;

            int keyFile = AppConstants.FileTypeDictionary.FirstOrDefault(x => x.Value == _loader.UserSettings.DefaultSaveFile).Key;
            _modeArray[keyFile] = true;

            if (_loader.UserSettings.DefaultSavePath == null)
                UserPath = AppConstants.UserFilePath;
            else
                UserPath = _loader.UserSettings.DefaultSavePath;
        }

        #endregion

        #region Properties

        private bool[] _modeArray = new bool[] { true, false, false };
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

        private string _userPath = AppConstants.UserFilePath;
        public string UserPath
        {
            get { return _userPath; }
            set
            {
                _userPath = value;
                OnPropertyChanged("UserPath");
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
            _loader.UserSettings.DefaultSaveFile = AppConstants.FileTypeDictionary[SelectedMode];
            _loader.UserSettings.DefaultSavePath = UserPath;
            _loader.SetSettings();
        }

        private ICommand _backSettingsCommand;
        public ICommand BackSettingsCommand
        {
            get { return _backSettingsCommand ?? (_backSettingsCommand = new DelegateCommand(CloseWindow)); }
        }

        private void CloseWindow(object obj)
        {
            var window = System.Windows.Application.Current.Windows.OfType<SettingsWindow>().SingleOrDefault(w => w.IsActive);
            window.Close();
        }

        private ICommand _openPathPickerCommand;
        public ICommand OpenPathPickerCommand
        {
            get { return _openPathPickerCommand ?? (_openPathPickerCommand = new DelegateCommand(OpenFilePicker)); }
        }

        private void OpenFilePicker(object obj)
        {
            var _filePathDialog = new FolderBrowserDialog();
            _filePathDialog.ShowDialog();
            if (!string.IsNullOrWhiteSpace(_filePathDialog.SelectedPath))
                UserPath = _filePathDialog.SelectedPath;
            else 
                UserPath = AppConstants.UserFilePath;
        }

        #endregion

        #region NavigationAware

        public void OnNavigatingFrom() { }

        public void OnNavigatingTo(object arg) { }

        #endregion
    }
}
