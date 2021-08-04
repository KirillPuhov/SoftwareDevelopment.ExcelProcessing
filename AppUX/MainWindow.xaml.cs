using AppUX.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using AppUX.Models;
using Newtonsoft.Json;
using System.IO;
using AppUX.UiMethods.Methods;

namespace AppUX
{
    public partial class MainWindow : Window
    {
        MainViewModel _viewModel = new MainViewModel();
        GridManager _manager = new GridManager();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel;

            #region Manage theme
            Setting _setting = new Setting();
            _setting = GetJsonSetting("./setting.json");

            List<string> styles = new List<string> { "Light", "Dark" };
            ThemeCmb.SelectionChanged += ThemeChange;
            ThemeCmb.ItemsSource = styles;
            ThemeCmb.SelectedItem = _setting.ThemeStatus;
            #endregion
        }

        #region Window Theme
        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string _style = ThemeCmb.SelectedItem as string;

            var _uri = new Uri("Themes/" + _style + ".xaml", UriKind.Relative);
            SetJsonSettings(_style, "./setting.json");
            ResourceDictionary resourceDict = Application.LoadComponent(_uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void SetJsonSettings(string _themeStatus, string _pathJson)
        {
            JsonSerializer _json = new JsonSerializer();

            if (File.Exists(_pathJson))
                File.Delete(_pathJson);

            StreamWriter _streamWriter = new StreamWriter(_pathJson);
            JsonWriter _jsonWriter = new JsonTextWriter(_streamWriter);

            _json.Serialize(_jsonWriter, _themeStatus);

            _jsonWriter.Close();
            _streamWriter.Close();
        }

        private Setting GetJsonSetting(string _pathJson)
        {
            Setting _result = new Setting();
            JsonSerializer _json = new JsonSerializer();

            if (File.Exists(_pathJson))
            {
                StreamReader _streamReader = new StreamReader(_pathJson);
                JsonReader _jsonReader = new JsonTextReader(_streamReader);

                _result.ThemeStatus = _json.Deserialize(_jsonReader).ToString();
                _jsonReader.Close();
                _streamReader.Close();
            }

            return _result;
        }
        #endregion

        #region Grid
        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd.MM.yyyy";
        }
 
        #endregion

        #region Filter Triggers
        private void Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGrid _parameter = ExcelTable;
            _viewModel.Filter = FilterBox.Text;
            _viewModel.FilterCommand.Execute(_parameter);
        }

        private void FilterOpenButton_Click(object sender, RoutedEventArgs e)
        {
            _manager.DoubleAnimationShow(0, 1, 0.3, DialogForFilter);
        }

        private void FilterBackButton_Click(object sender, RoutedEventArgs e)
        {
            _manager.DoubleAnimationHide(1, 0, 0.3, DialogForFilter);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            var _parameter = FilterBox;
            _viewModel.FilterClearCommand.Execute(_parameter);
        }
        #endregion

        #region Create Triggers
        private void CreateOpenButton_Click(object sender, RoutedEventArgs e)
        {
            _manager.DoubleAnimationShow(0, 1, 0.3, DialogForCreate);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            layoutPanelRoot.Visibility = Visibility.Hidden;
            layoutPanel.Visibility = Visibility.Visible;

            Grid _parameter = layoutPanel;

            _viewModel.NextCommand.Execute(_parameter);
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            _manager.DoubleAnimationHide(1, 0, 0.3, DialogForCreate);

            layoutPanelRoot.Visibility = Visibility.Visible;
            layoutPanel.Visibility = Visibility.Hidden;

            Grid _grid = layoutPanel;

            var _columnNames = new Dictionary<int, string>();

            object[] _parameters = new object[3];
            _parameters[0] = _grid;
            _parameters[1] = _columnNames;

            _viewModel.CreateTableCommand.Execute(_parameters);
        }

        private void CreateBackButton_Click(object sender, RoutedEventArgs e)
        {
            _manager.DoubleAnimationHide(1, 0, 0.3, DialogForCreate);
        }
        #endregion 
    }
}
