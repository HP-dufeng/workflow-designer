namespace DemoDiagram.Components.StencilSets
{
    public record RectangleModel : Stencil
    {
        public RectangleModel()
        {   
            ComponentType = typeof(Components.StencilSets.Rectangle);
        }
    }
}