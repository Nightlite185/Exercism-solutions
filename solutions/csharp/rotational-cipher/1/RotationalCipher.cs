using System.Text;

public static class RotationalCipher
{
    private static readonly string alphabet = "abcdefghijklmnopqrstuvwxyz";
    private const int ALPHABET_LEN = 26;
    public static string Rotate(string text, int shiftKey)
    {
        StringBuilder sb = new();
        
        foreach (char character in text)
        {
            if (shiftKey is > 26 or < 0)
                throw new ArgumentOutOfRangeException(nameof(shiftKey), "shiftKey needs to >= 0 and <= 26");

            int letterIndex = alphabet.IndexOf(character, StringComparison.OrdinalIgnoreCase);

            if (letterIndex == -1)
            {
                sb.Append(character);
                continue;
            }

            int shiftedIndex = letterIndex + shiftKey;

            if (shiftedIndex >= ALPHABET_LEN)
                shiftedIndex -= ALPHABET_LEN; // rolling back to start and starting to index from there.

            char shiftedLetter = char.IsUpper(character)
                ? char.ToUpperInvariant(alphabet[shiftedIndex]) 
                : alphabet[shiftedIndex];

            sb.Append(shiftedLetter);
        }
        
        return sb.ToString();
    }
}