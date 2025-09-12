class RemoteControlCar
{
    public readonly int speed;
    public readonly int batteryDrain;
    private int distanceDriven = 0;
    private int batteryLeft = 100;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        return batteryLeft < batteryDrain;
    }

    public int DistanceDriven()
    {
        return distanceDriven;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            distanceDriven += speed;
            batteryLeft -= batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new(speed: 50, batteryDrain: 4);
    }
}

class RaceTrack
{
    private int distance;
    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        return (car.batteryDrain * distance/car.speed) <= 100;
    }
}
