using DemoDiagram.Components;

namespace DemoDiagram.Components.Containers
{
    public record SurfaceModel : SVGObject
    {
        public Coordinate Offset { get; set; }
    }
}