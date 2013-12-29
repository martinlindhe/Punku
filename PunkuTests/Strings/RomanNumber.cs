using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Strings")]
public class Strings_RomanNumber
{
	[Test]
	public void DecimalToRoman01 ()
	{
		Assert.AreEqual (Punku.Strings.RomanNumber.DecimalToRoman (1955), "MCMLV");
	}

	[Test]
	public void DecimalToRoman02 ()
	{
		Assert.AreEqual (Punku.Strings.RomanNumber.DecimalToRoman (1666), "MDCLXVI");
	}

	[Test]
	public void RomanToDecimal01 ()
	{
		Assert.AreEqual (Punku.Strings.RomanNumber.RomanToDecimal ("LXXX"), 80);
	}

	[Test]
	public void RomanToDecimal02 ()
	{
		Assert.AreEqual (Punku.Strings.RomanNumber.RomanToDecimal ("MMX"), 2010);
	}

	[Test]
	public void RomanToDecimal03 ()
	{
		Assert.AreEqual (Punku.Strings.RomanNumber.RomanToDecimal ("MCMXCIX"), 1999);
	}

	[Test]
	public void RomanToDecimal04 ()
	{
		Assert.AreEqual (Punku.Strings.RomanNumber.RomanToDecimal ("MCMLXXXVIII"), 1988);
	}

	[Test]
	public void RomanToDecimal05 ()
	{
		Assert.AreEqual (Punku.Strings.RomanNumber.RomanToDecimal ("MMMMCMXCIX"), 4999);
	}
}