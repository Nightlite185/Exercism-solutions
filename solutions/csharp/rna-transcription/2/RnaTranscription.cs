using System.Text;

public static class RnaTranscription
{
    private static readonly Dictionary<char, char> DnaToRna = new()
    {
        ['C'] = 'G',
        ['G'] = 'C',
        ['T'] = 'A',
        ['A'] = 'U'
    };

    public static string ToRna(string strand)
    {
        strand = strand.ToUpperInvariant();
        StringBuilder sb = new();

        foreach (char c in strand)
            sb.Append(DnaToRna.TryGetValue(c, out char val)
                ? val
                : throw new ArgumentException("Strand contains an invalid character.")
            );

        return sb.ToString();
    }
}
