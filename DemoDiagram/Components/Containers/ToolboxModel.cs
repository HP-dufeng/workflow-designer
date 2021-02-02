using System.Collections.Generic;
using DemoDiagram.Components;

namespace DemoDiagram
{
    public record Toolbox : SVGObject
    {

        public List<Stencil> Tools {get;set;}
    }
}