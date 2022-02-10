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

        private readonly char semicolon = (char)59;

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
                foreach (DataColumn item in table.Columns)
                {
                    _headers += item.ColumnName + semicolon;
                }

                if (!File.Exists(fileName))
                    File.WriteAllText(fileName, _headers);

                foreach (DataRow row in table.Rows)
                {
                    string _row = "\n";

                    foreach (var _word in row.ItemArray)
                    {
                        _row += Convert.ToString(_word) + semicolon;
                    }

                    File.AppendAllText(fileName, _row);
                }
            });
        }

        #endregion
    }
}
