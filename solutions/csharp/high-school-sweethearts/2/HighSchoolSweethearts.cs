using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        const int middleLength = 3;
        const int targetLength = 61;

        // int actualTextLength = studentA.Length + studentB.Length + middleLength;     // This line is useless, planned to use it earlier but it turns out 
        const int paddingSize = (targetLength - middleLength) / 2;                      // that it needs to be either a const or a literal, so it cannot be dynamically calculated.

        return $"{studentA,paddingSize} ♡ {studentB,-paddingSize}";
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        const int p = 10;
        const int m = -10;

        return $@"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**{studentA,p}  +  {studentB,m}**
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
";
    }

    public static string DisplayGermanExchangeStudents(
        string studentA,
        string studentB,
        DateTime start,
        float hours)
    {
        string hour = hours.ToString();


        CultureInfo germanCulture = CultureInfo.GetCultureInfo("de-DE");
        return $"{studentA} and {studentB} have been dating since {start:dd'.'MM'.'yyyy} - that's {hours.ToString("N2", germanCulture)} hours";
    }
}
