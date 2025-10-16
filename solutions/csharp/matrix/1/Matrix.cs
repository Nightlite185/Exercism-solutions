public class Matrix(string input)
{
    private static string message = "Invalid character in input, only digits are allowed";
    private readonly int[][] matrix = [.. input
    .Split('\n')
    .Select(x => x
        .Split(' ')
        .Select(c => int.TryParse(c, out int digit)
            ? digit
            : throw new ArgumentException(message))
        
        .ToArray())];

    public int[] Row(int row)
        => matrix[row - 1];

    public int[] Column(int col)
        => [..matrix.Select(row => row[col - 1])];
}