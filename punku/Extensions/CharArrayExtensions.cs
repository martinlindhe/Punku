using System;
using System.Text;

public static class CharArrayExtensions
{
	public static string ToUtf16String (this char[] input)
	{
		var res = new StringBuilder ();
		foreach (char c in input)
			res.Append (c);
	
		return res.ToString ();
	}
}

