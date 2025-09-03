public static class LogAnalysis
{
    public static string SubstringAfter(this string str, string section)
    {
        var idx_after_section = str.IndexOf(section) + section.Length;
        return str[idx_after_section..];
    }

    public static string SubstringBetween(this string str, string left, string right)
    {
        int left_idx = str.IndexOf(left) + left.Length;
        int right_idx = str.IndexOf(right);
        return str[left_idx..right_idx];
    }

    public static string Message(this string str) => str.SubstringAfter(": ");

    public static string LogLevel(this string str) => str.SubstringBetween("[", "]");
}