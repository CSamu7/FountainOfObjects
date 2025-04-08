public class Coordinate
{
    public int X { get; set; }
    public int Y { get; set; }
    public Coordinate(int x, int y)
    {
        X = x; Y = y;
    }
    public static bool AreCoordinatesAdjacent(Coordinate c1, Coordinate c2)
    {
        if (AreCoordinatesEqual(c1, c2)) return false;
        int x = Math.Abs(c1.X - c2.X);
        int y = Math.Abs(c1.Y - c2.Y);

        return x <= 1 && y <= 1;
    }

    public static bool AreCoordinatesEqual(Coordinate c1, Coordinate c2)
    {
        return c1.X == c2.X && c1.Y == c2.Y;
    }
}