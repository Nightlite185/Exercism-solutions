static class LogLine
{
    public static string Message(string logLine)
    {
        return logLine.Substring(logLine.IndexOf(":")+1).Trim(); // we're taking everything what comes after the colon - its the message we want
    }                                                              // and also trimming the whitespace using trim() method

    public static string LogLevel(string logLine)
    {
        int index_to_remove = 0; // the "[" is at index one so we wanna remove it
        int chars_to_remove = 1; // just one character to remove
        int log_lvl_idx = 0;

        string[] splitted = logLine.Split(']');
        return splitted[log_lvl_idx].Remove(index_to_remove, chars_to_remove).ToLower();
    }

    public static string Reformat(string logLine)
    {
        return $"{Message(logLine)} ({LogLevel(logLine)})"; // reformatting it to "<message> (<level>)" using the $string interpolation
    }
}