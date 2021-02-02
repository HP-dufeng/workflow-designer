

using AutomationDesigner.Store.StencilSetsUserCase.Models;

namespace AutomationDesigner.Store.StencilSetsUserCase
{
    public record FetchStencilSetsResultAction
    {
        public StencilSets StencilSets { get;}

        public FetchStencilSetsResultAction(StencilSets stencilSets)
        {
            StencilSets = stencilSets;
        }
    }
}