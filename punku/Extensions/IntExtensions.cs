using System;

public static class IntExtensions
{
	public static bool IsNegative (this int i)
	{
		return (i < 0) ? true : false;
	}

	/**
	 * @ return the number of digits in the number
	 */
	public static int CountDigits (this int i)
	{
		if (i < 0)
			throw new Exception ("FIXME how to handle negative numbers?");

		int cnt = 1;
		while (i > 9) {
			cnt++;
			i /= 10;
		}
		return cnt;
	}
}

