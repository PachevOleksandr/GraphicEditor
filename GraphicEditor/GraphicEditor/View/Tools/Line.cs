using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.View.Tools
{
    internal class Line : Figure
    {
        public Line(Image image) : base(image) { }

        protected override void DrawFigure(Point point, Graphics graphics)
        {
            var pen = new Pen(ForegroundColor, Thickness);

            graphics.DrawLine(pen, startPoint, point);
        }
    }
}
