using System.Text;
using System.Text.RegularExpressions;

public static partial class Identifier
{
    private static void SpaceTo_(this StringBuilder sb) => sb.Replace(' ', '_');   // replacing whitespace with _
    private static void ChangeCtrl(this StringBuilder sb) => sb.Replace("\0", "CTRL");   // replacing \0 with CTRL
    private static void KebabToCamelCase(this StringBuilder sb, int hyphenIdx)
    {
        if (hyphenIdx == -1) return; // return quickly if there is no hyphen

        sb[0] = char.ToLower(sb[0]);    // replacing the first char with lowercase variant
        sb[hyphenIdx + 1] = char.ToUpper(sb[hyphenIdx + 1]);
        sb.Remove(hyphenIdx, 1);

    }
    private static void OnlyLettersButNotGreek(this StringBuilder sb)
    {
        string output = sb.ToString();

        output = LettersOnly().Replace(output, "");
        output = OmitGreek().Replace(output, "");

        sb.Clear();
        sb.Append(output);
    }

    public static string Clean(string identifier)
    {
        if (identifier == "") return identifier;    // checking if its not empty, if it is - return quickly " "
        int hyphenIdx = identifier.IndexOf('-');    // noting the index of hyphen in the nickname

        StringBuilder sb = new(identifier);    // creating a new string builder object
        sb.SpaceTo_();

        sb.ChangeCtrl();
        sb.KebabToCamelCase(hyphenIdx);
        sb.OnlyLettersButNotGreek();

        return sb.ToString();
    }

    [GeneratedRegex(@"[\p{IsGreek}]")]
    private static partial Regex OmitGreek();
    [GeneratedRegex(@"[^\p{L}_]")]
    private static partial Regex LettersOnly();
}