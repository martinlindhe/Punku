using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Strings")]
public class StringExtensionTest
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
}