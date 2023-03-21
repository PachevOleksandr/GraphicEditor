using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.View.Tools
{
    internal interface IDrawingTool<T> where T : class, IDrawingToolData
    {
        public void StartDrawingFrom(T data);
        public void DrawNext(T data);
    }
}
