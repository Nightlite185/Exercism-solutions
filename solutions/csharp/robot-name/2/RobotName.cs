public class Robot
{
    private readonly Random random = new();

    private string? _name = null;
    private static List<string> allPreviousNames = [];
    public string Name
    {
        get
        {
            ThrowIfAllNamesUsed();

            if (_name == null)
            {
                string charPrefix = $"{(char)random.Next('A', 'Z' + 1)}{(char)random.Next('A', 'Z' + 1)}"; // adding one bc upper bound is exclusive
                int numSuffix = random.Next(100, 1000); // here as well, would be 999 but had to add one.

                _name = $"{charPrefix}{numSuffix}";

                if (allPreviousNames.Contains(_name))
                {
                    Reset();
                    _name = Name;
                }
                else
                    allPreviousNames.Add(_name);
            }

            return _name;
        }
    }

    public void Reset()
    {
        _name = null;
    }

    public void ThrowIfAllNamesUsed()
    {
        const int allPossibleNamesCount = 676_000;
        if (allPreviousNames.Count == allPossibleNamesCount)
            throw new InvalidOperationException("All possible names are already taken. Please contact our Customer help desk for assistance.");
    }
}