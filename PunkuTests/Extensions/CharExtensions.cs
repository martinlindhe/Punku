using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Extensions")]
public class Extensions_Char
{
	[Test]
	public void ToHexString01 ()
	{
		Assert.AreEqual (
			'h'.ToHexString (),
			"0068"
		);
	}

	[Test]
	public void IsUpperCase01 ()
	{
		Assert.AreEqual ('X'.IsUpperCase (), true);
	}

	[Test]
	public void IsUpperCase02 ()
	{
		Assert.AreEqual ('Ö'.IsUpperCase (), true);
	}

	[Test]
	public void IsUpperCase03 ()
	{
		// NOTE non characters are always false
		Assert.AreEqual (' '.IsUpperCase (), false);
	}

	[Test]
	public void IsLowerCase01 ()
	{
		Assert.AreEqual ('x'.IsLowerCase (), true);
	}

	[Test]
	public void IsLowerCase02 ()
	{
		Assert.AreEqual ('ö'.IsLowerCase (), true);
	}

	[Test]
	public void IsLowerCase03 ()
	{
		// NOTE non characters are always false
		Assert.AreEqual (' '.IsLowerCase (), false);
	}

	[Test]
	public void IsAsciiLetter1 ()
	{
		Assert.AreEqual ('o'.IsAsciiLetter (), true);
	}

	[Test]
	public void IsAsciiLetter2 ()
	{
		Assert.AreEqual ('ö'.IsAsciiLetter (), false);
	}

	[Test]
	public void IsAsciiLetter3 ()
	{
		Assert.AreEqual ('4'.IsAsciiLetter (), false);
	}

	[Test]
	public void IsAsciiDigit1 ()
	{
		Assert.AreEqual ('7'.IsAsciiDigit (), true);
	}

	[Test]
	public void IsAsciiDigit2 ()
	{
		Assert.AreEqual ('f'.IsAsciiDigit (), false);
	}

	[Test]
	public void IsAsciiDigit3 ()
	{
		Assert.AreEqual ('ö'.IsAsciiDigit (), false);
	}
}
