public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
            throw new ArgumentException("Strand lengths differ.");

        return firstStrand
            .Zip(secondStrand, (nuc_1, nuc_2) => nuc_1 != nuc_2)
            .Count(nuc => nuc == true);
    }
}