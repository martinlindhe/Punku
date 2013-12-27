using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Strings")]
public class Strings_Invert
{
	[Test]
	public void Test01 ()
	{
		Assert.AreEqual (Punku.Strings.Invert.InvertEnglish ("ellwll"), "voodoo");
	}

	[Test]
	public void Test02 ()
	{
		Assert.AreEqual (Punku.Strings.Invert.InvertEnglish ("hrnkov"), "simple");
	}
}
