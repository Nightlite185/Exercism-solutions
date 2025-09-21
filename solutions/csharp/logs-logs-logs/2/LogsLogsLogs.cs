enum LogLevel
{
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42,
    Unknown = 0
}
static class LogLine
{
    private static readonly Dictionary<string, LogLevel> dict = new()
    {
        {"TRC", LogLevel.Trace},
        {"DBG", LogLevel.Debug},
        {"INF", LogLevel.Info},
        {"WRN", LogLevel.Warning},
        {"ERR", LogLevel.Error},
        {"FTL", LogLevel.Fatal}
    };
    public static LogLevel ParseLogLevel(string logLine)
    {
        int levelEndIdx = logLine.IndexOf(']');
        string logLineParsed = logLine[1..levelEndIdx];

        return dict.TryGetValue(logLineParsed, out LogLevel level) ?
            level:
                LogLevel.Unknown;
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        return $"{(int)logLevel}:{message}";
    }
}