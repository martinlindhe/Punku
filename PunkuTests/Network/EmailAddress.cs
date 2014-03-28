using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Network")]
public class Network_EmailAddress
{
	[Test]
	public void Valid01 ()
	{
		Assert.AreEqual (Punku.Network.EmailAddress.IsValid ("a@test.com"), true);
	}

	[Test]
	public void Valid02 ()
	{
		Assert.AreEqual (Punku.Network.EmailAddress.IsValid ("first.last@test.com"), true);
	}

	[Test]
	public void Valid03 ()
	{
		Assert.AreEqual (Punku.Network.EmailAddress.IsValid ("first-last@test.com"), true);
	}

	[Test]
	public void Valid04 ()
	{
		Assert.AreEqual (Punku.Network.EmailAddress.IsValid ("1@test.com"), true);
	}

	[Test]
	public void Valid05 ()
	{
		// NOTE: we allow utf-8 in email addresses
		Assert.AreEqual (Punku.Network.EmailAddress.IsValid ("körv@test.com"), true);
	}

	[Test]
	public void Invalid01 ()
	{
		Assert.AreEqual (Punku.Network.EmailAddress.IsValid ("a*@test.com"), false);
	}

	[Test]
	public void Invalid02 ()
	{
		Assert.AreEqual (Punku.Network.EmailAddress.IsValid ("a?@test.com"), false);
	}

	[Test]
	public void Invalid03 ()
	{
		Assert.AreEqual (Punku.Network.EmailAddress.IsValid ("a#@test.com"), false);
	}

	[Test]
	public void Invalid04 ()
	{
		Assert.AreEqual (Punku.Network.EmailAddress.IsValid ("first@last@test.com"), false);
	}

	[Test]
	public void Invalid05 ()
	{
		Assert.AreEqual (Punku.Network.EmailAddress.IsValid ("first@@test.com"), false);
	}

	[Test]
	public void Invalid06 ()
	{
		Assert.AreEqual (Punku.Network.EmailAddress.IsValid ("hej.hej.com"), false);
	}

	[Test]
	public void Invalid07 ()
	{
		Assert.AreEqual (Punku.Network.EmailAddress.IsValid ("@hej.hej.com"), false);
	}

	[Test]
	public void Invalid08 ()
	{
		Assert.AreEqual (Punku.Network.EmailAddress.IsValid ("hej@hej."), false);
	}

	[Test]
	public void Invalid09 ()
	{
		Assert.AreEqual (Punku.Network.EmailAddress.IsValid ("hej@hej"), false);
	}
}
