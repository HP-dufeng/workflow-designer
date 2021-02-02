namespace DemoDiagram.Components
{
    public record Translation(double X, double Y) : Coordinate(X, Y)
    {

        public string ToTranslate()
        {
            return $"translate({X}, {Y})";
        }

        public static Translation operator +(Translation a, Coordinate b)
        {
            return new Translation(a.X + b.X, a.Y + b.Y);

        }

        public static Translation operator +(Translation a, Position b)
        {
            return new Translation(a.X + b.X, a.Y + b.Y);

        }
    }
}