using System.Text;

public static class Say
{
    private enum ChunkMainUnit { None = 1, thousand = 2, million = 3, billion = 4 }

    #region helper methods
    public static IEnumerable<string> Chunkify(this string str, int chunkSize)
    {
        int remainder = str.Length % chunkSize;
        int i = 0;

        if (remainder > 0)
        {
            yield return str[..remainder];
            i = remainder;
        }

        for (; i < str.Length; i += chunkSize)
            yield return str.Substring(i, chunkSize);
    }
    
    private static string SetTeens(int number, ref bool onesSetFlag)
    {
        onesSetFlag = true;
        return $"{teensEnglish[number.StripNum(10)]} "; // adding space at the end
    }
    private static string SetTens(int intTens, ref bool hyphenRequired)
    {
        hyphenRequired = true;
        return tensEnglish[intTens / 10];
    }
    private static string SetOnes(int intOnes, ref bool onesSetFlag)
    {
        onesSetFlag = true;
        return onesEnglish[intOnes];
    }
    private static int StripNum(this int number, int StripFrom)
    => number >= StripFrom
        ? number % StripFrom
        : number;

    #endregion

    #region vocabulary arrays

    private static readonly string[] onesEnglish = ["", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
    private static readonly string[] teensEnglish = ["ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"];
    private static readonly string[] tensEnglish = ["DO NOT USE THIS", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"];

    #endregion

    private static string ProcessChunk(this string strChunk, ChunkMainUnit unit)
    {
        int intChunk = int.Parse(strChunk);
        if (intChunk == 0)
            return "";

        bool areOnesSet = false;
        bool hyphenRequired = false;
        int intTens = intChunk.StripNum(100);
        int intOnes = intChunk.StripNum(10);

        string hundreds = intChunk >= 100
            ? $"{onesEnglish[intChunk / 100]} hundred "
            : "";

        string tens = intTens switch
        {
            >= 10 and < 20 => SetTeens(intChunk, ref areOnesSet),
            >= 20 => SetTens(intTens, ref hyphenRequired),

            _ => "" // this only runs if there are no tens - so the intTens is 0
        };

        string ones = areOnesSet || intOnes == 0
            ? "" 
            : SetOnes(intOnes, ref areOnesSet);

        return $"{hundreds}{tens}{(hyphenRequired && areOnesSet? '-':"")}{ones} {(unit == ChunkMainUnit.None? "": unit)} "; 
    }
    
    public static string InEnglish(long number)
    {
        if (number is < 0 or > 999_999_999_999) 
            throw new ArgumentOutOfRangeException(nameof(number), "number cannot be negative or higher than 999 billion");

        if (number == 0) // return quick if its 0
            return "zero";
            
        int i = -1;
        var sb = new StringBuilder();

        string[] chunks = [..number.ToString().Chunkify(3)];
        
        foreach (var chunk in chunks)
        {
            i++;
            var chunkNum = (ChunkMainUnit)(chunks.Length - i);

            sb.Append(chunk.ProcessChunk(chunkNum));
        }

        return sb.ToString().Trim();
    }
}