namespace DemoDiagram.Components
{
    public record Coordinate(double X, double Y)
    {
        public static Coordinate operator -(Coordinate a, Coordinate b)
        {
            return new Coordinate(a.X - b.X, a.Y - b.Y);

        }

        public static Coordinate operator +(Coordinate a, Coordinate b)
        {
            return new Coordinate(a.X + b.X, a.Y + b.Y);

        }

        public static Coordinate operator %(Coordinate a, double v)
        {
            return new Coordinate(a.X % v, a.Y % v);

        }
    }
}