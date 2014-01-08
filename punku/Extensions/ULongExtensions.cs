using System;

public static class ULongExtensions
{
	/**
	 * @return the number of digits in the number (base 10)
	 */
	public static int CountDigits (this ulong i)
	{
		int cnt = 1;

		while (i >= 10) {
			cnt++;
			i /= 10;
		}

		return cnt;
	}

	/**
	 * @return byte array of the separate digits in the number (base 10)
	 */
	public static byte[] Digits (this ulong i)
	{
		int count = CountDigits (i);
		byte[] digits = new byte[count];

		for (int n = count - 1; n >= 0; n--) {
			digits [n] = (byte)(i % 10);
			i /= 10;
		}

		return digits;
	}
}


