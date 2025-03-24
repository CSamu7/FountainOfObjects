public class Coordinate {
    public int X { get; set; }
    public int Y { get; set; }

    public Coordinate(int x,int y) {
        X = x; Y = y;
    }

    public static bool AreCoordinatesAdjacent(Coordinate coordinate1,Coordinate coordinate2) {
        int distanceX = Math.Abs(coordinate1.X - coordinate2.X);
        int distanceY = Math.Abs(coordinate1.Y - coordinate2.Y);

        return distanceX == 1 || distanceY == 1;
    }
}