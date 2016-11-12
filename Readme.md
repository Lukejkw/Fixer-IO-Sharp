#Fixer-IO-Sharp

[![Build status](https://ci.appveyor.com/api/projects/status/c3d877jpnadweg1f?svg=true)](https://ci.appveyor.com/project/Lukejkw/fixer-io-sharp)

Fixer-IO-Sharp is a simple library that allows you to get currency information.

The library is powered by [fixer.io](http://fixer.io/) and currencies are pulled from the [European Central Bank](http://www.ecb.europa.eu/stats/exchange/eurofxref/html/index.en.html)

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

var result = client.GetLatest();
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

Blog at [lukewarrendev.co.za](http://lukewarrendev.co.za)

Twitter: [@lukejkwarren](https://twitter.com/@lukejkwarren)