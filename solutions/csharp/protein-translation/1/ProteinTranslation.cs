public static class ProteinTranslation
{
    private static Dictionary<string, string> codonMap = new()
    {
        ["AUG"] = "Methionine",
    
        ["UUU"] = "Phenylalanine",
        ["UUC"] = "Phenylalanine",

        ["UUA"] = "Leucine",
        ["UUG"] = "Leucine",

        ["UCU"] = "Serine",
        ["UCC"] = "Serine",
        ["UCA"] = "Serine",
        ["UCG"] = "Serine",

        ["UAU"] = "Tyrosine",
        ["UAC"] = "Tyrosine",

        ["UGU"] = "Cysteine",
        ["UGC"] = "Cysteine",

        ["UGG"] = "Tryptophan",

        ["UAA"] = "STOP",
        ["UAG"] = "STOP",
        ["UGA"] = "STOP"
    };
    public static string[] Proteins(string strand)
    {
        var splitted = strand.Chunk(3).Select(c=> new string(c));

        return [.. splitted

            .Select(x=> codonMap.TryGetValue( x, out string? value)
                ? value
                : throw new ArgumentException("Invalid element found in strand")
            )

            .TakeWhile(s => s != "STOP")];
    }
}