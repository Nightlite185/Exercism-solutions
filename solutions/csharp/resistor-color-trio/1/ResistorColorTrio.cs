public static class ResistorColorTrio
{
    private static Dictionary<string, int> colorNums = new()
    {
        ["black"] = 0,
        ["brown"] = 1,
        ["red"] = 2,
        ["orange"] = 3,
        ["yellow"] = 4,
        ["green"] = 5,
        ["blue"] = 6,
        ["violet"] = 7,
        ["grey"] = 8,
        ["white"] = 9,
    };

    public static string Label(string[] colors)
    {
        colors = colors[0..3];

        if (!colors.All(colorNums.ContainsKey))
            throw new ArgumentException("one of the colors is invalid");

        int[] ints = [.. colors.Select(c => colorNums[c])];

        int firstTwo = ints[0] * 10 + ints[1];

        long value = firstTwo * (long)Math.Pow(10, ints[2]);


        return value switch
        {
            >= 1_000_000_000L => $"{value / 1_000_000_000L} gigaohms",
            >= 1_000_000L => $"{value / 1_000_000L} megaohms",
            >= 1_000L => $"{value / 1_000L} kiloohms",
            _ => $"{value} ohms"
        }; 
    }
}
