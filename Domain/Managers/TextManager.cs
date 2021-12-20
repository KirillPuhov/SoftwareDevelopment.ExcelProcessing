using Domain.Interfaces;
using System;
using System.Data;
using System.IO;

namespace Domain.Managers
{
    public class TextManager : IExportTable
    {
        #region Fields

        private char space = (char)32;

        #endregion

        #region Export methods

        public bool Export(DataTable table, string fileName)
        {
            try
            {
                return TryExportTable(table, fileName);
            }
            catch (Exception ex)
            {
                throw new Exception("ExportOfText: " + ex);
            }
        }

        private bool TryExportTable(DataTable table, string fileName)
        {
            string _headers = null;

            foreach (DataColumn item in table.Columns)
            {
                _headers += item.ColumnName + space;
            }

            if (!File.Exists(fileName))
                File.WriteAllText(fileName, _headers);

            foreach (DataRow row in table.Rows)
            {
                string _row = "\n";

                foreach (var _word in row.ItemArray)
                {
                    _row += Convert.ToString(_word) + space;
                }

                File.AppendAllText(fileName, _row);
            }

            return true;
        }

        #endregion
    }
}
