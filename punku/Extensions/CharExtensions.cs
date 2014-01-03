using System;
using System.Text;

public static class CharExtensions
{
	/**
	 * Returns a 4-letter long hex value representation of char (UTF-16)
	 */
	public static string ToHexString (this char c)
	{
		int value = Convert.ToInt32 (c);
		return value.ToString ("x4");
	}
}

