public class DndCharacter
{
    public int Strength { get; private init; }
    public int Dexterity { get; private init; }
    public int Constitution { get; private init; }
    public int Intelligence { get; private init; }
    public int Wisdom { get; private init; }
    public int Charisma { get; private init; }
    public int Hitpoints { get; private init; }

    public static int Modifier(int score) 
    {
        double mod = (score - 10d) / 2d;
        return (int)Math.Round(mod, 0, MidpointRounding.ToNegativeInfinity);
    }

    public static int Ability()
    {
        Random rand = new();
        var scores = new int[4];

        for (int i = 0; i < scores.Length; i++)
            scores[i] = rand.Next(1, 7);
        
        int min = scores.Min();
        return scores.Sum() - min;
    }

    public static DndCharacter Generate()
    {
        int _constitution = Ability();
        
        return new()
        {
            Constitution = _constitution,
            Hitpoints = 10 + Modifier(_constitution),

            Strength = Ability(),
            Dexterity = Ability(),
            Intelligence = Ability(),
            Wisdom = Ability(),
            Charisma = Ability(),
        };
    }
}
