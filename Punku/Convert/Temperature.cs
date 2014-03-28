/**
 * Conversion functions for different units of temperature
 *
 * http://en.wikipedia.org/wiki/Temperature_conversion_formulas
 * http://en.wikipedia.org/wiki/Conversion_of_units#Temperature
 * http://en.wikipedia.org/wiki/Orders_of_magnitude_%28temperature%29
 *
 * @author Martin Lindhe, 2009-2014 <martin@ubique.se>
 */
using System;

namespace Punku.Convert
{
	public class Temperature
	{
		public static decimal CelciusToKelvin (decimal c)
		{
			return c + 273.15m;
		}

		public static decimal CelciusToFahrenheit (decimal c)
		{
			return (c * (9m / 5m)) + 32m;
		}

		public static decimal CelciusToRankine (decimal c)
		{
			return (c + 273.15m) * (9m / 5m);
		}

		public static decimal CelciusToDelisle (decimal c)
		{ 
			return  (100m - c) * (3m / 2m);
		}

		public static decimal CelciusToNewton (decimal c)
		{
			return c * (33m / 100m);
		}

		public static decimal CelciusToReaumur (decimal c)
		{
			return c * (4m / 5m);
		}

		public static decimal CelciusToRomer (decimal c)
		{
			return (c * (21m / 40m)) + 7.5m;
		}

		public static decimal KelvinToCelcius (decimal k)
		{
			return k - 273.15m;
		}

		public static decimal FahrenheitToCelcius (decimal f)
		{
			return (f - 32m) * (5m / 9m);
		}

		public static decimal RankineToCelcius (decimal r)
		{
			return (r - 491.67m) * (5m / 9m);
		}

		public static decimal DelisleToCelcius (decimal d)
		{
			return 100m - (d * (2m / 3m));
		}

		public static decimal NewtonToCelcius (decimal n)
		{
			return n * (100m / 33m);
		}

		public static decimal ReaumurToCelcius (decimal r)
		{
			return r * (5m / 4m);
		}

		public static decimal RomerToCelcius (decimal r)
		{
			return (r - 7.5m) * (40m / 21m);
		}

		public static decimal FormatToCelcius (string format, decimal value)
		{
			switch (format) {
			case "C":
			case "celcius":
			case "centigrade":
			case "centigrades":
				return value;

			case "F":
			case "fahrenheit":
				return Temperature.FahrenheitToCelcius (value);

			case "R":
			case "rankine":
				return Temperature.RankineToCelcius (value);

			case "D":
			case "delisle":
				return Temperature.DelisleToCelcius (value);

			case "N":
			case "newton":
				return Temperature.NewtonToCelcius (value);

			case "réaumur":
				return Temperature.ReaumurToCelcius (value);

			case "rømer":
				return Temperature.RomerToCelcius (value);

			case "K":
			case "kelvin":
				return Temperature.KelvinToCelcius (value);

			// 10^1 K
			case "daK":
			case "decakelvin":
				return Temperature.KelvinToCelcius (value * 10m);

			// 10^2 K
			case "hK":
			case "hectokelvin":
				return Temperature.KelvinToCelcius (value * 100m);

			// 10^3 K
			case "kK":
			case "kilokelvin":
				return Temperature.KelvinToCelcius (value * 1000m);

			// 10^6 K
			case "MK":
			case "megakelvin":
				return Temperature.KelvinToCelcius (value * 1000000m);

			// 10^9 K
			case "GK":
			case "gigakelvin":
				return Temperature.KelvinToCelcius (value * 1000000000m);

			// 10^12 K
			case "TK":
			case "terakelvin":
				return Temperature.KelvinToCelcius (value * 1000000000000m);

			// 10^15 K
			case "PK":
			case "petakelvin":
				return Temperature.KelvinToCelcius (value * 1000000000000000m);

			// 10^18 K
			case "EK":
			case "exakelvin":
				return Temperature.KelvinToCelcius (value * 1000000000000000000m);

			// 10^21 K
			case "ZK":
			case "zettakelvin":
				return Temperature.KelvinToCelcius (value * 1000000000000000000000m);

			// 10^24 K
			case "YK":
			case "yottakelvin":
				return Temperature.KelvinToCelcius (value * 1000000000000000000000000m);

			// 10−1 K
			case "dK":
			case "decikelvin":
				return Temperature.KelvinToCelcius (value / 10m);

			// 10−2 K
			case "cK":
			case "centikelvin":
				return Temperature.KelvinToCelcius (value / 100m);

			// 10−3 K
			case "mK":
			case "millikelvin":
				return Temperature.KelvinToCelcius (value / 1000m);

			// 10−6 K
			case "µK":
			case "microkelvin":
				return Temperature.KelvinToCelcius (value / 1000000m);

			// 10−9 K
			case "nK":
			case "nanokelvin":
				return Temperature.KelvinToCelcius (value / 1000000000m);

			// 10−12 K
			case "pK":
			case "picokelvin":
				return Temperature.KelvinToCelcius (value / 1000000000000m);

			// 10−15 K 	
			case "fK":
			case "femtokelvin":
				return Temperature.KelvinToCelcius (value / 1000000000000000m);

			// 10−18 K
			case "aK":
			case "attokelvin":
				return Temperature.KelvinToCelcius (value / 1000000000000000000m);

			// 10−21 K
			case "zK":
			case "zeptokelvin":
				return Temperature.KelvinToCelcius (value / 1000000000000000000000m);

			// 10−24 K
			case "yK":
			case "yoctokelvin":
				return Temperature.KelvinToCelcius (value / 1000000000000000000000000m);
			}

			throw new Exception ("from " + format);
		}

		public static decimal CelciusToFormat (string format, decimal c)
		{
			switch (format) {
			case "C":
			case "celcius":
			case "centigrade":
			case "centigrades":
				return c;

			case "F":
			case "fahrenheit":
				return Temperature.CelciusToFahrenheit (c);

			case "R":
			case "rankine":
				return Temperature.CelciusToRankine (c);

			case "K":
			case "kelvin":
				return Temperature.CelciusToKelvin (c);

			case "D":
			case "delisle":
				return Temperature.CelciusToDelisle (c);

			case "N":
			case "newton":
				return Temperature.CelciusToNewton (c);

			case "réaumur":
				return Temperature.CelciusToReaumur (c);

			case "rømer":
				return Temperature.CelciusToRomer (c);
			}

			throw new Exception ("to " + format);
		}

		public static decimal Convert (string from, string to, decimal value)
		{
			decimal celcius = FormatToCelcius (from, value);

			return CelciusToFormat (to, celcius);
		}
	}
}
