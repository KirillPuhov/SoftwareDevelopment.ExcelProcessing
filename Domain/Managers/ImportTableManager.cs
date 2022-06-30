using Domain.Interfaces;
using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Windows;

namespace Domain.Managers
{
    public class ImportTableManager : IImportTable
    {
        #region Fields

        private DataTableCollection _tableCollection = null;

        #endregion

        #region Import methods

        public DataTableCollection Import(string filePath)
        {
            var _path = string.IsNullOrWhiteSpace(filePath) ? throw new Exception("ImportOfExcel: Null or empty file path!\n") : filePath;

            try
            {
                return TryImportTable(_path);
            }
            catch (IOException io)
            {
                MessageBox.Show(io.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
        private DataTableCollection TryImportTable(string path)
        {
            DataSet _result = null;

            using (var _stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var _reader = ExcelReaderFactory.CreateReader(_stream))
                {
                    _result = _reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        UseColumnDataType = true,
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                }
            }

            var _dataSet = DataTypeConvert(_result);
            _tableCollection = _dataSet.Tables;

            return _tableCollection;
        }

        private DataSet DataTypeConvert(DataSet origDataSet)
        {
            var _clone = origDataSet.Clone();
            foreach (DataTable _table in _clone.Tables)
            {
                for (int i = 0; i < _table.Columns.Count; i++)
                {
                    if (_table.Columns[i].DataType == typeof(int) || _table.Columns[i].DataType == typeof(double))
                        continue;

                    if (_table.Columns[i].DataType != typeof(string))
                        _table.Columns[i].DataType = typeof(string);
                }
            }

            foreach (DataTable _table in origDataSet.Tables)
            {
                var _targetTable = _clone.Tables[_table.TableName];
                foreach (DataRow _row in _table.Rows)
                {
                    _targetTable.ImportRow(_row);
                }
            }

            return _clone;
        }
        #endregion
    }
}
