using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.View.Tools
{
    internal class DrawingToolData
    {
        public Image? Image { get; set; }
        public Color ForegroundColor { get; set; }
        public Color BackgroundColor { get; set; }

        public int Thickness { get; set; }

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public bool IsColored { get; set; }

        public float FontSize { get; set; }
        public Font? Font { get; set; }

        public DrawingToolData()
        {
            Image = null;
            ForegroundColor = Color.Black;
            BackgroundColor = Color.White;
            Thickness = 1;
            StartPoint = new Point(0, 0);
            EndPoint = new Point(0, 0);
            IsColored = false;
            FontSize = 11;
            Font = new Font(FontFamily.GenericMonospace, FontSize);
        }
    }
}
