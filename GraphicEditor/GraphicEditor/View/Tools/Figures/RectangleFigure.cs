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
            var pen = new Pen(data.ForegroundColor, data.Thickness);

            var size = new Size(data.EndPoint.X - data.StartPoint.X, data.EndPoint.Y - data.StartPoint.Y);

            graphics.DrawRectangle(pen, new Rectangle(data.StartPoint, size));
        }
    }
}
