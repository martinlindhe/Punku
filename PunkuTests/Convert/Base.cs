using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Convert")]
public class Convert_Base
{
	[Test]
	public static void BaseConvert01 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ToBase (255, 10), "255");
	}

	[Test]
	public static void BaseConvert02 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ToBase (255, 16), "FF");
	}

	[Test]
	public static void BaseConvert03 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ToBase (255, 8), "377");
	}

	[Test]
	public static void BaseConvert04 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ToBase (255, 2), "11111111");
	}

	[Test]
	public static void ConvertToBase5 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ToBase (255, 5), "2010");
	}

	[Test]
	public static void ConvertToBase12 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ToBase (255, 12), "193");
	}

	[Test]
	public static void ConvertToBase20 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ToBase (255, 20), "CF");
	}

	[Test]
	public static void ConvertToBase60 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ToBase (255, 60), "4F");
	}

	[Test]
	public static void Decimal01 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ParseToInt64 ("256"), 256);
	}

	[Test]
	public static void Hex01 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ParseToInt64 ("0x100"), 256);
	}

	[Test]
	public static void Binary01 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ParseToInt64 ("b100000000"), 256);
	}

	[Test]
	public static void Octal01 ()
	{
		Assert.AreEqual (Punku.Convert.Base.ParseToInt64 ("021"), 17);
	}

	[Test]
	public static void BaseConversion01 ()
	{
		var x = new Punku.Convert.Base ("255");
		Assert.AreEqual (x.Value, 255);
		Assert.AreEqual (x.ToOctal (), "0377");
		Assert.AreEqual (x.ToBinary (), "b11111111");
		Assert.AreEqual (x.ToHex (), "0xff");
	}
}
