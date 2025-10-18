using System.Text;

public static class FlowerField
{
    private static string[]? garden; 
    /* storing it as a field so helper methods can reference it themselves, without passing it in every time.
    I am absolutely aware it's not the best software design decision, but it's just a small exercise, for this scale it's not a problem.
    and made it nullable bc why initialize it into empty array if it gets replaced later anyway. */
    private static bool? IsFlower(int row, int col)
    {
        if (col < 0 || row < 0)
            return null;

        if (row >= garden!.Length || col >= garden[row].Length)
            return null;
            
        return garden[row][col] == '*';
    }
    private static int AreaFlowersCount(int row, int col)
    {
        bool?[] area =
        [
            // up and down
            IsFlower(row+1, col),
            IsFlower(row-1, col),

            // left and right
            IsFlower(row, col+1),
            IsFlower(row, col-1),

            // upper diagonals
            IsFlower(row+1, col+1),
            IsFlower(row+1, col-1),

            // bottom diagonals
            IsFlower(row-1, col-1),
            IsFlower(row-1, col+1),
        ];

        return area.Count(x=> x is true);
    }
    
    public static string[] Annotate(string[] input)
    {
        if (input.Length == 0)
            return input;

        garden = input;

        StringBuilder rowBuilder = new();
        var resultGarden = new string[garden.Length];

        for (int row_i = 0; row_i < garden.Length; row_i++)
        {
            string row = garden[row_i];

            for (int field_i = 0; field_i < row.Length; field_i++)
            {
                char field = row[field_i];

                if (field == ' ')
                {
                    int flowerCount = AreaFlowersCount(row_i, field_i);
                    rowBuilder.Append(flowerCount == 0 ? " ": flowerCount);
                }

                else
                    rowBuilder.Append('*');
            }

            resultGarden[row_i] = rowBuilder.ToString();
            rowBuilder.Clear();
        }

        return resultGarden;
    }
}