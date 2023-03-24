using GraphicEditor.View.Drawing.Tools.Input;

namespace GraphicEditor.View.Drawing.Tools.Figures
{
    internal class EllipseFigure : Figure
    {
        protected override void DrawFigure(DrawingToolData data, Graphics graphics)
        {
            var foregroundPen = new Pen(data.ForegroundColor, data.Thickness);

            var size = new Size(data.EndPoint.X - data.StartPoint.X, data.EndPoint.Y - data.StartPoint.Y);

            if (data.IsColored)
            {
                var backgroundPen = new Pen(data.BackgroundColor, data.Thickness);
                graphics.FillEllipse(backgroundPen.Brush, new Rectangle(data.StartPoint, size));
            }

            graphics.DrawEllipse(foregroundPen, new Rectangle(data.StartPoint, size));
        }
    }
}
