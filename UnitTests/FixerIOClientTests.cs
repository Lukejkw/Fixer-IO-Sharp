using Fixer_IO_Sharp;
using NUnit.Framework;
using System;

namespace UnitTests
{
    [TestFixture]
    public class FixerIOClientTests
    {
        [Test]
        public void Ctor_CanCreateClient()
        {
            Assert.DoesNotThrow(() => new FixerIOClient());
        }

        [Test]
        public void BaseCurrency_WithNoneSet_ReturnsValidDefault()
        {
            var sut = new FixerIOClient();

            Assert.AreEqual(3, sut.BaseCurrency.Length);
        }

        [Test]
        public void SetBaseCurrency_WithValidCurrencyCode_SetsBaseCurrency()
        {
            var sut = new FixerIOClient();

            sut.BaseCurrency = "ZAR";

            Assert.AreEqual("ZAR", sut.BaseCurrency);
        }

        [Test]
        public void SetBaseCurrency_WithInvalidCurrencyCode_ThrowsNotSupportedException()
        {
            var sut = new FixerIOClient();

            Assert.Throws<ArgumentNullException>(() => sut.BaseCurrency = null);
            Assert.Throws<ArgumentNullException>(() => sut.BaseCurrency = string.Empty);
            Assert.Throws<ArgumentNullException>(() => sut.BaseCurrency = "   ");
            Assert.Throws<NotSupportedException>(() => sut.BaseCurrency = "ZARR");
            Assert.Throws<NotSupportedException>(() => sut.BaseCurrency = "ZA");
            Assert.Throws<NotSupportedException>(() => sut.BaseCurrency = "ZA1");
            Assert.Throws<NotSupportedException>(() => sut.BaseCurrency = "ZA!");
        }

        [Test]
        public void GetSymbols_WithNoneSet_ReturnsNull()
        {
            var sut = new FixerIOClient();

            Assert.AreEqual(null, sut.Symbols);
        }

        [Test]
        public void SetSymbols_WithValidSymbols_ReturnsSymbols()
        {
            var sut = new FixerIOClient();

            sut.Symbols = new[] { "ZAR", "USD" };

            Assert.AreEqual(new[] { "ZAR", "USD" }, sut.Symbols);
        }

        [Test]
        public void SetSymbols_WithInvalidSymbols_ThrowsNotSupportedException()
        {
            var sut = new FixerIOClient();

            Assert.Throws<ArgumentNullException>(() => sut.Symbols = new string[] { null });
            Assert.Throws<ArgumentNullException>(() => sut.Symbols = new[] { string.Empty });
            Assert.Throws<ArgumentNullException>(() => sut.Symbols = new[] { "   " });
            Assert.Throws<NotSupportedException>(() => sut.Symbols = new[] { "ZARR" });
            Assert.Throws<NotSupportedException>(() => sut.Symbols = new[] { "ZA" });
            Assert.Throws<NotSupportedException>(() => sut.Symbols = new[] { "ZA1" });
            Assert.Throws<NotSupportedException>(() => sut.Symbols = new[] { "ZA!" });
        }
    }
}