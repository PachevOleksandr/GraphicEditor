using GraphicEditor.View.Drawing.Tools.Input;

namespace GraphicEditor.View.Drawing.Tools.Figures
{
    internal class LineFigure : Figure
    {
        protected override void DrawFigure(DrawingToolData data, Graphics graphics)
        {
            var pen = new Pen(data.ForegroundColor, data.Thickness);

            graphics.DrawLine(pen, data.StartPoint, data.EndPoint);
        }
    }
}
