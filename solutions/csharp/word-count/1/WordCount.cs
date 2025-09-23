public static class WordCount
{
    private static readonly string[] Separators = [";", ":", ",", ".", " ", @"\t", @"\n", "!", "?"];
    private static bool HasInvalidChar(this string word) => word.Any(c => !char.IsAsciiLetterOrDigit(c) && c != '\'');
    public static IDictionary<string, int> CountWords(string phrase)
    {
        ArgumentException.ThrowIfNullOrEmpty(phrase);
        
        Dictionary<string, int> wordCount = [];
        phrase = phrase.ToLower();

        string[] words_list = phrase.Split(Separators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);


        foreach (string str in words_list)
        {
            string word = str;
            if (word.HasInvalidChar())
                continue;

            if (word == "'")
                continue;

            if (word[0] == '\'')
                word = word[1..];

            if (word.Last() == '\'')
                word = word[..^1];


            wordCount.TryAdd(word, 0);
            wordCount[word] += 1;
        }

        return wordCount;
    }
}