public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    public RobotSimulator(Direction direction, int x, int y)
    {
        X = x;
        Y = y;

        directionNum = (int)direction;

        actions = new()
        {
            [Direction.North] = MoveNorth,
            [Direction.East] = MoveEast,
            [Direction.South] = MoveSouth,
            [Direction.West] = MoveWest
        };
    }

    private readonly Dictionary<Direction, Action> actions;
    public Direction Direction => (Direction)directionNum;
    private int directionNum;

    #region Coords
    public int X { get; private set; }
    public int Y { get; private set; }
    #endregion

    #region Actions
    private void MoveNorth() => Y++;
    private void MoveSouth() => Y--;
    private void MoveEast() => X++;
    private void MoveWest() => X--;
    #endregion

    public void Move(string instructions)
    {
        foreach (char move in instructions)
        {
            switch (move)
            {
                case 'A':
                    actions[Direction]();
                    break;

                case 'R':
                    directionNum.Loop(x=> x+1);
                    break;

                case 'L':
                    directionNum.Loop(x => x-1);
                    break;

                default:
                    throw new ArgumentException("One or more of the chars is invalid.");
            }
        }
    }
}

public static class Helpers
{
    public static void Loop(this ref int value, Func<int, int> action, int max = 4)
    {
        value = action(value);
        value = ((value % max) + max) % max;
    }
}