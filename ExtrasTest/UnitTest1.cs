using FrisExtras.Misc;

namespace ExtrasTest;

public class Tests
{
    [Test]
    public void IsEvenTest()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Misc.IsEven(2));
            Assert.That(Misc.IsEven(4));
            Assert.That(Misc.IsEven(56));
        });
    }

    [Test]
    public void IsUnevenTest()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Misc.IsEven(3), Is.False);
            Assert.That(Misc.IsEven(5), Is.False);
            Assert.That(Misc.IsEven(57), Is.False);
        });
    }

    [Test]
    public void ContainsIllegalCharCheck()
    {
        var list = new List<string>
        {
            "Test\\",
            "Test\"",
            "Test\'",
            "Test<",
            "Test>",
            "Test?",
            "Test:",
            "Test/",
            "Test|",
            "Test*",
            "Test#",
            "Test%",
            "Test&",
            "Test{",
            "Test}",
            "Test$",
            "Test!",
            "Test@",
            "Test+",
            "Test`",
            "Test=",
            "Test=`{}<>&",
            ".Test",
            "Test.",
            "    "
        };
        
        Assert.Multiple(() =>
        {
            Assert.That(Misc.IllegalCharCheck("Test\\"));
            Assert.That(Misc.IllegalCharCheck("Test\""));
            Assert.That(Misc.IllegalCharCheck("Test\'"));
            Assert.That(Misc.IllegalCharCheck("Test<"));
            Assert.That(Misc.IllegalCharCheck("Test>"));
            Assert.That(Misc.IllegalCharCheck("Test?"));
            Assert.That(Misc.IllegalCharCheck("Test:"));
            Assert.That(Misc.IllegalCharCheck("Test/"));
            Assert.That(Misc.IllegalCharCheck("Test|"));
            Assert.That(Misc.IllegalCharCheck("Test*"));
            Assert.That(Misc.IllegalCharCheck("Test#"));
            Assert.That(Misc.IllegalCharCheck("Test%"));
            Assert.That(Misc.IllegalCharCheck("Test&"));
            Assert.That(Misc.IllegalCharCheck("Test{"));
            Assert.That(Misc.IllegalCharCheck("Test}"));
            Assert.That(Misc.IllegalCharCheck("Test$"));
            Assert.That(Misc.IllegalCharCheck("Test!"));
            Assert.That(Misc.IllegalCharCheck("Test@"));
            Assert.That(Misc.IllegalCharCheck("Test+"));
            Assert.That(Misc.IllegalCharCheck("Test`"));
            Assert.That(Misc.IllegalCharCheck("Test="));
            Assert.That(Misc.IllegalCharCheck("Test=`{}<>&"));
            Assert.That(Misc.IllegalCharCheck(".Test"));
            Assert.That(Misc.IllegalCharCheck("Test."));
            Assert.That(Misc.IllegalCharCheck("   "));
            Assert.That(Misc.IllegalCharCheck(list));
        });
    }

    [Test]
    public void ContainsWhiteSpace()
    {
        var list = new List<string>
        {
            "Test1",
            "Test2",
            " ",
            "      ",
            "Test3"
        };

        Assert.Multiple(() =>
        {
            Assert.That(Misc.WhitespaceCheck("     "));
            Assert.That(Misc.WhitespaceCheck(list));
        });
    }
}