using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicEditor.View.Controls
{
    public partial class ResizablePanel : Panel
    {
        private ResizeDirection canResizeAt = ResizeDirection.None;

        [Flags]
        public enum ResizeDirection : short
        {
            None = 0,
            Top = 1,
            Right = 2,
            TopAndRight,
            Bottom = 4,
            TopAndBottom,
            RightAndBottom,
            Left = 8,
            TopAndLeft,
            RightAndLeft,
            TopAndRightAndLeft,
            BottomAndLeft,
            TopAndBottomAndLeft,
            RightAndBottomAndLeft,
            All
        }

        public event EventHandler Resized;

        private int borderThickness;
        [Category(nameof(ResizablePanel))]
        [DefaultValue(2)]
        [Description("Border thickness.")]
        public int BorderThickness
        {
            get => borderThickness;
            set
            {
                borderThickness = value;

                UpdatePadding();
                Invalidate();
                Update();
            }
        }

        private Color borderColor = Color.Gray;
        [Category(nameof(ResizablePanel))]
        [Description("Border color.")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;

                Invalidate();
                Update();
            }
        }

        private ResizeDirection resizeDirections;
        [Category(nameof(ResizablePanel))]
        [DefaultValue(ResizeDirection.All)]
        [Description("Resize directions.")]
        public ResizeDirection ResizeDirections
        {
            get => resizeDirections;
            set
            {
                resizeDirections = value;

                UpdatePadding();
                Invalidate();
                Update();
            }
        }

        public int ContentWidth
        {
            get => Width - Padding.Left - Padding.Right;
            set => Width = value + Padding.Right + Padding.Left;
        }

        public int ContentHeight
        {
            get => Height - Padding.Top - Padding.Bottom;
            set => Height = value + Padding.Top + Padding.Bottom;
        }

        public ResizablePanel()
        {
            InitializeComponent();

            BorderThickness = 2;
            ResizeDirections = ResizeDirection.All;
        }

        private void UpdatePadding()
        {
            Padding = new Padding(ResizeDirections.HasFlag(ResizeDirection.Left) ? BorderThickness : 0,
                                      ResizeDirections.HasFlag(ResizeDirection.Top) ? BorderThickness : 0,
                                      ResizeDirections.HasFlag(ResizeDirection.Right) ? BorderThickness : 0,
                                      ResizeDirections.HasFlag(ResizeDirection.Bottom) ? BorderThickness : 0);

            UpdateMinimumSize();
        }

        private void UpdateMinimumSize()
        {
            if (MinimumSize.Height < Padding.Top + Padding.Bottom ||
                MinimumSize.Width < Padding.Left + Padding.Right)
            {
                MinimumSize = new(Padding.Top + Padding.Bottom, Padding.Left + Padding.Right);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            ControlPaint.DrawBorder(pe.Graphics, ClientRectangle,
                                    BorderColor, BorderThickness, ResizeDirections.HasFlag(ResizeDirection.Left) ? ButtonBorderStyle.Dashed : ButtonBorderStyle.None,
                                    BorderColor, BorderThickness, ResizeDirections.HasFlag(ResizeDirection.Top) ? ButtonBorderStyle.Dashed : ButtonBorderStyle.None,
                                    BorderColor, BorderThickness, ResizeDirections.HasFlag(ResizeDirection.Right) ? ButtonBorderStyle.Dashed : ButtonBorderStyle.None,
                                    BorderColor, BorderThickness, ResizeDirections.HasFlag(ResizeDirection.Bottom) ? ButtonBorderStyle.Dashed : ButtonBorderStyle.None);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.X >= Width - BorderThickness && ResizeDirections.HasFlag(ResizeDirection.Right))
            {
                canResizeAt |= ResizeDirection.Right;
            }
            if (e.Y >= Height - BorderThickness && ResizeDirections.HasFlag(ResizeDirection.Bottom))
            {
                canResizeAt |= ResizeDirection.Bottom;
            }
            if (e.X <= BorderThickness && ResizeDirections.HasFlag(ResizeDirection.Left))
            {
                canResizeAt |= ResizeDirection.Left;
            }
            if (e.Y <= BorderThickness && ResizeDirections.HasFlag(ResizeDirection.Top))
            {
                canResizeAt |= ResizeDirection.Top;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (canResizeAt != ResizeDirection.None)
            {
                canResizeAt = ResizeDirection.None;
                Resized?.Invoke(this, EventArgs.Empty);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (canResizeAt != ResizeDirection.None)
            {
                var locationX = Location.X;
                var locationY = Location.Y;

                if (canResizeAt.HasFlag(ResizeDirection.Left))
                {
                    Width = e.X < MinimumSize.Width ? MinimumSize.Width : e.X;
                    locationX = e.X;
                }
                if (canResizeAt.HasFlag(ResizeDirection.Right))
                {
                    Width = e.X < MinimumSize.Width ? MinimumSize.Width : e.X;
                }
                if (canResizeAt.HasFlag(ResizeDirection.Top))
                {
                    Height = e.Y < MinimumSize.Height ? MinimumSize.Height : e.Y;
                    locationY = e.Y;
                }
                if (canResizeAt.HasFlag(ResizeDirection.Bottom))
                {
                    Height = e.Y < MinimumSize.Height ? MinimumSize.Height : e.Y;
                }

                Location = new Point(locationX, locationY);
            }


            if (e.X >= Width - BorderThickness && e.Y >= Height - BorderThickness && ResizeDirections.HasFlag(ResizeDirection.RightAndBottom) ||
                e.X <= BorderThickness && e.Y <= BorderThickness && ResizeDirections.HasFlag(ResizeDirection.TopAndLeft))
            {
                Cursor = Cursors.SizeNWSE;
            }
            else if (e.X <= BorderThickness && e.Y >= Height - BorderThickness && ResizeDirections.HasFlag(ResizeDirection.BottomAndLeft) ||
                     e.X >= Width - BorderThickness && e.Y <= BorderThickness && ResizeDirections.HasFlag(ResizeDirection.TopAndRight))
            {
                Cursor = Cursors.SizeNESW;
            }
            else if (e.Y <= BorderThickness && ResizeDirections.HasFlag(ResizeDirection.Top) ||
                     e.Y >= Height - BorderThickness && ResizeDirections.HasFlag(ResizeDirection.Bottom))
            {
                Cursor = Cursors.SizeNS;
            }
            else if (e.X >= Width - BorderThickness && ResizeDirections.HasFlag(ResizeDirection.Right) ||
                     e.X <= BorderThickness && ResizeDirections.HasFlag(ResizeDirection.Left))
            {
                Cursor = Cursors.SizeWE;
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
