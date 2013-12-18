/**
 * Handle swedish personal identity number (aka Personnummer)
 *
 * The personal identity number consists of 10 digits and a hyphen.
 * The first six correspond to the person's birthday, in YYMMDD form.
 * They are followed by a hyphen. The seventh through ninth are a serial number.
 * An odd eight number is assigned to men, an even number to women.
 * The tenth digit is a checksum.
 *
 * http://en.wikipedia.org/wiki/Personal_identity_number_%28Sweden%29
 *
 * @author Martin Lindhe, 2007-2013 <martin@ubique.se>
 */

using System;

// TODO ToDateTime exception check unit test
// TODO use ToDateTime in IsValidDate() method to remove duplicated code
namespace Punku
{
	public class PersonalIdentityNumberSweden
	{
		public static DateTime ToDateTime (string s)
		{
			// TODO unit test for the exceptions thrown by DateTime will throw exception if date is invalid
			s = s.Replace ("-", "");

			/// XXX refactor IsValidDate more?!?! or use TryParse directly with specified format string
			int yy;

			if (s.Length == 12) {
				yy = System.Convert.ToInt32 (s.Substring (0, 4), 10);
			} else if (s.Length == 10) {
				yy = System.Convert.ToInt32 (s.Substring (0, 2), 10);

				var now_last2 = System.Convert.ToInt32 (DateTime.Now.ToString ("yy"), 10);

				if (yy > now_last2)
					yy = 1900 + yy;
				else
					yy = 2000 + yy;

			} else {
				throw new Exception (); // TODO throw a proper exception 
			}

			int mm = System.Convert.ToInt32 (s.Substring (2, 2), 10);
			int dd = System.Convert.ToInt32 (s.Substring (4, 2), 10);
			// Console.WriteLine ("yy = " + yy + ", mm = " + mm + ", dd = " + dd);
	
			return new DateTime (yy, mm, dd);
		}

		/**
		 * odd = male
		 */
		public static bool IsMale (string s)
		{
			if (!IsValid (s))
				return false;

			var gender = System.Convert.ToInt32 (s.Substring (s.Length - 2, 1), 10);
		
			if ((gender % 2) != 0)
				return true;

			return false;
		}

		/**
		 * even = female
	     */
		public static bool IsFemale (string s)
		{
			if (!IsValid (s))
				return false;

			var gender = System.Convert.ToInt32 (s.Substring (s.Length - 2, 1), 10);

			if ((gender % 2) == 0)
				return true;

			return false;
		}

		private static bool IsValidDate (string s)
		{
			int yy;

			if (s.Length == 12) {
				yy = System.Convert.ToInt32 (s.Substring (0, 4), 10);
			} else if (s.Length == 10) {
				yy = System.Convert.ToInt32 (s.Substring (0, 2), 10);

				var now_last2 = System.Convert.ToInt32 (DateTime.Now.ToString ("yy"), 10);

				if (yy > now_last2)
					yy = 1900 + yy;
				else
					yy = 2000 + yy;

			} else {
				return false;
			}

			int mm = System.Convert.ToInt32 (s.Substring (2, 2), 10);
			int dd = System.Convert.ToInt32 (s.Substring (4, 2), 10);
			// Console.WriteLine ("yy = " + yy + ", mm = " + mm + ", dd = " + dd);

			// fail = date is invalid
			try {
				var checkDate = new DateTime (yy, mm, dd);

				return true;
			} catch {
				return false;
			}
		}

		public static bool IsValid (string s)
		{
			s = s.Replace ("-", "");

			if (!IsValidDate (s))
				return false;

			string part;
			if (s.Length == 12)
				part = s.Substring (2, 9);
			else if (s.Length == 10)
				part = s.Substring (0, 9);
			else
				return false;

			int calc = Punku.Strings.Luhn.Calculate (part);
			int input = System.Convert.ToInt32 (s.Substring (s.Length - 1, 1), 10);

			if (calc == input)
				return true;

			return false;
		}
	}
}

