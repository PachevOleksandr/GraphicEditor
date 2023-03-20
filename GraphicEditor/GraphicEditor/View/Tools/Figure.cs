using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.View.Tools
{
    internal abstract class Figure //: IDrawingTool
    {
        public Color ForegroundColor { get; set; }
        public Color BackgroundColor { get; set; }
        public ushort Thickness { get; set; }

        abstract public void Draw(int x, int y, Image image);
    }
}
