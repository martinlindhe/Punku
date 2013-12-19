using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Convert")]
public class Convert_Datasize
{
	[Test]
	public static void Test01 ()
	{
		Assert.AreEqual (Punku.Convert.Datasize.Convert ("megabyte", "byte", 0.5m), 524288);
	}

	[Test]
	public static void Test02 ()
	{
		Assert.AreEqual (Punku.Convert.Datasize.Convert ("megabit", "megabyte", 100), 12.5m);
	}

	[Test]
	public static void Test03 ()
	{
		Assert.AreEqual (Punku.Convert.Datasize.Convert ("gb", "MiB", 1), 1024);
	}

	[Test]
	public static void Test04 ()
	{
		Assert.AreEqual (Punku.Convert.Datasize.Convert ("zb", "tb", 1), 1073741824);
	}

	[Test]
	public static void Test05 ()
	{
		Assert.AreEqual (Punku.Convert.Datasize.Convert ("zettabyte", "exabyte", 1), 1024);
	}

	[Test]
	public static void Test06 ()
	{
		Assert.AreEqual (Punku.Convert.Datasize.Convert ("zettabit", "exabit", 1), 1024);
	}

	[Test]
	public static void ToBytes01 ()
	{
		Assert.AreEqual (Punku.Convert.Datasize.ToBytes ("2 KiB"), 2048);
	}

	[Test]
	public static void ToBytes02 ()
	{
		Assert.AreEqual (Punku.Convert.Datasize.ToBytes ("3M"), 3145728);
	}
}