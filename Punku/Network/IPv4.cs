using System;

// NOTE: IPAddress is a internal C# class
namespace Punku
{
	public class IPv4
	{
		/**
		 * Converts input string containing a IPv4 number to a uint32
		 */
		public static uint ToUInt32 (string s)
		{
			string[] parts = s.Split ('.');
			if (parts.Length != 4)
				throw new FormatException ();

			long res = 0;
			long multiplier = 0x1000000;

			foreach (var x in parts) {
				int val;
				if (int.TryParse (x, out val) == false)
					throw new FormatException ();

				if (val > 255)
					throw new FormatException ();

				res += val * multiplier;
				multiplier /= 256;
			}

			if (res > uint.MaxValue)
				throw new FormatException ();

			return (uint)res;
		}

		/**
		 * Converts a uint to a IPv4 number as a string
		 */
		public static string ToString (uint value)
		{
			return Punku.Strings.DottedDecimalNotation.ToDecimalNotation (value, 8, '.');
		}

		/**
		 * Returns true if input string is a valid IPv4 address
		 */
		public static bool IsIPv4 (string s)
		{
			try {
				ToUInt32 (s);
				return true;
			} catch (FormatException) {
				return false;
			}
		}
	}
}

