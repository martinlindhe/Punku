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
}