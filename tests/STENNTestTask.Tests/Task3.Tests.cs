using STENNTestTask.Classes.Task3;

namespace STENNTestTask.Tests;

public class Task3
{
    [Test]
    public void GetTreeNodeNames_WhenInvoked_ReturnExpectedResult()
    {
        var tree = new Tree
        {
            Name = "Name 1",
            Children = new List<Tree>
            {
                new Tree
                {
                    Name = "Name 1.1",
                    Children = new List<Tree>
                    {
                        new Tree
                        {
                            Name = "Name 2.1",
                        },
                        new Tree
                        {
                            Name = "Name 2.2",
                        },
                        new Tree
                        {
                            Name = "Name 2.3",
                        },
                    }
                },
                new Tree
                {
                    Name = "Name 1.2",
                },
                new Tree
                {
                    Name = "Name 1.3",
                },
            }
        };

        var actual = STENNTestTask.Task3.GetTreeNodeNames(tree);

        var expected = new List<string>
        {
            "Name 1",
            "Name 1.1",
            "Name 2.1",
            "Name 2.2",
            "Name 2.3",
            "Name 1.2",
            "Name 1.3",
        };

        Assert.That(actual, Is.EquivalentTo(expected));
    }
}