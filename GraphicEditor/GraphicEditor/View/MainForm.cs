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

        private List<ThicknessValue> thicknessValues;

        public MainForm()
        {
            InitializeComponent();

#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            resizablePanel.Resized += drawingArea_SizeChanged;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).

            drawingArea = new PictureBox()
            {
                Dock = DockStyle.Fill,
            };

#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            drawingArea.MouseDown += drawingArea_MouseDown;
            drawingArea.MouseMove += drawingArea_MouseMove;
            drawingArea.MouseUp += drawingArea_MouseUp;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).

            resizablePanel.Controls.Add(drawingArea);

            tools = new()
            {
                { DrawingToolType.Pencil, new Pencil() },
                { DrawingToolType.TextInput, new TextInput(drawingArea) },
                { DrawingToolType.Line, new LineFigure() },
                { DrawingToolType.Rectangle, new RectangleFigure() },
                { DrawingToolType.Ellipse, new EllipseFigure() },
            };

            thicknessValues = new List<ThicknessValue>()
            {
                new ThicknessValue(1),
                new ThicknessValue(3),
                new ThicknessValue(5),
                new ThicknessValue(7)
            };

            thicknessToolStripComboBox.Items.AddRange(thicknessValues.ToArray());
            thicknessToolStripComboBox.SelectedIndex = 0;
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
            resizablePanel.Width = image.Width + resizablePanel.Padding.Right + resizablePanel.Padding.Left;
            resizablePanel.Height = image.Height + resizablePanel.Padding.Top + resizablePanel.Padding.Bottom;

            drawingArea.Image = image;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Z))
            {
                drawingSheet.Undo();
            }
            else if (keyData == (Keys.Control | Keys.Y))
            {
                drawingSheet.Redo();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region Work with files

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "All|*.bmp;*png|" +
                                    "Default image files|*.bmp|" +
                                    "Pictures|*.png;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                drawingSheet.LoadImageFromFile(openFileDialog.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Default image files|*.bmp|" +
                                    "Pictures|*.png;";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                drawingSheet.SaveImageToFile(saveFileDialog.FileName);
            }
        }

        #endregion

        private void drawingArea_SizeChanged(object sender, EventArgs e)
        {
            if (sender is ResizablePanel rp)
            {
                int sheetWidth = rp.Width - rp.Padding.Left - rp.Padding.Right;
                int sheetHeight = rp.Height - rp.Padding.Top - rp.Padding.Bottom;

                imageSizeInfoLabel.Text = $"Size: {sheetWidth} x {sheetHeight}";
                drawingSheet?.Resize(sheetWidth, sheetHeight);
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

            if (drawingSheet.SelectedTool.Executing)
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
                if (drawingSheet != null && cb.SelectedItem is ThicknessValue v)
                {
                    drawingSheet.DrawingData.Thickness = v.Value;
                }
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

                    if (drawingSheet.SelectedTool.Executing)
                        drawingSheet.StopDrawing();

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

        private void undoToolStripButton_Click(object sender, EventArgs e)
        {
            drawingSheet.Undo();
        }

        private void redoToolStripButton_Click(object sender, EventArgs e)
        {
            drawingSheet.Redo();
        }

        #endregion

        private void clearToolStripButton_Click(object sender, EventArgs e)
        {
            drawingSheet.Clear();
        }

        private void fillFigureToolStripButton_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripButton btn)
            {
                btn.Checked = !btn.Checked;
                drawingSheet.DrawingData.IsColored = btn.Checked;
            }
        }
    }
}
