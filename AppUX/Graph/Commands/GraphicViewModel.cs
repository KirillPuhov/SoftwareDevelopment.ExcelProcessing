using AppUX.Constants;
using AppUX.Services;
using AppUX.ViewModel;
using Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppUX.Graph.Commands
{
    public class GraphicViewModel : INotifyPropertyChanged
    {
        private IDialogService _dialogService;
        private IOgeReport _report;

        private string _numberOfParticipants;

        public string NumberOfParticipants
        {
            get { return _numberOfParticipants; }
            set
            {
                _numberOfParticipants = value;
                OnPropertyChanged("NumberOfParticipants");
            }
        }

        private string _averagePoint;

        public string AveragePoint
        {
            get { return _averagePoint; }
            set
            {
                _averagePoint = value;
                OnPropertyChanged("AveragePoint");
            }
        }

        private string _maxPoint;

        public string MaxPoint
        {
            get { return _maxPoint; }
            set
            {
                _maxPoint = value;
                OnPropertyChanged("MaxPoint");
            }
        }

        private string _minPoint;

        public string MinPoint
        {
            get { return _minPoint; }
            set
            {
                _minPoint = value;
                OnPropertyChanged("MinPoint");
            }
        }

        private double[] _values = new double[4];

        public double[] Values
        {
            get { return _values; }
            set
            {
                _values = value;
                OnPropertyChanged("Values");
            }
        }

        private double[] _positions = { 0, 1, 2, 3 };

        public double[] Positions
        {
            get { return _positions; }
            set
            {
                _positions = value;
                OnPropertyChanged("Positions");
            }
        }

        private string[] _labels = { "\"2\"", "\"3\"", "\"4\"", "\"5\"" };

        public string[] Labels
        {
            get { return _labels; }
            set
            {
                _labels = value;
                OnPropertyChanged("Labels");
            }
        }

        private RelayCommand _reportCommand;

        public RelayCommand ReportCommand
        {
            get
            {
                return _reportCommand ??
                    (_reportCommand = new RelayCommand(obj => 
                    {
                        try
                        {
                            _report.Report(AppConstants.UserFilePath + "\\report.docx");
                        }
                        catch (Exception ex)
                        {
                            _dialogService.ShowError(ex.Message);
                        }
                    }));
            }
        }

        public GraphicViewModel(IDialogService dialogService, IOgeReport report)
        {
            _dialogService = dialogService;
            _report = report;

            for (int i = 0; i < _report.PercentDict.Count; i++)
            {
                Values[i] = _report.PercentDict[i];
            }

            GetData();
        }

        public void GetData()
        {
            NumberOfParticipants = _report.NumberOfParticipants.ToString();
            AveragePoint         = _report.GPA.ToString();
            MaxPoint             = _report.Max.ToString();
            MinPoint             = _report.Min.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
