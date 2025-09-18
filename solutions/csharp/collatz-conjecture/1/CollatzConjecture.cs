public static class CollatzConjecture
{
    public static bool IsEven(this int number)
    {
        return number % 2 == 0;
    }
    public static int Steps(int number)
    {
        if (number <= 0) throw new ArgumentOutOfRangeException(nameof(number), "number must be positive");
        int i;

        for (i = 0; number != 1; i++)
        {
            if (number.IsEven())
                number /= 2;
            else
                number = number * 3 + 1;
        }

        return i;
    }
}