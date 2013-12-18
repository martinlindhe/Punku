/**
 * Conversion functions between different units of volume
 *
 * https://en.wikipedia.org/wiki/Litre
 * http://en.wikipedia.org/wiki/Volume
 *
 * @author Martin Lindhe, 2010-2013 <martin@ubique.se>
 */
using System;

namespace Punku.Convert
{
	public class Volume
	{
		public static decimal Convert (string from, string to, decimal val)
		{
			var s1 = GetScale (from);
			var s2 = GetScale (to);

			var res = s1 * val;
			return res / s2;
		}

		/**
	 	 * unit scale to one liter
	  	 */
		public static decimal GetScale (string name)
		{
			switch (name) {
			// yl, yoctolitre 10 ^−24 L
			// zl, zeptolitre 10 ^−21 L
			// al, attolitre 10 ^−18 L
			// fl, femtolitre 10 ^−15 L
			// pl, picolitre 10 ^−12 L
			// nl, nanolitre 10 ^−9 L

			// 10 ^−3 L
			case "ml":
			case "milliliter":
			case "milliliters":
			case "millilitre":
			case "millilitres":
				return 0.001m;

			// 10 ^−2 L
			case "cl":
			case "centiliter":
			case "centiliters":
			case "centilitre":
			case "centilitres":
				return 0.01m;         

			// 10 ^−1 L
			case "dl":
			case "deciliter":
			case "deciliters":
			case "decilitre":
			case "decilitres":
				return 0.1m;

			// 10 ^0 L
			case "l":
			case "liter":
			case "liters":
			case "litre":
			case "litres":
				return 1;

			// 10 ^1 L
			case "dal":
			case "decalitre":
			case "decalitres":
				return 10;

			// 10 ^2 L
			case "hl":
			case "hectolitre":
			case "hectolitres":
				return 100;

			// 10 ^3 L
			case "m³":
			case "kl":
			case "kilolitre":
			case "kilolitres":
			case "cubic meter":
			case "cubic meters":
			case "cubic metre":
			case "cubic metres":
				return 1000;
			
			// 10 ^6 L
			case "ML":
			case "megalitre":
			case "megalitres":
				return 1000000;
			
			// GL, gigalitre 10 ^9 L
			// TL, teralitre 10 ^12 L
			// PL, petalitre 10 ^15 L
			// EL, exalitre 10 ^18 L
			// ZL, zettalitre 10 ^21 L
			// YL, yottalitre 10 ^24 L

			case "cubic inch":
				return 0.016387064m;

			case "cubic foot":
				return 28.316846592m;

			// U.S liquid gallon
			case "gallon":
			case "gallons":
			case "us gallon":
			case "us gallons":
				return 3.785411784m;

			// imperial (uk) gallon
			case "uk gallon":
			case "uk gallons":
				return 4.54609m;

			// imperial (uk) pint
			case "pint":
			case "uk pint":
			case "imperial pint":
				return 0.56826125m;

			// U.S. fluid pint
			case "us pint":
				return 0.473176473m;
			}
			throw new Exception ("unknown scale " + name);
		}
	}
}
