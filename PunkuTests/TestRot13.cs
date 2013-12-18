using System;
using NUnit.Framework;
using Punku;

[TestFixture]
public class TestRot13
{
	[Test]
	public void RunTests ()
	{
		Assert.AreEqual (Rot13.Transform ("secret"), "frperg");
		Assert.AreEqual (Rot13.Transform ("pnrfne fnynq"), "caesar salad");
	}
}
