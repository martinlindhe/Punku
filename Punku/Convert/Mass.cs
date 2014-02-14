/**
 * Conversion functions between different units of mass
 *
 * http://en.wikipedia.org/wiki/Conversion_of_units#Mass
 *
 * @author Martin Lindhe, 2009-2013 <martin@ubique.se>
 */
using System;

namespace Punku.Convert
{
	public class Mass
	{
		public static decimal Convert (string from, string to, decimal val)
		{
			var s1 = GetScale (from);
			var s2 = GetScale (to);

			var res = s1 * val;
			return res / s2;
		}

		/**
	 	 * unit scale to one gram 
	  	 */
		public static decimal GetScale (string name)
		{
			switch (name) {
			case "g":
			case "gram":
				return 1;   

			case "hg":
			case "hecto":
			case "hectogram":
				return 100;

			case "kg":
			case "kilo":
			case "kilogram":
				return 1000;

			// Metric tonne
			case "t":
			case "ton":
			case "tonne":
				return 1000000;

			case "kt":
			case "kiloton":
			case "kilotonne":
				return 1000000000;

			case "mt":
			case "megaton":
			case "megatonne":
				return 1000000000000;

			case "oz":
			case "ounce":
			case "ounces":
				return 28.349523125m;

			// 1 Pound = 16 ounces
			case "lb":
			case "lbs":
			case "pound":
			case "pounds":
				return 28.349523125m * 16;

			// 1 Stone = 14 pounds
			case "st":
			case "stone":
			case "stones":
				return (28.349523125m * 16) * 14; 
			}

			throw new Exception ("unknown scale " + name);
		}
	}
}

