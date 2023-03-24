using GraphicEditor.Model;
using GraphicEditor.View.Tools;
using GraphicEditor.View.Tools.ClassicalTools;
using GraphicEditor.View.Tools.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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
            set
            {
                DrawingData.Image = value;
                ImageChanged?.Invoke(this, DrawingData.Image);
            }
        }

        private IDrawingTool selectedTool;
        public IDrawingTool SelectedTool
        {
            get => selectedTool;
            set
            {
                if (value != null)
                {
                    selectedTool = value;
                }
            }
        }

        public History<Image> ImageHistory { get; private set; }

        public DrawingSheet()
        {
            DrawingData = new DrawingToolData();
        }

        public DrawingSheet(int width, int height) : this()
        {
            Image = GetEmptyImage(width, height);
            ImageHistory = new History<Image>(Image.Clone() as Image);
        }

        public DrawingSheet(Image image) : this()
        {
            Image = image;
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

            ImageHistory.Reset();
            ImageChanged?.Invoke(this, Image);
        }

        private void ResetHistory(Image image)
        {
            ImageHistory = new(image.Clone() as Image);
        }

        public void AddToHistory(Image image)
        {
            ImageHistory.AddItem(image.Clone() as Image);
        }

        public void SaveImageToFile(string filePath)
        {
            Image.Save(filePath);
        }

        public void LoadImageFromFile(string filePath)
        {
            var newImage = Image.FromFile(filePath);
            Image = new Bitmap(newImage, newImage.Width, newImage.Height);

            ResetHistory(Image);
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
            AddToHistory(Image);
        }

        public Image InvertImage(Action<int> notifyPercentageChanged, Image image)
        {
            var bmp = new Bitmap(image);

            var bits = bmp.LockBits(new Rectangle(Point.Empty, bmp.Size),
                                    ImageLockMode.ReadWrite,
                                    bmp.PixelFormat);

            int pixelSize = bmp.PixelFormat == PixelFormat.Format32bppArgb ? 4 : 3;

            var bytes = new byte[bits.Height * bits.Stride];
            Marshal.Copy(bits.Scan0, bytes, 0, bytes.Length);

            int percentage = 0;

            for (int i = 0; i < bytes.Length; i += pixelSize)
            {
                bytes[i] = (byte)Math.Abs(bytes[i] - byte.MaxValue);
                bytes[i + 1] = (byte)Math.Abs(bytes[i + 1] - byte.MaxValue);
                bytes[i + 2] = (byte)Math.Abs(bytes[i + 2] - byte.MaxValue);

                int p = (int)((float)i / bytes.Length * 100);

                if (p != percentage)
                {
                    percentage = p;
                    notifyPercentageChanged(percentage);

                    Thread.Sleep(100);
                }
            }

            Marshal.Copy(bytes, 0, bits.Scan0, bytes.Length);

            return bmp;
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
            ImageChanged?.Invoke(this, Image);

            AddToHistory(Image);
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
