using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Strings")]
public class Strings_Luhn
{
	[Test]
	public void Calculate01 ()
	{
		// number taken from wikipedia example
		Assert.AreEqual (Punku.Strings.Luhn.Calculate ("811228987"), 4);
	}

	[Test]
	public void Calculate02 ()
	{
		Assert.AreEqual (Punku.Strings.Luhn.Calculate ("556684863"), 5);
	}

	[Test]
	public void Calculate03 ()
	{
		Assert.AreEqual (Punku.Strings.Luhn.Calculate ("556455465"), 6);
	}

	[Test]
	public void Calculate04 ()
	{
		Assert.AreEqual (Punku.Strings.Luhn.Calculate ("556632022"), 1);
	}

	[Test]
	public void Calculate05 ()
	{
		Assert.AreEqual (Punku.Strings.Luhn.Calculate ("556539135"), 5);
	}

	[Test]
	public void Calculate06 ()
	{
		Assert.AreEqual (Punku.Strings.Luhn.Calculate ("916629873"), 8);
	}

	[Test]
	public void Calculate07 ()
	{
		Assert.AreEqual (Punku.Strings.Luhn.Calculate ("969722774"), 3);
	}
}
