using System;
using System.Collections.Generic;

namespace CurrencySharp
{
    public class CurrencyResult
    {
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
    }
}