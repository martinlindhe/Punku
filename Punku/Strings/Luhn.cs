/**
 * To calculate the checksum, multiply the individual digits in the identity number with 212121-212.
 * The resulting products (a two digit product, such as 16, would be converted to 1 + 6) are
 * added together. The checksum is 10 minus the ones place digit in this sum.
 * 
 * http://en.wikipedia.org/wiki/Luhn_algorithm
 *
 * @author Martin Lindhe, 2007-2013 <martin@ubique.se>
 */ 
using System;

namespace Punku.Strings
{
	public class Luhn
	{
		public static int Calculate (string s)
		{
			int sum = 0, cnt = 0;

			for (int i = s.Length - 1; i >= 0; i--) {
			
				string c = s.Substring (i, 1);

				// Switch between 212121212
				int mod = (2 - (cnt & 1));
				int tmp = System.Convert.ToInt32 (c, 10) * mod;

				if (tmp > 9)
					tmp -= 9;

				cnt++;
				sum += tmp;
			}

			// Substract the ones place digit from 10
			sum = (10 - (sum % 10)) % 10;
			return sum;
		}
	}
}
