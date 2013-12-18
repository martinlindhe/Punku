/**
 * To calculate the checksum, multiply the individual digits in the identity number with 212121-212.
 * The resulting products (a two digit product, such as 16, would be converted to 1 + 6) are
 * added together. The checksum is 10 minus the ones place digit in this sum.
 *
 * @author Martin Lindhe, 2007-2013 <martin@startwars.org>
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
				// Switch between 212121212
				string xx = s.Substring (i, 1);
				var tmp = System.Convert.ToInt32 (xx, 10) * (2 - (cnt & 1));

				if (tmp > 9)
					tmp -= 9;

				//Log (xx + " * " + (2 - (cnt & 1)) + "  = " + tmp);

				cnt++;
				sum += tmp;

				//Log (" ( sum = " + sum + ")");
			}

			// Substract the ones place digit from 10
			sum = (10 - (sum % 10)) % 10;
			return sum;
		}

		static void Log (string s)
		{
			Console.WriteLine ("[Luhn ]" + s);
		}
	}
}

