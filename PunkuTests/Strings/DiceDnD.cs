using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Strings")]
public class Strings_DiceDnD
{
	private void RandomCheckRolls (Punku.Game.DiceDnD d)
	{
		Assert.LessOrEqual (d.MinValue, d.Roll ()); 
		Assert.GreaterOrEqual (d.MaxValue, d.Roll ());
	}

	[Test]
	public void Roll1 ()
	{
		var d = new Punku.Game.DiceDnD ("2D6");
		Assert.AreEqual (d.MinValue, 2, "FAIL 1");
		Assert.AreEqual (d.MaxValue, 12, "FAIL 2"); 
		RandomCheckRolls (d);
	}

	[Test]
	public void Roll2 ()
	{
		var d = new Punku.Game.DiceDnD ("1D8+60");
		Assert.AreEqual (d.MinValue, 61, "FAIL 3"); 
		Assert.AreEqual (d.MaxValue, 68, "FAIL 4"); 
		RandomCheckRolls (d);
	}

	[Test]
	public void Roll3 ()
	{
		var d = new Punku.Game.DiceDnD ("10d2-10");
		Assert.AreEqual (d.MinValue, 0, "FAIL 5"); 
		Assert.AreEqual (d.MaxValue, 10, "FAIL 6"); 
		RandomCheckRolls (d);    
	}

	[Test]
	public void Roll4 ()
	{
		var d = Punku.Game.DiceDnD.Roll ("10d2-10");
		Assert.LessOrEqual (10, d, "FAIL 6");  
		Assert.GreaterOrEqual (0, d, "FAIL 5"); 
	}

	[Test]
	[ExpectedException (typeof(ArgumentException))]
	public void Exception01 ()
	{
		new Punku.Game.DiceDnD ("");	
	}

	[Test]
	[ExpectedException (typeof(ArgumentException))]
	public void Exception02 ()
	{
		new Punku.Game.DiceDnD (" ");	
	}
}
