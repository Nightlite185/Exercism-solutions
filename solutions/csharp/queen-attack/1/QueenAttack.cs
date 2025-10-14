public readonly struct Queen(int row, int column)
{
    public int Row { get; } = row;
    public int Column { get; } = column;
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black) 
            => white.Column == black.Column
            || white.Row == black.Row
            || Math.Abs(white.Row - black.Row) == Math.Abs(white.Column - black.Column);

    public static Queen Create(int row, int column)
        => row is < 0 or > 7 || column is < 0 or > 7
            ? throw new ArgumentOutOfRangeException("'row' or 'column'", "coordinates cannot be negative or higher than 7")
            : new(row, column);
}