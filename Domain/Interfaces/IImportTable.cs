using System.Data;

namespace Domain.Interfaces
{
    public interface IImportTable
    {
        DataTableCollection Import(string path);
    }
}
