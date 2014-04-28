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
		Assert.AreEqual (d.MinValue, 2);
		Assert.AreEqual (d.MaxValue, 12); 
		RandomCheckRolls (d);
	}

	[Test]
	public void Roll2 ()
	{
		var d = new Punku.Game.DiceDnD ("1D8+60");
		Assert.AreEqual (d.MinValue, 61); 
		Assert.AreEqual (d.MaxValue, 68); 
		RandomCheckRolls (d);
	}

	[Test]
	public void Roll3 ()
	{
		var d = new Punku.Game.DiceDnD ("10d2-10");
		Assert.AreEqual (d.MinValue, 0); 
		Assert.AreEqual (d.MaxValue, 10); 
		RandomCheckRolls (d);    
	}

	[Test]
	public void RollStatic1 ()
	{
		var d = Punku.Game.DiceDnD.Roll ("10d2-10");
		Assert.GreaterOrEqual (d, 0); 
		Assert.LessOrEqual (d, 10);  
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
