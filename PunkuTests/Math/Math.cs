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
		ulong x = 123;
		Assert.AreEqual (Punku.Math.IsNarcissisticNumber (x), false);
	}

	[Test]
	public void IsNarcissisticNumber02 ()
	{
		ulong x = 8208;
		Assert.AreEqual (Punku.Math.IsNarcissisticNumber (x), true);
	}

	[Test]
	public void IsNarcissisticNumber03 ()
	{
		ulong x = 32164049651;
		Assert.AreEqual (Punku.Math.IsNarcissisticNumber (x), true);
	}
}