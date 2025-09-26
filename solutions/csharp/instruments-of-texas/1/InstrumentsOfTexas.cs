public class CalculationException(int operand1, int operand2, string message, Exception inner) : Exception
{
    public int Operand1 { get; } = operand1;
    public int Operand2 { get; } = operand2;
    new public string Message { get; init; } = message;
    new public Exception InnerException { get; init; } = inner;
}

public class CalculatorTestHarness(Calculator calculator)
{
    private readonly Calculator calculator = calculator;

    public string TestMultiplication(int x, int y)
    {
        try
        { Multiply(x, y); }

        catch (CalculationException e)
        {
            if (x < 0 && y < 0)
                return $"Multiply failed for negative operands. {e.InnerException.Message}";
            else
                return $"Multiply failed for mixed or positive operands. {e.InnerException.Message}";
        }

        return "Multiply succeeded";
        }

    public void Multiply(int x, int y)
    {
        try
            { calculator.Multiply(x, y); }
        
        catch(OverflowException e)
            { throw new CalculationException(x, y, "The sink is overflowing with ints, please call the Number Plumber™", e); }
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}
