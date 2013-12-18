using System;
using NUnit.Framework;
using Punku;

[TestFixture]
public class MassTest
{
	[Test]
	public static void Test01 ()
	{
		Assert.AreEqual (Punku.Convert.Mass.Convert ("kg", "lb", 500), 1102.3113109243879036148690067m);
	}

	[Test]
	public static void Test02 ()
	{
		Assert.AreEqual (Punku.Convert.Mass.Convert ("lb", "kg", 500), 226.796185m);
	}

	[Test]
	public static void Test03 ()
	{
		Assert.AreEqual (Punku.Convert.Mass.Convert ("t", "kg", 1), 1000);
	}

	[Test]
	public static void Test04 ()
	{
		Assert.AreEqual (Punku.Convert.Mass.Convert ("kg", "t", 2000), 2);
	}

	[Test]
	public static void Test05 ()
	{
		Assert.AreEqual (Punku.Convert.Mass.Convert ("oz", "g", 1), 28.349523125m);
	}

	[Test]
	public static void Test06 ()
	{
		Assert.AreEqual (Punku.Convert.Mass.Convert ("kg", "gram", 1), 1000);
	}
}
