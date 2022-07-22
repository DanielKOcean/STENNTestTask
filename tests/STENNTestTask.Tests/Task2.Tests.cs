
using STENNTestTask.Classes.Task2;

namespace STENNTestTask.Tests;

public class Task2
{
    [Test]
    public void CarClasses_AreEqual_IfFieldsAreEqual()
    {
        var car1 = new Car { Model = "BMW", Color = "White", Description = "German car" };
        var car2 = new Car { Model = "BMW", Color = "White", Description = "German car" };

        var eq = car1 == car2;

        Assert.That(eq, Is.True);
    }

    [Test]
    public void CarClasses_AreNotEqual_IfFieldsAreNotEqual()
    {
        var car1 = new Car { Model = "BMW", Color = "White", Description = "German car" };
        var car2 = new Car { Model = "Mazda", Color = "Red", Description = "Japanese car" };

        var eq = car1 == car2;

        Assert.That(eq, Is.False);
    }

    [Test]
    public void CarClasses_AreEqual_IfBothNull()
    {
        Car car1 = null;
        Car car2 = null;

        var eq = car1 == car2;

        Assert.That(eq, Is.True);
    }

    [Test]
    public void CarClasses_AreEqual_IfBothHaveOneRef()
    {
        var car1 = new Car { Model = "BMW", Color = "White", Description = "German car" };
        var car2 = car1;

        var eq = car1 == car2;

        Assert.That(eq, Is.True);
    }
}