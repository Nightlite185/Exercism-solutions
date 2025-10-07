public class SpaceAge(int seconds)
{
    private readonly int earthAge = seconds;
    private const int EarthYearInSeconds = 31_557_600;
    private readonly Dictionary<string, double> PlanetsYearInSeconds = new()
    {
        ["Mercury"] = EarthYearInSeconds  * 0.2408467,
        ["Venus"]   = EarthYearInSeconds  * 0.61519726,
        ["Earth"]   = EarthYearInSeconds  * 1.0,
        ["Mars"]    = EarthYearInSeconds  * 1.8808158,
        ["Jupiter"] = EarthYearInSeconds  * 11.862615,
        ["Saturn"]  = EarthYearInSeconds  * 29.447498,
        ["Uranus"]  = EarthYearInSeconds  * 84.016846,
        ["Neptune"] = EarthYearInSeconds  * 164.79132
    };

    public double OnEarth()
        => earthAge / PlanetsYearInSeconds["Earth"];

    public double OnMercury()
        => earthAge / PlanetsYearInSeconds["Mercury"];

    public double OnVenus()
        => earthAge / PlanetsYearInSeconds["Venus"];

    public double OnMars()
        => earthAge / PlanetsYearInSeconds["Mars"];

    public double OnJupiter()
        => earthAge / PlanetsYearInSeconds["Jupiter"];

    public double OnSaturn()
        => earthAge / PlanetsYearInSeconds["Saturn"];

    public double OnUranus()
        => earthAge / PlanetsYearInSeconds["Uranus"];

    public double OnNeptune()
        => earthAge / PlanetsYearInSeconds["Neptune"];
}