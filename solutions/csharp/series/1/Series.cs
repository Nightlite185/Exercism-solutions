public static class Series
{
    private static ArgumentException InvalidNumberException
        => new( message: "Given number must be higher than 0 and lower than string's length",
        paramName: "sliceLength");
    public static string[] Slices(string numbers, int sliceLength)
        => sliceLength switch
        {
            int when sliceLength > numbers.Length => throw InvalidNumberException,

            <= 0 => throw InvalidNumberException,

            int when sliceLength == numbers.Length => [numbers],

            1 => [.. numbers.ToArray().Select(char.ToString)],

            _ => [..numbers
            .Index()
            .Where(w => w.Index <= numbers.Length - sliceLength)
            .Select(sel => numbers.Substring(sel.Index, sliceLength))],
        };
}