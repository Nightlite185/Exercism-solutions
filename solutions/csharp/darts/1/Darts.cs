public static class Darts
{
    private const int INNER_ABS = 1;
    private const int MIDDLE_ABS = 5;
    private const int OUTER_ABS = 10;
    private static double DartToCenterDistance;
    
    private static bool AbsLessOrEquals(double num1, int num2)
    {
        return Math.Abs(num1) <= num2;
    }

    private static void CordsToDistance(double dart_x, double dart_y)
    {
        // using the pythagorean theorem to calculate the distance between the center (0,0) to the dart's point
        DartToCenterDistance = Math.Sqrt(Math.Pow(dart_x, 2) + Math.Pow(dart_y, 2)); 
    }

    private static bool IsDartInCircle(this int circle_r_abs)
    {
        return AbsLessOrEquals(DartToCenterDistance, circle_r_abs);
    }
    
    public static int Score(double x, double y)
    {
        CordsToDistance(x,y);

        return
        INNER_ABS.IsDartInCircle() ? 10 : // inner circle - 10 points
        MIDDLE_ABS.IsDartInCircle() ? 5 : // middle circle - 5 points
        OUTER_ABS.IsDartInCircle() ? 1 :  // outer circle - 1 point
                                    0;   // if missed - 0 points
    }
}
