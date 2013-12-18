/**
 * Conversion functions between different units of energy
 *
 * http://en.wikipedia.org/wiki/Kilowatt_hour
 * http://en.wikipedia.org/wiki/Conversion_of_units#Energy
 * http://en.wikipedia.org/wiki/Unit_of_energy
 *
 * @author Martin Lindhe, 2012-2013 <martin@ubique.se>
 */
using System;

namespace Punku.Convert
{
	public class Energy
	{
		public static decimal Convert (string from, string to, decimal val)
		{
			var s1 = GetScale (from);
			var s2 = GetScale (to);

			var res = s1 * val;
			return res / s2;
		}

		/**
	 	 * unit scale to one watt hour 
	  	 */
		public static decimal GetScale (string name)
		{
			switch (name) {
			// 10^-6
			case "µWh":
			case "microwatt hour":
				return 0.000001m;

			// 10^-3
			case "mWh":
			case "milliwatt hour":
				return 0.001m;

			// watt hour
			case "wh":
			case "watt hour":
				return 1; 

			// 10^3
			case "kWh":
			case "kilowatt hour":
				return 1000;

			// 10^6
			case "MWh":
			case "megawatt hour":
				return 1000000;         

			// 10^9
			case "GWh":
			case "gigawatt hour":
				return 1000000000;

			// 10^12
			case "TWh":
			case "terawatt hour":
				return 1000000000000;

			// 10^15
			case "PWh":
			case "petawatt hour":
				return 1000000000000000;
			}

			throw new Exception ("unknown scale " + name);
		}
	}
}
