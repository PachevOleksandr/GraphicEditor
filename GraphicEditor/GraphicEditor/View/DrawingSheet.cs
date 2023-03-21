﻿using GraphicEditor.Model;
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
            Initialize();

            Image = GetEmptyImage(width, height);
            ImageHistory = new History<Image>(Image);
        }

        public DrawingSheet(Image image)
        {
            Initialize();

            Image = image;
            ImageHistory = new History<Image>(Image);
        }

        private void Initialize()
        {
            SelectedTool = new Pencil
            {
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
            Image = Image.FromFile(filePath);
        }
    }
}
