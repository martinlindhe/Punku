using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Extensions")]
public class Extensions_String
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
	public void Alphanumeric01 ()
	{
		Assert.AreEqual ("".IsAlphanumeric (), false);
	}

	[Test]
	public void Alphanumeric02 ()
	{
		Assert.AreEqual (" ".IsAlphanumeric (), false);
	}

	[Test]
	public void Alphanumeric03 ()
	{
		Assert.AreEqual ("1abcEEs".IsAlphanumeric (), true);
	}

	[Test]
	public void Alphanumeric04 ()
	{
		Assert.AreEqual ("ab-".IsAlphanumeric (), false);
	}

	[Test]
	public void Alphanumeric05 ()
	{
		Assert.AreEqual ("'".IsAlphanumeric (), false);
	}

	[Test]
	public void Alphanumeric06 ()
	{
		Assert.AreEqual ("ab'".IsAlphanumeric (), false);
	}

	[Test]
	public void Alphanumeric07 ()
	{
		Assert.AreEqual ("abå".IsAlphanumeric (), false);
	}

	[Test]
	public void NumbersOnly06 ()
	{
		Assert.AreEqual ("1".IsNumbersOnly (), true);
	}

	[Test]
	public void Palindrome01 ()
	{
		Assert.AreEqual ("".IsPalindrome (), false);
	}

	[Test]
	public void Palindrome02 ()
	{
		Assert.AreEqual (" ".IsPalindrome (), false);
	}

	[Test]
	public void Palindrome03 ()
	{
		Assert.AreEqual ("racecar".IsPalindrome (), true);
	}

	[Test]
	public void Palindrome04 ()
	{
		Assert.AreEqual ("hello".IsPalindrome (), false);
	}

	[Test]
	public void ToBase64_01 ()
	{
		Assert.AreEqual ("pleasure.".ToBase64 (), "cGxlYXN1cmUu");
	}

	[Test]
	public void FromBase64_01 ()
	{
		Assert.AreEqual ("aGVsbG8=".FromBase64 (), "hello");
	}
}