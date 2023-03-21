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
        public Image Image { get; set; }

        public Pencil(Image image)
        {
            Image = image;
        }

        public void StartDrawingFrom(Point startPoint, Color color, int thickness)
        {
            var pen = new Pen(color);

            using (var graphics = Graphics.FromImage(Image))
            {
                graphics.FillEllipse(pen.Brush, new Rectangle(startPoint, new Size(Thickness, Thickness)));
            }

            previousPoint = startPoint;
        }

        public void DrawNext(Point point)
        {
            var pen = new Pen(ForegroundColor, Thickness);

            using (var graphics = Graphics.FromImage(Image))
            {
                graphics.DrawLine(pen, previousPoint, point);
                graphics.FillEllipse(pen.Brush, new Rectangle(point, new Size(Thickness, Thickness)));
            }

            previousPoint = point;
        }
    }
}
