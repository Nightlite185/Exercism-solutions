public static class Pangram
{
    public static bool IsPangram(string input)
    {
        const int alphabetLettersCount = 26;

        return input
            .ToLowerInvariant()
            .Where(c => char.IsLetter(c))
            .Distinct()
            .Count()
            == alphabetLettersCount;
    }
}