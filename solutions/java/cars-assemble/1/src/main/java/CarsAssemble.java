public class CarsAssemble {

    public double productionRatePerHour(int speed) {
        int carsPerSpeed = 221;
        return carsPerSpeed * speed * successRate(speed);
    }

    private static double successRate(int speed){
        return (speed == 0) ? 0
        : (speed >= 1 && speed <= 4) ? 1
        : (speed >= 5 && speed <= 8) ? 0.9
        : (speed == 9) ? 0.8
        : 0.77;
    }

    public int workingItemsPerMinute(int speed) {
        int minsInHour = 60;
        return (int)productionRatePerHour(speed) / minsInHour;
    }
}