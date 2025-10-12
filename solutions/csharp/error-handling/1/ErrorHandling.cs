public static class ErrorHandling
{
    public static void HandleErrorByThrowingException()
        => throw new Exception("some cool exception");

    public static int? HandleErrorByReturningNullableType(string input)
    {
        try
            { return Convert.ToInt32(input); }

        catch (Exception ex) when (ex is OverflowException or FormatException)
            { return null; }
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        try
        {
            result = Convert.ToInt32(input);
            return true;
        }

        catch (Exception ex) when (ex is OverflowException or FormatException)
        {
            result = -1;
            return false;
        }
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        using (disposableObject)
            throw new Exception("some cool exception");
    }
}