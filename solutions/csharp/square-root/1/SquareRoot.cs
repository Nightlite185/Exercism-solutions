public static class SquareRoot
{
    public static int Root(int number)
    {
        int result = 0;
        int potential;
        for (int i = 1; i <= number; i += 2) // I'm Incrementing i by 2 every time for the sake of efficiency.
        {
            potential = i * i;

            if (potential == number)
            {
                result = i;
                break;
            }

            else if (potential > number) // if potential is higher than the number, then the root is just the skipped one,
            {
                result = i - 1; // so we take i-1.
                break;
            }
        }

        return result;
    }
}
