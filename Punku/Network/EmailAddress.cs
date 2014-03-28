// NOTE internal MailAddress class exists

using System;
using System.Text.RegularExpressions;

namespace Punku.Network
{
	public class EmailAddress
	{
		/**
		 * @return true if s is a properly formatted e-mail address
		 *
		 * NOTE: allows utf-8 addresses
		 */
		public static bool IsValid (string s)
		{
			return Regex.IsMatch (
				s, 
				@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
			);
		}
	}
}

