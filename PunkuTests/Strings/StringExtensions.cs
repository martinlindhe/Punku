using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Strings")]
public class Strings_StringExtensions
{
	[Test]
	public void Repeat01 ()
	{
		Assert.AreEqual ("hej".Repeat (2), "hejhej");
	}

	[Test]
	public void Repeat02 ()
	{
		Assert.AreEqual ("häj".Repeat (2), "häjhäj");
	}

	[Test]
	public void Count01 ()
	{
		Assert.AreEqual ("haj".Count ('a'), 1);
	}

	[Test]
	public void Count02 ()
	{
		Assert.AreEqual ("haaj".Count ('a'), 2);
	}

	[Test]
	public void Count03 ()
	{
		Assert.AreEqual ("häj".Count ('a'), 0);
	}

	[Test]
	public void Count04 ()
	{
		Assert.AreEqual ("haj".Count ('ä'), 0);
	}

	[Test]
	public void NumbersOnly01 ()
	{
		Assert.AreEqual ("123".IsNumbersOnly (), true);
	}

	[Test]
	public void NumbersOnly02 ()
	{
		Assert.AreEqual ("".IsNumbersOnly (), false);
	}

	[Test]
	public void NumbersOnly03 ()
	{
		Assert.AreEqual ("12a".IsNumbersOnly (), false);
	}

	[Test]
	public void NumbersOnly04 ()
	{
		Assert.AreEqual ("1 ".IsNumbersOnly (), false);
	}

	[Test]
	public void NumbersOnly05 ()
	{
		Assert.AreEqual (" 1".IsNumbersOnly (), false);
	}

	[Test]
	public void NumbersOnly06 ()
	{
		Assert.AreEqual ("1".IsNumbersOnly (), true);
	}
}