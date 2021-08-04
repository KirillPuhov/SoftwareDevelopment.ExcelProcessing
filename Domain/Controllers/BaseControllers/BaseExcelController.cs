using Domain.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace Domain.Controllers.BaseControllers
{
    public abstract class BaseExcelController
    {
        private IExcelManager _manager;
        private IDataTableHelper _helper;

        public BaseExcelController(IExcelManager manager, IDataTableHelper helper)
        {
            _manager = manager;
            _helper = helper;
        }

        public DataTable GetTable(string _path) 
        {
            return _manager.Import(_path);
        }

        public bool SetTable(DataTable _table, string _fileName)
        {
            return _manager.Export(_table, _fileName);
        }

        public DataTable TableCreate(Dictionary<int, string> dictionary, string tableName)
        {
            return _helper.CreateNewDataTable(dictionary, tableName);
        }
    }
}
