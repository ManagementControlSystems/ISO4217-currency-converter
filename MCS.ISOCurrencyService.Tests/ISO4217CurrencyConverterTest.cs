using System;
using Xunit;

namespace MCS.ISOCurrencyService.Tests
{
    public class ISO4217CurrencyConverterTest
    {
        private readonly string _path = @"C:\Users\atulloch.MCSYSTEMS\source\repos\MCS.ISOCurrency\MCS.ISOCurrencyService.Tests\Data\iso_4217.xml";
        [Fact]
        public void LoadCurrencies_Test()
        {
            //arrange
            var sut = new ISO4217CurrencyConverter();

            //act
            sut.LoadCurrencies(_path);

            //assert
            Assert.NotNull(sut.Currencies);
            Assert.NotNull(sut.Currencies.CcyTbl);
            Assert.NotNull(sut.Currencies.CcyTbl.CcyNtry);
            Assert.True(sut.Currencies.CcyTbl.CcyNtry.Count > 0);
        }

        [Fact]
        public void Convert3CharCodeToNumeric_Test()
        {
            //arrange
            var sut = new ISO4217CurrencyConverter();
            sut.LoadCurrencies(_path);
            var currencyCode = "USD";
            var expected = "840";

            //act
            var actual = sut.Convert3CharCodeToNumeric(currencyCode);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertNumericTo3CharCode_Test()
        {
            //arrange
            var sut = new ISO4217CurrencyConverter();
            sut.LoadCurrencies(_path);
            var numeric = "388";
            var expected = "JMD";

            //act
            var actual = sut.ConvertNumericTo3CharCode(numeric);

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
