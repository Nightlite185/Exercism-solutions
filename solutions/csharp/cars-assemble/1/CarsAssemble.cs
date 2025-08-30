static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        return (speed == 0) ? 0 :
        (speed >= 1 && speed <= 4) ? 1 :
        (speed >= 5 && speed <= 8) ? 0.9 :
        (speed == 9) ? 0.8 :
        0.77;
    }

    public static double ProductionRatePerHour(int speed)
    {
        const int carsPerSpeed = 221;
        return carsPerSpeed * speed * SuccessRate(speed);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        const int minutes_in_hour = 60;
        return (int)ProductionRatePerHour(speed) / minutes_in_hour;
    }
}
