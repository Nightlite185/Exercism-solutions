public static class ResistorColor
{
    private static string[] colorsList = ["black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"];
    private static Dictionary<string, int> colorCodeMap = colorsList
        .Select((color, index) => new { color, index })

        .ToDictionary(
               key => key.color,
               val => val.index
        );

    public static int ColorCode(string color)
    {
        return colorCodeMap[color];
    }

    public static string[] Colors()
    {
        return colorsList;
    }
}