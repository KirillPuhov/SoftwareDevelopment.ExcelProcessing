using System;
using System.Data;
using System.Threading.Tasks;
using Domain.Interfaces;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace Domain.Managers
{
    public class WordManager : IExportTable
    {
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
                throw new Exception("ExportOfWord: " + ex);
            }
        }

        private async void TryExportTable(DataTable table, string fileName)
        {
            DocX _document = DocX.Create(fileName);

            Table _wordtable = _document.AddTable(table.Rows.Count + 1, table.Columns.Count);

            _wordtable.Alignment = Alignment.center;

            _wordtable.Design = TableDesign.TableGrid;

            _document.InsertParagraph(table.TableName).FontSize(36).Bold().Alignment = Alignment.center;

            bool _fillColumnName = false;

            await Task.Run(() => 
            {
                if (!_fillColumnName)
                {
                    for (int c = 0; c < table.Columns.Count; c++)
                    {
                        _wordtable.Rows[0].Cells[c].Paragraphs[0].Append(table.Columns[c].ColumnName).FontSize(10).Alignment = Alignment.center;
                    }
                    _fillColumnName = true;
                }

                for (int r = 1; r < _wordtable.Rows.Count; r++)
                {
                    for (int c = 0; c < table.Columns.Count; c++)
                    {
                        _wordtable.Rows[r].Cells[c].Paragraphs[0].Append(table.Rows[r - 1].ItemArray[c].ToString()).FontSize(10);
                    }
                }

                _document.InsertParagraph().InsertTableAfterSelf(_wordtable);

                _document.Save();
            });
        }

        #endregion
    }
}