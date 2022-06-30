using AppUX.Constants;

namespace AppUX.Services
{
    public class FilterService : IFilterService
    {
        public string GetFilter(string column, string value)
        {
            string _format = null;
            if (int.TryParse(value, out int i))
            {
                _format = string.IsNullOrWhiteSpace(value)
                          || string.IsNullOrWhiteSpace(column) ? string.Empty : string.Format("[{0}] = '{1}'", column, value);
            }
            else if (double.TryParse(value, out double d))
            {
                _format = string.IsNullOrWhiteSpace(value)
                          || string.IsNullOrWhiteSpace(column) ? string.Empty : string.Format("[{0}] = '{1}'", column, value);
            }
            else
            {
                _format = string.IsNullOrWhiteSpace(value)
                          || string.IsNullOrWhiteSpace(column) ? string.Empty : string.Format("[{0}] LIKE '%{1}%'", column, value);
            }

            return _format;
        }

        public string GetSorting(string value, int mode)
        {
            string _sorting = null;
            switch (mode)
            {
                case 0:
                    _sorting = string.Format("{0} {1}", value, AppConstants.Ascending);
                    break;
                case 1:
                    _sorting = string.Format("{0} {1}", value, AppConstants.Descending);
                    break;
            }
            return _sorting;
        }
    }
}
