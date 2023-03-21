using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicEditor.View.Controls
{
    public partial class ResizablePanel : Panel
    {
        private bool canResize;
        private int borderSize = 2;

        public ResizablePanel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.X >= Width - borderSize ||
                e.Y >= Height - borderSize ||
                e.X >= Width - borderSize && e.Y >= Height - borderSize)
            {
                canResize = true;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            canResize = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (canResize)
            {
                int newWidth = e.X < MinimumSize.Width ? MinimumSize.Width : e.X;
                int newHeight = e.Y < MinimumSize.Height ? MinimumSize.Height : e.Y;

                Size = new Size(newWidth, newHeight);
            }


            if (e.X >= Width - borderSize)
            {
                Cursor = Cursors.SizeWE;
            }
            else if (e.Y >= Height - borderSize)
            {
                Cursor = Cursors.SizeNS;
            }
            else if (e.X >= Width - borderSize && e.Y >= Height - borderSize)
            {
                Cursor = Cursors.SizeNWSE;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            Cursor = Cursors.Default;
        }
    }
}
