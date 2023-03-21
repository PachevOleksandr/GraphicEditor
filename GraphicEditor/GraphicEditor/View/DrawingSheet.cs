using GraphicEditor.View.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.View
{
    internal class DrawingSheet
    {
        public delegate void ImageHandler(object sender, Image image);
        public event ImageHandler ImageChanged;

        public Color ForegroundColor
        {
            get => SelectedTool.ForegroundColor;
            set => SelectedTool.ForegroundColor = value;
        }

        public Color BackgroundColor
        {
            get => SelectedTool.BackgroundColor;
            set => SelectedTool.BackgroundColor = value;
        }

        private Image image;
        public Image Image
        {
            get => image;
            private set
            {
                image = value;
                ImageChanged.Invoke(this, image);
            }
        }

        public IDrawingTool SelectedTool { get; set; }

        public DrawingSheet(int width, int height)
        {
            Initialize();

            Image = GetEmptyImage(width, height, BackgroundColor);
        }

        public DrawingSheet(Image image)
        {
            Initialize();

            Image = image;
        }

        private void Initialize()
        {
            ForegroundColor = Color.Black;
            BackgroundColor = Color.White;

            SelectedTool = new Pencil { Thickness = 1 };
        }

        private Image GetEmptyImage(int width, int height, Color color)
        {
            var img = new Bitmap(width, height);

            using (var graphics = Graphics.FromImage(img))
            {
                graphics.Clear(color);
            }

            return img;
        }

        public void Save()
        {

        }
    }
}
