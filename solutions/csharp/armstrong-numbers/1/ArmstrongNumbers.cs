public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        string strNum = number.ToString();

        int result = (int)strNum
            .Select(d => Math.Pow(d-'0', strNum.Length)) // char d - '0' --> gives the actual digit that the d was representing.
            .Sum();

        return result == number;
    }
}