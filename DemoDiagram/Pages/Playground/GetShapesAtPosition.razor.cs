using System.Collections.Generic;
using System.Linq;
using DemoDiagram.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DemoDiagram.Pages.Playground
{
    public partial class GetShapesAtPosition
    {
        Coordinate GotIt;


        Coordinate position = new Coordinate(200,150);

        Translation translation = new Translation(0, 0);

        double width=100, height=80;

        const long LEFT_MOUSE_BUTTON = 0;


        private void OnMouseMove(MouseEventArgs e)
        {
            GetAbstractShapesAtPosition(e);
        }

       




        private void GetAbstractShapesAtPosition(MouseEventArgs e)
        {
            var evPos = new Coordinate(e.OffsetX, e.OffsetY);

            if(isPointIncluded(evPos))
            {
                GotIt = evPos;
            }
            
        }

        private bool isPointIncluded(Coordinate evPos)
        {
            return IsIncluded(evPos);
        }

        private bool IsIncluded(Coordinate point)
        {
            var offset = 0;
            var ul = UpperLeft();
		    var lr = LowerRight();

            if(point.X >= ul.X - offset 
			&& point.X <= lr.X + offset && point.Y >= ul.Y - offset 
			&& point.Y <= lr.Y + offset)
			return true;
		else 
			return false;
        }

        private Coordinate UpperLeft()
        {
            var point = position + translation;

            return point;
        }

        private Coordinate LowerRight()
        {
            var (x, y) = position;

            var point = new Coordinate(x+width+translation.X, y+height+translation.Y  );

            return point;
        }
    }



    
}