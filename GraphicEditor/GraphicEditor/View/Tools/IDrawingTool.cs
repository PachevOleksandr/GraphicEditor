using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.View.Tools
{
    internal interface IDrawingTool
    {
        public bool Executing { get; }
        public DrawFinishType DrawFinishType { get; }

        public void StartDrawing(DrawingToolData data);
        public void DrawNext(DrawingToolData data);
        public void FinishDrawing(DrawingToolData data);

        public void CancelDrawing(DrawingToolData data);
    }
}
