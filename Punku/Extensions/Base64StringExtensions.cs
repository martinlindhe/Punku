using System;

public static class Base64StringExtensions
{
	/**
	 * @return base-64 encoded representation of the data
	 */
	public static string ToBase64 (this byte[] bytes)
	{
		return System.Convert.ToBase64String (bytes);
	}

	/**
     * @return base-64 encoded representation from UTF-8 input
     */
	public static string ToBase64 (this string input)
	{
		return System.Text.ASCIIEncoding.UTF8.GetBytes (input).ToBase64 ();
	}

	/**
	     * @return UTF-8 string decoded from base-64 encoded input
	     */
	public static string FromBase64 (this string input)
	{
		var x = System.Convert.FromBase64String (input);
		return System.Text.ASCIIEncoding.UTF8.GetString (x);
	}

	/**
	     * @return byte[] array decoded from base-64 encoded input
	     */
	public static byte[] FromBase64ToByteArray (this string input)
	{
		return System.Convert.FromBase64String (input);
	}
}

