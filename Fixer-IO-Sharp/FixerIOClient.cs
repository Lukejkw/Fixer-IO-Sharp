using CurrencySharp;
using RestSharp;
using System;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Fixer_IO_Sharp
{
    public class FixerIOClient : IFixerIOClient
    {
        private readonly RestClient _client;
        private string _baseCurrency;
        private const string DefaultBaseCurrency = "EUR";
        private const string BaseUrl = "http://api.fixer.io";

        /// <summary>
        /// Set 3 letter base currency code. Default is EUR.
        /// </summary>
        public string BaseCurrency
        {
            get
            {
                if (string.IsNullOrEmpty(_baseCurrency))
                {
                    _baseCurrency = DefaultBaseCurrency;
                }
                return _baseCurrency;
            }
            set
            {
                if (value.Length > 3)
                {
                    throw new Exception("Invalid Currency Code");
                }
                _baseCurrency = value;
            }
        }

        /// <summary>
        /// The symbols you wish to restrict the result set to.
        /// </summary>
        public string[] Symbols { get; set; }

        public FixerIOClient()
        {
            _client = new RestClient(BaseUrl);
        }

        /// <summary>
        /// Gets the latest rates for the configured base currency
        /// </summary>
        /// <returns></returns>
        public CurrencyResult GetLatest()
        {
            var request = new RestRequest("latest", Method.GET);
            return Execute<CurrencyResult>(request);
        }

        /// <summary>
        /// Gets the currency for a given day in history. Only dates from 1999 are supported
        /// </summary>
        /// <param name="date">The date to get rates for</param>
        /// <returns></returns>
        public CurrencyResult GetCurrenciesForDate(DateTime date)
        {
            if (date < new DateTime(1999, 1, 1))
                throw new NotSupportedException("Only currency information from 1999 is available");

            var request = new RestRequest(date.ToString("yyyy-MM-dd"), Method.GET);
            return Execute<CurrencyResult>(request);
        }

        private T Execute<T>(IRestRequest request) where T : new()
        {
            request.AddQueryParameter("base", BaseCurrency);
            if (Symbols != null && Symbols.Any())
            {
                request.AddQueryParameter("symbols", string.Join(",", Symbols));
            }

            var response = _client.Execute<T>(request);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }
            throw new Exception("Could not get CurrencyResult for one or more reasons");
        }
    }
}