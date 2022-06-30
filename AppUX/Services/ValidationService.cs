using System.Collections.Generic;
using System.Linq;

namespace AppUX.Services
{
    public class ValidationService : IValidationService
    {
        //Default not allowed symbols
        private char[] _notAllowedSymbols = { '!', '#', '$', '%', '&', '(', ')', '*', ',', '+', '-' };

        public char[] NotAllowedSymbols
        {
            get { return _notAllowedSymbols; }
            set { _notAllowedSymbols = value; }
        }

        public List<string> Edit<T>(T obj) where T : List<string>
        {
            var _list = obj as List<string>;
            if (_list.Count != 0)
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    for (int j = 0; j < _notAllowedSymbols.Length; j++)
                    {
                        _list[i] = _list[i].Replace(_notAllowedSymbols[j], '\0');
                    }
                }
            }
            return _list;
        }

        public bool IsValid<T>(T obj) where T : List<string>
        {
            var _list = obj as List<string>;
            if (_list.Count != 0)
            {
                foreach (var _item in _list)
                {
                    if (_item.Any(c => _notAllowedSymbols.Contains(c)))
                        return false;
                }
            }
            return true;
        }

        public bool TryConvertToReportModel(List<string> obj)
        {
            if (TryIntParse(obj[0]))
            {
                if (TryIntParse(obj[3]))
                {
                    if (TryIntParse(obj[4]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool TryIntParse(string value)
        {
            if (int.TryParse(value, out int output))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
