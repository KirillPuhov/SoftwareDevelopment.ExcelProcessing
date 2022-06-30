using AppUX.Constants;
using AppUX.Services;
using Domain.Controllers;
using Domain.Managers;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;

namespace AppUX.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private IDialogService _dialogService;
        private IValidationService _validationService;
        private IFilterService _filterService;

        #region Fields

        private ExportController _export;
        private DataTableCollection _dataTableCollect;
        private readonly SettingsLoader _loader;
        private readonly ExcelController _excel;

        #endregion

        #region ctor
        public MainViewModel(IDialogService dialogService, IValidationService validationService, IFilterService filterService)
        {
            FilterContent = new ObservableCollection<string>();
            ComboBoxLists = new ObservableCollection<string>();

            this._loader = SettingsLoader.GetInstance();
            this._excel = new ExcelController(new ImportTableManager());
            this._dialogService = dialogService;
            this._validationService = validationService;
            this._filterService = filterService;
        }

        #endregion

        #region Properties

        public ObservableCollection<string> FilterContent { get; set; }
        public ObservableCollection<string> ComboBoxLists { get; set; }
        

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
                        try
                        {
                            if (ExcelTable == null)
                            {
                                if (_dialogService.OpenFileDialog() == true)
                                {
                                    OpenFilePath = _dialogService.FilePath;

                                    if (!string.IsNullOrWhiteSpace(OpenFilePath))
                                    {
                                        _dataTableCollect = _excel.GetTable(OpenFilePath);

                                        if (_dataTableCollect == null)
                                            return;

                                        ColumnNameValidation();

                                        ExcelTable = _dataTableCollect[Convert.ToString(ComboBoxLists[0])];
                                        SheetsList = ComboBoxLists[0];

                                        FilterContent.Clear();
                                        for (int i = 0; i < ExcelTable.Columns.Count; i++)
                                        {
                                            FilterContent.Add(Convert.ToString(ExcelTable.Columns[i]));
                                        }
                                    }
                                }

                                FillReportList();
                            }
                        }
                        catch(Exception ex)
                        {
                            _dialogService.ShowError(ex.Message);
                        }
                    }));
            }
        }

        private void ColumnNameValidation()
        {
            char[] notAllowedSymbols = { '!', '№', '/', '.', ',', '+', '-', '#', '$', '%', '&', '(', ')', '*', };

            ComboBoxLists.Clear();
            _validationService.NotAllowedSymbols = notAllowedSymbols;

            var _list = new List<string>();

            foreach (DataTable _data in _dataTableCollect)
            {
                foreach (DataColumn _column in _data.Columns)
                {
                    _list.Add(_column.ColumnName);
                }
                ComboBoxLists.Add(_data.TableName);
            }

            if (!_validationService.IsValid(_list))
                _list = _validationService.Edit(_list);

            foreach (DataTable _data in _dataTableCollect)
            {
                for (int i = 0; i < _data.Columns.Count; i++)
                {
                    DataColumn _column = _data.Columns[i];
                    _column.ColumnName = _list[i];
                }
            }
        }

        private void FillReportList()
        {
            if(ExcelTable != null)
            {
                for (int i = 0; i < ExcelTable.Rows.Count; i++)
                {
                    var _row = ExcelTable.Rows[i];

                    var _list = new List<string>();

                    foreach (var _item in ExcelTable.Rows[i].ItemArray)
                    {
                        _list.Add(_item.ToString());
                    }

                    if (_row.ItemArray.Length == 5)
                    {
                        if (_validationService.TryConvertToReportModel(_list))
                        {
                            var model = new OgeReportsModel();

                            model.Id = Convert.ToInt32(_row.ItemArray[0]);
                            model.FullName = Convert.ToString(_row.ItemArray[1]);
                            model.ClassName = Convert.ToString(_row.ItemArray[2]);
                            model.AudienceNumber = Convert.ToInt32(_row.ItemArray[3]);
                            model.Points = Convert.ToInt32(_row.ItemArray[4]);

                            AppConstants.OgeReportsModelList.Add(model);
                        }
                    }

                }
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
                    (_saveCommand = new RelayCommand(obj => 
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
                        }
                        catch (Exception ex)
                        {
                            _dialogService.ShowError(ex.Message);
                        }
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
                        if (TableView != null)
                        {
                            var _format = _filterService.GetFilter(FilterSelectedItem, Filter);

                            TableView.RowFilter = _format;
                            Format = _format;

                            var SortItem = FilterSelectedItem;

                            if (string.IsNullOrWhiteSpace(FilterSelectedItem))
                                SortItem = FilterContent[0];

                            TableView.Sort = _filterService.GetSorting(SortItem, SortSelectedMode);
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
                        _dataTableCollect  = null;
                        ExcelTable         = null;
                        FilterSelectedItem = null;
                        SheetsList         = null;
                        Filter             = null;
                        Format             = null;
                        OpenFilePath       = null;
                        FilterContent.Clear();
                        ComboBoxLists.Clear();
                        AppConstants.OgeReportsModelList.Clear();

                    }));
            }
        }

        private RelayCommand _openSettingsWindow;

        public RelayCommand OpenSettingsWindow
        {
            get
            {
                return _openSettingsWindow ??
                    (_openSettingsWindow = new RelayCommand(obj => 
                    {
                        _dialogService.OpenSettingsWindow();
                    }));
            }
        }

        private RelayCommand _openReportWindow;

        public RelayCommand OpenReportWindow
        {
            get
            {
                return _openReportWindow ??
                    (_openReportWindow = new RelayCommand(obj => 
                    {
                        if (ExcelTable != null)
                        {
                            if (ExcelTable.Rows.Count != 0)
                            {
                                _dialogService.OpenGraphWindow();
                            }
                            else
                            {
                                _dialogService.ShowInfo("Table is empty");
                            }
                        }
                        else
                        {
                            _dialogService.ShowInfo("Table is empty");
                        }
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