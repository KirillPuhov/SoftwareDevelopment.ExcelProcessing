using System.Data;

namespace Domain.Interfaces
{
    public interface IExcelManager
    {
        DataTable Import(string path);
        bool Export(DataTable table, string fileName);
    }
}
