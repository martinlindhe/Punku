using System;
using System.Text;

namespace Punku.Strings
{
	/**
	 * Used to display a IPv4 number stored as uint32
	 * 0x00FF0000 = "0.255.0.0"
	 * 
	 * https://en.wikipedia.org/wiki/Dot-decimal_notation
	 */
	public class DottedDecimalNotation
	{
		public static string ToDecimalNotation (uint value, int bitsPerPair = 8, char separator = '.')
		{
			if (bitsPerPair != 8)
				throw new NotImplementedException ();

			uint b1 = (value & 0xFF000000) >> 24;
			uint b2 = (value & 0x00FF0000) >> 16;
			uint b3 = (value & 0x0000FF00) >> 8;
			uint b4 = (value & 0x000000FF);

			var res = new StringBuilder ();

			res.Append (b1);
			res.Append (separator);

			res.Append (b2);
			res.Append (separator);

			res.Append (b3);
			res.Append (separator);

			res.Append (b4);

			return res.ToString ();
		}
	}
}

