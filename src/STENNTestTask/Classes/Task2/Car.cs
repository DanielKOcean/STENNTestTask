using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("STENNTestTask.Benchmarks")]
[assembly: InternalsVisibleTo("STENNTestTask.Tests")]
namespace STENNTestTask.Classes.Task2;

public class Car : IEquatable<Car>

{
    public string Model { get; set; }

    public string Color { get; set; }

    public string Description { get; set; }


    internal int GetHashCodeConcat() => $"{Model}_{Color}_{Description}".GetHashCode();

    // Benchmarked: Get hash wia tuple doesn't allocate memory, but has worst execution time results.
    internal int GetHashCodeTuple() => (Model, Color, Description).GetHashCode();

    // Benchmarked: Does not allocate memory and have middle performance
    internal int GetHashCodeCombine() => HashCode.Combine(Model, Color, Description);

    // Let's try to avoid useless memory allocations, so no string concatinations.
    // Benchmarked: Practically twice faster than using concat + zero memory allocation against ~1kB with concat.
    internal int GetHashCodeXOR() =>
        Model.GetHashCode() ^
        Color.GetHashCode() ^
        Description.GetHashCode();

    public override int GetHashCode() => GetHashCodeCombine(); // I like to use out-of-the-box solutions :)

    public override bool Equals(object obj) => Equals(obj as Car);

    public bool Equals(Car other)
    {
        if (other is null)
            return false;

        // If references are equal, we know that everithing inside class is 100% equal.
        if (ReferenceEquals(this, other))
            return true;

        // I think we need to check run-time types, too.
        if (GetType() != other.GetType())
            return false;

        // If previous conditions has passed through, just compare fields.
        return (Model == other.Model) &&
            (Color == other.Color) &&
            (Description == other.Description);

        // Sometimes it would be enough
        //return other is not null &&
        //    (Model == other.Model) &&
        //    (Color == other.Color) &&
        //    (Description == other.Description);
    }

    public static bool operator ==(Car lhs, Car rhs)
    {
        if (lhs is null)
        {
            if (rhs is null)
            {
                // null == null
                return true;
            }

            return false;
        }

        // If bouth are null, just use existing method.
        return lhs.Equals(rhs);
    }

    // Not equal operator - easy.
    public static bool operator !=(Car lhs, Car rhs) => !(lhs == rhs);
}
