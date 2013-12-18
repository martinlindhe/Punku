/**
 * Conversion functions for different units of length
 *
 * http://en.wikipedia.org/wiki/Conversion_of_units#Length
 * http://en.wikipedia.org/wiki/Unit_of_length
 * http://en.wikipedia.org/wiki/Orders_of_magnitude_%28length%29
 *
 * @author Martin Lindhe, 2009-2013 <martin@ubique.se>
 */

using System;

namespace Punku.Convert
{
	public class Length
	{
		public static decimal Convert (string from, string to, decimal val)
		{
			var s1 = GetScale (from);
			var s2 = GetScale (to);

			var res = s1 * val;
			return res / s2;
		}

		/**
	 	 * unit scale to one meter 
	  	 */
		public static decimal GetScale (string name)
		{
			switch (name) {
			// SI: Yoctometre     10^−24m
			case "ym":
			case "yoctometer":
			case "yoctometre":
				return 0.000000000000000000000001m; 
			// SI: Zeptometre     10^−21m
			case "zm":
			case "zeptometer":
			case "zeptometre":
				return 0.000000000000000000001m;  
			// SI: Attometre      10^−18m
			case "am":
			case "attometer":
			case "attometre":
				return 0.000000000000000001m;    
			// SI: Femtometre     10^−15m
			case "fm":
			case "femtometer":
			case "femtometre":
				return 0.000000000000001m;
			// SI: Picometre      10^−12m
			case "pm":
			case "picometer":
			case "picometre":
				return 0.000000000001m;  
			// SI: Nanometre      10^-9m
			case "nm":
			case "nanometer":
			case "nanometre":
				return 0.000000001m;
			// SI: Micrometre, μm 10^-6m
			case "micron":
			case "microns":
			case "micrometer":
			case "micrometre":
			case "µm":
				return 0.000001m; 
			// SI: Millimetre     10^-3m
			case "mm":
			case "millimeter":
				return 0.001m;
			// SI: Centimetre     10^-2m
			case "cm":
			case "centimeter":
				return 0.01m;
			// SI: Decimetre      10^-1m
			case "dm":
			case "decimeter":
				return 0.1m;
			// SI: Meter
			case "m":
			case "meter":
			case "meters":
				return 1;
			// SI: Kilometer      10^3m
			case "km":
			case "kilometer":
			case "kilometers":
				return 1000;
			// Scandinavian mile, http://en.wikipedia.org/wiki/Scandinavian_mile
			case "mil":
			case "scandmile":
				return 10000;

			case "in":
			case "inch":
			case "inches":
				return 0.0254m;
	
			case "ft":
			case "feet":
			case "feets":
				return 0.30480061m; 
		
			case "yd":
			case "yard":
			case "yards":
				return 0.9144m;
			// UK: Mile (nautical)
			case "ukmile":
				return 1852;
			// US: Mile (statute)
			case "mile":
			case "miles":
			case "usmile":
				return 1609.344m; 
			// Lunar distance, http://en.wikipedia.org/wiki/Lunar_distance_%28astronomy%29
			case "ld":
			case "lunar":
				return 384400000;
			// Astronomical Unit
			case "au":
			case "astronomical":
				return 149597870700;  
			}

			throw new Exception ("unknown scale " + name);
		}
	}
}
