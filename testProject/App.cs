using System;
using Punku;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace testProject
{
	public class App
	{
		public static void Main ()
		{
			Log ("res _" + Punku.Strings.DottedDecimalNotation.ToDecimalNotation (0xFF0000) + "_");

		}

		public static void Log (string s)
		{
			Console.WriteLine (s);
		}
	}
}

