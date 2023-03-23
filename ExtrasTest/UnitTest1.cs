namespace ExtrasTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

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
}