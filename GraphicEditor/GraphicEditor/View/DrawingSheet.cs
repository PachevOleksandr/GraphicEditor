using GraphicEditor.Model;
using GraphicEditor.View.Tools;
using GraphicEditor.View.Tools.ClassicalTools;
using GraphicEditor.View.Tools.Figures;
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

        public DrawingToolData DrawingData { get; set; }

        public Image Image
        {
            get => DrawingData.Image;
            private set
            {
                DrawingData.Image = value;
                ImageChanged?.Invoke(this, DrawingData.Image);
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

        public IDrawingTool SelectedTool { get; set; }
        public History<Image> ImageHistory { get; private set; }

        public DrawingSheet(DrawingToolData data, int width, int height)
        {
            DrawingData = data;

            Image = GetEmptyImage(width, height);

            Initialize();
        }

        public DrawingSheet(DrawingToolData data, Image image)
        {
            DrawingData = data;

            Image = image;

            Initialize();
        }

        public void Initialize()
        {
            ImageHistory = new History<Image>(Image.Clone() as Image);
        }

        private Image GetEmptyImage(int width, int height)
        {
            var img = new Bitmap(width, height);

            using (var graphics = Graphics.FromImage(img))
            {
                graphics.Clear(DrawingData.BackgroundColor);
            }

            return img;
        }

        public void Clear()
        {
            using (var graphics = Graphics.FromImage(Image))
            {
                graphics.Clear(DrawingData.BackgroundColor);
            }

            ImageHistory.Clear(Image.Clone() as Image);
            ImageChanged?.Invoke(this, Image);
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
                graphic.Clear(DrawingData.BackgroundColor);
                graphic.DrawImage(newImage, 0, 0);
            }

            Image = tmpBmp;
            ImageChanged?.Invoke(this, Image);
        }

        public void Resize(int width, int height)
        {
            var newImg = new Bitmap(width, height);

            using (var graphic = Graphics.FromImage(newImg))
            {
                graphic.Clear(DrawingData.BackgroundColor);
                graphic.DrawImage(Image, 0, 0);
            }

            Image = newImg;
            ImageHistory.AddItem(Image.Clone() as Image);
        }

        #region Drawing

        public void StartDrawingFrom(Point startPoint)
        {
            DrawingData.StartPoint = startPoint;

            SelectedTool.StartDrawing(DrawingData);
            ImageChanged?.Invoke(this, Image);
        }

        public void Draw(Point point)
        {
            DrawingData.EndPoint = point;

            SelectedTool.DrawNext(DrawingData);
            ImageChanged?.Invoke(this, Image);
        }

        public void StopDrawing()
        {
            SelectedTool.FinishDrawing(DrawingData);
            ImageHistory.AddItem(Image.Clone() as Image);
        }

        #endregion

        #region History

        public void Undo()
        {
            if (SelectedTool.Executing)
            {
                SelectedTool.CancelDrawing(DrawingData);
                return;
            }

            Image = ImageHistory.Undo().Clone() as Image;
        }

        public void Redo()
        {
            if (SelectedTool.Executing)
            {
                SelectedTool.FinishDrawing(DrawingData);
                return;
            }

            Image = ImageHistory.Redo().Clone() as Image;
        }

        #endregion
    }
}
