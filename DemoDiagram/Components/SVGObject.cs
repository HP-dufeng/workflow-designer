using System;

namespace DemoDiagram.Components
{
    public record SVGObject
    {
        public string Id { get; }

        public Coordinate Translation { get; set; }
        public string Transform => $"translate({Translation.X},{Translation.Y})";

        public SVGObject()
        {
            Id = Guid.NewGuid().ToString();
            Translation = new Coordinate(0, 0);
        }
    }
}