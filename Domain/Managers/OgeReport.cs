using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace Domain.Managers
{
    public class OgeReport : IOgeReport
    {
        #region Fields

        private static List<OgeReportsModel> _models;

        #endregion

        #region Properties

        private Dictionary<int, double> _numberOfPointsDict;
        public Dictionary<int, double> NumberOfPointsDict
        {
            get { return _numberOfPointsDict; }
            set { _numberOfPointsDict = value; }
        }


        private Dictionary<int, double> _percentDict;
        public Dictionary<int, double> PercentDict
        {
            get { return _percentDict; }
            set { value = _percentDict; }
        }


        private Dictionary<int, double> _marksDict;
        public Dictionary<int, double> MarksDict
        {
            get { return _marksDict; }
            set { _marksDict = value; }
        }


        private double _gpa = 0;
        public double GPA
        {
            get { return _gpa; }
            set { _gpa = value; }
        }


        private int _numberOfParticipants = 0;
        public int NumberOfParticipants
        {
            get { return _numberOfParticipants; }
            set { _numberOfParticipants = value; }
        }


        private int _max = 0;
        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }


        private int _min = 0;
        public int Min
        {
            get { return _min; }
            set { _min = value; }
        }

        #endregion

        #region ctor

        public OgeReport(List<OgeReportsModel> models)
        {
            _numberOfPointsDict = new Dictionary<int, double>();
            _percentDict = new Dictionary<int,double>();
            _marksDict = new Dictionary<int, double>();
            if (models != null)
                _models = models;

            GetStatistics();
        }

        #endregion

        #region Report generation

        public bool Report(string fileName)
        {
            TryToReport(fileName);

            return true;
        }

        private void TryToReport(string fileName)
        {
            DocX _document = DocX.Create(fileName);
            _document.InsertParagraph("Отчёт по Экзамену").FontSize(36).Bold().Alignment = Alignment.center;
            _document.InsertParagraph("Средний балл по классам").FontSize(12).Alignment = Alignment.left;

            Table _wordtable = _document.AddTable(2, 3);
            _wordtable.Alignment = Alignment.center;
            _wordtable.Design = TableDesign.TableGrid;

            _wordtable.Rows[0].Cells[0].Paragraphs[0].Append("9А").FontSize(16).Alignment = Alignment.center;
            _wordtable.Rows[0].Cells[1].Paragraphs[0].Append("9Б").FontSize(16).Alignment = Alignment.center;
            _wordtable.Rows[0].Cells[2].Paragraphs[0].Append("9В").FontSize(16).Alignment = Alignment.center;

            for (int i = 0; i < 3; i++)
            {
                _wordtable.Rows[1].Cells[i].Paragraphs[0].Append(_numberOfPointsDict[i].ToString()).FontSize(16).Alignment = Alignment.center;
            }

            _document.InsertParagraph().InsertTableAfterSelf(_wordtable);
            
            _document.InsertParagraph("");
            _document.InsertParagraph("Количество участников: " + _numberOfParticipants).FontSize(12).Alignment = Alignment.left;
            _document.InsertParagraph("Средний балл: " + _gpa).FontSize(12).Alignment = Alignment.left;
            _document.InsertParagraph("Максимальный балл: " + _max).FontSize(12).Alignment = Alignment.left;
            _document.InsertParagraph("Минимальный балл: " + _min).FontSize(12).Alignment = Alignment.left;

            _wordtable = _document.AddTable(2, 4);
            _wordtable.Alignment = Alignment.center;
            _wordtable.Design = TableDesign.TableGrid;

            _wordtable.Rows[0].Cells[0].Paragraphs[0].Append("\"2\"").FontSize(16).Alignment = Alignment.center;
            _wordtable.Rows[0].Cells[1].Paragraphs[0].Append("\"3\"").FontSize(16).Alignment = Alignment.center;
            _wordtable.Rows[0].Cells[2].Paragraphs[0].Append("\"4\"").FontSize(16).Alignment = Alignment.center;
            _wordtable.Rows[0].Cells[3].Paragraphs[0].Append("\"5\"").FontSize(16).Alignment = Alignment.center;

            for (int i = 0; i < 4; i++)
            {
                _wordtable.Rows[1].Cells[i].Paragraphs[0].Append(_marksDict[i].ToString() + "чел.").FontSize(16).Alignment = Alignment.center;
            }

            _document.InsertParagraph().InsertTableAfterSelf(_wordtable);

            var _image = _document.AddImage(@"./graphs/graph.png");
            var _picture = _image.CreatePicture(250f, 450f);
            var _p = _document.InsertParagraph("");
            _p.AppendPicture(_picture).Alignment = Alignment.center;

            _document.Save();
        }

        #endregion

        #region Get Statistics

        private void GetStatistics()
        {
            double _avgPoints = 0;

            int _maxPoint = -1;
            int _minPoint = 101;

            double _FCpoitns = 0;
            int _countFC = 0;

            double _SCpoitns = 0;
            int _countSC = 0;

            double _TCpoitns = 0; 
            int _countTC = 0;

            double _numberОfDeuces = 0;
            double _numberОfTriplets = 0;
            double _numberОfFours = 0;
            double _numberОfFives = 0;


            for (int i = 0; i < _models.Count; i++)
            {
                _avgPoints += _models[i].Points;
                _maxPoint = Math.Max(_maxPoint, _models[i].Points);
                _minPoint = Math.Min(_minPoint, _models[i].Points);

                if (_models[i].ClassName.Equals("9А"))
                {
                    _FCpoitns += _models[i].Points;
                    _countFC++;
                }


                if (_models[i].ClassName.Equals("9Б"))
                {
                    _SCpoitns += _models[i].Points;
                    _countSC++;
                }


                if (_models[i].ClassName.Equals("9В"))
                {
                    _TCpoitns += _models[i].Points;
                    _countTC++;
                }


                if ((_models[i].Points >= 0) && (_models[i].Points <= 20))
                    _numberОfDeuces++;

                if ((_models[i].Points >= 21) && (_models[i].Points <= 40))
                    _numberОfTriplets++;

                if ((_models[i].Points >= 41) && (_models[i].Points <= 70))
                    _numberОfFours++;

                if ((_models[i].Points >= 71) && (_models[i].Points <= 100))
                    _numberОfFives++;
            }

            _numberOfParticipants = _models.Count;
            _gpa = Math.Round(_avgPoints / _numberOfParticipants);
            _max = _maxPoint;
            _min = _minPoint;

            _marksDict.Add(0, _numberОfDeuces);
            _marksDict.Add(1, _numberОfTriplets);
            _marksDict.Add(2, _numberОfFours);
            _marksDict.Add(3, _numberОfFives);

            _percentDict.Add(0, Math.Round((_numberОfDeuces / _numberOfParticipants) * 100, 2));
            _percentDict.Add(1, Math.Round((_numberОfTriplets / _numberOfParticipants) * 100, 2));
            _percentDict.Add(2, Math.Round((_numberОfFours / _numberOfParticipants) * 100, 2));
            _percentDict.Add(3, Math.Round((_numberОfFives / _numberOfParticipants) * 100, 2));

            _numberOfPointsDict.Add(0, Math.Round(_FCpoitns /_countFC));
            _numberOfPointsDict.Add(1, Math.Round(_SCpoitns / _countSC));
            _numberOfPointsDict.Add(2, Math.Round(_TCpoitns / _countTC));
        }

        #endregion

    }
}
