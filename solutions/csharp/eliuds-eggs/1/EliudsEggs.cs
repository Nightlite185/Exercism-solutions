public static class EliudsEggs
{
    public static int EggCount(int encodedCount)
    {
        string binary = Convert.ToString(encodedCount, 2);

        return binary.Count(c => c == '1');
    }
}