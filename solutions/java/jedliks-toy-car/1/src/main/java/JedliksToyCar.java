public class JedliksToyCar {

    private int distance = 0;
    private int batteryLvl = 100;

    public static JedliksToyCar buy() {
        return new JedliksToyCar();
    }

    public String distanceDisplay() {
        return "Driven " + distance + " meters";
    }

    public String batteryDisplay() {
        return batteryLvl <= 0
            ? "Battery empty" 
            : "Battery at " + batteryLvl + '%';
    }

    public void drive() {
        if (batteryLvl > 0){
            distance += 20;
            batteryLvl -= 1;
        }
    }
}
