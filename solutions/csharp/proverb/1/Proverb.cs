public static class Proverb
{
    public static string[] Recite(string[] subjects) 
        => subjects.Length == 0 // if its empty - return empty string[]
            ? []                 
            
            : [..subjects
            .Index()
            .Skip(1)            // starting from 1st index and using previous index instead of current one to avoid stepping out of array's bounds.
            .Select(s => $"For want of a {subjects[s.Index - 1]} the {s.Item} was lost.") 
            .Append($"And all for the want of a {subjects[0]}.")];
}