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

        private IDrawingTool activeTool;

        private History<Image> drawingHistory;

        private Image? activeImage;
        public Image? ActiveImage
        {
            get => activeImage;
            set
            {
                activeImage = value;
                drawingArea.Image = activeImage;
            }
        }

        public int ImageWidth
        {
            get => drawingArea.Width;
            set => drawingArea.Width = value;
        }

        public int ImageHeight
        {
            get => drawingArea.Height;
            set => drawingArea.Height = value;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            drawingArea = new PictureBox()
            {
                Dock = DockStyle.Fill,
            };

            drawingArea.MouseDown += drawingArea_MouseDown;
            drawingArea.MouseMove += drawingArea_MouseMove;
            drawingArea.MouseUp += drawingArea_MouseUp;

            resizablePanel.Controls.Add(drawingArea);

            activeTool = new Line { ForegroundColor = Color.RebeccaPurple, Thickness = 7 };
            imageSizeInfoLabel.Text = $"Size: {drawingArea.Width} x {drawingArea.Height}";
            ActiveImage = new Bitmap(Width, Height);
            using (var graphics = Graphics.FromImage(ActiveImage))
            {
                graphics.Clear(Color.White);
            }

            drawingHistory = new History<Image>(ActiveImage.Clone() as Image);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Default image files|*.bmp;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var newImage = Image.FromFile(openFileDialog.FileName);
                var tmpBmp = new Bitmap(newImage.Width, newImage.Height);

                using (var graphic = Graphics.FromImage(tmpBmp))
                {
                    graphic.DrawImage(newImage, 0, 0);
                }

                ActiveImage = tmpBmp;
            }
        }

        private void drawingArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                activeTool.StartDrawing(e.X, e.Y, ActiveImage);
                drawingArea.Refresh();
            }
        }

        private void drawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            mousePositionLabel.Text = $"Position: {e.X}, {e.Y}";

            if (e.Button == MouseButtons.Left)
            {
                activeTool.Draw(e.X, e.Y, ActiveImage);
                drawingArea.Refresh();
            }
        }

        private void drawingArea_SizeChanged(object sender, EventArgs e)
        {
            imageSizeInfoLabel.Text = $"Size: {drawingArea.Width} x {drawingArea.Height}";
        }

        private void drawingArea_MouseUp(object sender, MouseEventArgs e)
        {
            drawingHistory.AddItem(ActiveImage.Clone() as Image);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.Z)
                {
                    ActiveImage = drawingHistory.Rollback();
                }
                else if (e.KeyCode == Keys.Y)
                {
                    ActiveImage = drawingHistory.GoForward();
                }
            }
        }
    }
}
