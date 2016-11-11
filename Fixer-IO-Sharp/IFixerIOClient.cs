using CurrencySharp;

namespace Fixer_IO_Sharp
{
    public interface IFixerIOClient
    {
        string BaseCurrency { get; set; }
        string[] Symbols { get; set; }

        CurrencyResult GetCurrenciesForDate(int year, int month, int day);
        CurrencyResult GetLatest();
    }
}