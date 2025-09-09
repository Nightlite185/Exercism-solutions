class RemoteControlCar
{

    private int _distanceDisplay = 0;
    private int _batteryDisplay = 100;

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_distanceDisplay} meters";
    }

    public string BatteryDisplay()
    {
        return _batteryDisplay<=0? $"Battery empty" :$"Battery at {_batteryDisplay}%";
    }

    public void Drive()
    {

        if (_batteryDisplay > 0)
        {
            _distanceDisplay += 20;
            _batteryDisplay -= 1;
        }
    }
}