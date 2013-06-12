using System;
using System.Text;
using NUnit.Framework;
using Punku;

[TestFixture]
public class TestByteArrayPrinter
{
    [Test]
    public void HexString1()
    {
        Assert.AreEqual(
            "",
            ByteArrayPrinter.ToHexString(Encoding.Default.GetBytes ("")) 
        );
    }

    [Test]
    public void HexString2()
    {
        Assert.AreEqual(
            "000102",
            ByteArrayPrinter.ToHexString(Encoding.Default.GetBytes ("\u0000\u0001\u0002"))
        );
    }

    [Test]
    public void HexString3()
    {
        Assert.AreEqual(
            "616263",
            ByteArrayPrinter.ToHexString(Encoding.Default.GetBytes ("abc"))
        );    
    }

    [Test]
    public void CString1()
    {
        Assert.AreEqual(
            "abc",
            ByteArrayPrinter.ToCString(Encoding.Default.GetBytes ("abc"))
        );    
    }

    [Test]
    public void CString2()
    {
        Assert.AreEqual(
            "abc",
            ByteArrayPrinter.ToCString(Encoding.Default.GetBytes ("abc\u00001"))
        );    
    }
}
