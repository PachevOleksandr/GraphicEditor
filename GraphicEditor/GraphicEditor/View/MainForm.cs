using GraphicEditor.Model;
using GraphicEditor.View.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicEditor.View
{
    public partial class MainForm : Form
    {
        private PictureBox drawingArea;

        private DrawingSheet drawingSheet;

        public MainForm()
        {
            InitializeComponent();

            drawingArea = new PictureBox()
            {
                Dock = DockStyle.Fill,
            };

#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            drawingArea.MouseDown += drawingArea_MouseDown;
            drawingArea.MouseMove += drawingArea_MouseMove;
            drawingArea.MouseUp += drawingArea_MouseUp;
            drawingArea.SizeChanged += drawingArea_SizeChanged;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).

            resizablePanel.Controls.Add(drawingArea);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            drawingSheet = new(Width - 10, Height - 10);
            drawingSheet.ImageChanged += DrawingSheet_ImageChanged;

            drawingArea.Image = drawingSheet.Image;

            foregroundColorButton.Image = GetMonoImage(foregroundColorButton.Width, foregroundColorButton.Height, drawingSheet.SelectedTool.ForegroundColor);
            backgroundColorButton.Image = GetMonoImage(backgroundColorButton.Width, backgroundColorButton.Height, drawingSheet.SelectedTool.BackgroundColor);
        }

        private Image GetMonoImage(int width, int height, Color color)
        {
            var image = new Bitmap(width, height);

            using (var graphics = Graphics.FromImage(image))
            {
                graphics.Clear(color);

                var penBlack = new Pen(Color.Black);
                graphics.DrawRectangle(penBlack, 0, 0, width - 1, height - 1);

                var penWhite = new Pen(Color.White);
                graphics.DrawRectangle(penWhite, 1, 1, width - 4, height - 4);
            }

            return image;
        }

        private void DrawingSheet_ImageChanged(object sender, Image image)
        {
            drawingArea.Image = image;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Default image files|*.bmp;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                drawingSheet.LoadImageFromFile(openFileDialog.FileName);
            }
        }

        private void drawingArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drawingSheet.StartDrawingFrom(new Point(e.X, e.Y));
            }
        }

        private void drawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            mousePositionLabel.Text = $"Position: {e.X}, {e.Y}";

            if (e.Button == MouseButtons.Left)
            {
                drawingSheet.Draw(new Point(e.X, e.Y));
            }
        }

        private void drawingArea_MouseUp(object sender, MouseEventArgs e)
        {
            drawingSheet.StopDrawing();
        }

        private void drawingArea_SizeChanged(object sender, EventArgs e)
        {
            if (sender is PictureBox pb)
                imageSizeInfoLabel.Text = $"Size: {pb.Width} x {pb.Height}";
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.Z)
                {
                    drawingSheet.Undo();
                }
                else if (e.KeyCode == Keys.Y)
                {
                    drawingSheet.Redo();
                }
            }
        }

        private void foregroundColorButton_Click(object sender, EventArgs e)
        {
            var btn = sender as ToolStripButton;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                drawingSheet.SelectedTool.ForegroundColor = colorDialog.Color;
                btn.Image = GetMonoImage(btn.Width, btn.Height, colorDialog.Color);
            }
        }

        private void backgroundColorButton_Click(object sender, EventArgs e)
        {
            var btn = sender as ToolStripButton;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                drawingSheet.SelectedTool.BackgroundColor = colorDialog.Color;
                btn.Image = GetMonoImage(btn.Width, btn.Height, colorDialog.Color);
            }
        }

        private void undoToolStripButton_Click(object sender, EventArgs e)
        {
            drawingSheet.Undo();
        }

        private void redoToolStripButton_Click(object sender, EventArgs e)
        {
            drawingSheet.Redo();
        }
    }
}
