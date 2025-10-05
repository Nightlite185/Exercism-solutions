using System.Collections.ObjectModel;

public class Authenticator(Identity admin)
{
    private readonly Identity admin = admin;

    private readonly Dictionary<string, Identity> developers
        = new()
        {
            ["Bertrand"] = new Identity
            {
                Email = "bert@ex.ism",
                EyeColor = "blue"
            },

            ["Anders"] = new Identity
            {
                Email = "anders@ex.ism",
                EyeColor = "brown"
            }
        };

    public Identity Admin
    {
        get => new (admin);
    }

    public IDictionary<string, Identity> GetDevelopers()
        => new ReadOnlyDictionary<string, Identity>(developers) ;
}

public struct Identity(Identity identity)
{
    public string Email { get; set; } = identity.Email;

    public readonly string EyeColor { get; init; } = identity.EyeColor;
}
