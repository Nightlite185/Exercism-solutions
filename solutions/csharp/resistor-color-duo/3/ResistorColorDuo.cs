public static class ResistorColorDuo
{
    private static Dictionary<string, int>  colorNums = new()
    {
        ["black"]  =  0,
        ["brown"]  =  1,
        ["red"]    =  2,
        ["orange"] =  3,
        ["yellow"] =  4,
        ["green"]  =  5,
        ["blue"]   =  6,
        ["violet"] =  7,
        ["grey"]   =  8,
        ["white"]  =  9,
    };
    public static int Value(string[] colors)
    {
        colors = colors[0..2];

        if (!colors.All(colorNums.ContainsKey))
            throw new ArgumentException("one of the elements in list is invalid");

        int[] ints = [..colors.Select(c => colorNums[c])];

        return ints[0] * 10 + ints[1]; // this only works if there aren't more than 9 colors.
    }
}