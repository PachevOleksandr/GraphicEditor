using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.View.Tools
{
    internal class Pencil : IDrawingTool
    {
        private Point previousPoint;

        public Color ForegroundColor { get; set; }
        public Color BackgroundColor { get; set; }

        public ushort Thickness { get; set; }

        public void StartDrawing(int x, int y, Image image)
        {
            var pen = new Pen(ForegroundColor);
            var graphics = Graphics.FromImage(image);
            graphics.FillRectangle(pen.Brush, x - Thickness / 2, y - Thickness / 2, Thickness, Thickness);

            previousPoint = new Point(x, y);
        }

        public void Draw(int x, int y, Image image)
        {
            var point = new Point(x, y);

            var pen = new Pen(ForegroundColor, Thickness);
            var graphics = Graphics.FromImage(image);
            graphics.DrawLine(pen, previousPoint, point);
            graphics.FillRectangle(pen.Brush, x - Thickness / 2, y - Thickness / 2, Thickness, Thickness);

            previousPoint = point;
        }
    }
}
