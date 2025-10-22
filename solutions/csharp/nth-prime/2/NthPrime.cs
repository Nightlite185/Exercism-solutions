public static class NthPrime
{
    private static int Sieve(int upperLimit, int nth)
    {
        var isPrime = new bool[upperLimit + 1];
        int primesFound = 0;

        Array.Fill(isPrime, true);
        isPrime[0] = false; isPrime[1] = false;


        for (int i = 2; i <= upperLimit && primesFound < nth; i++)
        {
            if (!isPrime[i])
                continue;

            primesFound++;

            if (primesFound == nth)
                return i;

            for (long c = (long)i * i; c <= upperLimit; c += i)
                isPrime[c] = false;
        }

        throw new Exception("Estimate too low");
    }
    public static int Prime(int nth)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(nth, 0);
        if (nth == 1) return 2;

        int maxEstimatedPrime = (int)Math.Max(10, nth * Math.Log(nth) + nth * Math.Log(Math.Log(nth))); // estimating the highest nth prime with cursed math
        
        return Sieve(maxEstimatedPrime, nth);
    }
}