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
        public Image Image { get; }

        public Figure(Image image)
        {
            Image = image;
        }

        public void StartDrawingFrom(Point startPoint)
        {
            this.startPoint = startPoint;
            startState = Image.Clone() as Image;
        }

        public void DrawNext(Point point)
        {
            if(startState == null)
            {
                return;
            }

            using (var graphic = Graphics.FromImage(Image))
            {
                graphic.DrawImage(startState, 0, 0);
                DrawFigure(point, graphic);
            }
        }

        abstract protected void DrawFigure(Point point, Graphics graphics);
    }
}
