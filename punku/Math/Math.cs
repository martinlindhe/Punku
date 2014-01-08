using System;

namespace Punku
{
	public static class Math
	{
		public static bool IsNarcissisticNumber (ulong n)
		{
			// NOTE: there can be a rounding error due to Math.Pow using doubles

			ulong res = 0;
			int count = n.CountDigits ();

			foreach (var x in n.Digits ())
				res += (ulong)System.Math.Pow (x, count);

			if (n == res)
				return true;

			return false;
		}
	}
}

