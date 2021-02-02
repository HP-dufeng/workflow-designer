using DemoDiagram.Components;

namespace DemoDiagram.Components.StencilSets
{
    public record CircleModel : Stencil
    {
        public CircleModel()
        {   
            ComponentType = typeof(Components.StencilSets.Circle);
        }
    }
}