public class PhoneNumber
{
    private const string ErrMessage = "Provided phone number is invalid, please try again.";
    public static ArgumentException InvalidNumberException => new(ErrMessage);
    static private bool N_DigitsInBounds(string phoneNumber)
    {
        const char lowerBound = '2';
        const char upperBound = '9';

        char N1 = phoneNumber[0];

        char N2 = phoneNumber[3];
        return (N1 is >= lowerBound and <= upperBound) &&
               (N2 is >= lowerBound and <= upperBound);
    }

    public static void ThrowIfNumberInvalid(string phoneNumber)
    {
        // chars that are not numbers
        if (!phoneNumber.All(x => char.IsDigit(x)))
            throw InvalidNumberException;

        // if the length of filtered is not 10
        if (phoneNumber.Length != 10)
            throw InvalidNumberException;

        // if the 0th and 3rd index chars are out of their bounds (range 2-9 inclusive)
        if (!N_DigitsInBounds(phoneNumber))
            throw InvalidNumberException;
    }

    
    public static string Clean(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber))
            throw InvalidNumberException;

        char[] punctuation = ['-', '(', ')', ' ', '.', '+'];
        var cleanedNum = string.Concat(phoneNumber.Where(c => !punctuation.Contains(c)));

        if (cleanedNum[0] is '1')
            cleanedNum = cleanedNum.Remove(0,1);

        ThrowIfNumberInvalid(cleanedNum);
        
        return cleanedNum;
    }
}