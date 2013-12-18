using System;

// TODO: rework into something that uses streams?!? and can be reused in metaemu & hexview?!
namespace Punku
{
	public class ByteArrayPrinter
	{
		public static string ToHexString (byte[] bytes)
		{
			char[] c = new char[bytes.Length * 2];

			byte b;
			int cx = 0;

			for (int bx = 0; bx < bytes.Length; ++bx) {
				b = (byte)(bytes [bx] >> 4);
				c [cx++] = (char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30);

				b = (byte)(bytes [bx] & 0x0F);
				c [cx++] = (char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30);
			}

			return new string (c);
		}

		public static string ToCString (byte[] bytes)
		{
			int len;
			for (len = 0; len < bytes.Length; len++)
				if (bytes [len] == 0)
					break;

			char[] c = new char[len];

			for (int i = 0; i < bytes.Length; i++) {
				if (bytes [i] == 0)
					break;
				c [i] = (char)bytes [i];
			}

			return new string (c);
		}
	}
}

