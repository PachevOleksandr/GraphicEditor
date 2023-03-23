using GraphicEditor.View.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GraphicEditor.View.Tools.ClassicalTools
{
    internal class TextInput : DrawingTool
    {
        private readonly PictureBox pictureBox;
        private TransparentTextBox textBox;

        public string Text => textBox.Text;

        public TextInput(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;

            DrawFinishType = DrawFinishType.OnUnselect;
        }

        public override void StartDrawing(DrawingToolData data)
        {
            base.StartDrawing(data);

            textBox = new TransparentTextBox();
            textBox.Parent = pictureBox;
            textBox.Multiline = true;
            textBox.AutoSize = true;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Location = data.StartPoint;
            textBox.Font = data.Font;
            textBox.ForeColor = data.ForegroundColor;
            textBox.Size = TextRenderer.MeasureText(" ", textBox.Font);

            textBox.TextChanged += TextBox_TextChanged;

            textBox.Show();
            textBox.Focus();
        }

        private void TextBox_TextChanged(object? sender, EventArgs e)
        {
            textBox.Size = TextRenderer.MeasureText(textBox.Text, textBox.Font);
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
            textBox.Hide();
        }
    }
}
