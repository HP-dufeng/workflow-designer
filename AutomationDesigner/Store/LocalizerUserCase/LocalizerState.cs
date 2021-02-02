using System.Collections.Generic;
using Fluxor;

namespace AutomationDesigner.Store.LocalizerUserCase
{
    public record LocalizerState
    {
        public Dictionary<string, string> Localizer;
    }

     public class Feature : Feature<LocalizerState>
    {
        public override string GetName() => nameof(LocalizerState);

        protected override LocalizerState GetInitialState()
            => new LocalizerState 
            { 
                Localizer = new Dictionary<string, string>()
            };
    }
}