public class Orm (Database database) : IDisposable
{
    private Database db = database;

    public void Begin()
        => db.BeginTransaction();

    public void Write(string data)
    {
        try
            { db.Write(data); }

        catch (InvalidOperationException)
            { db.Dispose(); }
    }

    public void Commit()
    {
        try
            { db.EndTransaction(); }

        catch (InvalidOperationException)
            { db.Dispose(); }
    }

    public void Dispose()
        => db.Dispose();

}
