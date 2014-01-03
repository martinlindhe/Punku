using System;

// TODO: use this in metaemu & hexview. move their hex printing to helper extensions
public static class ByteArrayExtensions
{
	public static string ToHexString (this byte[] bytes)
	{
		byte b;
		int cx = 0;

		char[] c = new char[bytes.Length * 2];

		for (int bx = 0; bx < bytes.Length; ++bx) {
			b = (byte)(bytes [bx] >> 4);
			c [cx++] = (char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30);

			b = (byte)(bytes [bx] & 0x0F);
			c [cx++] = (char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30);
		}

		return new string (c);
	}

	public static string ToCString (this byte[] bytes)
	{
		int len;

		for (len = 0; len < bytes.Length; len++)
			if (bytes [len] == 0)
				break;

		char[] c = new char[len];

		for (int i = 0; i < bytes.Length; i++) {

			// stop on NUL
			if (bytes [i] == 0)
				break;

			c [i] = (char)bytes [i];
		}

		return new string (c);
	}
}

