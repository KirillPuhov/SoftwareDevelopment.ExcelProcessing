using Domain.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace Domain.Managers
{
    public class DataTableHelper : IDataTableHelper
    {
        public DataTable CreateNewDataTable(Dictionary<int, string> dictionary, string tableName)
        {
            DataTable _newTable = new DataTable(tableName);
            foreach (var item in dictionary)
            {
                _newTable.Columns.Add(item.Value, typeof(string));
            }

            return _newTable;
        }
    }
}
