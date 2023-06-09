﻿using GraphicEditor.View.Drawing.Tools.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.View.Drawing.Tools
{
    internal abstract class DrawingTool : IDrawingTool
    {
        protected Image? previousImageState;

        public bool Executing { get; protected set; }
        public DrawFinishType DrawFinishType { get; init; }

        public virtual void StartDrawing(DrawingToolData data)
        {
            Executing = true;

            previousImageState = data.Image.Clone() as Image;
        }

        public virtual void DrawNext(DrawingToolData data)
        {
            if (!Executing)
                return;
        }

        public virtual void FinishDrawing(DrawingToolData data)
        {
            if (!Executing)
                return;

            Executing = false;
        }

        public void CancelDrawing(DrawingToolData data)
        {
            if (previousImageState == null)
                return;

            Executing = false;
            data.Image = previousImageState.Clone() as Image;
        }
    }
}
