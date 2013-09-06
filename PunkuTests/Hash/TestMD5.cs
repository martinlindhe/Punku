using System;
using System.IO;
using NUnit.Framework;
using Punku.Hash;

[TestFixture]
public class TestMD5
{
    [Test]
    public void RunTestEmptyString()
    {
        Assert.AreEqual(
            "d41d8cd98f00b204e9800998ecf8427e",
            new MD5("").ToString());
    }

    [Test]
    public void RunTestBrownFox()
    {
        Assert.AreEqual(
            "9e107d9d372bb6826bd81d3542a419d6",
            new MD5("The quick brown fox jumps over the lazy dog").ToString());
    }

    [Test]
    public void RunTestChecksumFromFile()
    {
        Assert.AreEqual(
            "5523c90d6373e63b34c483683434f45e",
            MD5.FromFile("../../resources/binary_file.jpg").ToString());
    }

    [Test]
    [ExpectedException(typeof(FileNotFoundException))]
    public void TestFileNotFoundException()
    {
        MD5.FromFile("/tmp/no_such_file");
    }
}
