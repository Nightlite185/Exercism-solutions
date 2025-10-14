[Flags]
internal enum Actions
{
    wink = 1,
    double_blink = 2,
    close_your_eyes = 4,
    jump = 8,
    Reverse = 16
}

public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        if (commandValue is < 0 or > 31)
            throw new ArgumentOutOfRangeException(nameof(commandValue), "wrong code, get out!!!!");

        List<string> results = []; // could also use IEnumerable<string> but I prefer a List<string> bc of mutability

        foreach (Actions action in Enum.GetValues<Actions>())
        {
            if (action == Actions.Reverse && (commandValue & (int)action) > 0)
                results.Reverse();

            else if ((commandValue & (int)action) > 0)
                results.Add(action.ToString().Replace('_', ' ')); // can't have an enum member containing whitespaces
}                                                                 // so I had to replace it with '_' and here replacing back to whitespaces
                                                                  // in the result bc the tests expect it in this format.
        return [.. results];
    }
}
        