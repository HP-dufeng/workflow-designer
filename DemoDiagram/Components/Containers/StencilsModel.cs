using System.Collections.Generic;
using DemoDiagram.Components;
using DemoDiagram.Components.StencilSets;

namespace DemoDiagram.Components.Containers
{
    public record StencilsModel : SVGObject
    {

        public List<Stencil> Stencils {get;set;}
    }
}
