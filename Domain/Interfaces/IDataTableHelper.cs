using System.Collections.Generic;
using System.Data;


namespace Domain.Interfaces
{
    public interface IDataTableHelper
    {
        DataTable CreateNewDataTable(Dictionary<int, string> dictionary, string tableName);
    }
}
