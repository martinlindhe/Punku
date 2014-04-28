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
		// non characters are always false
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
		// non characters are always false
		Assert.AreEqual (' '.IsLowerCase (), false);
	}
}
