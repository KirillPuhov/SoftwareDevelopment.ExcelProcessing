using System.Data;

namespace Domain.Interfaces
{
    public interface IExportTable
    {
        bool Export(DataTable table, string fileName);
    }
}
