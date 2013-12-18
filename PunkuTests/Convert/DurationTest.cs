using System;
using NUnit.Framework;
using Punku;

[TestFixture]
public class DurationTest
{
	[Test]
	public static void Test01 ()
	{
		Assert.AreEqual (Punku.Convert.Duration.Convert ("hour", "second", 1), 3600);
	}

	[Test]
	public static void Test02 ()
	{
		Assert.AreEqual (Punku.Convert.Duration.Convert ("day", "minute", 4), 5760);
	}

	[Test]
	public static void Test03 ()
	{
		Assert.AreEqual (Punku.Convert.Duration.Convert ("hour", "minutes", 1), 60);
	}

	[Test]
	public static void Test04 ()
	{
		Assert.AreEqual (Punku.Convert.Duration.Convert ("hour", "days", 4320), 180);
	}

	[Test]
	public static void Test05 ()
	{
		Assert.AreEqual (Punku.Convert.Duration.Convert ("week", "days", 2), 14);
	}

	[Test]
	public static void Test06 ()
	{
		Assert.AreEqual (Punku.Convert.Duration.Convert ("gregorian year", "second", 1), 31556952);
	}

	[Test]
	public static void Test07 ()
	{
		Assert.AreEqual (Punku.Convert.Duration.Convert ("julian year", "second", 1), 31557600);
	}

	[Test]
	public static void Test08 ()
	{
		Assert.AreEqual (Punku.Convert.Duration.Convert ("millisecond", "second", 1), 0.001);
	}

	[Test]
	public static void Test09 ()
	{
		Assert.AreEqual (Punku.Convert.Duration.Convert ("centisecond", "second", 2), 0.02);
	}

	[Test]
	public static void Test10 ()
	{
		Assert.AreEqual (Punku.Convert.Duration.Convert ("decisecond", "second", 4), 0.4);
	}

	[Test]
	public static void Test11 ()
	{
		Assert.AreEqual (Punku.Convert.Duration.Convert ("microsecond", "millisecond", 2), 0.002);
	}

	[Test]
	public static void Test12 ()
	{
		Assert.AreEqual (Punku.Convert.Duration.Convert ("nanosecond", "microsecond", 2), 0.002);
	}

	[Test]
	public static void Test13 ()
	{
		Assert.AreEqual (Punku.Convert.Duration.Convert ("picosecond", "nanosecond", 2), 0.002);
	}

	[Test]
	public static void Test14 ()
	{
		Assert.AreEqual (Punku.Convert.Duration.Convert ("ky", "year", 2), 2000);
	}

	[Test]
	public static void Test15 ()
	{
		Assert.AreEqual (Punku.Convert.Duration.Convert ("femtosecond", "attosecond", 1), 1000);
	}

	[Test]
	public static void Test16 ()
	{
		Assert.AreEqual (Punku.Convert.Duration.Convert ("attosecond", "second", 100000000000000000), 0.1);
	}

	[Test]
	public static void Test17 ()
	{
		Assert.AreEqual (Punku.Convert.Duration.Convert ("zeptosecond", "attosecond", 100), 0.1);
	}
}