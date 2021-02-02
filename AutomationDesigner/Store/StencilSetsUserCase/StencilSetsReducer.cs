using System.Linq;
using AutomationDesigner.Store.StencilSetsUserCase.Models;
using Fluxor;

namespace AutomationDesigner.Store.StencilSetsUserCase
{
    public static class StencilSetsReducer
    {
        [ReducerMethod]
        public static StencilSetsState OnFetchStencilSetsResultAction(StencilSetsState state, FetchStencilSetsResultAction action)
            => state with 
            { 
                StencilSets = action.StencilSets, 
                StencilItemGroups = action.StencilSets.Stencils
                .Where(m=>!m.MayBeRoot)
                .GroupBy(m=>m.Groups.First())
                .Select(m=> new StencilItemGroup(m.Key, m.ToList()))
                .ToList()
            };
    }
}