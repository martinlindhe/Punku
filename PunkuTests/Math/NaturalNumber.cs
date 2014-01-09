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

	[Test]
	public void ToDecimal03 ()
	{
		// NOTE: biggest number that fits in decimal datatype
		var bb = new NaturalNumber ("79228162514264337593543950335");
		Assert.AreEqual (bb.ToDecimal (), 79228162514264337593543950335m);
	}

	[Test]
	[ExpectedException (typeof(OverflowException))]
	public void ToDecimal04 ()
	{
		var bb = new NaturalNumber ("79228162514264337593543950336");
		bb.ToDecimal ();
	}

	[Test]
	public void Verify01 ()
	{
		var bb = new NaturalNumber ("123");
		Assert.AreEqual (
			bb.Digits, 
			new byte[] { 1, 2, 3 }
		);
	}
}
