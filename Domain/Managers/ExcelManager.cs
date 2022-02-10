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
            FileInfo newFile = new FileInfo(filePath);

            await Task.Run(() => 
            {
                using (ExcelPackage pck = new ExcelPackage(newFile))
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("DataTable");
                    ws.Cells["A1"].LoadFromDataTable(table, true);

                    if (ws is null)
                        throw new ArgumentNullException("ws was null");
                    else
                        pck.Save();
                }
            });
        }

        #endregion
    }
}
