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

    private static CultureInfo ToCulture(this Location location)
    {
        return location switch
        {
            Location.NewYork => CultureInfo.GetCultureInfo("en-US"),
            Location.London => CultureInfo.GetCultureInfo("en-GB"),
            Location.Paris => CultureInfo.GetCultureInfo("fr-FR"),

            _ => throw new ArgumentOutOfRangeException(nameof(location))
        };
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
        return DateTime.TryParse(dtStr, location.ToCulture(), DateTimeStyles.AssumeLocal, out var result)
            ? result
            : DateTime.MinValue;
    }
}