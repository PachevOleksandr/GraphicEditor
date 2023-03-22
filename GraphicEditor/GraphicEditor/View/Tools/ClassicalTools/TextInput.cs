using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicEditor.View.Tools.ClassicalTools
{
    internal class TextInput : DrawingTool
    {
        private readonly PictureBox pictureBox;
        private TextBox textBox;

        public string Text => textBox.Text;

        public TextInput(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;

            DrawFinishType = DrawFinishType.OnUnselect;
        }

        public override void StartDrawing(DrawingToolData data)
        {
            base.StartDrawing(data);

            textBox = new TextBox();
            textBox.Parent = pictureBox;
            textBox.Multiline = true;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Location = data.StartPoint;
            textBox.Font = data.Font;
            textBox.ForeColor = data.ForegroundColor;
            textBox.BackColor = data.BackgroundColor;

            textBox.Show();
            textBox.Focus();
        }

        public override void DrawNext(DrawingToolData data)
        {
            textBox.Font = data.Font;
            textBox.ForeColor = data.ForegroundColor;
            textBox.BackColor = data.BackgroundColor;
        }

        public override void FinishDrawing(DrawingToolData data)
        {
            base.FinishDrawing(data);

            using (var graphic = Graphics.FromImage(data.Image))
            {
                var pen = new Pen(data.ForegroundColor);
                graphic.DrawString(Text, data.Font, pen.Brush, data.StartPoint);
            }

            textBox.IsAccessible = false;
            textBox.Dispose();
        }
    }
}
