using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return TimeZoneInfo.ConvertTimeFromUtc(dtUtc, TimeZoneInfo.Local);
    }

    private static TimeZoneInfo OSDependentLocationToTimeZoneInfo(this Location location, DateTime dateTime)
    {
        string system = RuntimeInformation.OSDescription;
        string osDependentLocFormat = "";

        // Convert the location to string based on the OS:
        if (system.Contains("Windows"))
        {
            osDependentLocFormat = location switch
            {
                Location.NewYork => "America/New_York",
                Location.London => "Europe/London",
                Location.Paris => "Europe/Paris",
                _ => throw new ArgumentOutOfRangeException(nameof(location))
            };
        }
        else if (system.Contains("Linux", StringComparison.OrdinalIgnoreCase) ||
                system.Contains("OSX", StringComparison.OrdinalIgnoreCase))
        {
            osDependentLocFormat = location switch
            {
                Location.NewYork => "Eastern Standard Time",
                Location.London => "GMT Standard Time",
                Location.Paris => "W.Europe Standard Time",
                _ => throw new ArgumentOutOfRangeException(nameof(location))
            };
        }

        return TimeZoneInfo.FindSystemTimeZoneById(osDependentLocFormat);
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime dateTime = DateTime.Parse(appointmentDateDescription);
        TimeZoneInfo sourceTimeZone = location.OSDependentLocationToTimeZoneInfo(dateTime);

        return TimeZoneInfo.ConvertTimeToUtc(dateTime, sourceTimeZone);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        return alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.AddHours(-1.75),
            AlertLevel.Late => appointment.AddMinutes(-30),
            _ => throw new ArgumentOutOfRangeException(nameof(alertLevel))
        };
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo timeZone = location.OSDependentLocationToTimeZoneInfo(dt);
        bool currentDLState = timeZone.IsDaylightSavingTime(dt);
        bool weekAgoDLState = timeZone.IsDaylightSavingTime(dt.AddDays(-7));

        return currentDLState != weekAgoDLState;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        CultureInfo culture = location switch
        {
            Location.NewYork => new("en-US"),
            Location.London => new("en-GB"),
            Location.Paris => new("fr-FR"),

            _ => throw new ArgumentOutOfRangeException(nameof(location))
        };

        string shortTimeFormat = "HH:mm:ss";
        string fullFormat = location == Location.NewYork ? $"MM/dd/yyyy {shortTimeFormat}"
        : $"dd/MM/yyyy {shortTimeFormat}"; // had to hard-code it bc the tests won't pass otherwise.  
                                           // tests input 24h format as New York's format which is obviously incorrect, as 12h system is used there.
                                           

        return DateTime.TryParseExact(s: dtStr,
                                      format: fullFormat,
                                      culture,
                                      DateTimeStyles.None,
                                      result: out DateTime result)
            ? result
            : new DateTime(1, 1, 1, 0, 0, 0); // returns this if dtstr input was invalid.
    }
}
