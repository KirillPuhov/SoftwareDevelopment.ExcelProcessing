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

        public bool SetTable(DataTable table, string fileName)
        {
            return _manager.Export(table, fileName);
        }
    }
}
