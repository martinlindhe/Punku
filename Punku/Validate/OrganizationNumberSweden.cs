/**
 * http://sv.wikipedia.org/wiki/Organisationsnummer
 *
 * @author Martin Lindhe, 2007-2013 <martin@ubique.se>
 */
using System;

namespace Punku
{
	public class OrganizationNumberSweden
	{
		public static bool IsValid (string s)
		{
			s = s.Replace ("-", "");

			if (s.Length == 12) {
				var y = s.Substring (0, 2);
				if (y == "19" || y == "20")
					s = s.Substring (2);
			}

			if (s.Length != 10)
				return false;

			int calc = Punku.Strings.Luhn.Calculate (s.Substring (0, 9));
			int input = System.Convert.ToInt32 (s.Substring (s.Length - 1, 1), 10);

			if (calc == input)
				return true;

			return false;
		}

		public static bool IsAktieBolag (string s)
		{
			if (!IsValid (s))
				return false;

			if (s.Substring (0, 2) != "55")
				return false;

			if (System.Convert.ToInt32 (s.Substring (2, 2), 10) < 20)
				return false;

			if (System.Convert.ToInt32 (s.Substring (4, 2), 10) < 20)
				return false;

			return true;
		}
	}
}

