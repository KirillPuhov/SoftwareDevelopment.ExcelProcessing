using Domain.Interfaces;
using ExcelDataReader;
using OfficeOpenXml;
using System;
using System.Data;
using System.IO;

namespace Domain.Managers
{
    public class ExcelManager : IExcelManager
    {
        #region Import excel tables
        private DataTableCollection _tableCollection = null;

        public DataTable Import(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new Exception("ImportOfExcel: Null or empty file path!\n");
            }

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
                    {
                        break;
                    }
                    else if (_column.DataType == typeof(DateTime))
                    {
                        break;
                    }   
                    else if(_column.DataType != typeof(string))
                    {
                        _column.DataType = typeof(string);
                    }
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

        #region Export tables to Excel
        public bool Export(DataTable table, string filePath)
        {
            try
            {
                return TryExport(table, filePath);   
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: " + ex);
            }
        }

        private bool TryExport(DataTable table, string filePath)
        {
            try
            {
                FileInfo newFile = new FileInfo(filePath);
                using (ExcelPackage pck = new ExcelPackage(newFile))
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Accounts");
                    ws.Cells["A1"].LoadFromDataTable(table, true);
                    pck.Save();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("ExportToExcel: " + ex.Message);
            }
        }
        #endregion
    }
}
