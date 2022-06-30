using Domain.Interfaces;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace Domain.Managers
{
    public class TextManager : IExportTable
    {
        #region Fields

        private readonly char _semicolon = (char)59;

        #endregion

        #region Export methods

        public bool Export(DataTable table, string fileName)
        {
            try
            {
                TryExportTable(table, fileName);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ExportOfText: " + ex);
            }
        }

        private async void TryExportTable(DataTable table, string fileName)
        {
            string _headers = null;

            await Task.Run(() => 
            {
                foreach (DataColumn _item in table.Columns)
                {
                    _headers += _item.ColumnName + _semicolon;
                }

                if (!File.Exists(fileName))
                    File.WriteAllText(fileName, _headers);

                foreach (DataRow _row in table.Rows)
                {
                    string _rows = "\n";

                    foreach (var _word in _row.ItemArray)
                    {
                        _rows += Convert.ToString(_word) + _semicolon;
                    }

                    File.AppendAllText(fileName, _rows);
                }
            });
        }

        #endregion
    }
}
