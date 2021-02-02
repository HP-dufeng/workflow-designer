using System.Collections.Generic;

namespace AutomationDesigner.Store.LocalizerUserCase
{
    public record FetchLocalizerResultAction 
    {
        public Dictionary<string, string> Localizer;

        public FetchLocalizerResultAction(Dictionary<string, string> localizer)
        {
            Localizer = localizer;
        }
    }
}