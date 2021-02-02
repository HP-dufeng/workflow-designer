using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Fluxor;
using Newtonsoft.Json.Linq;

namespace AutomationDesigner.Store.LocalizerUserCase
{
    public class FetchLocalizerActionEffect: Effect<FetchLocalizerAction>
    {
        private readonly HttpClient http;

        public FetchLocalizerActionEffect(HttpClient http)
        {
            this.http = http;
        }

        protected override async Task HandleAsync(FetchLocalizerAction action, IDispatcher dispatcher)
        {
            var jsonElement = await http.GetFromJsonAsync<JsonElement>("i18n/en.json");
        
            var jsonStr = jsonElement.GetRawText();
            var jobj = JObject.Parse(jsonStr);
            
            var dic = new Dictionary<string, string>();
            
            foreach(var item in jobj.DescendantsAndSelf())
            {
                if(string.IsNullOrEmpty(item.Path) ||item.Values().FirstOrDefault() == null )
                    continue;
                if(dic.ContainsKey(item.Path))
                    dic[item.Path] = item.Values().FirstOrDefault().ToString();
                else
                    dic.Add(item.Path, item.Values().FirstOrDefault().ToString());
                
            }


            dispatcher.Dispatch(new FetchLocalizerResultAction(dic));
        }
    }
}