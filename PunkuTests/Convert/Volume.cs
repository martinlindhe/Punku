using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Convert")]
public class Convert_Volume
{
	[Test]
	public static void Test01 ()
	{
		Assert.AreEqual (Punku.Convert.Volume.Convert ("kl", "litres", 1), 1000);
	}

	[Test]
	public static void Test02 ()
	{
		Assert.AreEqual (Punku.Convert.Volume.Convert ("us gallon", "liter", 2), 7.570823568m);
	}

	[Test]
	public static void Test03 ()
	{
		Assert.AreEqual (Punku.Convert.Volume.Convert ("uk gallon", "liter", 2), 9.09218m);
	}

	[Test]
	public static void Test04 ()
	{
		Assert.AreEqual (Punku.Convert.Volume.Convert ("cubic meter", "us gallon", 528), 139482.84364510236332058715861m);
	}

	[Test]
	public static void Test05 ()
	{
		Assert.AreEqual (Punku.Convert.Volume.Convert ("cubic meter", "deciliter", 0.5m), 5000);
	}

	[Test]
	public static void Test06 ()
	{
		Assert.AreEqual (Punku.Convert.Volume.Convert ("deciliter", "liter", 5), 0.5m);
	}

	[Test]
	public static void Test07 ()
	{
		Assert.AreEqual (Punku.Convert.Volume.Convert ("milliliter", "us gallon", 3.785411784m * 2), 0.002m);
	}
}
