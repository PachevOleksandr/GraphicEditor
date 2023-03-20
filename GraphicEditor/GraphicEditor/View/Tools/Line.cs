using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.View.Tools
{
    internal class Line : Figure
    {
        protected override void DrawFigure(int x, int y, Graphics graphics)
        {
            var pen = new Pen(ForegroundColor, Thickness);

            graphics.DrawLine(pen, startPoint, new Point { X = x, Y = y });
        }
    }
}
