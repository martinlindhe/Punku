using System;
using System.Text;
using Punku;

public static class StringExtensions
{
	public static string Repeat (this string input, int count)
	{
		var builder = new StringBuilder ((input == null ? 0 : input.Length) * count);

		for (int i = 0; i < count; i++)
			builder.Append (input);

		return builder.ToString ();
	}

	public static int Count (this string input, char letter)
	{
		int count = 0;
		foreach (char c in input)
			if (c == letter)
				count++;

		return count;
	}

	public static bool IsNumbersOnly (this string input)
	{
		if (input == "")
			return false;

		foreach (char c in input)
			if (c < '0' || c > '9')
				return false;

		return true;
	}

	/** 
	 * Debug: print line to console
	 */
	public static void Log (this string input)
	{
		string paramName = MemberInfoGetter.GetMemberName (() => input);
		Console.WriteLine ("<string " + paramName + ", " + input.Length + "> " + input);
	}
}
