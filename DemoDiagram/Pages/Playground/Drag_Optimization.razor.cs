using DemoDiagram.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DemoDiagram.Pages.Playground
{
    public partial class Drag_Optimization
    {
        [Inject]
        public BrowserService browser {get;set;}

        double svgWidth = 801, svgHeight = 481;

        Position position = new Position(100, 100);

        bool mouseDown = false;

        Coordinate mouseMoveFrom;

        Translation translation = new Translation(0, 0);

        string circle_stroke = "black";

        const long LEFT_MOUSE_BUTTON = 0;

        string cursor_style_left, cursor_style_top, cursor_style_visibility = "hidden";

        private void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == LEFT_MOUSE_BUTTON)
            {
                mouseDown = true;
                mouseMoveFrom = new Coordinate(e.OffsetX, e.OffsetY);

                var (x, y) = translation + position;
                cursor_style_left = $"{x}px";
                cursor_style_top = $"{y}px";
                cursor_style_visibility = "visible";
            }
        }
        private void OnMouseMove(MouseEventArgs e)
        {
            if (mouseDown)
            {
                var (x, y) = (e.ClientX, e.ClientY);
                cursor_style_left = $"{x}px";
                cursor_style_top = $"{y}px";
                circle_stroke = "grey";
            }
        }

        private void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == LEFT_MOUSE_BUTTON)
            {
                if (mouseDown)
                {
                    var mouseMoveEnd = new Coordinate(e.OffsetX, e.OffsetY);
                    translation = MouseUpTransform(mouseMoveEnd);

                    var (x, y) = translation + position;
                    cursor_style_left = $"{x}px";
                    cursor_style_top = $"{y}px";
                    cursor_style_visibility = "visible";
                    circle_stroke = "black";
                }

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
            {
                if (mouseDown)
                {

                    translation = MouseOutTransform(new Coordinate(e.OffsetX, e.OffsetY));

                    cursor_style_visibility = "hidden";
                    circle_stroke = "black";


                    StateHasChanged();
                }

                mouseDown = false;
            }

        }

        private Translation MouseUpTransform(Coordinate mouseMoveEnd)
        {

            var distance = mouseMoveEnd - mouseMoveFrom;
            translation += distance;

            return translation;

        }

        private Translation MouseOutTransform(Coordinate mouseMoveEnd)
        {
            var (x, y) = (mouseMoveEnd.X, mouseMoveEnd.Y);
            x = x <= 0 ? 20 : x >= svgWidth ? svgWidth - 20 : x;
            y = y <= 0 ? 20 : y >= svgHeight ? svgHeight - 20 : y;
            var correction = new Coordinate(x, y);

            var distance = correction - mouseMoveFrom;
            translation += distance;

            //var distance = mouseMoveEnd - mouseMoveFrom;
            //translation += distance;

            // var (tx, ty) = translation;
            //tx = tx + position.X >= svgWidth ? svgWidth - position.X - 20 : tx;
            //ty = ty + position.Y >= svgHeight ? svgHeight - position.Y - 20 : ty;

            //var outX = tx + position.X ;
            //var outY = ty + position.Y;
            //tx = outX >= svgWidth ? svgWidth - position.X - 20 : outX <= 0 ? -position.X+20 : tx;
            //ty = outY >= svgHeight ? svgHeight - position.Y - 20 : outY <= 0 ? -position.Y+20 : ty;
            //translation = new Translation(tx, ty);

            return translation;
        }
    }
}