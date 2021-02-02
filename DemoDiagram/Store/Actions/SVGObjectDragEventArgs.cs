using DemoDiagram.Components;

namespace DemoDiagram.Store.Actions
{
    public record SVGObjectDragEventArgs(string Id, Coordinate Offset);
}