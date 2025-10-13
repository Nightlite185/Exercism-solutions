public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden(string diagram)
{
    private readonly string[] students = ["Alice", "Bob", "Charlie", "David", "Eve", "Fred", "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry"];
    private readonly Dictionary<char, Plant> PlantEncoding = new()
    {
        ['G'] = Plant.Grass,
        ['C'] = Plant.Clover,
        ['R'] = Plant.Radishes,
        ['V'] = Plant.Violets
    };
    private readonly string diagram = string.IsNullOrWhiteSpace(diagram)
        ? throw new ArgumentException("Provided diagram cannot be empty or whitespace.")
        : diagram;

    public IEnumerable<Plant> Plants(string student)
    {
        if (!diagram.Contains('\n'))
            throw new ArgumentException("diagram needs to have two rows");

        int studentIndex = student[0] - 'A';
        string[] splitted = diagram.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        IEnumerable<Plant> symbols = [];

        foreach (string row in splitted)
            symbols = symbols.Concat(row
                .Skip(studentIndex*2)
                .Take(2)
                .Select(p => PlantEncoding[p])
            );
        
        return symbols;
    }
}