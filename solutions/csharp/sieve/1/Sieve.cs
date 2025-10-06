public static class Sieve
{
    public static int[] Primes(int limit)
    {
        List<int> numbers = [.. Enumerable.Range(2, limit-1)];

        List<int> primes = [];
        HashSet<int> notPrime = [];

        int idx = -1;

        foreach (int num in numbers)
        {
            idx++;

            if (notPrime.Contains(num))
                continue;

            else
            {
                notPrime.UnionWith(numbers.Skip(idx).Where(a => a % num == 0));
                primes.Add(num);
            }
        }

        return [..primes];
    }
}