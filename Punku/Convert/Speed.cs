/**
 * Conversion functions between different speed units
 *
 * http://en.wikipedia.org/wiki/Speed
 * http://en.wikipedia.org/wiki/Miles_per_hour
 * http://en.wikipedia.org/wiki/Metre_per_second
 * http://en.wikipedia.org/wiki/Kilometres_per_hour
 * http://en.wikipedia.org/wiki/Knot_(unit)
 *
 * @author Martin Lindhe, 2012-2013 <martin@ubique.se>
 */
using System;

namespace Punku.Convert
{
	public class Speed
	{
		public static decimal Convert (string from, string to, decimal val)
		{
			var s1 = GetScale (from);
			var s2 = GetScale (to);

			var res = s1 * val;
			return res / s2;
		}

		/**
	 	 * unit scale to one m/s 
	  	 */
		public static decimal GetScale (string name)
		{
			switch (name) {
			// meters per second
			case "m/s":
				return 1;

			// kilometers per hour
			case "km/h":
				return 0.277778m;

			// feet per second
			case "ft/s":
				return 0.3048m;

			// miles per hour
			case "mph":
				return 0.44704m;

			case "knot":
			case "knots":
				return 0.514444m;
			}
			throw new Exception ("unknown scale " + name);
		}
	}
}
