/**
 * Conversion functions between different byte representations
 *
 * http://en.wikipedia.org/wiki/Units_of_information
 * http://en.wikipedia.org/wiki/Template:Quantities_of_bits
 * http://en.wikipedia.org/wiki/Template:Quantities_of_bytes
 *
 * @author Martin Lindhe, 2009-2013 <martin@ubique.se>
 */

using System;

namespace Punku.Convert
{
	public class Datasize
	{
		public static decimal ToBytes (string input)
		{
			string num = "";
			foreach (char c in input) {
				if (c < '0' || c > '9')
					break;
				num += c;
			}

			var form = input.Substring (num.Length);

			if (num.Length < 1 || form.Length < 1)
				throw new Exception ("parse fail " + input);

			var val = System.Convert.ToInt64 (num, 10);

			return Convert (form.Trim (), "byte", (decimal)val);
		}

		public static decimal Convert (string from, string to, decimal val)
		{
			var s1 = GetScale (from);
			var s2 = GetScale (to);

			var res = s1 * val;
			return res / s2;
		}

		/**
		 * Unit scale to a bit
		 */
		public static decimal GetScale (string name)
		{
			switch (name) {
			case "bit":
			case "bits":
				return 1m;

			// 2^10
			case "kbit":	
			case "kilobit":
			case "kilobits":
				return 1024m;

			// 2^20
			case "mbit":
			case "megabit":
			case "megabits":
				return 1048576m;

			// 2^30
			case "gbit":
			case "gigabit":
			case "gigabits":
				return 1073741824m;

			// 2^40
			case "tbit":
			case "terabit":
			case "terabits":
				return 1099511627776m;

			// 2^50
			case "pbit":
			case "petabit":
			case "petabits":
				return 1125899906842624m;

			// 2^60
			case "ebit":
			case "exabit":
			case "exabits":
				return 1152921504606846976m;

			// 2^70
			case "zbit":
			case "zettabit":
			case "zettabits":
				return 1180591620717411303424m;

			// 2^80
			case "ybit":
			case "yottabit":
			case "yottabits":
				return 1208925819614629174706176m;

			case "b":
			case "byte":
			case "bytes":
				return 8m;

			// (2^10)*8
			case "k":
			case "K":
			case "kb":
			case "KiB":
			case "kbyte":
			case "kbytes":
			case "kilobyte":
			case "kilobytes":
				return 8192m;

			// (2^20)*8
			case "M":
			case "mb":
			case "MiB":
			case "mbyte":
			case "mbytes":
			case "megabyte":
			case "megabytes":
				return 8388608m;

			// (2^30)*8
			case "G":
			case "gb":
			case "GiB":
			case "gbyte":
			case "gbytes":
			case "gigabyte":
			case "gigabytes":
				return 8589934592m;

			// (2^40)*8
			case "T":
			case "tb":
			case "TiB":
			case "tbyte":
			case "tbytes":
			case "terabyte":
			case "terabytes":
				return 8796093022208m;

			// (2^50)*8
			case "pb":
			case "petabyte":
			case "petabytes":
				return 9007199254740992m;

			// (2^60)*8
			case "eb":
			case "exabyte":
			case "exabytes":
				return 9223372036854775808m;

			// (2^70)*8
			case "zb":
			case "zettabyte":
			case "zettabytes":
				return 9444732965739290427392m;

			// (2^80)*8
			case "yb":
			case "yottabyte":
			case "yottabytes":
				return 9671406556917033397649408m;
			}

			throw new Exception ("unknown scale " + name);
		}
	}
}
