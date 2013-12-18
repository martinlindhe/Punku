using System;
using NUnit.Framework;
using Punku;

[TestFixture]
public class AreaTest
{
	[Test]
	public static void Test01 ()
	{
		Assert.AreEqual (Punku.Convert.Area.Convert ("m²", "are", 1), 0.01m);
	}

	[Test]
	public static void Test02 ()
	{
		Assert.AreEqual (Punku.Convert.Area.Convert ("ha", "square metre", 2), 20000);
	}

	[Test]
	public static void Test03 ()
	{
		Assert.AreEqual (Punku.Convert.Area.Convert ("square kilometer", "square meter", 2), 2000000);
	}

	[Test]
	public static void Test04 ()
	{
		Assert.AreEqual (Punku.Convert.Area.Convert ("acres", "square meter", 3), 12140.5692672m);
	}

	[Test]
	public static void Test05 ()
	{
		Assert.AreEqual (Punku.Convert.Area.Convert ("square feet", "square meter", 2), 0.18580608m);
	}

	[Test]
	public static void Test06 ()
	{
		Assert.AreEqual (Punku.Convert.Area.Convert ("square yard", "square meter", 4), 3.34450944m);
	}

	[Test]
	public static void Test07 ()
	{
		Assert.AreEqual (Punku.Convert.Area.Convert ("acre", "hectare", 140), 56.6559899136m);
	}

	[Test]
	public static void Test08 ()
	{
		Assert.AreEqual (Punku.Convert.Area.Convert ("acre", "hectare", 1), 0.40468564224m);
	}

	[Test]
	public static void Test09 ()
	{
		Assert.AreEqual (Punku.Convert.Area.Convert ("cm²", "m²", 100000), 10);
	}

	[Test]
	public static void Test10 ()
	{
		Assert.AreEqual (Punku.Convert.Area.Convert ("mm²", "cm²", 100000), 1000);
	}

	[Test]
	public static void Test11 ()
	{
		Assert.AreEqual (Punku.Convert.Area.Convert ("dm²", "cm²", 100), 10000);
	}

	[Test]
	public static void Test12 ()
	{
		Assert.AreEqual (Punku.Convert.Area.Convert ("square inches", "cm²", 100), 645.16m);
	}

	[Test]
	public static void Test13 ()
	{
		Assert.AreEqual (Punku.Convert.Area.Convert ("square foot", "square inch", 1), 144);
	}
}