using System;

namespace Punku
{
	public static class Math
	{
		/**
		 * Checks if n is a narcissistic number
		 * https://en.wikipedia.org/wiki/Narcissistic_number
		 * http://oeis.org/A005188
		 */
		public static bool IsNarcissisticNumber (ulong n, uint digitBase = 10)
		{
			// NOTE: there can be a rounding error due to Math.Pow using doubles

			ulong res = 0;
			uint digitCount = n.CountDigits (digitBase);

			foreach (var digit in n.Digits (digitBase))
				res += (ulong)System.Math.Pow (digit, digitCount);

			if (n == res)
				return true;

			return false;
		}
	}
}

