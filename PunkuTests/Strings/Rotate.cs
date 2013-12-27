using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Strings")]
public class Strings_Rotate
{
	[Test]
	public void Test01 ()
	{
		Assert.AreEqual (Punku.Strings.Rotate.Rot13 ("secret"), "frperg");
	}

	[Test]
	public void Test02 ()
	{
		Assert.AreEqual (Punku.Strings.Rotate.Rot13 ("pnrfne fnynq"), "caesar salad");
	}
}
