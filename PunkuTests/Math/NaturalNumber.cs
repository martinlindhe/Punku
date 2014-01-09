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
		var x = new NaturalNumber ("12345");
		Assert.AreEqual (x.ToDecimal (), 12345);
	}

	[Test]
	public void ToDecimal02 ()
	{
		var x = new NaturalNumber ("00012345");
		Assert.AreEqual (x.ToDecimal (), 12345);
	}

	[Test]
	public void ToDecimal03 ()
	{
		var x = new NaturalNumber ("0");
		Assert.AreEqual (x.ToDecimal (), 0);
	}

	[Test]
	[ExpectedException (typeof(ArgumentOutOfRangeException))]
	public void ToDecimal04 ()
	{
		var x = new NaturalNumber ("");
	}

	[ExpectedException (typeof(ArgumentOutOfRangeException))]
	public void ToDecimal05 ()
	{
		var x = new NaturalNumber ("1", 1);
	}

	[ExpectedException (typeof(ArgumentOutOfRangeException))]
	public void ToDecimal06 ()
	{
		var x = new NaturalNumber ("1", 0);
	}

	[Test]
	public void ToDecimal07 ()
	{
		var x = new NaturalNumber ("79228162514264337593543950335");
		Assert.AreEqual (x.ToDecimal (), Decimal.MaxValue);
	}

	[Test]
	[ExpectedException (typeof(OverflowException))]
	public void ToDecimal08 ()
	{
		var x = new NaturalNumber ("79228162514264337593543950336");
		x.ToDecimal ();
	}

	[Test]
	public void ToDecimal09 ()
	{
		var bb = new NaturalNumber ("11111111", 2);
		Assert.AreEqual (bb.ToDecimal (), 255);
	}

	[Test]
	public void ToDecimal10 ()
	{
		var bb = new NaturalNumber ("FF", 16);
		Assert.AreEqual (bb.ToDecimal (), 255);
	}

	[Test]
	public void Verify01 ()
	{
		var x = new NaturalNumber ("123");
		Assert.AreEqual (
			x.Digits, 
			new byte[] { 1, 2, 3 }
		);
	}

	[Test]
	public void Verify02 ()
	{
		var x = new NaturalNumber ("0");
		Assert.AreEqual (
			x.Digits, 
			new byte[] { 0 }
		);
	}
}
