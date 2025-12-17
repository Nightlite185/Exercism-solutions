public static class ListOps
{
    public static int Length<T>(List<T> input) 
        => input.Count;

    public static List<T> Reverse<T>(List<T> input)
    {
        List<T> copy = [..input];

        copy.Reverse();
        return copy;
    }

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map) 
        => [.. input.Select(x => map(x))];

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate) 
        => [.. input.Where(x => predicate(x))];

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func) 
        => input.Aggregate(start, func);

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    {
        List<TIn> copy = [..input];
        copy.Reverse();

        TOut newFunc(TOut TOut, TIn TIn)
            => func(TIn, TOut);

        return copy.Aggregate(start, newFunc);
    }

    public static List<T> Concat<T>(List<List<T>> input) 
        => [.. input.SelectMany(x => x)];

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
        List<T> copy = [..left];
        
        copy.AddRange(right);
        return copy;
    }
}