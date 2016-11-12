#Fixer-IO-Sharp

Fixer-IO-Sharp is a simple wrapper library that helps you get currency information for the Euro.

The library is powered by [http://fixer.io/](fixer.io) and currencies are pulled from [http://www.ecb.europa.eu/stats/exchange/eurofxref/html/index.en.html](European Central Bank)

I offer absolutely no warranty for the data return by the API as the data is not my own.

## How to Use the API

### Initialize Fixer IO Client

Using the defaults will use Euro as the base currency and will not filter rates

``` javascript

var client = new FixerIOClient();

```

To change the base currency or filter the symbols, just set the properties.

The below example will set the base currency to US Dollars and will only show rates for Euros and South African Rands

``` javascript

var client = new FixerIOClient()
{
    BaseCurrency = "USD",
    Symbols = new[]{ "EUR", "ZAR" }
};

```

### Get Latest Rates

``` javascript

var result = client.GetRatesForDate(new DateTime(2010, 01, 01));
result.Rates; // Rates (Dictionary<string, decimal>)

```

### Get Rates for a date in history (after 1999)

``` javascript

var result = client.GetRatesForDate(new DateTime(2010, 01, 01));
result.Rates; // Rates (Dictionary<string, decimal>)

```

## Contributions

Please feel free but first read the docs for the API [http://fixer.io/](fixer.io) and check Github issues.

## Contact Developer

Developed by Luke Warren

Blog at [http://lukewarrendev.co.za](lukewarrendev.co.za)

Twitter: [https://twitter.com/@lukejkwarren](@lukejkwarren)