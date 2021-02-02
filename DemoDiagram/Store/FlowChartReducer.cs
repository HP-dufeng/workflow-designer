using DemoDiagram.Store.Actions;
using Fluxor;

namespace DemoDiagram.Store
{
        public static class FlowChartReducer
    {

        [ReducerMethod]
        public static FlowChartState OnScrollSurfaceAction(FlowChartState state, ScrollSurfaceAction action)
            => state.ScrollSurface(action.offset);

        [ReducerMethod]
        public static FlowChartState OnStencilDragAction(FlowChartState state, StencilDragAction action)
            => state.HandleStencilDragAction(action.Args.Id, action.Args.Offset);

    }
}