using System.Reflection.Metadata.Ecma335;

[Flags]
enum Permission
{
    None = 0,
    Read = 1,
    Write = 2,
    Delete = 4,
    All = Read | Write | Delete,
}

[Flags]
enum AccountType
{
    Guest = Permission.Read,
    User = Permission.Read | Permission.Write,
    Moderator = Permission.All,
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        return Enum.IsDefined(accountType)
            ? (Permission)accountType
            : Permission.None;
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        return current | grant;
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        return current & ~revoke;
    }

    public static bool Check(Permission current, Permission check)
    {
        return current.HasFlag(check);
    }
}