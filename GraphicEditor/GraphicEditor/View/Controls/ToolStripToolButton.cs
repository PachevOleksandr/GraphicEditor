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

namespace GraphicEditor.View.Controls
{
    public partial class ToolStripToolButton : ToolStripButton
    {
        [Category("Drawing")]
        [DefaultValue(DrawingToolType.Pencil)]
        [Description("Contains drawing tool type")]
        public DrawingToolType Tool { get; set; }

        [Category("Grouping")]
        [Description("Group index")]
        public int GroupIndex { get; set; }

        public ToolStripToolButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            if (Checked)
            {
                var parent = Parent;
                if (parent != null)
                {
                    var children = parent.Items;
                    foreach (var child in children)
                    {
                        if (child != this && child is ToolStripToolButton ctr)
                        {
                            if (ctr.GroupIndex == GroupIndex)
                                ctr.Checked = false;
                        }
                    }
                }
            }

            base.OnCheckedChanged(e);
        }
    }
}
