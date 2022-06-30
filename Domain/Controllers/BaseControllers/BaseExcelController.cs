using Domain.Interfaces;
using System.Data;

namespace Domain.Controllers.BaseControllers
{
    public abstract class BaseExcelController
    {
        private IImportTable _importer;

        public BaseExcelController(IImportTable importer)
        {
            _importer = importer;
        }

        public DataTableCollection GetTable(string path) 
        {
            return _importer.Import(path);
        }
    }
}
