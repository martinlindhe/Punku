using System;
using Punku;

public static class Int32Extensions
{
	/*	* 
	 * Debug: print line to console
	 */
	public static void Log (this Int32 input)
	{
		string paramName = MemberInfoGetter.GetMemberName (() => input);
		Console.WriteLine ("<Int32 " + paramName + "> " + input);
	}
}