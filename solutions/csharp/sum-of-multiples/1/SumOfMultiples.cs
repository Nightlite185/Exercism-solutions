public static class SumOfMultiples
{
    private static HashSet<int> GetMultiples(this int number, int max)
    {
        if (number <= 0)
            return [0];

        int mult = number;
        HashSet<int> multiples = [];

        while (mult < max)
        {
            multiples.Add(mult);
            mult += number;
        }

        return multiples;
    }
    public static int Sum(IEnumerable<int> multiples, int max)
        => multiples
        .SelectMany(m => m.GetMultiples(max))
        .Distinct() // "To Distinct or not to Distinct, thats the greatest question" or sth like that lol
        .Sum();
}