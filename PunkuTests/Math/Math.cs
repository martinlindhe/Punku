using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Math")]
public class Math_Tests
{
	[Test]
	public void IsNarcissisticNumber01 ()
	{
		int x = 123;
		Assert.AreEqual (Punku.Math.IsNarcissisticNumber (x), false);
	}

	[Test]
	public void IsNarcissisticNumber02 ()
	{
		int x = 8208;
		Assert.AreEqual (Punku.Math.IsNarcissisticNumber (x), true);
	}
}