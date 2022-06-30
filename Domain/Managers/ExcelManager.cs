using Domain.Interfaces;
using OfficeOpenXml;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace Domain.Managers
{
    public class ExcelManager : IExportTable
    {
        #region Export methods

        public bool Export(DataTable table, string filePath)
        {
            try
            {
                TryExport(table, filePath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("ExportToExcel: " + ex.Message);
            }
        }

        private async void TryExport(DataTable table, string filePath)
        {
            var _newFile = new FileInfo(filePath);

            await Task.Run(() => 
            {
                using (ExcelPackage _package = new ExcelPackage(_newFile))
                {
                    ExcelWorksheet _worksSheet = _package.Workbook.Worksheets.Add("DataTable");
                    _worksSheet.Cells["A1"].LoadFromDataTable(table, true);

                    if (_worksSheet is null)
                        throw new ArgumentNullException("ws was null");
                    else
                        _package.Save();
                }
            });
        }

        #endregion
    }
}
