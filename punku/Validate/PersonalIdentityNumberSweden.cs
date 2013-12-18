/**
 * Handle swedish personal identity number (aka Personnummer)
 *
 * The personal identity number consists of 10 digits and a hyphen.
 * The first six correspond to the person's birthday, in YYMMDD form.
 * They are followed by a hyphen. The seventh through ninth are a serial number.
 * An odd number is assigned to men, an even number to women.
 * The tenth digit is a checksum.
 *
 * http://en.wikipedia.org/wiki/Personal_identity_number_%28Sweden%29
 * http://sv.wikipedia.org/wiki/Organisationsnummer
 *
 * @author Martin Lindhe, 2007-2013 <martin@ubique.se>
 */

using System;

// TODO acceptera "YYMMDD-XXXX" input. acceptera "YYYYMMDD-XXXX" åxå
// TODO bool IsValid()-verifiera YYMMDD & base check, IsMale(), IsFemale(). ToDatestamp()
namespace Punku
{
	public class OrganizationNumberSweden
	{
		public static bool IsValid (string s)
		{
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

	public class PersonalIdentityNumberSweden
	{
	}
}

