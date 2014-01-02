using System;
using System.IO;
using NUnit.Framework;
using Punku.Hash;

[TestFixture]
[Category ("Hash")]
public class Hash_Sha2_384
{
	[Test]
	public void EmptyString ()
	{
		Assert.AreEqual (
			"38b060a751ac96384cd9327eb1b1e36a21fdb71114be07434c0cc7bf63f6e1da274edebfe76f65fbd51ad2f14898b95b",
			new Sha2_384 ("").ToString ());
	}

	[Test]
	public void Datablock01 ()
	{
		byte[] x = { 1, 2, 3, 4, 5, 6, 7, 8 };
		Assert.AreEqual (
			"9b110bbc741bb66ac09ed8e066e348990c5dbdb7406a2bdf8d77167364820e06b5c78b53f82015a7887786628374e6ae", 
			new Sha2_384 (x).ToString ());
	}

	[Test]
	public void BrownFox ()
	{
		Assert.AreEqual (
			"ca737f1014a48f4c0b6dd43cb177b0afd9e5169367544c494011e3317dbf9a509cb1e5dc1e85a941bbee3d7f2afbc9b1",
			new Sha2_384 ("The quick brown fox jumps over the lazy dog").ToString ());
	}

	[Test]
	public void ChecksumFromFile ()
	{
		Assert.AreEqual (
			"1d220ac9d0581c6f662986d502f2740d55b9afa9c1d1095888685f92064d569f834dd70e0ffde61cdbb473eaa210bbc1",
			Sha2_384.FromFile ("../../_Resources/binary_file.jpg").ToString ());
	}

	[Test]
	[ExpectedException (typeof(FileNotFoundException))]
	public void FileNotFoundException ()
	{
		Sha2_384.FromFile ("/tmp/no_such_file");
	}
}
