using System;
using System.Text;

public static class ByteArrayExtensions
{
	/**
	 * Returns a hex string representation of the content
	 */
	public static string ToHexString (this byte[] bytes)
	{
		byte b;

		var res = new StringBuilder ();

		for (int bx = 0; bx < bytes.Length; bx++) {

			b = (byte)(bytes [bx] >> 4);
			res.Append ((char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30));

			b = (byte)(bytes [bx] & 0x0F);
			res.Append ((char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30));
		}

		return res.ToString ();
	}

	/**
	 * Decodes byte array to a C-string (each letter is 1 byte, 0 = end of text)
	 */
	public static string ToCString (this byte[] bytes)
	{
		var res = new StringBuilder ();

		foreach (byte x in bytes) {

			if (x == 0)
				break;

			res.Append ((char)x);
		}

		return res.ToString ();
	}

	/**
	 * Decodes byte array to a DOS $-terminated string (each letter is 1 byte, $ = end of text)
	 */
	public static string ToDosString (this byte[] bytes)
	{
		var res = new StringBuilder ();

		foreach (byte x in bytes) {
	
			if (x == (byte)'$')
				break;

			res.Append ((char)x);
		}

		return res.ToString ();
	}
}

