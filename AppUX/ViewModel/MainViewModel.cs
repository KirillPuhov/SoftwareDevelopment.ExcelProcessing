using AppUX.Constants;
using Domain.Controllers;
using Domain.Managers;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;

namespace AppUX.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ExportController _export;
        private readonly ExcelController _excel = new ExcelController(new ImportTableManager());
        private readonly SettingsLoader _loader = SettingsLoader.GetInstance();

        #endregion

        #region Properties

        public ObservableCollection<string> ComboBoxContent { get; set; }
        public MainViewModel()
        {
            ComboBoxContent = new ObservableCollection<string>();
        }

        private bool[] _modeArray = new bool[] { true, false };
        public bool[] ModeArray
        {
            get 
            { 
                return _modeArray; 
            }
            set
            {
                _modeArray = value;
                OnPropertyChanged("ModeArray");
            }
        }

        public int SelectedMode
        {
            get
            {
                return Array.IndexOf(_modeArray, true);
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

        private string _selectedItem2;
        public string SelectedItem2
        {
            get { return _selectedItem2; }
            set
            {
                _selectedItem2 = value;
                OnPropertyChanged("SelectedItem2");
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
                        OpenFileDialog _fileDialog = new OpenFileDialog();

                        if (_fileDialog.ShowDialog() is false)
                            return;
                        FilePath = _fileDialog.FileName;

                        if (string.IsNullOrWhiteSpace(FilePath) is true)
                            return;

                        ExcelTable = _excel.GetTable(FilePath);

                        ComboBoxContent.Clear();
                        for (int i = 0; i < ExcelTable.Columns.Count; i++)
                        {
                            ComboBoxContent.Add(Convert.ToString(ExcelTable.Columns[i]));
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

                switch (_loader.UserSettings.DefaultSaveFile)
                {
                    case AppConstants.ExcelFile:
                        _export = new ExportController(new ExcelManager());
                        _fileName = AppConstants.ExcelFile + "_file.xlsx";
                        break;

                    case AppConstants.WordFile:
                        _export = new ExportController(new WordManager());
                        _fileName = AppConstants.WordFile + "_file.docx";
                        break;

                    case AppConstants.TextFile:
                        _export = new ExportController(new TextManager());
                        _fileName = AppConstants.TextFile + "_file.txt";
                        break;
                }

                string _filePath = _loader.UserSettings.DefaultSavePath + "\\" + _fileName;

                if (ExcelTable is null)
                    return;

                var _data = TableView.ToTable();
                bool _result = _export.SetTable(_data, _filePath);

                FilePath = "Готово";
            }
            catch (Exception)
            {
                throw new Exception();
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
                        ExcelTable   = null;
                        SelectedItem = null;
                        Filter       = null;
                        Format       = null;
                        FilePath     = null;
                        ComboBoxContent.Clear();
                    }));
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

                        string _format = string.IsNullOrWhiteSpace(Filter)
                                      || string.IsNullOrWhiteSpace(SelectedItem) ? string.Empty : string.Format("[{0}] = '{1}'", SelectedItem, Filter);

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
                        if (string.IsNullOrWhiteSpace(SelectedItem2))
                            return;

                        switch (SelectedMode)
                        {
                            case 0:
                                Sorting = string.Format("{0} {1}", SelectedItem2, AppConstants.Ascending);
                                break;
                            case 1:
                                Sorting = string.Format("{0} {1}", SelectedItem2, AppConstants.Descending);
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
                        if (TableName != null)
                            TableView.Sort = string.Empty;

                        if(!string.IsNullOrWhiteSpace(SelectedItem))
                            SelectedItem   = string.Empty;

                        if(!string.IsNullOrWhiteSpace(SelectedItem2))
                            SelectedItem2  = string.Empty;

                        if(!string.IsNullOrWhiteSpace(Filter))
                            Filter         = string.Empty;

                        if(!string.IsNullOrWhiteSpace(Format))
                            Format         = string.Empty;

                        if (!string.IsNullOrWhiteSpace(Sorting))
                            Sorting        = string.Empty;

                        ModeArray = new bool[] { true, false };
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