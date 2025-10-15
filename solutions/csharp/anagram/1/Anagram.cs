public class Anagram(string @base)
{
    private readonly string baseWord = @base.ToLowerInvariant();
    private static bool DictEquals(Dictionary<char, int> dict1, Dictionary<char, int> dict2)
    {
        if (dict1.Count != dict2.Count) // this line checks if the dict2 doesn't have more keys than dict1
            return false;               // that we didn't go through, bc this only iterates through dict1's kvps

        foreach (KeyValuePair<char, int> kvp in dict1)
        {
            if (dict2.TryGetValue(kvp.Key, out int value))
                if (value == kvp.Value)
                    continue;

            return false;
        }

        return true;
    }
    public string[] FindAnagrams(string[] potentialMatches)
    {
        if (potentialMatches.Length == 0) // quick return if list empty
            return potentialMatches;

        List<string> anagrams = [];
        Dictionary<char, int> baseWordMap = baseWord.CountBy(x => x).ToDictionary();


        foreach (string potWord in potentialMatches)
        {
            string potLowerCase = potWord.ToLowerInvariant();

            if (potLowerCase == baseWord) // a word can't be its own anagram
                continue;

            Dictionary<char, int> potMap = potLowerCase.CountBy(x => x).ToDictionary();

            if (DictEquals(baseWordMap, potMap))
                anagrams.Add(potWord);
        }
        
        return [..anagrams];
    }
}