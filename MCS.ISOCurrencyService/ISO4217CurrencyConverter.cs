using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MCS.ISOCurrencyService
{
    public class ISO4217CurrencyConverter : IISO4217CurrencyConverter
    {
        private static ISO_4217 _loadedCurrencies;
        private readonly string _initializationError = "LoadCurrencies should be called with the path to the source xml file prior to conversion";

        public ISO_4217 Currencies {
            get { return _loadedCurrencies; }
        }

        // Summary
        // The path of the xml file with currencies.
        // The default xml file can be updated from
        // https://www.currency-iso.org/en/home/tables/table-a1.html
        public void LoadCurrencies(string path)
        {
            if (_loadedCurrencies != null)
                return;

            var xml = File.ReadAllText(path);
            var serializer = new XmlSerializer(typeof(ISO_4217));
            using (StringReader sr = new StringReader(xml))
                _loadedCurrencies = (ISO_4217)serializer.Deserialize(sr);
        }

        public string Convert3CharCodeToNumeric(string currencyCode)
        {
            if (string.IsNullOrWhiteSpace(currencyCode))
                throw new ArgumentException($"{nameof(currencyCode)} is required.");
            if (_loadedCurrencies == null)
                throw new CurrencyServiceException(_initializationError);

            var currency = _loadedCurrencies.CcyTbl.CcyNtry.FirstOrDefault(c => c.Ccy == currencyCode);
            if (currency == null)
                throw new CurrencyServiceException($"Currency code: {currencyCode} does not exist.");

            return currency.CcyNbr;
        }

        public string ConvertNumericTo3CharCode(string numeric)
        {
            if (string.IsNullOrWhiteSpace(numeric))
                throw new ArgumentException($"{nameof(numeric)} is required.");
            if (_loadedCurrencies == null)
                throw new CurrencyServiceException(_initializationError);

            var currency = _loadedCurrencies.CcyTbl.CcyNtry.FirstOrDefault(c => c.CcyNbr == numeric);
            if (currency == null)
                throw new CurrencyServiceException($"Currency code: {numeric} does not exist.");

            return currency.Ccy;
        }
    }

    public class CurrencyServiceException : ApplicationException
    {
        public CurrencyServiceException(string message) : base(message) { }
    }
}
