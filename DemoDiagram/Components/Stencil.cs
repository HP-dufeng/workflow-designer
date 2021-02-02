using System;

namespace DemoDiagram.Components
{
    public record Stencil : SVGObject
    {
        public Coordinate Position { get; set;}

        public Type ComponentType {get;init;}

        public void HandleDrag(Coordinate offset)
        {
            Translation += offset;

        }
    }
}