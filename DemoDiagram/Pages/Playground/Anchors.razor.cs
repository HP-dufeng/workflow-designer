using System.Collections.Generic;
using System.Linq;
using DemoDiagram.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DemoDiagram.Pages.Playground
{
    public partial class Anchors
    {
        [Inject]
        public BrowserService browser { get; set; }

        public Line line = new Line
        {
            Start = new Coordinate(112.80140689983956, 150.74336220540607),
            BendPoints = new List<Coordinate> { new Coordinate(174, 123) },
            End = new Coordinate(239.76945571881345, 188.76945571881345)
        };

        double svgWidth = 801, svgHeight = 481;


        bool mouseDown = false;

        Coordinate mouseMoveFrom;

        Position magnetPosition = new Position(400, 400);
        Translation magnetTranslation = new Translation(7, 7);

        Position dockerPosition = new Position(8, 8);
        Translation docker_green_translation = new Translation(231.76945571881345, 180.76945571881345);
        Translation docker_red_translation = new Translation(241, 190);

        string Dockers_Visibility = "hidden";


        const long LEFT_MOUSE_BUTTON = 0;



        private void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == LEFT_MOUSE_BUTTON)
            {
                mouseDown = true;
                mouseMoveFrom = new Coordinate(e.OffsetX, e.OffsetY);


            }
        }
        private void OnMouseMove(MouseEventArgs e)
        {
            if (mouseDown)
            {
                var mouseMoveEnd = new Coordinate(e.OffsetX, e.OffsetY);
                var distance = mouseMoveEnd - mouseMoveFrom;
                docker_green_translation += distance;
                docker_red_translation += distance;

                line.End = mouseMoveEnd;

                // TODO ...
                SnapToMagnet(e);
                // GetAbstractShapesAtPosition(e);



                mouseMoveFrom = mouseMoveEnd;

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
            {

                mouseDown = false;
            }

        }

        private void OnMouseOver(MouseEventArgs e)
        {

        }

        private void MouseMoveTransform(Coordinate mouseMoveEnd)
        {

            // var distance = mouseMoveEnd - mouseMoveFrom;
            // translation += distance;

            // line.End = mouseMoveEnd;


        }



        private void SnapToMagnet(MouseEventArgs e)
        {
            var evPos = new Coordinate(e.ClientX, e.ClientY);
            if (isPointIncluded(evPos))
            {
                // absolute location
                var absoluteMagnetLocation = magnetPosition + magnetTranslation;
                var absoluteDockerLocation = dockerPosition + docker_green_translation;

                var distance = absoluteMagnetLocation - absoluteDockerLocation;

                docker_green_translation += distance;
                docker_red_translation += distance;
                line.End += distance;

                mouseDown = false;

                System.Console.WriteLine($"Got it at: {evPos.X} {evPos.Y}");
            }

        }


        private void GetAbstractShapesAtPosition(MouseEventArgs e)
        {
            var evPos = new Coordinate(e.OffsetX, e.OffsetY);

            if (isPointIncluded(evPos))
            {


                System.Console.WriteLine($"Got it at: {evPos.X} {evPos.Y}");
            }

        }

        private bool isPointIncluded(Coordinate evPos)
        {
            return IsIncluded(evPos);
        }

        private bool IsIncluded(Coordinate point)
        {
            var offset = 10;
            var ul = UpperLeft();
            var lr = LowerRight();

            if (point.X >= ul.X - offset
            && point.X <= lr.X + offset && point.Y >= ul.Y - offset
            && point.Y <= lr.Y + offset)
                return true;
            else
                return false;
        }

        private Coordinate UpperLeft()
        {
            var point = magnetPosition + magnetTranslation;

            return point;
        }

        private Coordinate LowerRight()
        {
            var (x, y) = magnetPosition;

            var point = new Coordinate(x + 4 + magnetTranslation.X, y + 4 + magnetTranslation.Y);

            return point;
        }





    }

    public record Line
    {
        public Coordinate Start { get; set; }

        public List<Coordinate> BendPoints { get; set; }
        public Coordinate End { get; set; }

        public string Drawn()
        {
            var bend_cmds = BendPoints.Aggregate("", (acc, coordinate) => acc + $" L{coordinate.X} {coordinate.Y} ");

            var d = $"M{Start.X} {Start.Y} {bend_cmds} L{End.X} {End.Y}";

            return d;
        }
    }
}