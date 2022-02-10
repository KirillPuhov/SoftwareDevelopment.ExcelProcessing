using AppUX.Constants;
using Domain.Controllers;
using Domain.Managers;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;

namespace AppUX.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ExportController _export;
        private DataTableCollection _dataTableCollect;
        private readonly SettingsLoader _loader = SettingsLoader.GetInstance();
        private readonly ExcelController _excel = new ExcelController(new ImportTableManager());

        #endregion

        #region Properties

        public ObservableCollection<string> FilterContent { get; set; }
        public ObservableCollection<string> ComboBoxLists { get; set; }
        public MainViewModel()
        {
            FilterContent = new ObservableCollection<string>();
            ComboBoxLists = new ObservableCollection<string>();
        }

        private bool[] _sortModeArray = new bool[] { true, false };
        public bool[] SortModeArray
        {
            get 
            { 
                return _sortModeArray; 
            }
            set
            {
                _sortModeArray = value;
                OnPropertyChanged("SortModeArray");
            }
        }

        public int SortSelectedMode
        {
            get
            {
                return Array.IndexOf(_sortModeArray, true);
            }
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

        private DataView TableView
        {
            get
            {
                if (ExcelTable !=null)
                    return ExcelTable.DefaultView;

                return null;
            }
        }

        private string _openFilePath;
        public string OpenFilePath
        {
            get { return _openFilePath; }
            set
            {
                _openFilePath = value;
                OnPropertyChanged("OpenFilePath");
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

        private string _sorting;
        public string Sorting
        {
            get { return _sorting; }
            set
            {
                _sorting = value;
                OnPropertyChanged("Sorting");
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

        private string _filterSelectedItem;
        public string FilterSelectedItem
        {
            get { return _filterSelectedItem; }
            set
            {
                _filterSelectedItem = value;
                OnPropertyChanged("FilterSelectedItem");
            }
        }

        private string _sorterSelectedItem;
        public string SorterSelectedItem
        {
            get { return _sorterSelectedItem; }
            set
            {
                _sorterSelectedItem = value;
                OnPropertyChanged("SorterSelectedItem");
            }
        }

        private string _sheetsList;
        public string SheetsList
        {
            get { return _sheetsList; } 
            set 
            {
                _sheetsList = value; 
                OnPropertyChanged("SheetsList"); 
            }
        }

        #endregion

        #region OpenCommand and SaveCommand

        private RelayCommand _openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand ??
                    (_openCommand = new RelayCommand(obj =>
                    {
                        var _fileDialog = new OpenFileDialog();
                        if (_fileDialog.ShowDialog() is false)
                            return;

                        OpenFilePath = _fileDialog.FileName;

                        if (string.IsNullOrWhiteSpace(OpenFilePath) is true)
                            return;

                        _dataTableCollect = _excel.GetTable(OpenFilePath);

                        ColumnNameValidation();

                        ExcelTable = _dataTableCollect[Convert.ToString(ComboBoxLists[0])];
                        SheetsList = ComboBoxLists[0];

                        FilterContent.Clear();
                        for (int i = 0; i < ExcelTable.Columns.Count; i++)
                        {
                            FilterContent.Add(Convert.ToString(ExcelTable.Columns[i]));
                        }
                    }));
            }
        }

        private void ColumnNameValidation()
        {
            ComboBoxLists.Clear();
            foreach (DataTable _data in _dataTableCollect)
            {
                foreach (DataColumn _column in _data.Columns)
                {
                    if (_column.ColumnName.Contains("!"))
                        _column.ColumnName = _column.ColumnName.Replace("!", "");

                    if (_column.ColumnName.Contains("№"))
                        _column.ColumnName = _column.ColumnName.Replace("№", "");

                    if (_column.ColumnName.Contains("/"))
                        _column.ColumnName = _column.ColumnName.Replace("/", "");

                    if (_column.ColumnName.Contains("."))
                        _column.ColumnName = _column.ColumnName.Replace(".", "");

                    if (_column.ColumnName.Contains(","))
                        _column.ColumnName = _column.ColumnName.Replace(",", "");
                }
                ComboBoxLists.Add(_data.TableName);
            }
        }

        private RelayCommand _sheetChanged;
        public RelayCommand SheetChanged
        {
            get
            {
                return _sheetChanged ??
                    (_sheetChanged = new RelayCommand(obj =>
                    {
                        if (!string.IsNullOrWhiteSpace(SheetsList) || !string.IsNullOrEmpty(SheetsList))
                        {
                            ExcelTable = _dataTableCollect[Convert.ToString(SheetsList)];

                            FilterContent.Clear();
                            for (int i = 0; i < ExcelTable.Columns.Count; i++)
                            {
                                FilterContent.Add(Convert.ToString(ExcelTable.Columns[i]));
                            }
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
                    (_saveCommand = new RelayCommand(TrySave));
            }
        }

        private void TrySave(object obj)
        {
            try
            {
                string _fileName = null;
                var _rnd = new Random().Next().ToString();

                switch (_loader.UserSettings.DefaultSaveFile)
                {
                    case AppConstants.ExcelFile:
                        _export = new ExportController(new ExcelManager());
                        _fileName = AppConstants.ExcelFile + "_" + _rnd + ".xlsx";
                        break;

                    case AppConstants.WordFile:
                        _export = new ExportController(new WordManager());
                        _fileName = AppConstants.WordFile + "_" + _rnd + ".docx";
                        break;

                    case AppConstants.TextFile:
                        _export = new ExportController(new TextManager());
                        _fileName = AppConstants.TextFile + "_" + _rnd + ".txt";
                        break;
                }

                string _filePath = _loader.UserSettings.DefaultSavePath + "\\" + _fileName;

                if (ExcelTable is null)
                    return;

                var _data = TableView.ToTable();
                bool _result = _export.SetTable(_data, _filePath);

                OpenFilePath = "Готово";
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        #endregion

        #region FilterCommand and SortTableCommand

        private RelayCommand _filterCommand;
        public RelayCommand FilterCommand
        {
            get
            {
                return _filterCommand ??
                    (_filterCommand = new RelayCommand(obj => 
                    {
                        if (TableView is null)
                            return;

                        string _format = null;
                        if (int.TryParse(Filter, out int i))
                        {
                            _format = string.IsNullOrWhiteSpace(Filter)
                                      || string.IsNullOrWhiteSpace(FilterSelectedItem) ? string.Empty : string.Format("[{0}] = '{1}'", FilterSelectedItem, Filter);
                        }
                        else if (double.TryParse(Filter, out double d))
                        {
                            _format = string.IsNullOrWhiteSpace(Filter)
                                      || string.IsNullOrWhiteSpace(FilterSelectedItem) ? string.Empty : string.Format("[{0}] = '{1}'", FilterSelectedItem, Filter);
                        }
                        else
                        {
                            _format = string.IsNullOrWhiteSpace(Filter)
                                      || string.IsNullOrWhiteSpace(FilterSelectedItem) ? string.Empty : string.Format("[{0}] LIKE '%{1}%'", FilterSelectedItem, Filter);
                        }

                        TableView.RowFilter = _format;
                        Format = _format;
                    }));
            }
        }

        private RelayCommand _sortTableCommand;
        public RelayCommand SortTableCommand
        {
            get
            {
                return _sortTableCommand ??
                    (_sortTableCommand = new RelayCommand(obj => 
                    {
                        if (string.IsNullOrWhiteSpace(SorterSelectedItem))
                            return;

                        switch (SortSelectedMode)
                        {
                            case 0:
                                Sorting = string.Format("{0} {1}", SorterSelectedItem, AppConstants.Ascending);
                                break;
                            case 1:
                                Sorting = string.Format("{0} {1}", SorterSelectedItem, AppConstants.Descending);
                                break;
                        }

                        TableView.Sort = Sorting;
                    }));
            }
        }

        private RelayCommand _clearFilterCommand;
        public RelayCommand ClearFilterCommand
        {
            get
            {
                return _clearFilterCommand ??
                    (_clearFilterCommand = new RelayCommand(obj => 
                    {
                        if (Sorting != null)
                            TableView.Sort = null;

                        if (!string.IsNullOrWhiteSpace(FilterSelectedItem))
                            FilterSelectedItem = string.Empty;

                        if(!string.IsNullOrWhiteSpace(SorterSelectedItem))
                            SorterSelectedItem = string.Empty;

                        if (!string.IsNullOrWhiteSpace(Sorting))
                            Sorting            = string.Empty;

                        if (!string.IsNullOrWhiteSpace(Filter))
                            Filter             = string.Empty;

                        if(!string.IsNullOrWhiteSpace(Format))
                            Format             = string.Empty;

                        if (!string.IsNullOrWhiteSpace(Sorting))
                            Sorting            = string.Empty;

                        SortModeArray = new bool[] { true, false };
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
                        _dataTableCollect  = null;
                        ExcelTable         = null;
                        FilterSelectedItem = null;
                        SheetsList         = null;
                        Filter             = null;
                        Format             = null;
                        OpenFilePath       = null;
                        FilterContent.Clear();
                        ComboBoxLists.Clear();

                    }));
            }
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
    }
}