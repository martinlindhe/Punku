using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Strings")]
public class MorseCodeTest
{
	[Test]
	public void Decode01 ()
	{
		Assert.AreEqual (Punku.Strings.MorseCode.Decode ("-.. --- - -.. .- ... .... -.. .- ... .... -.. --- -"), "dotdashdashdot");
	}

	[Test]
	public void Encode01 ()
	{
		Assert.AreEqual (Punku.Strings.MorseCode.Encode ("hello world"), ".... . .-.. .-.. ---  .-- --- .-. .-.. -..");
	}
}


