public class GradeSchool
{
    private readonly Dictionary<int, HashSet<string>> Dziennik = [];


    public bool Add(string student, int grade)
    {
        Dziennik.TryAdd(grade, []);
        
        return Dziennik.Values.Any(set => set.Contains(student)) 
            ? false 
            : Dziennik[grade].Add(student);
    }

    public IEnumerable<string> Roster()
        => Dziennik
        .OrderBy(x => x.Key)
        .SelectMany(x => x.Value.OrderBy(c=>c));

    public IEnumerable<string> Grade(int grade)
        => Dziennik.TryGetValue(grade, out var students)
            ? students.Order()
            : [];
}