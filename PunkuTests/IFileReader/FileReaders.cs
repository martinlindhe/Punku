using System;
using System.IO;
using NUnit.Framework;
using Punku;

[TestFixture]
public class TestFileReaders
{
    [Test]
    public void TestBinary()
    {
        var x = new Punku.BinaryReader("/home/ml/WNDAP360_RM_03May2011.pdf");

        Console.WriteLine("size is " + x.Length);
    }

    [Test]
    public void TestImage()
    {
        var x = new Punku.ImageReader("/home/ml/WNDAP360_RM_03May2011.pdf");

        Console.WriteLine("size is " +x.Width + " x " +x.Height);
    }
}