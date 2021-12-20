using System;
using System.Data;
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
                return TryExportTable(table, fileName);
            }
            catch (Exception ex)
            {
                throw new Exception("ExportOfWord: " + ex);
            }
        }

        private bool TryExportTable(DataTable table, string fileName)
        {
            DocX document = DocX.Create(fileName);

            Table wordtable = document.AddTable(table.Rows.Count + 1, table.Columns.Count);

            wordtable.Alignment = Alignment.center;

            wordtable.Design = TableDesign.TableGrid;

            document.InsertParagraph(table.TableName).FontSize(36).Bold().Alignment = Alignment.center;

            bool fillColumnName = false;
            if (!fillColumnName)
            {
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    wordtable.Rows[0].Cells[c].Paragraphs[0].Append(table.Columns[c].ColumnName).FontSize(10).Alignment = Alignment.center;
                }
                fillColumnName = true;
            }

            for (int r = 1; r < wordtable.Rows.Count; r++)
            {
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    wordtable.Rows[r].Cells[c].Paragraphs[0].Append(table.Rows[r - 1].ItemArray[c].ToString()).FontSize(10);
                }
            }

            document.InsertParagraph().InsertTableAfterSelf(wordtable);

            document.Save();
            return true;
        }

        #endregion
    }
}