using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Math")]
public class Math_NaturalNumber
{
	[Test]
	public void ToDecimal01 ()
	{
		var bb = new NaturalNumber ("12345");
		Assert.AreEqual (bb.ToDecimal (), 12345);
	}

	[Test]
	public void ToDecimal02 ()
	{
		var bb = new NaturalNumber ("00012345");
		Assert.AreEqual (bb.ToDecimal (), 12345);
	}
}
