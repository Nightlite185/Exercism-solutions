public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        char[] separators = [' ', '-'];

        return string.Concat(
        phrase
            .Split(separators)
            .Select(w => w.FirstOrDefault(char.IsLetter))
            .Where(c => c != '\0')
            .Select(char.ToUpperInvariant)
        );
    }
}