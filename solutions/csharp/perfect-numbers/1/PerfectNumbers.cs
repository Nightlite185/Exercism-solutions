using Xunit.Internal;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static int[] GetAllDivisors(this int number)
    {
        HashSet<int> divisors = [1];

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                divisors.AddRange([i, number/i]);
        }
        
        return [..divisors];
    }
    public static Classification Classify(int number)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(number);

        int summedDivisors = number.GetAllDivisors().Sum();   

        return summedDivisors switch
        {
            int when summedDivisors > number => Classification.Abundant,
            int when summedDivisors < number => Classification.Deficient,

            1 => Classification.Deficient,
            _ => Classification.Perfect
        };

    }
}