using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace DemoDiagram
{


    public class BrowserService
    {
        private readonly IJSRuntime js;

        public BrowserService(IJSRuntime js)
        {
            this.js = js;
        }

        public async Task<DocumentSize> GetDocumentSize()
        {
            return await js.InvokeAsync<DocumentSize>("getDocumentSize");
        }

    }

    public class DocumentSize
    {
        public int ClientWidth { get; set; }
        public int ClientHeight { get; set; }
    }
}