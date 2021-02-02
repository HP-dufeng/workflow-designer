using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutomationDesigner.Store.StencilSetsUserCase.Models;
using Fluxor;
using Newtonsoft.Json.Linq;

namespace AutomationDesigner.Store.StencilSetsUserCase
{
    public class FetchStencilSetsActionEffect : Effect<FetchStencilSetsAction>
    {
        private readonly HttpClient http;

        public FetchStencilSetsActionEffect(HttpClient http)
        {
            this.http = http;
        }

        protected override async Task HandleAsync(FetchStencilSetsAction action, IDispatcher dispatcher)
        {
            var stencilSets = await http.GetFromJsonAsync<StencilSets>("sample-data/stencilset_bpmn.json");

            dispatcher.Dispatch(new FetchStencilSetsResultAction(stencilSets));
        }
    }
}