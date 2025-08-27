class Lasagna {

    public int ExpectedMinutesInOven() => 40;
    
    public int RemainingMinutesInOven(int elapsed_time) => ExpectedMinutesInOven() - elapsed_time;

    public int PreparationTimeInMinutes(int layers) => layers * 2;

    public int ElapsedTimeInMinutes(int layers, int elapsed_time) => PreparationTimeInMinutes(layers) + elapsed_time;
}
