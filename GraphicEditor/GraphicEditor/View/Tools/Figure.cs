using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.View.Tools
{
    internal abstract class Figure : IDrawingTool
    {
        protected Point startPoint;
        private Image? startState;

        public Color ForegroundColor { get; set; }
        public Color BackgroundColor { get; set; }
        public ushort Thickness { get; set; }

        public void StartDrawing(int x, int y, Image image)
        {
            startPoint = new Point(x, y);
            startState = image.Clone() as Image;
        }

        public void Draw(int x, int y, Image image)
        {
            if(startState == null)
            {
                return;
            }

            using (var graphic = Graphics.FromImage(image))
            {
                graphic.DrawImage(startState, 0, 0);
                DrawFigure(x, y, graphic);
            }
        }

        abstract protected void DrawFigure(int x, int y, Graphics graphics);
    }
}
