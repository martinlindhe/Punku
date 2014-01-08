using System;

public static class IntExtensions
{
	public static bool IsNegative (this int i)
	{
		return (i < 0) ? true : false;
	}
}

