using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Extensions")]
public class Extensions_ULong
{
	[Test]
	public void CountBits01 ()
	{
		ulong x = 1;
		Assert.AreEqual (x.CountBits (), 1);
	}

	[Test]
	public void CountBits02 ()
	{
		ulong x = 0;
		Assert.AreEqual (x.CountBits (), 0);
	}

	[Test]
	public void CountBits03 ()
	{
		ulong x = 0xFF;
		Assert.AreEqual (x.CountBits (), 8);
	}

	[Test]
	public void CountBits04 ()
	{
		ulong x = 0xFFFFF;
		Assert.AreEqual (x.CountBits (), 20);
	}

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

	[Test]
	public static void IsRepdigit01 ()
	{
		ulong x = 1;
		Assert.AreEqual (x.IsRepdigit (), false);
	}

	[Test]
	public static void IsRepdigit02 ()
	{
		ulong x = 4444444;
		Assert.AreEqual (x.IsRepdigit (), true);
	}

	[Test]
	public static void IsRepdigit03 ()
	{
		ulong x = 444445;
		Assert.AreEqual (x.IsRepdigit (), false);
	}

	[Test]
	public static void IsPandigitalNumber01 ()
	{
		ulong x = 1223334444555567890;
		Assert.AreEqual (x.IsPandigitalNumber (10), true);
	}

	[Test]
	public static void IsPandigitalNumber02 ()
	{
		ulong x = 1023456789;
		Assert.AreEqual (x.IsPandigitalNumber (10), true);
	}

	[Test]
	public static void IsPandigitalNumber03 ()
	{
		ulong x = 123456789;
		Assert.AreEqual (x.IsPandigitalNumber (10), false);
	}

	[Test]
	public static void IsPandigitalNumber04 ()
	{
		ulong x = 102345678;
		Assert.AreEqual (x.IsPandigitalNumber (10), false);
	}

	[Test]
	public static void IsPandigitalNumber05 ()
	{
		ulong x = "1023".FromBase (4);
		Assert.AreEqual (x.IsPandigitalNumber (4), true);
	}

	[Test]
	public static void IsPrime01 ()
	{
		ulong x = 223;
		Assert.AreEqual (x.IsPrime (), true);
	}

	[Test]
	public static void IsPrime02 ()
	{
		ulong x = 997;
		Assert.AreEqual (x.IsPrime (), true);
	}

	[Test]
	public static void IsPrime03 ()
	{
		ulong x = 100;
		Assert.AreEqual (x.IsPrime (), false);
	}

	[Test]
	public static void IsEven01 ()
	{
		ulong x = 118;
		Assert.AreEqual (x.IsEven (), true);
	}

	[Test]
	public static void IsEven02 ()
	{
		ulong x = 1977710;
		Assert.AreEqual (x.IsEven (), true);
	}

	[Test]
	public static void IsEven03 ()
	{
		ulong x = 0;
		Assert.AreEqual (x.IsEven (), true);
	}

	[Test]
	public static void IsEven04 ()
	{
		ulong x = 1;
		Assert.AreEqual (x.IsEven (), false);
	}

	[Test]
	public static void IsOdd01 ()
	{
		ulong x = 1;
		Assert.AreEqual (x.IsOdd (), true);
	}

	[Test]
	public static void IsOdd02 ()
	{
		ulong x = 10009;
		Assert.AreEqual (x.IsOdd (), true);
	}

	[Test]
	public static void IsOdd03 ()
	{
		ulong x = 0;
		Assert.AreEqual (x.IsOdd (), false);
	}

	[Test]
	public static void IsOdd04 ()
	{
		ulong x = 4;
		Assert.AreEqual (x.IsOdd (), false);
	}
}
