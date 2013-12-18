using System;
using NUnit.Framework;
using Punku;

[TestFixture]
public class Rot13Test
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
