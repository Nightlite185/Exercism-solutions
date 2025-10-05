public static class Grains
{
    const int allSquares = 64;
    public static ulong Square(int n)
    {
        return n switch
        {
            (<= 0  or  > 64) => throw new ArgumentOutOfRangeException(nameof(n), "n is out of range."),
            1 => 1,
            _ => (ulong)Math.Pow(2, n-1)
        };

    }

    public static ulong Total()
    {
        return (ulong)Math.Pow(2, allSquares);
    }
}