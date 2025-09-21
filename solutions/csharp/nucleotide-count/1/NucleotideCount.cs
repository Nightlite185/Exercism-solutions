public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        ArgumentNullException.ThrowIfNull(sequence);

        var dict = new Dictionary<char, int>
        {
            ['G'] = 0,
            ['A'] = 0,
            ['T'] = 0,
            ['C'] = 0
        };

        foreach (char nuc in sequence)
        {
            if (dict.ContainsKey(nuc))
                dict[nuc] += 1;

            else
                throw new ArgumentException("Sequence is not proper DNA, as it contains invalid characters.", nameof(sequence));
        }
        
        return dict;
    }
}