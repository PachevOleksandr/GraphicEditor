using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.View.Tools.Figures
{
    internal class Line : Figure
    {
        protected override void DrawFigure(DrawingToolData data, Graphics graphics)
        {
            var pen = new Pen(data.ForegroundColor, data.Thickness);

            graphics.DrawLine(pen, data.StartPoint, data.EndPoint);
        }
    }
}
