public class HighScores(List<int> list)
{
    private List<int> allScores = list;
    
    private List<int> sortedScores = [.. list.OrderDescending()];    

    public List<int> Scores() => [.. allScores];
    
    public int Latest() => allScores.Last();
    
    public int PersonalBest() => sortedScores[0];
    
    public List<int> PersonalTopThree()
        => allScores.Count >= 3
            ? sortedScores[0..3]
            : sortedScores[0..allScores.Count];
}