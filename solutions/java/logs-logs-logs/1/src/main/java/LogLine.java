public class LogLine {
    private final String line;
    private final LogLevel lvl;

    public LogLine(String logLine) {
        line = logLine;

        lvl = switch (line.substring(1, 4)) {
            case "TRC" -> LogLevel.TRACE;
            case "DBG" -> LogLevel.DEBUG;
            case "INF" -> LogLevel.INFO;
            case "WRN" -> LogLevel.WARNING;
            case "ERR" -> LogLevel.ERROR;
            case "FTL" -> LogLevel.FATAL;

            default -> LogLevel.UNKNOWN;
        };
    }

    public LogLevel getLogLevel() { return lvl; }

    public String getOutputForShortLog() {
        var message = line.substring(7);
        
        return lvl.value.toString() + ":" + message;
    }
}
