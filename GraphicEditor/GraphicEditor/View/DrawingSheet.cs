using GraphicEditor.Model;
using GraphicEditor.View.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicEditor.View
{
    internal class DrawingSheet
    {
        public delegate void ImageHandler(object sender, Image image);
        public event ImageHandler ImageChanged;

        private Image image;
        public Image Image
        {
            get => image;
            private set
            {
                image = value;
                ImageChanged?.Invoke(this, image);
            }
        }

        public int Width
        {
            get => Image.Width;
        }

        public int Height
        {
            get => Image.Height;
        }

        public IDrawingTool SelectedTool { get; private set; }
        public History<Image> ImageHistory { get; }

        public DrawingSheet(int width, int height)
        {
            Image = GetEmptyImage(width, height);
            ImageHistory = new History<Image>(Image);

            Initialize();
        }

        public DrawingSheet(Image image)
        {
            Image = image;
            ImageHistory = new History<Image>(Image);

            Initialize();
        }

        private void Initialize()
        {
            SelectedTool = new Pencil(Image)
            {
                ForegroundColor = Color.Black,
                BackgroundColor = Color.White,
                Thickness = 1
            };
        }

        private Image GetEmptyImage(int width, int height)
        {
            var img = new Bitmap(width, height);

            using (var graphics = Graphics.FromImage(img))
            {
                graphics.Clear(Color.White);
            }

            return img;
        }

        public void SaveImageToFile(string filePath)
        {
            Image.Save(filePath);
        }

        public void LoadImageFromFile(string filePath)
        {
            var newImage = Image.FromFile(filePath);
            var tmpBmp = new Bitmap(newImage.Width, newImage.Height);

            using (var graphic = Graphics.FromImage(tmpBmp))
            {
                graphic.DrawImage(newImage, 0, 0);
            }

            Image = newImage;
        }

        #region Drawing

        public void StartDrawingFrom(Point startPoint)
        {
            SelectedTool.StartDrawingFrom(startPoint);
            ImageChanged?.Invoke(this, Image);
        }

        public void Draw(Point point)
        {
            SelectedTool.DrawNext(point);
            ImageChanged?.Invoke(this, Image);
        }

        public void StopDrawing()
        {
            ImageHistory.AddItem(Image.Clone() as Image);
        }

        #endregion

        #region History

        public void Rollback()
        {
            Image = ImageHistory.Rollback();
        }

        public void GoForward()
        {
            Image = ImageHistory.GoForward();
        }

        #endregion
    }
}
