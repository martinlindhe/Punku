using System;
using System.Text;

public static class CharArrayExtensions
{
	/**
	 * Returns a hex string representation of the content,
	 * where each char is 4 hex letters (UTF-16)
	 */
	public static string ToHexString (this char[] input)
	{
		var res = new StringBuilder ();

		foreach (char c in input)
			res.Append (c.ToHexString ());

		return res.ToString ();
	}

	/**
	 * Returns a UTF-16 string representation of the char[]
	 */
	public static string ToUtf16String (this char[] input)
	{
		// TODO use encoding.convert ?!
		var res = new StringBuilder ();

		foreach (char c in input)
			res.Append (c);
	
		return res.ToString ();
	}
}
