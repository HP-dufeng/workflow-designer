namespace DemoDiagram.Components
{
    public record Position(double X, double Y) : Coordinate(X, Y)
    {
        public static Position operator +(Position a, Coordinate b)
        {
            return new Position(a.X + b.X, a.Y + b.Y);

        }
    }
}