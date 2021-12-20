using Domain.Interfaces;
using System.Data;

namespace Domain.Controllers.BaseControllers
{
    public abstract class BaseExportController
    {
        private IExportTable _manager;

        public BaseExportController(IExportTable manager)
        {
            _manager = manager;
        }

        public bool SetTable(DataTable _table, string _fileName)
        {
            return _manager.Export(_table, _fileName);
        }
    }
}
