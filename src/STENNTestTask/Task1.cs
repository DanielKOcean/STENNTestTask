namespace STENNTestTask;
public class Task1
{
    public static void Swap(ref int x, ref int y, ref int z)
    {
        x += y;
        y = x - y;
        x = x - y;

        y += z;
        z = y - z;
        y = y - z;
    }
}
