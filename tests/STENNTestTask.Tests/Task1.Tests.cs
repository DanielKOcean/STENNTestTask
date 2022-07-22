namespace STENNTestTask.Tests;

public class Task1
{
    [Test]
    [TestCase(1, 2, 3, 2, 3, 1)]
    [TestCase(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue)]
    [TestCase(int.MaxValue, int.MaxValue, int.MaxValue - 1, int.MaxValue, int.MaxValue - 1, int.MaxValue)]
    [TestCase(int.MaxValue, int.MaxValue - 1, int.MaxValue, int.MaxValue - 1, int.MaxValue, int.MaxValue)]
    [TestCase(-1, -2, -3, -2, -3, -1)]
    [TestCase(int.MinValue, int.MinValue, int.MinValue, int.MinValue, int.MinValue, int.MinValue)]
    [TestCase(int.MinValue, int.MinValue, int.MinValue + 1, int.MinValue, int.MinValue + 1, int.MinValue)]
    [TestCase(int.MinValue, int.MinValue + 1, int.MinValue, int.MinValue + 1, int.MinValue, int.MinValue)]
    public void Swap_WhenGetTestValues_ReturnsCorrectResult(int x, int y, int z, int expX, int expY, int expZ)
    {
        STENNTestTask.Task1.Swap(ref x, ref y, ref z);

        Assert.Multiple(() =>
        {
            Assert.That(x, Is.EqualTo(expX));
            Assert.That(y, Is.EqualTo(expY));
            Assert.That(z, Is.EqualTo(expZ));
        });
    }
}