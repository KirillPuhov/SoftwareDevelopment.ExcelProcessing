using System.Data;

namespace Domain.Interfaces
{
    public interface IImportTable
    {
        DataTable Import(string path);
    }
}
