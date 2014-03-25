/**
 * toy
 * 
 * https://en.wikipedia.org/wiki/Narcissistic_number
 * http://oeis.org/A005188
 */
using System;
using Punku;

namespace Punku.Math
{
	public class NarcissisticNumber
	{
		/**
		 * narcissistic number finder
		 */
		public static void Finder (uint numberBase)
		{
			var time = new MeasureTime ();

			for (ulong i = 1; i < ulong.MaxValue; i++) {

				if (IsNarcissisticNumber (i, numberBase)) {
					Console.WriteLine ("nars in base " + numberBase + " = " + Punku.Convert.Base.ToBase (i, numberBase));
				}
			}

			time.Stop ();
		}

		/**
		 * Checks if n is a narcissistic number
		 */
		public static bool IsNarcissisticNumber (ulong n, uint numberBase = 10)
		{
			// NOTE: there can be a rounding error due to Math.Pow using doubles

			ulong res = 0;
			uint digitCount = n.CountDigits (numberBase);

			foreach (var digit in n.Digits (numberBase))
				res += (ulong)System.Math.Pow (digit, digitCount);

			if (n == res)
				return true;

			return false;
		}
	}
}
