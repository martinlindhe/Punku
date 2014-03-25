using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Strings")]
public class Strings_DottedDecimalNotation
{
	[Test]
	public void Test01 ()
	{
		Assert.AreEqual (Punku.Strings.DottedDecimalNotation.ToDecimalNotation (0x16A), "0.0.1.106");
	}

	[Test]
	public void Test02 ()
	{
		Assert.AreEqual (Punku.Strings.DottedDecimalNotation.ToDecimalNotation (0xFF000000), "255.0.0.0");
	}

	[Test]
	public void Test03 ()
	{
		Assert.AreEqual (Punku.Strings.DottedDecimalNotation.ToDecimalNotation (0xFF0000), "0.255.0.0");
	}

	[Test]
	public void Test04 ()
	{
		Assert.AreEqual (Punku.Strings.DottedDecimalNotation.ToDecimalNotation (0xFF00), "0.0.255.0");
	}

	[Test]
	public void Test05 ()
	{
		Assert.AreEqual (Punku.Strings.DottedDecimalNotation.ToDecimalNotation (0xFF), "0.0.0.255");
	}
}
