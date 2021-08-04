using Domain.Controllers;
using Domain.Managers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace AppUX.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ExcelController _excel = new ExcelController(new ExcelManager(), new DataTableHelper());

        public ObservableCollection<string> _cmbContent { get; set; }
        public MainViewModel()
        {
            _cmbContent = new ObservableCollection<string>();
        }

        private DataTable _excelTable;
        public DataTable ExcelTable
        {
            get { return _excelTable; }
            set
            {
                _excelTable = value;
                OnPropertyChanged("ExcelTable");
            }
        }

        private string _path;
        public string FilePath
        {
            get { return _path; }
            set
            {
                _path = value;
                OnPropertyChanged("FilePath");
            }
        }

        private string _tableName;
        public string TableName
        {
            get { return _tableName; }
            set
            {
                _tableName = value;
                OnPropertyChanged("TableName");
            }
        }

        private string _columnCount;
        public string ColumnCount
        {
            get { return _columnCount; }
            set
            {
                _columnCount = value;
                OnPropertyChanged("ColumnCount");
            }
        }

        private string _format;
        public string Format 
        {
            get { return _format; }
            set
            {
                _format = value;
                OnPropertyChanged("Format");
            }
        }

        private string _filter;
        public string Filter
        {
            get { return _filter; }
            set
            {
                _filter = value;
                OnPropertyChanged("Filter");
            }
        }

        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        #region Сommands for opening and saving tables
        private RelayCommand _openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand ??
                    (_openCommand = new RelayCommand(obj =>
                    {
                        OpenFileDialog _fileDialog = new OpenFileDialog();

                        if (_fileDialog.ShowDialog() == true)
                            FilePath = _fileDialog.FileName;

                        if (string.IsNullOrWhiteSpace(FilePath) == true)
                        {
                            return;
                        }

                        ExcelTable = _excel.GetTable(FilePath);

                        _cmbContent.Clear();
                        for (int i = 0; i < ExcelTable.Columns.Count; i++)
                        {
                            _cmbContent.Add(Convert.ToString(ExcelTable.Columns[i]));
                        }
                    }));
            }
        }

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??
                    (_saveCommand = new RelayCommand(obj => 
                    {
                        try
                        {
                            DataView _dataView = new DataView();
                            DataTable _data = new DataTable();
                            SaveFileDialog _saveFileDialog = new SaveFileDialog();
                            string _filePath = null;

                            _saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx|Excel file (*.xls)|*.xls";
                            if (_saveFileDialog.ShowDialog() == true)
                                _filePath = string.Empty;

                            _filePath = _saveFileDialog.FileName;

                            if (string.IsNullOrWhiteSpace(_filePath) == true)
                            {
                                return;
                            }

                            if (ExcelTable == null)
                            {
                                MessageBox.Show("Info: Table cannot be empty", "Table", MessageBoxButton.OK, MessageBoxImage.Information);
                                return;
                            }

                            _dataView = ExcelTable.DefaultView;

                            _dataView.RowFilter = Format;
                            _data = _dataView.ToTable();

                            bool _result = _excel.SetTable(_data, _filePath);

                            if (_result == true)
                                FilePath = "Готово";
                            else
                                FilePath = "Файл не сохранен";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }));
            }
        }

        private RelayCommand _gridClearCommand;
        public RelayCommand GridClearCommand
        {
            get
            {
                return _gridClearCommand ??
                    (_gridClearCommand = new RelayCommand(obj =>
                    {
                        Filter = string.Empty;
                        ExcelTable = null;
                        FilePath = string.Empty;
                        _cmbContent.Clear();
                    }));
            }
        }
        #endregion

        #region Сommands for creating new tables
        private RelayCommand _nextCommand;
        public RelayCommand NextCommand
        {
            get
            {
                return _nextCommand ??
                    (_nextCommand = new RelayCommand(obj =>
                    {
                        var _layoutPanel = (Grid)obj;

                        ClearChildrenInPanel(_layoutPanel);
                        AddChildrenInPanel(_layoutPanel, Convert.ToInt32(ColumnCount));
                    }));
            }
        }

        private void ClearChildrenInPanel(Grid _panel)
        {
            for (int j = 0; j < _panel.Children.Count; j++)
            {
                if (_panel.Children[j].GetType() == typeof(TextBox))
                {
                    _panel.Children.Remove((TextBox)_panel.Children[j]);
                    j--;
                }
            }
        }

        private void AddChildrenInPanel(Grid _panel, int _columnCount)
        {
            for (int i = 0; i < _columnCount; i++)
            {
                TextBox myTextBox = new TextBox();
                myTextBox.Height = 17;
                myTextBox.SetValue(Grid.RowProperty, 1);
                myTextBox.TextWrapping = TextWrapping.Wrap;
                myTextBox.Name = "Column" + (i + 1);
                myTextBox.Text = myTextBox.Name;
                myTextBox.VerticalAlignment = VerticalAlignment.Top;
                myTextBox.Margin = new Thickness(0, 25 * i, 0, 0);
                _panel.Children.Add(myTextBox);
            }
        }

        private RelayCommand _createTableCommand;
        public RelayCommand CreateTableCommand
        {
            get
            {
                return _createTableCommand ??
                    (_createTableCommand = new RelayCommand(obj => 
                    {
                        var _helper = new DataTableHelper();

                        var _layoutPanel = (Grid)((object[])obj)[0];
                        var _columnNames = (Dictionary<int, string>)((object[])obj)[1];

                        GetColumnNames(_layoutPanel, _columnNames);
                        ExcelTable = _helper.CreateNewDataTable(_columnNames, TableName);

                        _cmbContent.Clear();
                        for (int i = 0; i < ExcelTable.Columns.Count; i++)
                        {
                            _cmbContent.Add(Convert.ToString(ExcelTable.Columns[i]));
                        }

                        TableName = string.Empty;
                        ColumnCount = string.Empty;
                    }));
            }
        }

        private void GetColumnNames(Grid _layoutPanel, Dictionary<int, string> _columnNames)
        {
            foreach (UIElement element in _layoutPanel.Children)
            {
                if (element is TextBox)
                {
                    string content = ((TextBox)element).Text;

                    string name = ((TextBox)element).Name.Replace("Column", "");
                    int id = Convert.ToInt32(name) - 1;

                    _columnNames.Add(id, content);
                }
            }
        }
        #endregion

        #region Filter commands
        private RelayCommand _filterCommand;
        public RelayCommand FilterCommand
        {
            get
            {
                return _filterCommand ??
                    (_filterCommand = new RelayCommand(obj =>
                    {
                        var _table = (DataGrid)obj;

                        try
                        {
                            DataView _dataView;

                            if (ExcelTable != null)
                            {
                                _dataView = _table.ItemsSource as DataView;
                            }
                            else
                            {
                                return;
                            }

                            if (!string.IsNullOrEmpty(Filter) && !string.IsNullOrEmpty(SelectedItem))
                            {
                                try
                                {
                                    string _format = string.Format("[{0}] = '{1}'", SelectedItem, Filter);

                                    _dataView.RowFilter = _format;
                                    Format = _format;
                                }
                                catch (Exception)
                                {
                                    return;
                                }
                            }
                            else
                            {
                                _dataView.RowFilter = null;
                                Format = null;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }));
            }
        }

        private RelayCommand _filterClearCommand;
        public RelayCommand FilterClearCommand
        {
            get
            {
                return _filterClearCommand ??
                    (_filterClearCommand = new RelayCommand(obj =>
                    {
                        SelectedItem = string.Empty;
                        ((TextBox)obj).Text = string.Empty;
                    }));
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
