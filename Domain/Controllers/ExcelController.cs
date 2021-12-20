using Domain.Controllers.BaseControllers;
using Domain.Interfaces;

namespace Domain.Controllers
{
    public sealed class ExcelController : BaseExcelController
    {
        public ExcelController(IImportTable importer) : base(importer) { }
    }
}
