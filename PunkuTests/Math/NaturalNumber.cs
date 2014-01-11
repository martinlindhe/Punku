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
		var x = new NaturalNumber ("11111111", 2);
		Assert.AreEqual (x.ToDecimal (), 255);
	}

	[Test]
	public void ToDecimal10 ()
	{
		var x = new NaturalNumber ("FF", 16);
		Assert.AreEqual (x.ToDecimal (), 255);
	}

	[Test]
	public void ToString01 ()
	{
		var x = new NaturalNumber ("123", 10);
		Assert.AreEqual (
			x.ToString (),
			"123"
		);
	}

	[Test]
	public void Parse01 ()
	{
		var x = new NaturalNumber ("123");
		Assert.AreEqual (
			x.Digits, 
			new byte[] { 1, 2, 3 }
		);
	}

	[Test]
	public void Parse02 ()
	{
		var x = new NaturalNumber ("0");
		Assert.AreEqual (
			x.Digits, 
			new byte[] { 0 }
		);
	}

	[Test]
	public void Equals01 ()
	{
		// validates NaturalNumber.Equals()
		var n1 = new NaturalNumber ("123", 10);
		var n2 = new NaturalNumber ("123", 10);
		Assert.AreEqual (n1.Equals (n2), true);
	}

	[Test]
	public void Equals02 ()
	{
		// validates NaturalNumber.Equals()
		var n1 = new NaturalNumber ("123", 10);
		var n2 = new NaturalNumber ("456", 10);
		Assert.AreEqual (n1.Equals (n2), false);
	}

	[Test]
	public void Equals03 ()
	{
		// validates NaturalNumber equality "==" overload
		var n1 = new NaturalNumber ("777", 8);
		var n2 = new NaturalNumber ("777", 8);
		Assert.AreEqual (n1 == n2, true);
	}

	[Test]
	public void Add01 ()
	{
		// validate add resulting in same-length number
		var n1 = new NaturalNumber ("435", 10);
		var n2 = new NaturalNumber ("101", 10);
		Assert.AreEqual (
			(n1 + n2).ToDecimal (),
			536
		);
	}

	[Test]
	public void Add02 ()
	{
		// validate add resulting in 1 digit larger number
		var n1 = new NaturalNumber ("1", 10);
		var n2 = new NaturalNumber ("11", 10);
		Assert.AreEqual (
			(n1 + n2).ToDecimal (),
			12
		);
	}

	[Test]
	public void Add03 ()
	{
		// validate add with single carry
		var n1 = new NaturalNumber ("19", 10);
		var n2 = new NaturalNumber ("12", 10);
		Assert.AreEqual (
			(n1 + n2).ToDecimal (),
			31
		);
	}

	[Test]
	public void Add04 ()
	{
		// validate add resulting in 1 digit larger number
		var n1 = new NaturalNumber ("90", 10);
		var n2 = new NaturalNumber ("30", 10);
		Assert.AreEqual (
			(n1 + n2).ToDecimal (),
			120
		);
	}
}
