using System;
using NUnit.Framework;
using Punku;

[TestFixture]
public class LengtTest
{
	[Test]
	public static void Test01 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("m", "au", 100000000000), 0.6684587122268445495995953370m);
	}

	[Test]
	public static void Test02 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("au", "m", 2), 299195741400);
	}

	[Test]
	public static void Test03 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("m", "ft", 100), 328.08333290409097278381431061m);
	}

	[Test]
	public static void Test04 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("ft", "m", 100), 30.480061m);
	}

	[Test]
	public static void Test05 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("m", "in", 100), 3937.0078740157480314960629921m);
	}

	[Test]
	public static void Test06 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("in", "m", 100), 2.54m);
	}

	[Test]
	public static void Test07 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("m", "yd", 1000), 1093.6132983377077865266841645m);
	}

	[Test]
	public static void Test08 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("yd", "m", 1000), 914.4m);
	}

	[Test]
	public static void Test09 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("usmile", "m", 1.5m), 2414.016m);
	}

	[Test]
	public static void Test10 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("m", "usmile", 1000), 0.6213711922373339696174341844m);
	}

	[Test]
	public static void Test11 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("ukmile", "m", 1.5m), 2778);
	}

	[Test]
	public static void Test12 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("m", "ukmile", 300), 0.1619870410367170626349892009m);
	}

	[Test]
	public static void Test13 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("mm", "yd", 500), 0.5468066491688538932633420822m);
	}

	[Test]
	public static void Test14 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("yd", "mm", 0.25m), 228.6m);
	}

	[Test]
	public static void Test15 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("mm", "nm", 10), 10000000);
	}

	[Test]
	public static void Test16 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("nm", "mm", 500000), 0.5m);
	}

	[Test]
	public static void Test17 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("pm", "nm", 500000), 500);
	}

	[Test]
	public static void Test18 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("nm", "pm", 0.04m), 40);
	}

	[Test]
	public static void Test19 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("fm", "pm", 50000000), 50000);
	}

	[Test]
	public static void Test20 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("am", "fm", 50000000), 50000);
	}

	[Test]
	public static void Test21 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("zm", "am", 50000000), 50000);
	}

	[Test]
	public static void Test22 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("ym", "zm", 50000000), 50000);
	}

	[Test]
	public static void Test23 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("km", "ld", 500000), 1.3007284079084287200832466181m);
	}

	[Test]
	public static void Test24 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("meter", "cm", 1), 100);
	}

	[Test]
	public static void Test25 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("mil", "kilometer", 10), 100);
	}

	[Test]
	public static void Test26 ()
	{
		Assert.AreEqual (Punku.Convert.Length.Convert ("micrometer", "nanometer", 1), 1000);
	}
}
