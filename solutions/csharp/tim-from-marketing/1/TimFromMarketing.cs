static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string? id_final;
        id_final = id == null ? "" : $"[{id}] - ";
        
        department ??= "OWNER";
        

        return $"{id_final}{name} - {department.ToUpper()}";
    }
}