/**
 * EAN-13 (European Article Number / International Article Number) validator
 *
 * Used worldwide for marking products often sold at retail point of sale
 *
 * http://en.wikipedia.org/wiki/European_Article_Number
 *
 * @author Martin Lindhe, 2010-2013 <martin@ubique.se>
 */
using System;

// TODO port over "render EAN-13 barcode" code from core_dev as a separate class
// TODO verify string only contains digits. need a "IsNumbersOnly" utility string method!
namespace Punku.Strings
{
	public class Ean13
	{
		public static bool IsValid (string s)
		{
			if (s.Length != 13)
				return false;

			int checkDigit = System.Convert.ToInt32 (s.Substring (s.Length - 1, 1), 10);

			if (CalculateChecksum (s) == checkDigit)
				return true;

			return false;
		}

		/**
    	 * Calculates checksum for EAN-13 or EAN-8 barcode numbers
     	 */
		private static int CalculateChecksum (string s)
		{

			int sum = 0;

			for (int i = s.Length - 2; i >= 0; i--) {
				int x = System.Convert.ToInt32 (s.Substring (i, 1), 10);

				Console.WriteLine (i + ": " + x + " * " + (((i % 2) != 0) ? "3" : "1"));

				if ((i % 2) != 0)
					sum += x * 3;
				else
					sum += x;
			}

			// round upwards to next ten-digit (eg: 47 => 50)
			var next_ten = (int)Math.Ceiling (((double)sum / 10)) * 10;
			return next_ten - sum;
		}
	}
}

