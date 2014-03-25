using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Strings")]
public class Strings_Ean13
{
	[Test]
	public void Invalid01 ()
	{
		Assert.AreEqual (Punku.Strings.Ean13.IsValid ("7310070030604"), false);
	}

	[Test]
	public void Invalid02 ()
	{
		Assert.AreEqual (Punku.Strings.Ean13.IsValid ("7310500078040"), false);
	}

	[Test]
	public void Invalid03 ()
	{
		Assert.AreEqual (Punku.Strings.Ean13.IsValid ("a310500078040"), false);
	}

	[Test]
	public void Valid01 ()
	{
		// folköl
		Assert.AreEqual (Punku.Strings.Ean13.IsValid ("7310070030603"), true);
	}

	[Test]
	public void Valid02 ()
	{
		// folköl
		Assert.AreEqual (Punku.Strings.Ean13.IsValid ("7310500078045"), true);
	}

	[Test]
	public void Valid03 ()
	{
		// Grov Baksnus 42g
		Assert.AreEqual (Punku.Strings.Ean13.IsValid ("7311250009433"), true);
	}

	[Test]
	public void Valid04 ()
	{
		// Sony SRS-BTM8/BC 230V 50Hz
		Assert.AreEqual (Punku.Strings.Ean13.IsValid ("4905524895223"), true);
	}

	[Test]
	public void Valid05 ()
	{
		// ICA Basic Lättdryck fläder 2dl
		Assert.AreEqual (Punku.Strings.Ean13.IsValid ("7318690084587"), true);
	}

	[Test]
	public void Valid06 ()
	{
		// Hasselnötter med skal, 400g
		Assert.AreEqual (Punku.Strings.Ean13.IsValid ("8006860118109"), true);
	}

	[Test]
	public void Valid07 ()
	{
		// Milky Way godis
		Assert.AreEqual (Punku.Strings.Ean13.IsValid ("5900951020940"), true);
	}

	[Test]
	public void Valid08 ()
	{
		// Coop Änglamark Russin 250g
		Assert.AreEqual (Punku.Strings.Ean13.IsValid ("7340011301547"), true);
	}
}
