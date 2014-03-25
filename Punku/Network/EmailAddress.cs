using System;
using System.Text.RegularExpressions;

namespace Punku.Network
{
	public class EmailAddress
	{
		public static bool IsValid (string s)
		{
			// allows utf8: @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"

			return Regex.IsMatch (
				s, 
				@"^([a-zA-Z0-9])+([a-zA-Z0-9._-])*@([a-zA-Z0-9_-])+([a-zA-Z0-9._-]+)+$"
			);
		}
	}
}

