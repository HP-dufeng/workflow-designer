
using System.Collections.Generic;
using AutomationDesigner.Store.StencilSetsUserCase.Models;
using Fluxor;

namespace AutomationDesigner.Store.StencilSetsUserCase
{

    public record StencilSetsState
    {
        

        public StencilSets StencilSets { get; init; }

        public List<StencilItemGroup> StencilItemGroups {get; init;}
    }

    public class Feature : Feature<StencilSetsState>
    {
        public override string GetName() => nameof(StencilSetsState);

        protected override StencilSetsState GetInitialState()
            => new StencilSetsState 
            { 
                StencilSets = null, 
                StencilItemGroups = new List<StencilItemGroup>(),
            };
    }
}