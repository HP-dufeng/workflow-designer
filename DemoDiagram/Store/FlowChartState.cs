using System;
using System.Collections.Generic;
using System.Linq;
using DemoDiagram.Components;
using DemoDiagram.Components.Containers;
using DemoDiagram.Components.StencilSets;
using DemoDiagram.Store.Actions;
using Fluxor;

namespace DemoDiagram.Store
{
    public record FlowChartState
    {
        public SVGContainer Container { get; set; }

        public FlowChartState ScrollSurface(Coordinate offset)
        {
            var newOffset = this.Container.Surface.Offset + offset;

            return this with
            {
                Container = this.Container with
                {
                    Surface = this.Container.Surface with { Offset = newOffset, Translation = newOffset % 80 },
                    StencilsContainer = this.Container.StencilsContainer with { Translation = newOffset },
                }
            };
        }

        public FlowChartState HandleStencilDragAction(string stencilId, Coordinate offset)
        {
            var stencil = this.Container.StencilsContainer.Stencils.First(m => m.Id == stencilId);
            stencil?.HandleDrag(offset);

            return this;
        }

    }

    public class Feature : Feature<FlowChartState>
    {
        public override string GetName() => nameof(FlowChartState);

        protected override FlowChartState GetInitialState() => new FlowChartState
        {
            Container = new SVGContainer
            {
                Surface = new SurfaceModel { Offset = new Coordinate(0, 0) },
                StencilsContainer = new StencilsModel
                {
                    Stencils = new List<Stencil>
                    {
                         new CircleModel{ Position = new Coordinate(200, 200) } ,
                         new CircleModel{ Position = new Coordinate(250, 200) },
                         new RectangleModel{ Position = new Coordinate(300, 200) },
                    },
                    // tools = new List<Components.StencilSets.Circle> 
                    // { 
                    //     new Components.StencilSets.Circle()
                    // },
                },
                Toolbox = new Toolbox
                {
                    Tools = new List<Stencil> { new CircleModel { Position = new Coordinate(85, 29) } }
                }
            }
        };
    }

}