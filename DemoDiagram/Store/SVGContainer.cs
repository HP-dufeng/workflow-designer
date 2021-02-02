using DemoDiagram.Components.Containers;

namespace DemoDiagram.Components
{
    public record SVGContainer : SVGObject
    {
        public Canvas Canvas{get;set;}

        public SurfaceModel Surface {get;set;}

        public StencilsModel StencilsContainer {get;set;}
        
        public Toolbox Toolbox {get;set;}

    }
}