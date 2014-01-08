using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Extensions")]
public class Extensions_Int
{
	[Test]
	public void Negative01 ()
	{
		int x = 1;
		Assert.AreEqual (x.IsNegative (), false);
	}

	[Test]
	public void Negative02 ()
	{
		int x = 0;
		Assert.AreEqual (x.IsNegative (), false);
	}

	[Test]
	public void Negative03 ()
	{
		int x = -1;
		Assert.AreEqual (x.IsNegative (), true);
	}

	[Test]
	public void GetDigitCount01 ()
	{
		int x = 1;
		Assert.AreEqual (x.CountDigits (), 1);
	}

	[Test]
	public void GetDigitCount02 ()
	{
		int x = 1234;
		Assert.AreEqual (x.CountDigits (), 4);
	}

	[Test]
	public void GetDigitCount03 ()
	{
		int x = 99999999;
		Assert.AreEqual (x.CountDigits (), 8);
	}

	[Test]
	public void GetDigitCount04 ()
	{
		int x = 123456789;
		Assert.AreEqual (x.CountDigits (), 9);
	}
}