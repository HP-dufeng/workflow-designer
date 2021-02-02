using System;
using DemoDiagram.Store;
using DemoDiagram.Store.Actions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DemoDiagram.Components
{
    public class SVGDragableComponentBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        [Parameter]
        public string Transform {get;set;}
        
        [Parameter]
        public Coordinate Position {get;set;}


        [Parameter]
        public EventCallback<SVGObjectDragEventArgs> OnDrag { get; set; }

        protected MouseController mouseController;
        protected Action<MouseEventArgs> OnMouseDown;
        protected Action<MouseEventArgs> OnMouseMove;
        protected Action<MouseEventArgs> OnMouseUp;
        protected Action<MouseEventArgs> OnMouseOut;

        public SVGDragableComponentBase()
        {
            this.mouseController = new MouseController(
                offset => OnDrag.InvokeAsync(new SVGObjectDragEventArgs(Id, offset))
                );

            OnMouseDown = mouseController.OnMouseDown;
            OnMouseMove = mouseController.OnMouseMove;
            OnMouseOut = mouseController.OnMouseOut;
            OnMouseUp = mouseController.OnMouseUp;

        }
    }
}