using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Strings")]
public class Strings_Rot13
{
	[Test]
	public void Test01 ()
	{
		Assert.AreEqual (Punku.Strings.Rot13.Transform ("secret"), "frperg");
	}

	[Test]
	public void Test02 ()
	{
		Assert.AreEqual (Punku.Strings.Rot13.Transform ("pnrfne fnynq"), "caesar salad");
	}
}
