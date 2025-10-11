public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        foreach (T thing in collection)
        {
            if (predicate(thing))
                yield return thing;
        }
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        foreach (T thing in collection)
        {
            if (!predicate(thing))
                yield return thing;
        }
    }
}