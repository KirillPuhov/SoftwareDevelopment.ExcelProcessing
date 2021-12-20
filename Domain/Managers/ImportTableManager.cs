using Domain.Interfaces;
using ExcelDataReader;
using System;
using System.Data;
using System.IO;

namespace Domain.Managers
{
    public class ImportTableManager : IImportTable
    {
        #region Fields

        private DataTableCollection _tableCollection = null;

        #endregion

        #region Import methods

        public DataTable Import(string filePath)
        {
            var path = string.IsNullOrWhiteSpace(filePath) ? throw new Exception("ImportOfExcel: Null or empty file path!\n") : filePath;

            try
            {
                return TryImportTable(path);
            }
            catch (Exception ex)
            {
                throw new Exception("ImportOfExcel: " + ex);
            }
        }

        private DataTable TryImportTable(string path)
        {
            var _table = new DataTable();
            FileStream _stream = File.Open(path, FileMode.Open, FileAccess.Read);

            IExcelDataReader _reader = ExcelReaderFactory.CreateReader(_stream);

            DataSet _db = _reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (x) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });

            var _result = ConvertToDataSetOfStrings(_db);
            _tableCollection = _result.Tables;

            foreach (DataTable _data in _tableCollection)
            {
                _table = _data;
            }
            return _table;
        }

        private DataSet ConvertToDataSetOfStrings(DataSet _sourceDataSet)
        {
            var _result = _sourceDataSet.Clone();
            foreach (DataTable _table in _result.Tables)
            {
                foreach (DataColumn _column in _table.Columns)
                {
                    if (_column.DataType == typeof(int) || _column.DataType == typeof(double))
                        break;

                    if (_column.DataType == typeof(DateTime))
                        break;

                    if (_column.DataType != typeof(string))
                        _column.DataType = typeof(string);
                }
            }

            foreach (DataTable _table in _sourceDataSet.Tables)
            {
                var _targetTable = _result.Tables[_table.TableName];
                foreach (DataRow _row in _table.Rows)
                {
                    _targetTable.ImportRow(_row);
                }
            }
            return _result;
        }
        #endregion
    }
}
