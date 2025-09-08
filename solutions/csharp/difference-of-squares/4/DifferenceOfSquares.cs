public static class DifferenceOfSquares
{

    public static int CalculateSquareOfSum(int max)
    {
        if (max == 1) return 1;

        var num_list = Enumerable.Range(1, max);
        int summed = num_list.Sum();

        return (int)Math.Pow(summed, 2);
    }

    public static int CalculateSumOfSquares(int max)
    {
        if (max == 1) return 1;

        return Enumerable.Range(1, max)
        .Select(n => n*n)
        .Sum();
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}