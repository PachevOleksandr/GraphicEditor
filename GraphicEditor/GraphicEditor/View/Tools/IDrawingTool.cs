using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.View.Tools
{
    internal interface IDrawingTool
    {
        public Color ForegroundColor { get; set; }
        public Color BackgroundColor { get; set; }

        public ushort Thickness { get; set; }

        public void StartDrawing(int x, int y, Image image);
        public void Draw(int x, int y, Image image);
    }
}
