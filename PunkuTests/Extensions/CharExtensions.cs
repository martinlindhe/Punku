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
		// non characters are always true
		Assert.AreEqual (' '.IsUpperCase (), true);
	}

	[Test]
	public void IsLowerCase01 ()
	{
		Assert.AreEqual ('x'.IsLowerCase (), true);
	}

	[Test]
	public void IsLowerCase02 ()
	{
		// non characters are always true
		Assert.AreEqual (' '.IsLowerCase (), true);
	}
}

