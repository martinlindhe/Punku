/**
 * Conversion functions between different units of area
 *
 * http://en.wikipedia.org/wiki/Area
 *
 * @author Martin Lindhe, 2010-2013 <martin@ubique.se>
 */

using System;

namespace Punku.Convert
{
	public class Area
	{
		public static decimal Convert (string from, string to, decimal val)
		{
			var s1 = GetScale (from);
			var s2 = GetScale (to);

			var res = s1 * val;
			return res / s2;
		}

		/**
		 * unit scale to square metre (m²) 
		 */
		public static decimal GetScale (string name)
		{
			switch (name) {
			// square millimetre (1.0 × 10^-6 m²)
			case "mm²": 
			case "square millimeter":
			case "square millimetre":
			case "square millimeters":
			case "square millimetres":
				return 0.000001m;

			// square centimetre
			case "cm²":  
			case "square centimeter":
			case "square centimetre":
			case "square centimeters":
			case "square centimetres":
				return 0.0001m;

			// square decimetre
			case "dm²":       
			case "square decimeter":
			case "square decimetre":
			case "square decimeters":
			case "square decimetres":
				return 0.01m;

			// square metre
			case "m²":     
			case "square meter":
			case "square metre":
			case "square meters":
			case "square metres":
				return 1;

			// are (100 m²)
			case "a":
			case "are":
			case "ares":
				return 100;

			// hectare (10 000 m²)
			case "ha":       
			case "hectare":
			case "hectares":
				return 10000;

			// square kilometre (100 hectares)
			case "km²":     
			case "square kilometer":
			case "square kilometre":
			case "square kilometers":
			case "square kilometres":
				return 1000000;

			// square inch
			case "in²":    
			case "square inch":
			case "square inches":
				return 0.00064516m;

			// square foot = 144 square inches
			case "ft²":    
			case "square foot":
			case "square feet":
				return 0.09290304m;

			// square yard = 9 square feet
			case "yd²":   
			case "square yard":
			case "square yards":
				return 0.83612736m;

			// 1 acre = 4840 square yards = 43560 square feet
			case "acre":  
			case "acres":
				return 4046.8564224m;

			// square mile (U.S. mile) = 640 acres
			case "mile²":    
			case "square mile":
			case "square miles":
				return 2589988.11m;
			}
			throw new Exception ("unknown scale " + name);
		}
	}
}

