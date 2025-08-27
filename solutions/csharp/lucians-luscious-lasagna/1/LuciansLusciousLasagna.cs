class Lasagna {
    
    public int ExpectedMinutesInOven()
    {
        return 40;
    }

    public int RemainingMinutesInOven(int elapsed_time)
    {
        return ExpectedMinutesInOven() - elapsed_time;
    }

    public int PreparationTimeInMinutes(int layers)
    {
        return layers * 2;
    }

    public int ElapsedTimeInMinutes(int layers, int elapsed_time)
    {
        return PreparationTimeInMinutes(layers) + elapsed_time;
    }
}
