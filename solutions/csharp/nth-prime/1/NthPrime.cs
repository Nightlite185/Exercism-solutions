public static class NthPrime
{
    private static int Sieve(int upperLimit, int nth)
    {
        List<int> numbers = [.. Enumerable.Range(2, upperLimit)];
        int primesFound = 0;
        int currentPrime = 2; // first default and lowest prime
        HashSet<int> notPrime = [];

        for (int idx = 0; idx < numbers.Count && primesFound < nth; idx++)
        {
            int num = numbers[idx];

            if (notPrime.Contains(num))
                continue;

            else
            {
                notPrime.UnionWith(numbers.Skip(idx).Where(a => a % num == 0));
                
                currentPrime = num;
                primesFound++;
            }
        }

        return currentPrime;
    }
    public static int Prime(int nth)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(nth, 0);

        int maxEstimatedPrime = (int)(nth * Math.Log(nth) * 1.5);

        return Sieve(maxEstimatedPrime, nth);
    }
    
    
}