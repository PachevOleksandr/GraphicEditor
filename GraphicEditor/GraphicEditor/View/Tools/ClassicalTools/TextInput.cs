using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.View.Tools.ClassicalTools
{
    internal class TextInput : DrawingTool
    {
        private readonly TextBox textBox;

        public string Text => textBox.Text;

        public TextInput(PictureBox pictureBox)
        {
            DrawFinishType = DrawFinishType.OnUnselect;

            textBox = new TextBox();
            textBox.Parent = pictureBox;
            textBox.Size = new Size(40, 20);
            textBox.Visible = false;
            textBox.Multiline = true;
            textBox.BackColor = pictureBox.BackColor;
            textBox.ForeColor = pictureBox.ForeColor;
        }

        public override void StartDrawing(DrawingToolData data)
        {
            base.StartDrawing(data);

            textBox.Location = data.StartPoint;
            textBox.Show();
        }

        public override void DrawNext(DrawingToolData data)
        {
        }

        public override void FinishDrawing(DrawingToolData data)
        {
            base.FinishDrawing(data);

            using (var graphic = Graphics.FromImage(data.Image))
            {
                var pen = new Pen(data.ForegroundColor);
                graphic.DrawString(Text, data.Font, pen.Brush, data.StartPoint);
            }
        }
    }
}
