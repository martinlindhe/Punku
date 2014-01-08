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
	public void CountDigits01 ()
	{
		int x = 1;
		Assert.AreEqual (x.CountDigits (), 1);
	}

	[Test]
	public void CountDigits02 ()
	{
		int x = 1234;
		Assert.AreEqual (x.CountDigits (), 4);
	}

	[Test]
	public void CountDigits03 ()
	{
		int x = 99999999;
		Assert.AreEqual (x.CountDigits (), 8);
	}

	[Test]
	public void CountDigits04 ()
	{
		int x = 123456789;
		Assert.AreEqual (x.CountDigits (), 9);
	}

	[Test]
	public void Digits01 ()
	{
		int x = 7;
		Assert.AreEqual (
			x.Digits (),
			new byte[] { 7 }
		);
	}

	[Test]
	public void Digits02 ()
	{
		int x = 123456789;
		Assert.AreEqual (
			x.Digits (),
			new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
		);
	}
}