
public static class DifferenceOfSquares
{

    public static int CalculateSquareOfSum(int max)
    {
        if (max == 1) return 1;

        var num_list = Enumerable.Range(1, max);
        int result = 0;

        foreach (int num in num_list)
            result += num;

        result = (int)Math.Pow(result, 2);

        return result;
    }

    public static int CalculateSumOfSquares(int max)
    {
        if (max == 1) return 1;

        var num_list = Enumerable.Range(1, max);
        int result = 0;

        foreach (int num in num_list)
            result += (int)Math.Pow(num, 2);

        return result;
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}