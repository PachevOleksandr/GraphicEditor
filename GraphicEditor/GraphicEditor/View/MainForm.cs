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
        public MainForm()
        {
            InitializeComponent();
            imageSizeInfoLabel.Text = $"Size: {drawingArea.Width} x {drawingArea.Height}";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Default image files|*.bmp;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                drawingArea.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void drawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            mousePositionLabel.Text = $"Position: {e.X}, {e.Y}";
        }

        private void drawingArea_SizeChanged(object sender, EventArgs e)
        {
            imageSizeInfoLabel.Text = $"Size: {drawingArea.Width} x {drawingArea.Height}";
        }
    }
}
