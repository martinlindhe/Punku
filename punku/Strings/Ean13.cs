/**
 * EAN-13 (European Article Number / International Article Number) validator
 *
 * Used worldwide for marking products often sold at retail point of sale
 *
 * http://en.wikipedia.org/wiki/European_Article_Number
 * http://en.wikipedia.org/wiki/GS1_Sweden
 * 
 * http://www.gs1.se/Support/Nummerupplysning/
 *
 * @author Martin Lindhe, 2010-2013 <martin@ubique.se>
 */
using System;

// TODO port over "render EAN-13 barcode" code from core_dev as a separate class
namespace Punku.Strings
{
	public class Ean13
	{
		public string Number;
		public int Country;
		public string CountryName;
		public string Company;
		public string CompanyName;
		public string Product;

		public Ean13 (string s)
		{
			if (!IsValid (s))
				throw new FormatException ();

			Number = s;

			Country = System.Convert.ToInt32 (s.Substring (0, 3), 10);
		}

		public static bool IsValid (string s)
		{
			if (s.Length != 13)
				return false;

			if (!s.IsNumbersOnly ())
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

				// Console.WriteLine (i + ": " + x + " * " + (((i % 2) != 0) ? "3" : "1"));

				if ((i % 2) != 0)
					sum += x * 3;
				else
					sum += x;
			}

			// round upwards to next ten-digit (eg: 47 => 50)
			var next_ten = (int)Math.Ceiling (((double)sum / 10)) * 10;
			return next_ten - sum;
		}

		public static Ean13 Parse (string s)
		{
			if (!IsValid (s))
				throw new FormatException ();

			var check = s.Substring (s.Length - 1, 1);

			var ean13 = new Ean13 (s);

			// Country lookup: http://en.wikipedia.org/wiki/List_of_GS1_country_codes

			if (ean13.Country >= 730 && ean13.Country <= 739) {
				ean13.CountryName = "Sweden";

				//GS1-13 code structure: GS1-YYYYYY-ZZZ-C    3|6|3|1, where Y = company, Z = product
				ean13.Company = s.Substring (3, 6);
				ean13.Product = s.Substring (9, 3);

				switch (ean13.Company) {
				case "001130":
					ean13.CompanyName = "Coop Trading A/S";
					break;
				case "007003":
				case "007013":
					ean13.CompanyName = "Carlsberg Sverige AB";
					break;
				case "040002":
					ean13.CompanyName = "Spendrups Bryggeriaktiebolag";
					break;
				case "050007":
					ean13.CompanyName = "Findus Sverige AB";
					break;
				case "125000":
					ean13.CompanyName = "Swedish Match North Europe AB";
					break;
				case "869008":
					ean13.CompanyName = "ICA Sverige AB";
					break;
				}
				return ean13;
			}

			if (ean13.Country >= 400 && ean13.Country <= 440) {
				ean13.CountryName = "Germany";
				return ean13;
			}
			if (ean13.Country >= 490 && ean13.Country <= 499) {
				ean13.CountryName = "Japan";
				return ean13;
			}
			if (ean13.Country >= 500 && ean13.Country <= 509) {
				ean13.CountryName = "United Kingdom";
				return ean13;
			}

			if (ean13.Country == 590) {
				ean13.CountryName = "Poland";
				return ean13;
			}

			if (ean13.Country == 729) {
				ean13.CountryName = "Israel";
				return ean13;
			}

			if (ean13.Country >= 800 && ean13.Country <= 839) {
				ean13.CountryName = "Italy, San Marino and Vatican City";
				return ean13;
			}

			return ean13;
		}
	}
}

