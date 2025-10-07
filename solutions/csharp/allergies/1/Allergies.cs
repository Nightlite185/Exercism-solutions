[Flags]
public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies(int mask)
{

    private readonly Allergen mask = (Allergen)mask;

    public bool IsAllergicTo(Allergen allergen)
        => mask.HasFlag(allergen);

    public Allergen[] List()
        => [.. Enum.GetValues<Allergen>()
            .Where(a=> mask.HasFlag(a))];
}