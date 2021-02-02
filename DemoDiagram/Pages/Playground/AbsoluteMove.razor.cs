using DemoDiagram.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DemoDiagram.Pages.Playground
{
    public partial class AbsoluteMove
    {
        [Inject]
        public BrowserService browser { get; set; }
        double svgWidth = 801, svgHeight = 481;

        bool mouseDown = false;
        const double LEFT_MOUSE_BUTTON = 0;

        Position position = new Position(150, 100);

        Coordinate dragFrom;
        Coordinate dragTo;

        private void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == LEFT_MOUSE_BUTTON)
            {
                mouseDown = true;

                dragFrom = new Coordinate(e.OffsetX, e.OffsetY);
            }
        }
        private void OnMouseMove(MouseEventArgs e)
        {
            if (mouseDown)
            {
                dragTo = new Coordinate(e.OffsetX, e.OffsetX);

                var offset = dragTo - dragFrom;

                // translation += offset;

                // Transform = $"translate({translation.X},{translation.Y})";

                position = new Position(e.OffsetX, e.OffsetY);

                dragFrom = dragTo;
            }
        }

        private void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == LEFT_MOUSE_BUTTON)
            {
                mouseDown = false;
            }
        }

        private async void OnMouseOut(MouseEventArgs e)
        {
            var window = await browser.GetDocumentSize();

            if (e.OffsetX <= 0 // left
                || (e.OffsetY <= 0) // top
            || (e.OffsetX >= svgWidth || e.ClientX >= window.ClientWidth) // right
            || (e.OffsetY >= svgHeight || e.ClientY >= window.ClientHeight) // bottom
            )
                mouseDown = false;
        }
    }
}