using GraphicEditor.View.Drawing.Tools.Input;

namespace GraphicEditor.View.Drawing.Tools.Figures
{
    internal abstract class Figure : DrawingTool
    {
        private Image? startState;

        public override void StartDrawing(DrawingToolData data)
        {
            base.StartDrawing(data);
            startState = data.Image.Clone() as Image;
        }

        public override void DrawNext(DrawingToolData data)
        {
            base.DrawNext(data);

            if (startState == null)
            {
                return;
            }

            using (var graphic = Graphics.FromImage(data.Image))
            {
                graphic.DrawImage(startState, 0, 0);

                DrawFigure(data, graphic);
            }
        }

        abstract protected void DrawFigure(DrawingToolData data, Graphics graphics);
    }
}
