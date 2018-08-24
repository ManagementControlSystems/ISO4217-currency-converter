# ISO4217-currency-converter
This project was created to handle converting between the 3 character code for currencies and the 3 digit codes as defined by the ISO 4217 standard.
It uses an xml file from https://www.iso.org/iso-4217-currency-codes.html as the source of the currency mappings.
LoadCurrencies should be called once with the path to the file and the instance of the converter can be called continuously using the in memory list.

Usage:
```
  var path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/list_one.xml");
  var converter = new ISO4217CurrencyConverter();
  converter.LoadCurrencies(path);
  var currencyCode = "USD";

  var numericCode = converter.Convert3CharCodeToNumeric(currencyCode);
  
  var numeric = 840;
  var characterCode = converter.ConvertNumericTo3CharCode(numeric);
  
```
