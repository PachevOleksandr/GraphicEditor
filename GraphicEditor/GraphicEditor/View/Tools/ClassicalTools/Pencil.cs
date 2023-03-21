using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.View.Tools.ClassicalTools
{
    internal class Pencil : IDrawingTool<DrawingToolData>
    {
        private Point previousPoint;

        public void StartDrawingFrom(DrawingToolData data)
        {
            var pen = new Pen(data.ForegroundColor);

            using (var graphics = Graphics.FromImage(data.Image))
            {
                graphics.FillEllipse(pen.Brush, new Rectangle(data.StartPoint, new Size(data.Thickness, data.Thickness)));
            }

            previousPoint = data.StartPoint;
        }

        public void DrawNext(DrawingToolData data)
        {
            var pen = new Pen(data.ForegroundColor, data.Thickness);

            using (var graphics = Graphics.FromImage(data.Image))
            {
                graphics.DrawLine(pen, previousPoint, data.EndPoint);
                graphics.FillEllipse(pen.Brush, new Rectangle(data.EndPoint, new Size(data.Thickness, data.Thickness)));
            }

            previousPoint = data.EndPoint;
        }
    }
}
