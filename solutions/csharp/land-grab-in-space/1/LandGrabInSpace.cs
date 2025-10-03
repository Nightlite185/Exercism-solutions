public struct Coord(ushort x, ushort y)
{
    public ushort X { get; } = x;
    public ushort Y { get; } = y;

    // override object.Equals
    public override bool Equals(object? obj)
    {
        
        if (obj == null || obj is not Coord coord)
        {
            return false;
        }

        return this.X == coord.X && this.Y == coord.Y;
    }
    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}

public struct Plot(Coord co1, Coord co2, Coord co3, Coord co4)
{
    public readonly Coord c1 = co1;
    public readonly Coord c2 = co2;
    public readonly Coord c3 = co3;
    public readonly Coord c4 = co4;

    public override bool Equals(object? obj)
    {

        if (obj == null || obj is not Plot plot)
        {
            return false;
        }

        return
            this.c1.Equals(plot.c1) &&
            this.c2.Equals(plot.c2) &&
            this.c3.Equals(plot.c3) &&
            this.c4.Equals(plot.c4);

    }

    public override int GetHashCode()
    {
        return HashCode.Combine(c1, c2, c3, c4);
    }
}


public class ClaimsHandler
{
    private List<Plot> claimsTaken = [];
    public void StakeClaim(Plot plot)
    {
        claimsTaken.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        return claimsTaken.Contains(plot);
    }

    public bool IsLastClaim(Plot plot)
    {
        return claimsTaken.Last().Equals(plot);
    }

    public Plot GetClaimWithLongestSide()
    {
        List<(Plot plot, int max)> results = [];

        foreach (Plot p in claimsTaken)
        {
            Coord[] coords = [p.c1, p.c2, p.c3, p.c4];


            int maxWidth =
                coords.Max(c => c.X)
                - coords.Min(c => c.X);

            int maxHeight =
                coords.Max(c => c.Y)
                - coords.Min(c => c.Y);


            results.Add((plot: p, max: Math.Max(maxWidth, maxHeight)));
        }

        return results.MaxBy(set=> set.max).plot;
    }
}
