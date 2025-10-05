public static class Grains
{
    const int allSquares = 64;
    public static ulong Square(int n)
    {
        return n switch
        {
            (<= 0  or  > 64) => throw new ArgumentOutOfRangeException(nameof(n), "n is out of range."), // brackets on the left side for readability*
            _ => (ulong)Math.Pow(2, n-1)
        };

    }

    public static ulong Total() => (ulong)Math.Pow(2, allSquares);
}