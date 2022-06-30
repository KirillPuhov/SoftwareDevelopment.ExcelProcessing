using System.Collections.Generic;

namespace AppUX.Services
{
    public interface IValidationService
    {
        bool IsValid<T>(T obj) where T : List<string>;

        char[] NotAllowedSymbols { get; set; }

        List<string> Edit<T>(T obj) where T : List<string>;

        bool TryConvertToReportModel(List<string> obj);
    }
}
