﻿using GraphicEditor.View.Drawing.Tools.Input;

namespace GraphicEditor.View.Drawing.Tools.ClassicalTools
{
    internal class Pencil : DrawingTool
    {
        private Point previousPoint;

        public override void StartDrawing(DrawingToolData data)
        {
            base.StartDrawing(data);

            var pen = new Pen(data.ForegroundColor);

            using (var graphics = Graphics.FromImage(data.Image))
            {
                var point = new Point(data.StartPoint.X - data.Thickness / 2, data.StartPoint.Y - data.Thickness / 2);
                graphics.FillEllipse(pen.Brush, new Rectangle(point, new Size(data.Thickness, data.Thickness)));
            }

            previousPoint = data.StartPoint;
        }

        public override void DrawNext(DrawingToolData data)
        {
            var pen = new Pen(data.ForegroundColor, data.Thickness);

            using (var graphics = Graphics.FromImage(data.Image))
            {
                var point = new Point(data.EndPoint.X - data.Thickness / 2, data.EndPoint.Y - data.Thickness / 2);
                graphics.DrawLine(pen, previousPoint, data.EndPoint);
                graphics.FillEllipse(pen.Brush, new Rectangle(point, new Size(data.Thickness, data.Thickness)));
            }

            previousPoint = data.EndPoint;
        }
    }
}
