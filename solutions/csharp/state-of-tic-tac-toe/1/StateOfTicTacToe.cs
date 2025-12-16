public enum State
{
    Win,
    Draw,
    Ongoing,
    Invalid
}

public class TicTacToe(string[] rows)
{
    private const char X = 'X'; // I don't like literals everywhere in code
    private const char O = 'O'; // so I made these constants.
    private readonly string[] rows = rows;
    private int countX;
    private int countO;
    private char? WonPiece = null;
    
    public State State
    {
        get
        {
            State result = State.Ongoing;
            CountPieces();

            if (countX > 1 && countO == 0 
            || countO > 1 && countX == 0)
                return State.Invalid;
    
            if (countO > countX) // there cannot be more O's than X's since we assume X starts.
                return State.Invalid;

            if (countX < 3 && countO < 3) goto quit; // early exit if there aren't enough pieces for a win.

            if (CheckRows(ref result) && result is State.Invalid) goto quit;
            if (CheckColumns(ref result) && result is State.Invalid) goto quit;
            if (CheckDiagonals(ref result) && result is State.Invalid) goto quit;
                
            if (countX + countO == 9 && result is not State.Win) 
                return State.Draw;

            quit: return result;
        }
    }

    private void CountPieces()
    {
        var flat = rows.SelectMany(p => p);

        if (flat.Count() != 9) throw new ArgumentException("Invalid grid");

        countX = flat.Count(p => p == X);
        countO = flat.Count(p => p == O);
    }

    /// <returns>bool whether game ended or still ongoing.</returns>
    private bool CheckDiagonals(ref State result)
    {
        char[][] diagonals = [
            [rows[0][0], rows[1][1], rows[2][2]],
            [rows[0][2], rows[1][1], rows[2][0]]
        ];

        foreach (var diag in diagonals)
        {
            if (CheckOneCluster(diag) is char winner)
            {
                if (IsWinValid(winner))
                {
                    result = State.Win;
                    WonPiece = winner;
                }
                
                else
                {
                    result = State.Invalid;
                    return true;
                }
            }
        }

        return result is State.Win;
    }

    private bool CheckRows(ref State result)
    {
        foreach (string row in rows)
        {
            if (CheckOneCluster(row) is char winner)
            {
                if (IsWinValid(winner))
                {
                    result = State.Win;
                    WonPiece = winner;
                }
                
                else
                {
                    result = State.Invalid;
                    return true;
                }
            }
        }

        return result is State.Win;
    }
    private bool CheckColumns(ref State result)
    {
        for (int i = 0; i < 3; i++)
        {
            char[] column = [rows[0][i], rows[1][i], rows[2][i]];

            if (CheckOneCluster(column) is char winner)
            {
                if (IsWinValid(winner))
                {
                    result = State.Win;
                    WonPiece = winner;
                }
                
                else
                {
                    result = State.Invalid;
                    return true;
                }
            }
        }

        return result is State.Win;
    }
    
    /// <returns>null if winner not found, else either 'X' or 'O' char</returns>
    private static char? CheckOneCluster(IEnumerable<char> cluster) 
        => cluster.All(p => p == X)
            ? X

        : cluster.All(p => p == O)
            ? O

        : null;
    private bool IsWinValid(char winner) 
        => (WonPiece == null || WonPiece == winner)
        
        && winner switch
        {
            X => countX > countO,
            O => countX == countO,

            _ => false
        };
}
