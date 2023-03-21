using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.View.Tools
{
    internal interface IDrawingToolData
    {
        public Image? Image { get; set; }
        public Color ForegroundColor { get; set; }
        public Color BackgroundColor { get; set; }
    }
}
