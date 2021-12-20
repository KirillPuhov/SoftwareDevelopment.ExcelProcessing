using Domain.Controllers.BaseControllers;
using Domain.Interfaces;

namespace Domain.Controllers
{
    public sealed class ExportController : BaseExportController
    {
        public ExportController(IExportTable manager) : base(manager) { }
    }
}
