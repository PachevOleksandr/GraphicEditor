using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.View.Tools
{
    internal interface IDrawingTool
    {
        public void StartDrawingFrom(DrawingToolData data);
        public void DrawNext(DrawingToolData data);
    }
}
