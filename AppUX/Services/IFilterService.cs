namespace AppUX.Services
{
    public interface IFilterService
    {
        string GetFilter(string column, string value);

        string GetSorting(string value, int mode);
    }
}
