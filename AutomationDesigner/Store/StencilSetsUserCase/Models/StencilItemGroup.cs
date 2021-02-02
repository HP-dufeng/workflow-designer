using System.Collections.Generic;

namespace AutomationDesigner.Store.StencilSetsUserCase.Models
{
    public record StencilItemGroup
    {
        public string Name {get; init;}
        public List<Stencil> StencilItems {get; init;}

        public StencilItemGroup(string name, List<Stencil> stencilItems)
        {
            Name = name;
            StencilItems = stencilItems;
        }
    }
}