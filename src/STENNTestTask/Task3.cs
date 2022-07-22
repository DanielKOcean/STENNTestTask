using STENNTestTask.Classes.Task3;

namespace STENNTestTask;
public static class Task3
{
    public static List<string> GetTreeNodeNames(Tree tree)
    {
        var treeNames = new List<string>
        {
            tree.Name,
        };

        if(tree.Children?.Count() > 0)
        {
            foreach (var child in tree.Children)
            {
                // Let solve this problem by using recursion. Of course slow, but it works.
                treeNames.AddRange(GetTreeNodeNames(child));
            }
        }        

        return treeNames;
    }
}
