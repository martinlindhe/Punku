using System;
using NUnit.Framework;
using Punku;

[TestFixture]
public class TestMorseCode
{
	[Test]
	public void TestDecode ()
	{
		Assert.AreEqual (MorseCode.Decode ("-.. --- - -.. .- ... .... -.. .- ... .... -.. --- -"), "dotdashdashdot");
	}

	[Test]
	public void TestEncode ()
	{
		Assert.AreEqual (MorseCode.Encode ("hello world"), ".... . .-.. .-.. ---  .-- --- .-. .-.. -..");
	}
}


