using STENNTestTask.Classes.Task2;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text;

namespace STENNTestTask.Benchmarks;

[MemoryDiagnoser]
public class GetHashCodeConcatVSXOR
{ 
    private readonly Car _car; // Class under benchmark

    public GetHashCodeConcatVSXOR()
    {
        var rand = new Random();

        _car = new Car
        {
            Model = GetRandomString(rand.Next(5, 257)),
            Color = GetRandomString(rand.Next(5, 257)),
            Description = GetRandomString(rand.Next(5, 257)),
        };
    }

    // Simple string randomizer just for test
    internal static string GetRandomString(int stringLength)
    {
        var sb = new StringBuilder();
        int numGuidsToConcat = (((stringLength - 1) / 32) + 1);
        for (int i = 1; i <= numGuidsToConcat; i++)
        {
            sb.Append(Guid.NewGuid().ToString("N"));
        }

        return sb.ToString(0, stringLength);
    }

    [Benchmark]
    public int GetHashCodeConcat() => _car.GetHashCodeConcat();

    [Benchmark]
    public int GetHashCodeTuple() => _car.GetHashCodeTuple();

    [Benchmark]
    public int GetHashCodeCombine() => _car.GetHashCodeCombine();

    [Benchmark]
    public int GetHashCodeXOR() => _car.GetHashCodeXOR();
}

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
    }
}
