public static class BottleSong
{
    private static readonly string[] numbers = ["Ten", "Nine", "Eight", "Seven", "Six", "Five", "Four", "Three", "Two", "One", "no"];
    private const string PluralFirstVerse = "green bottles hanging on the wall";
    private const string SingularFirstVerse = "One green bottle hanging on the wall,";
    private const string ThirdVerse = "And if one green bottle should accidentally fall,";

    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(startBottles, 10);       // 10 bc we only account for no more than 10 bottles in the song, sorry not sorry lol
        ArgumentOutOfRangeException.ThrowIfGreaterThan(takeDown, startBottles);
        List<string> strings = [];

        for (int i = 1; i <= takeDown; i++)
        {
            int idx = 10 - startBottles + i;

            string nextNum = numbers[idx]; 
            string currentNum = numbers[idx - 1];

            string firstVerse = currentNum == "One"
                ? SingularFirstVerse
                : $"{currentNum} {PluralFirstVerse},";

            string forthVerse = nextNum == "One"
                ? "There'll be one green bottle hanging on the wall."
                : $"There'll be {nextNum.ToLower()} {PluralFirstVerse}.";


            strings.AddRange(firstVerse, firstVerse, ThirdVerse, forthVerse);

            if (takeDown != i)
                strings.Add("");
        }
        return strings;
    }
}