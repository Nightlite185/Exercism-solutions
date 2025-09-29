using System.Text;

public static class Raindrops
{
    private static bool Divisible(this int num, int divider) => num % divider == 0;
    public static string Convert(int number)
    {
        var sb = new StringBuilder();

        if (number.Divisible(3))
            sb.Append("Pling");

        if (number.Divisible(5))
            sb.Append("Plang");

        if (number.Divisible(7))
            sb.Append("Plong");

        string result = sb.ToString();

        return string.IsNullOrEmpty(result) ?
            number.ToString() :
            result;
    }
}