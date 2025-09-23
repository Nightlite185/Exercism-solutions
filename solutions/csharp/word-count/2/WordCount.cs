using System.Text.RegularExpressions;
public static partial class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        ArgumentException.ThrowIfNullOrEmpty(phrase);

        return words_digits_apos()
        .Matches(phrase.ToLowerInvariant())
        .GroupBy(w => w.ToString())
        .ToDictionary(w => w.Key, w => w.Count());
    }

    [GeneratedRegex(@"\w+'\w+|\w+")]
    private static partial Regex words_digits_apos();

}