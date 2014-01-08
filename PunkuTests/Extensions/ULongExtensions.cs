using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Extensions")]
public class Extensions_ULong
{
	[Test]
	public void CountDigits01 ()
	{
		ulong x = 1;
		Assert.AreEqual (x.CountDigits (), 1);
	}

	[Test]
	public void CountDigits02 ()
	{
		ulong x = 1234;
		Assert.AreEqual (x.CountDigits (), 4);
	}

	[Test]
	public void CountDigits03 ()
	{
		ulong x = 99999999;
		Assert.AreEqual (x.CountDigits (), 8);
	}

	[Test]
	public void CountDigits04 ()
	{
		ulong x = 123456789;
		Assert.AreEqual (x.CountDigits (), 9);
	}

	[Test]
	public void CountDigits05 ()
	{
		ulong x = 0xFFFF;
		Assert.AreEqual (x.CountDigits (16), 4);
	}

	[Test]
	public void CountDigits06 ()
	{
		ulong x = Convert.ToUInt64 ("11111111", 2);
		Assert.AreEqual (x.CountDigits (2), 8);
	}

	[Test]
	public void Digits01 ()
	{
		ulong x = 7;
		Assert.AreEqual (
			x.Digits (10),
			new byte[] { 7 }
		);
	}

	[Test]
	public void Digits02 ()
	{
		ulong x = 123456789;
		Assert.AreEqual (
			x.Digits (10),
			new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
		);
	}

	[Test]
	public static void ToBase01 ()
	{
		ulong x = 255;
		Assert.AreEqual (x.ToBase (8), "377");
	}

	[Test]
	public static void ToBase02 ()
	{
		ulong x = 255;
		Assert.AreEqual (x.ToBase (2), "11111111");
	}
}