public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object? obj)
    {

        if (obj is null || obj is not FacialFeatures features)
            return false;

        // TODO: write your implementation of Equals() here

        return this.PhiltrumWidth == features.PhiltrumWidth &&
               this.EyeColor == features.EyeColor;

    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
}

public class Identity(string email, FacialFeatures facialFeatures)
{
    public string Email { get; } = email;
    public FacialFeatures FacialFeatures { get; } = facialFeatures;

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not Identity id)
            return false;

        return this.Email == id.Email &&
               this.FacialFeatures.Equals(id.FacialFeatures);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }


}

public class Authenticator
{
    private List<Identity> idList = [testAdminId];
    private static readonly Identity testAdminId = new("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        return identity.Equals(testAdminId);
    }

    public bool Register(Identity identity)
    {
        if (IsRegistered(identity))
            return false;

        idList.Add(identity);
        return true;
    }

    public bool IsRegistered(Identity identity)
    {
        return idList.Contains(identity);
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return identityA == identityB;
    }
}