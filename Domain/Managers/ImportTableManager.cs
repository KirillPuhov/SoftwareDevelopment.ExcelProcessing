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

        public DataTableCollection Import(string filePath)
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
        private DataTableCollection TryImportTable(string path)
        {
            DataSet _result = null;

            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    _result = reader.AsDataSet(new ExcelDataSetConfiguration
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
            foreach (DataTable table in _clone.Tables)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    if (table.Columns[i].DataType == typeof(int) || table.Columns[i].DataType == typeof(double))
                        continue;

                    if (table.Columns[i].DataType != typeof(string))
                        table.Columns[i].DataType = typeof(string);
                }
            }

            foreach (DataTable table in origDataSet.Tables)
            {
                var _targetTable = _clone.Tables[table.TableName];
                foreach (DataRow _row in table.Rows)
                {
                    _targetTable.ImportRow(_row);
                }
            }

            return _clone;
        }
        #endregion
    }
}
