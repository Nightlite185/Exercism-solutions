public static class EliudsEggs
{
    public static int EggCount(int encodedCount)
    {
        int i = 0;

        while (encodedCount != 0)
        {
            if ((encodedCount & 1) != 0)
                i++;

            encodedCount >>= 1;
        }

        return i;
    }
}