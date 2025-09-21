using System.Diagnostics;

public class PhoneNumber
{
    private const string InvalidNumberError = "Provided phone number is invalid, please try again.";
    static private bool NumberHasInValidDigits(string phoneNumber, int[] indexesList, (char lowerBound, char upperBound) bounds)
    {
        foreach (var idx in indexesList)
        {
            char c = phoneNumber[idx];
            Debug.WriteLine($"[{idx}] → '{c}' (code: {(int)c})");

            if (c >= bounds.lowerBound && c <= bounds.upperBound)
                Debug.WriteLine("✅ Passed the filter");
            else
                Debug.WriteLine("❌ Failed the filter");
        }



        return

        indexesList
        .Select(idx => phoneNumber[idx])
        .Where(c => c >= bounds.lowerBound && c <= bounds.upperBound)
        .Count() < indexesList.Length;
    }

    static public void ThrowIfNumberInvalid(string phoneNumber)
    {
        int[] twoToNineNumIdxs = [0, 3];
        int[] zeroToNineNumIdxs = [1, 2, 4, 5, 6, 7, 8, 9];

        // chars that are not numbers
        if (!phoneNumber.All(x => char.IsDigit(x)))
            throw new ArgumentException(message: InvalidNumberError, nameof(phoneNumber));

        // if the length of filtered is not 10
        if (phoneNumber.Length != 10)
            throw new ArgumentException(message: InvalidNumberError, nameof(phoneNumber));

        // if the 0th and 3rd index chars are out of their bounds (range 2-9 inclusive)
        if (
                NumberHasInValidDigits(phoneNumber, twoToNineNumIdxs, (lowerBound: '2', upperBound: '9'))
            )
            throw new ArgumentException(message: InvalidNumberError, nameof(phoneNumber));
    }

    
    public static string Clean(string phoneNumber)
    {
        char[] punctuation = ['-', '(', ')', ' ', '.', '+'];
        var parsedNum = string.Concat(phoneNumber.Where(c => !punctuation.Contains(c)))!; // old line : var parsedNum = phoneNumber.Where(c => !punctuation.Contains(c))!;

        if (parsedNum[0] is '1')
            parsedNum = parsedNum.Remove(0,1);

        ThrowIfNumberInvalid(parsedNum);
        
        return parsedNum;
    }
}