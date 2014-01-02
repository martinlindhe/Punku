using System;
using System.IO;
using NUnit.Framework;
using Punku.Hash;

[TestFixture]
[Category ("Hash")]
public class Hash_Sha2_512
{
	[Test]
	public void EmptyString ()
	{
		Assert.AreEqual (
			"cf83e1357eefb8bdf1542850d66d8007d620e4050b5715dc83f4a921d36ce9ce47d0d13c5d85f2b0ff8318d2877eec2f63b931bd47417a81a538327af927da3e",
			new Sha2_512 ("").ToString ());
	}

	[Test]
	public void BrownFox ()
	{
		Assert.AreEqual (
			"07e547d9586f6a73f73fbac0435ed76951218fb7d0c8d788a309d785436bbb642e93a252a954f23912547d1e8a3b5ed6e1bfd7097821233fa0538f3db854fee6",
			new Sha2_512 ("The quick brown fox jumps over the lazy dog").ToString ());
	}

	[Test]
	public void ChecksumFromFile ()
	{
		Assert.AreEqual (
			"ec2d27359ed8b286545cb7b64830c1cd9ac6dbe4d4fd4bd1fb79da4247511b79bbcff9edfbdfbf20070bdf0cb22485478e8b6b07bb9f12c9a46ad2a996c2c666",
			Sha2_512.FromFile ("../../_Resources/binary_file.jpg").ToString ());
	}

	[Test]
	[ExpectedException (typeof(FileNotFoundException))]
	public void FileNotFoundException ()
	{
		Sha2_512.FromFile ("/tmp/no_such_file");
	}
}
