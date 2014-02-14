using System;

namespace Punku.Strings
{
	/** 
	 * Transform english text to inverted form (a=z, b=y, c=x etc)
	 */
	public class Invert : StringTransformer
	{
		public Invert ()
		{
			for (int i = 0; i < char.MaxValue; i++)
				Table [i] = (char)i;

			for (int i = 'a'; i <= 'z'; i++)
				Table [i] = (char)('z' - i + 'a');

			for (int i = 'A'; i <= 'Z'; i++)
				Table [i] = (char)('Z' - i + 'A');
		}

		public static string TransformStatic (string s)
		{
			var inv = new Invert ();
			return inv.Transform (s);
		}
	}
}

