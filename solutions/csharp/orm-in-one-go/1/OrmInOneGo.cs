public class Orm(Database database)
{
    private Database db = database;

    public void Write(string data)
    {
        try
        {
            db.BeginTransaction();
            db.Write(data);
            db.EndTransaction();
            db.Dispose();
        }

        catch (Exception)
        {
            db.Dispose();
            throw;
        }
    }

    public bool WriteSafely(string data)
    {
        try
        {
            this.Write(data);
        }

        catch (Exception)
        {
            return false;
        }

        return true;
    }
}