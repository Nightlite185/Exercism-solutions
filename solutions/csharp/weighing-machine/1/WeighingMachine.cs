class WeighingMachine(int precision)
{
    private const double TARE_OFFSET = 5;
    public int Precision { get; init; } = precision;
    public double TareAdjustment {get;set;} = TARE_OFFSET;

    public double Weight
    {
        get;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(Weight), "Weight must be a positive number");

            field = value;
        }
    }

    public string DisplayWeight
    {
        get
        {
            double result = Weight - TareAdjustment;
            string format = $"F{Precision}";

            return string.Concat(result.ToString(format), " kg"); 
        }
    }
}
