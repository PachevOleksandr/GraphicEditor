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
        public History<Image> ImageHistory { get; }

        public DrawingSheet(int width, int height)
        {
            DrawingData = new DrawingToolData();

            Image = GetEmptyImage(width, height);
            ImageHistory = new History<Image>(Image.Clone() as Image);

            Initialize();
        }

        public DrawingSheet(Image image)
        {
            DrawingData = new DrawingToolData();

            Image = image;
            ImageHistory = new History<Image>(Image.Clone() as Image);

            Initialize();
        }

        private void Initialize()
        {
            SelectedTool = new Pencil();
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

        public void SetDrawingTool(DrawingToolType drawingToolType)
        {
            switch (drawingToolType)
            {
                case DrawingToolType.Pencil:
                    SelectedTool = new Pencil();
                    break;
                case DrawingToolType.Line:
                    SelectedTool = new LineFigure();
                    break;
                case DrawingToolType.Ellipse:
                    SelectedTool = new EllipseFigure();
                    break;
                case DrawingToolType.Rectangle:
                    SelectedTool = new RectangleFigure();
                    break;
                default:
                    break;
            }
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

        public void Resize(int width, int height)
        {
            var newImg = new Bitmap(width, height);

            using (var graphic = Graphics.FromImage(newImg))
            {
                graphic.Clear(DrawingData.BackgroundColor);
                graphic.DrawImage(Image, 0, 0);
            }

            Image = newImg;
        }

        #region Drawing

        public void StartDrawingFrom(Point startPoint)
        {
            DrawingData.StartPoint = startPoint;

            SelectedTool.StartDrawingFrom(DrawingData);
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
            ImageHistory.AddItem(Image.Clone() as Image);
        }

        #endregion

        #region History

        public void Undo()
        {
            Image = ImageHistory.Undo().Clone() as Image;
        }

        public void Redo()
        {
            Image = ImageHistory.Redo().Clone() as Image;
        }

        #endregion
    }
}
