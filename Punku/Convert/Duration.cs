/**
 * Conversion functions between different duration scales
 *
 * http://en.wikipedia.org/wiki/Conversion_of_units#Time
 * http://en.wikipedia.org/wiki/Leap_year
 * http://en.wiktionary.org/wiki/kiloyear
 *
 * @author Martin Lindhe, 2009-2013 <martin@ubique.se>
 */

using System;

namespace Punku.Convert
{
	public class Duration
	{
		public static decimal Convert (string from, string to, decimal val)
		{
			var s1 = GetScale (from);
			var s2 = GetScale (to);

			var res = s1 * val;
			return res / s2;
		}

		/**
		 * Unit scale to a second
		 */
		public static decimal GetScale (string name)
		{
			switch (name) {
			// 10 ^-21 of a second
			case "zs":
			case "zeptosecond":
			case "zeptoseconds":
				return 0.000000000000000000001m;

			// 10 ^-18 of a second
			case "as":
			case "attosecond":
			case "attoseconds":
				return 0.000000000000000001m; 

			//  10 ^−15 of a second
			case "fs":
			case "femtosecond":
			case "femtoseconds":
				return 0.000000000000001m; 

			// 10 ^−12 of a second
			case "ps":
			case "picosecond":
			case "picoseconds":
				return 0.000000000001m; 

			// 10 ^-9
			case "ns":
			case "nanosecond":
			case "nanoseconds":
				return 0.000000001m;  

			// 10 ^-6
			case "µs":
			case "microsecond":
			case "microseconds":
				return 0.000001m;  

			//  10 ^-3
			case "ms":
			case "millisecond":
			case "milliseconds":
				return 0.001m;    

			// 1 / 100
			case "cs":
			case "centisecond":
			case "centiseconds":
				return 0.01m;    

			// 1 / 10
			case "ds":
			case "decisecond":
			case "deciseconds":
				return 0.1m;   

			case "s":
			case "sec":
			case "second":
			case "seconds":
				return 1;

			// 60 sec
			case "min":
			case "minute":
			case "minutes":
				return 60;  

			// 60 minutes
			case "hr":
			case "hour":
			case "hours":
				return 3600;

			// 24 hours
			case "dy":
			case "day":
			case "days":
				return 86400; 

			// 7 days
			case "wk":
			case "week":
			case "weeks":
				return 604800;

			// 30 days
			case "mo":
			case "month":
			case "months":
				return 2592000;

			// 365.2425 days (gregorian year), modern more exact measurement
			case "yr":
			case "year":
			case "years":
			case "gregorian year":
				return 31556952;

			// 365.25 days (julian year), still used sometimes as a simple estimate of a "year"
			case "jyr":
			case "julian year":
				return 31557600;

			case "ky":
			case "kyr":
			case "kyrs":
			case "kilo-year":
				return 31556952000;
			}
			throw new Exception ("unknown scale " + name);
		}
	}
}
