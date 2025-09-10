public class Player
{
    private readonly Random _random = new();
    public int RollDie()
    {
        return _random.Next(1, 19);
    }

    public double GenerateSpellStrength()
    {
        int random_numbah = _random.Next(1, 100);
        double random_rest = _random.NextDouble();

        return random_numbah + random_rest;
    }
}
