using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
public partial class LogParser
{
    private string[] validLogs = ["[TRC]", "[DBG]", "[INF]", "[WRN]", "[ERR]", "[FTL]"];
    public bool IsValidLine(string text)
        => validLogs.Any(c => c == text[..5]);

    public string[] SplitLogLine(string text)
    {
        return WeirdSeparators().Split(text);
    }

    public int CountQuotedPasswords(string lines)
    {
        return PasswordLiteral().Count(lines);
    }

    public string RemoveEndOfLineText(string line)
    {
        return LineEnderWithDigits().Replace(line, "");
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        List<string> finalList = [];

        foreach (string line in lines)
        {
            var match = GuiltyPassword().Match(line);

            if (match.Success)
                finalList.Add($"{match.Value}: {line}");

            else
                finalList.Add($"--------: {line}");
        }
        
        return [.. finalList];
    }

    [GeneratedRegex(@"\bpassword\w+\b", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex GuiltyPassword();
    [GeneratedRegex(@"end-of-line\d+")]
    private static partial Regex LineEnderWithDigits();
    [GeneratedRegex(@"<[=\*\^\-]+>")]
    private static partial Regex WeirdSeparators();
    [GeneratedRegex("\"[^\"]*password[^\"]*\"", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex PasswordLiteral();
}
