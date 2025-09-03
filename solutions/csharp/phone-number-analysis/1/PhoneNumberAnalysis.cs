public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        bool IsNewYork = phoneNumber[..3] == "212";
        bool IsFake = phoneNumber[4..7].All(num => num == '5');
        string LocalNumber = phoneNumber[^4..];

        return (IsNewYork, IsFake, LocalNumber);
    }
    
    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;
    }
}
