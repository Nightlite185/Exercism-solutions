public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        word = new string([.. word.ToLowerInvariant().Where(char.IsLetter)]);

        HashSet<char> chars = [.. word];
        return chars.Count == word.Length;
    }
}