using GraphicEditor.View.Drawing.Tools.Input;

namespace GraphicEditor.View.Drawing.Tools
{
    internal interface IDrawingTool
    {
        public bool Executing { get; }
        public DrawFinishType DrawFinishType { get; }

        public void StartDrawing(DrawingToolData data);
        public void DrawNext(DrawingToolData data);
        public void FinishDrawing(DrawingToolData data);

        public void CancelDrawing(DrawingToolData data);
    }
}
