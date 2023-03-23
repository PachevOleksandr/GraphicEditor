using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.View.Tools.Figures
{
    internal class RectangleFigure : Figure
    {
        protected override void DrawFigure(DrawingToolData data, Graphics graphics)
        {
            var location = data.StartPoint;

            if (data.StartPoint.Y > data.EndPoint.Y ||
               data.StartPoint.X > data.EndPoint.X)
            {
                location = data.EndPoint;
            }

            var foregroundPen = new Pen(data.ForegroundColor, data.Thickness);

            var size = new Size(Math.Abs(data.EndPoint.X - data.StartPoint.X), Math.Abs(data.EndPoint.Y - data.StartPoint.Y));

            if(data.IsColored)
            {
                var backgroundPen = new Pen(data.BackgroundColor, data.Thickness);
                graphics.FillRectangle(backgroundPen.Brush, new Rectangle(location, size));
            }

            graphics.DrawRectangle(foregroundPen, new Rectangle(location, size));
        }
    }
}
