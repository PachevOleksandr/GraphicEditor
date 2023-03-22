using GraphicEditor.Model;
using GraphicEditor.View.Controls;
using GraphicEditor.View.Tools;
using GraphicEditor.View.Tools.ClassicalTools;
using GraphicEditor.View.Tools.Figures;
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

        private Dictionary<DrawingToolType, IDrawingTool> tools;

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

            thicknessToolStripComboBox.SelectedIndex = 0;

            tools = new()
            {
                { DrawingToolType.Pencil, new Pencil() },
                { DrawingToolType.TextInput, new TextInput(drawingArea) },
                { DrawingToolType.Line, new LineFigure() },
                { DrawingToolType.Rectangle, new RectangleFigure() },
                { DrawingToolType.Ellipse, new EllipseFigure() },
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var data = new DrawingToolData
            {
                ForegroundColor = foregroundColorDialog.Color,
                BackgroundColor = backgroundColorDialog.Color,
                Thickness = thicknessToolStripComboBox.SelectedIndex * 2 + 1
            };

            drawingSheet = new(data, resizablePanel.Width - 4, resizablePanel.Height - 4);
            drawingSheet.ImageChanged += DrawingSheet_ImageChanged;
            drawingSheet.SelectedTool = tools.First().Value;

            drawingArea.Image = drawingSheet.Image;

            foregroundColorButton.Image = GetMonoImage(foregroundColorButton.Width, foregroundColorButton.Height, drawingSheet.DrawingData.ForegroundColor);
            backgroundColorButton.Image = GetMonoImage(backgroundColorButton.Width, backgroundColorButton.Height, drawingSheet.DrawingData.BackgroundColor);
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

        #region Work with files

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Default image files|*.bmp;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                drawingSheet.LoadImageFromFile(openFileDialog.FileName);
            }
        }

        #endregion

        private void drawingArea_SizeChanged(object sender, EventArgs e)
        {
            if (sender is PictureBox pb)
            {
                imageSizeInfoLabel.Text = $"Size: {pb.Width} x {pb.Height}";
                drawingSheet?.Resize(pb.Width, pb.Height);
            }
        }

        #region Drawing

        private void drawingArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (drawingSheet.SelectedTool.Executing)
                {
                    drawingSheet.StopDrawing();
                }
                else
                {
                    drawingSheet.StartDrawingFrom(new Point(e.X, e.Y));
                }
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
            if (drawingSheet.SelectedTool.DrawFinishType == DrawFinishType.OnMouseUp &&
                drawingSheet.SelectedTool.Executing)
            {
                drawingSheet.StopDrawing();
            }
        }

        #endregion

        #region Drawing tool settings

        private void foregroundColorButton_Click(object sender, EventArgs e)
        {
            var btn = sender as ToolStripButton;

            if (foregroundColorDialog.ShowDialog() == DialogResult.OK)
            {
                drawingSheet.DrawingData.ForegroundColor = foregroundColorDialog.Color;
                btn.Image = GetMonoImage(btn.Width, btn.Height, foregroundColorDialog.Color);
            }
        }

        private void backgroundColorButton_Click(object sender, EventArgs e)
        {
            var btn = sender as ToolStripButton;

            if (backgroundColorDialog.ShowDialog() == DialogResult.OK)
            {
                drawingSheet.DrawingData.BackgroundColor = backgroundColorDialog.Color;
                btn.Image = GetMonoImage(btn.Width, btn.Height, backgroundColorDialog.Color);
            }
        }

        private void thicknessToolStripCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ToolStripComboBox cb)
            {
                if (drawingSheet != null)
                    drawingSheet.DrawingData.Thickness = cb.SelectedIndex * 2 + 1;
            }
        }

        private void drawingTool_ToolStripButton_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripToolButton btn)
            {
                try
                {
                    var selectedTool = tools[btn.Tool];

                    if (selectedTool == null)
                        throw new NullReferenceException();

                    drawingSheet.SelectedTool = selectedTool;
                    btn.Checked = true;
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Tool exists but not implemented.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Cannot find tool.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region History

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

        private void undoToolStripButton_Click(object sender, EventArgs e)
        {
            drawingSheet.Undo();
        }

        private void redoToolStripButton_Click(object sender, EventArgs e)
        {
            drawingSheet.Redo();
        }

        #endregion
    }
}
