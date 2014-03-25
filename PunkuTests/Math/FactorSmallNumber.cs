using System;
using NUnit.Framework;
using Punku;
using System.Collections.Generic;

[TestFixture]
[Category ("Math")]
public class Math_FactorSmallNumber
{
	[Test]
	public void Factor01 ()
	{
		Assert.AreEqual (
			Punku.Math.FactorSmallNumber.Factor (362), 
			new List<long> { 2, 181 }
		);
	}
}
