using System;
using DemoDiagram.Components;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DemoDiagram.Store 
{
    public class MouseController
    {

        private Action<Coordinate> onDrag;

        public MouseController(Action<Coordinate> onDrag)
        {
            this.onDrag = onDrag;
        }

        const double LEFT_MOUSE_BUTTON = 0;
        bool mouseDown = false;
        Coordinate dragFrom;
        Coordinate dragTo;

        private Coordinate offset ;


        public void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == LEFT_MOUSE_BUTTON)
            {
                mouseDown = true;
                
                dragFrom = new Coordinate(e.ClientX, e.ClientY);
            }
        }

        public void OnMouseMove(MouseEventArgs e)
        {
            if (mouseDown)
            {
                dragTo = new Coordinate(e.ClientX, e.ClientY);

                offset = dragTo - dragFrom;
                
                onDrag?.Invoke(offset);

                dragFrom = dragTo;
            }
        }

        public void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == LEFT_MOUSE_BUTTON)
            {
                mouseDown = false;
            }
        }

        public void OnMouseOut(MouseEventArgs e)
        {
            mouseDown = false;
        }

        
    }    
}