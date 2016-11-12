using CurrencySharp;
using System;

namespace Fixer_IO_Sharp
{
    public interface IFixerIOClient
    {
        string BaseCurrency { get; set; }
        string[] Symbols { get; set; }

        CurrencyResult GetRatesForDate(DateTime date);

        CurrencyResult GetLatest();
    }
}