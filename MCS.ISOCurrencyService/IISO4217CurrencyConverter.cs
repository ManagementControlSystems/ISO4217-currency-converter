using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.ISOCurrencyService
{
    public interface IISO4217CurrencyConverter
    {
        void LoadCurrencies(string path);
        string ConvertNumericTo3CharCode(string numeric);
        string Convert3CharCodeToNumeric(string currencyCode);
    }
}
