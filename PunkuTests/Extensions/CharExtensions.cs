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
		char c = 'h';

		Assert.AreEqual (
			c.ToHexString (),
			"0068"
		);
	}
}

