using System.Collections;

public static class FlattenArray
{
    public static IEnumerable Flatten(this IEnumerable input)
    {
        List<object> list = [];

        foreach (var item in input)
        {
            if (item is null) continue;

            else if (item is IEnumerable nested)
                list.MergeWith(nested.Flatten());

            else list.Add(item);
        }

        return list;
    }

    public static void MergeWith(this List<object> main, IEnumerable flat)
    {
        foreach (var item in flat)
            main.Add(item);
    }
}