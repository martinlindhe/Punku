using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Network")]
public class Network_EmailAddress
{
	[Test]
	public void IsValid01 ()
	{
		Assert.AreEqual (Punku.Network.EmailAddress.IsValid ("a@test.com"), true);
	}

	[Test]
	public void IsValid02 ()
	{
		Assert.AreEqual (Punku.Network.EmailAddress.IsValid ("first.last@test.com"), true);
	}

	[Test]
	public void IsValid03 ()
	{
		// NOTE: we dont allow utf-8 in email addresses
		Assert.AreEqual (Punku.Network.EmailAddress.IsValid ("körv@test.com"), false);
	}
}
