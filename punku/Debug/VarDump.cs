using System;

namespace Punku
{
	public class VarDump
	{
		public static void Dump (string val)
		{
			// TODO also print hex data
			Console.WriteLine ("VarDump (" + val.Length + " string): " + val);
		}

		public static void Dump (char val)
		{
			int tmp = (int)val;
			Console.WriteLine ("VarDump (char): " + val + " (0x" + tmp.ToString ("x2") + ")");
		}

		public static void Dump (int val)
		{
			Console.WriteLine ("VarDump (int): " + val + " (0x" + val.ToString ("x4") + ")");
		}

		public static void Dump (char[] val)
		{
			throw new Exception ("XXX TODO print hex of char-arr");
		}
	}
}

