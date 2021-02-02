using Fluxor;

namespace AutomationDesigner.Store.LocalizerUserCase
{
    public static class LocalizerReducer
    {
        [ReducerMethod]
        public static LocalizerState OnFetchLocalizerResultAction(LocalizerState state, FetchLocalizerResultAction action)
            => state with { Localizer = action.Localizer };
    
    }
}