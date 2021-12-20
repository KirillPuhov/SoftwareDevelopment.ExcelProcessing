using Domain.Interfaces;
using OfficeOpenXml;
using System;
using System.Data;
using System.IO;

namespace Domain.Managers
{
    public class ExcelManager : IExportTable
    {
        #region Export methods

        public bool Export(DataTable table, string filePath)
        {
            try
            {
                return TryExport(table, filePath);   
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("ExportToExcel: " + ex.Message);
            }
        }

        private bool TryExport(DataTable table, string filePath)
        {
            FileInfo newFile = new FileInfo(filePath);
            using (ExcelPackage pck = new ExcelPackage(newFile))
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("DataTable");
                ws.Cells["A1"].LoadFromDataTable(table, true);

                if (ws is null)
                    return false;
                else
                    pck.Save(); 
            }
            return true;
        }

        #endregion
    }
}
