using AppUX.Models;
using AppUX.Constants;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace AppUX.ViewModel
{
    public class SettingsLoader : INotifyPropertyChanged
    {
        #region Fields

        private readonly string _settingsPath;

        #endregion

        #region Ctor

        public SettingsLoader(string settingsPath)
        {
            if (!File.Exists(settingsPath))
                throw new FileNotFoundException(settingsPath);

            _settingsPath = settingsPath;
            GetSettings();
        }

        #endregion

        #region Properties

        private static UserSettings _userSettings;
        public UserSettings UserSettings
        {
            get { return _userSettings; }
            set
            {
                _userSettings = value;
                OnPropertyChanged("UserSettings");
            }
        }

        #endregion

        #region Methods

        public void SetSettings()
        {
            JsonSerializer _json = new JsonSerializer();

            if (File.Exists(_settingsPath))
                File.Delete(_settingsPath);

            StreamWriter _streamWriter = new StreamWriter(_settingsPath);
            JsonWriter _jsonWriter = new JsonTextWriter(_streamWriter);

            _json.Serialize(_jsonWriter, UserSettings);

            _jsonWriter.Close();
            _streamWriter.Close();
        }

        public void SetResourcesSettings()
        {
            SetSettings();
            ChangeResource(AppConstants.ResourcesFolder, UserSettings.ThemeStatus);
            ChangeResource(AppConstants.ResourcesFolder, AppConstants.LanguagesDictionary[UserSettings.Language]);
        }

        public void GetSettings()
        {
            UserSettings _result = new UserSettings();
            JsonSerializer _json = new JsonSerializer();

            if (File.Exists(_settingsPath))
            {
                StreamReader _streamReader = new StreamReader(_settingsPath);
                JsonReader _jsonReader = new JsonTextReader(_streamReader);

                _result = _json.Deserialize<UserSettings>(_jsonReader);
                _jsonReader.Close();
                _streamReader.Close();
            }
            UserSettings = _result;
        }

        public void ChangeResource(string _folder, string _resource)
        {
            var _uri = new Uri(_folder + _resource + ".xaml", UriKind.Relative);

            ResourceDictionary resourceDict = Application.LoadComponent(_uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        #region Singleton

        private static readonly Lazy<SettingsLoader> _lazy =
            new Lazy<SettingsLoader>(() => new SettingsLoader(AppConstants.JsonSettingsFilePath));

        public static SettingsLoader GetInstance()
        {
            return _lazy.Value;
        }

        #endregion
    }
}
