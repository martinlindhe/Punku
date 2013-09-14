using System;
using NUnit.Framework;
using Punku;

[TestFixture]
public class RomanNumbers
{
	[Test]
	public void Test1 ()
	{
		Assert.AreEqual (RomanNumber.DecimalToRoman (1955), "MCMLV");
	}

	[Test]
	public void Test2 ()
	{
		Assert.AreEqual (RomanNumber.RomanToDecimal ("LXXX"), 80);
		Assert.AreEqual (RomanNumber.RomanToDecimal ("MMX"), 2010);
		Assert.AreEqual (RomanNumber.RomanToDecimal ("MCMXCIX"), 1999);
		Assert.AreEqual (RomanNumber.RomanToDecimal ("MCMLXXXVIII"), 1988);
		Assert.AreEqual (RomanNumber.RomanToDecimal ("MMMMCMXCIX"), 4999);
	}
}