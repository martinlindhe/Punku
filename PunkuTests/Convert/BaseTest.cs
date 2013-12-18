using System;
using NUnit.Framework;
using Punku;

[TestFixture]
public class BaseTest
{
	[Test]
	public static void TestBaseConvert1 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ToBase (255, 10), "255");
	}

	[Test]
	public static void TestBaseConvert2 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ToBase (255, 16), "FF");
	}

	[Test]
	public static void TestBaseConvert3 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ToBase (255, 8), "377");
	}

	[Test]
	public static void TestBaseConvert4 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ToBase (255, 2), "11111111");
	}

	[Test]
	public static void TestBaseConvertBase5 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ToBase (255, 5), "2010");
	}

	[Test]
	public static void TestBaseConvertBase12 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ToBase (255, 12), "193");
	}

	[Test]
	public static void TestBaseConvertBase20 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ToBase (255, 20), "CF");
	}

	[Test]
	public static void TestBaseConvertBase60 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ToBase (255, 60), "4F");
	}

	[Test]
	public static void TestDecimal ()
	{
		Assert.AreEqual (Punku.Convert.Base.ParseToInt64 ("256"), 256);
	}

	[Test]
	public static void TestHex ()
	{
		Assert.AreEqual (Punku.Convert.Base.ParseToInt64 ("0x100"), 256);
	}

	[Test]
	public static void TestBinary ()
	{
		Assert.AreEqual (Punku.Convert.Base.ParseToInt64 ("b100000000"), 256);
	}

	[Test]
	public static void TestOctal ()
	{

		Assert.AreEqual (Punku.Convert.Base.ParseToInt64 ("021"), 17);
	}

	[Test]
	public static void TestBaseConversion ()
	{
		var x = new Punku.Convert.Base ("255");
		Assert.AreEqual (x.ToDecimal (), 255);
		Assert.AreEqual (x.ToOctal (), "0377");
		Assert.AreEqual (x.ToBinary (), "b11111111");
		Assert.AreEqual (x.ToHex (), "0xff");
	}
}