using Fixer_IO_Sharp;
using NUnit.Framework;
using System;
using System.Linq;

namespace IntegrationTests
{
    [TestFixture]
    public class FixerIOClientTests
    {
        [Test]
        public void GetLatest_WithDefaults_ReturnsRates()
        {
            var sut = new FixerIOClient();

            var result = sut.GetLatest();

            Assert.NotNull(result);
            Assert.NotNull(result.Rates);
            Assert.True(result.Rates.Any());
            Assert.False(string.IsNullOrWhiteSpace(result.Base));
            Assert.AreNotEqual(default(DateTime), result.Date);
        }

        [Test]
        public void GetLatest_WithDifferentBase_ReturnsRates()
        {
            var sut = new FixerIOClient()
            {
                BaseCurrency = "USD"
            };

            var result = sut.GetLatest();

            Assert.NotNull(result);
            Assert.NotNull(result.Rates);
            Assert.True(result.Rates.Any());
            Assert.False(string.IsNullOrWhiteSpace(result.Base));
            Assert.AreNotEqual(default(DateTime), result.Date);
            Assert.AreEqual(result.Base, "USD");
        }

        [Test]
        public void GetLatest_WithSymbolsSet_ReturnsRatesOnlyForThoseSymbols()
        {
            var sut = new FixerIOClient()
            {
                Symbols = new[] { "ZAR", "USD" }
            };

            var result = sut.GetLatest();

            Assert.True(result.Rates.Any(r => r.Key != "ZAR" && r.Key != "ZAR"));
        }

        [Test]
        public void GetCurrenciesForDate_WithDefaults_ReturnsRates()
        {
            var sut = new FixerIOClient();

            var result = sut.GetCurrenciesForDate(new DateTime(2010, 01, 01));

            Assert.NotNull(result);
            Assert.NotNull(result.Rates);
            Assert.True(result.Rates.Any());
            Assert.False(string.IsNullOrWhiteSpace(result.Base));
            Assert.AreNotEqual(default(DateTime), result.Date);
        }

        [Test]
        public void GetCurrenciesForDate_WithSymbolsSet_ReturnsRatesOnlyForThoseSymbols()
        {
            var sut = new FixerIOClient()
            {
                Symbols = new[] { "ZAR", "USD" }
            };

            var result = sut.GetCurrenciesForDate(new DateTime(2010, 01, 01));

            Assert.True(result.Rates.Any(r => r.Key != "ZAR" && r.Key != "ZAR"));
        }

        [Test]
        public void GetCurrenciesForDate_WithDifferentBaseSet_ReturnsRatesOnlyForThoseSymbols()
        {
            var sut = new FixerIOClient()
            {
                BaseCurrency = "USD"
            };

            var result = sut.GetCurrenciesForDate(new DateTime(2010, 01, 01));

            Assert.NotNull(result);
            Assert.NotNull(result.Rates);
            Assert.True(result.Rates.Any());
            Assert.False(string.IsNullOrWhiteSpace(result.Base));
            Assert.AreNotEqual(default(DateTime), result.Date);
            Assert.AreEqual(result.Base, "USD");
        }
    }
}