public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old) 
        => old
        .SelectMany(kvp => kvp.Value.Select(letter =>
            KeyValuePair.Create(letter.ToLowerInvariant(), kvp.Key)))
        
        .ToDictionary();
}